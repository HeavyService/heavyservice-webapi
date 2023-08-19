using HeavyService.Persistance.Dtos.Users;
using HeavyService.Persistance.Validations.Users;
using Xunit;

namespace HeavyService.UnitTest.ValidatorTest.Users;

public class UserUpdateValidatorTest
{
    [Theory]
    [InlineData("bvhjfvbjhvbsdhbvjhsbvjhdbvhdbvjhdsbvhsbjvbdvjbhdsbjvjdsbvjhs")]
    [InlineData("bfgbgfgjhjhjhgjghjhgjhgjsbvjhdbvhdbvjhdsbvhsbjvbdvjbhdsbjvjdsbvjhs")]
    public void ShouldReturnWrongFirstName(string firstname)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = firstname;
        dto.LastName = "AAAAA";
        dto.Email = "akmalovaziz844@gmail.com";
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AAAAdjvnd")]
    [InlineData("AAcndjjcjdnvdnjdnjv")]
    [InlineData("dvmkdvkdvkdvdvdvmk")]
    public void ShouldReturnValidFirstName(string firstname)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = firstname;
        dto.LastName = "AAAAA";
        dto.Email = "akmalovaziz844@gmail.com";
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("bvhjfvbjhvbsdhbvjhsbvjhdbvhdbvjhdsbvhsbjvbdvjbhdsbjvjdsbvjhs")]
    [InlineData("bfgbgfgjhjhjhgjghjhgjhgjsbvjhdbvhdbvjhdsbvhsbjvbdvjbhdsbjvjdsbvjhs")]
    public void ShouldReturnWrongLastName(string lastname)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = "Akmalov";
        dto.LastName = lastname;
        dto.Email = "akmalovaziz844@gmail.com";
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AAAAdjvnd")]
    [InlineData("AAcndjjcjdnvdnjdnjv")]
    [InlineData("dvmkdvkdvkdvdvdvmk")]
    public void ShouldReturnValidLastName(string lastname)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = "Abdug'aniyev";
        dto.LastName = lastname;
        dto.Email = "akmalovaziz844@gmail.com";
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("dvdvjdnvjdskvsd")]
    [InlineData("@gmail.com")]
    [InlineData("@gmail.uz")]
    [InlineData("akmalovaziz@gmail")]
    [InlineData("akmalovaziz@gmailcom")]
    public void ShouldReturnWrongEmail(string email)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.Email = email;
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaaa@gmail.com")]
    [InlineData("aaa_asds@gmail.com")]
    [InlineData("aaa123@gmail.com")]
    public void ShouldReturnValidEmail(string email)
    {
        var dto = new UserUpdateDto();
        dto.FirstName = "Abdurahim";
        dto.LastName = "Abdug'aniyev";
        dto.Email = email;
        dto.Password = "AAaa11@@";

        var validator = new UserUpdateValidator();
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
        var dto = new UserUpdateDto();
        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.Email = "aaaa@gmail.com";
        dto.Password = password;

        var validator = new UserUpdateValidator();
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
        var dto = new UserUpdateDto();
        dto.FirstName = "Abdurahim";
        dto.LastName = "Abdug'aniyev";
        dto.Email = "aaaa@gmail.com";
        dto.Password = password;

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}