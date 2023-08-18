﻿using HeavyService.Domain.Entities.Users;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HeavyService.Service.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("Jwt");
    }
    public string GenerateToken(User user)
    {
        var identityClaims = new Claim[]
        {
            new Claim("FirstName", user.FirstName),
            new Claim("Lastname", user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Password", user.PasswordHash)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        int expiresHours = int.Parse(_configuration["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _configuration["Issuer"],
            audience: _configuration["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}