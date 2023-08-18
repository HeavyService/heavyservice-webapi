using HeavyService.Persistance.Dtos.Auth;
using HeavyService.Persistance.Validations.Auth;
using Xunit;

namespace HeavyService.UnitTest.ValidatorTest.Auth;

public class LoginValidatorTest
{
    [Theory]
    [InlineData("dvdvjdnvjdskvsd")]
    [InlineData("@gmail.com")]
    [InlineData("@gmail.uz")]
    [InlineData("akmalovaziz@gmail")]
    [InlineData("akmalovaziz@gmailcom")]
    public void ShouldReturnWrongEmail(string email)
    {
        var dto = new LoginDto();
        dto.Email = email;
        dto.Password = "AAaa11@@";

        var validator = new LoginValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaaa@gmail.com")]
    [InlineData("aaa_asds@gmail.com")]
    [InlineData("aaa123@gmail.com")]
    public void ShouldReturnValidEmail(string email)
    {
        var dto = new LoginDto();
        dto.Email = email;
        dto.Password = "AAaa11@@";

        var validator = new LoginValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("AAAA")]
    [InlineData("AAaaa122")]
    [InlineData("aaaa_aa155")]
    [InlineData("aaaaaaaa")]
    [InlineData("Aa1@")]
    [InlineData("12345678")]
    public void ShouldReturnWrongPassword(string password)
    {
        var dto = new LoginDto();
        dto.Email = "aaaa@gmail.com";
        dto.Password = password;

        var validator = new LoginValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AaA___1223")]
    [InlineData("AAAAAAAww123!!!")]
    [InlineData("AAaa!!11")]
    [InlineData("Akmalov_5977")]
    public void ShouldReturnValidPassword(string password)
    {
        var dto = new LoginDto();
        dto.Email = "aaaa@gmail.com";
        dto.Password = password;

        var validator = new LoginValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}