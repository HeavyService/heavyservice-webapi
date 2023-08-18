using HeavyService.Persistance.Dtos.Instruments;
using HeavyService.Persistance.Validations.Instruments;
using Microsoft.AspNetCore.Http;
using System.Text;
using Xunit;

namespace HeavyService.UnitTest.ValidatorTest.Instruments;

public class InstrumentCreateValidatorTest
{
    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aakbvhfbvjhfbvbfvbdfhvdfhvhjdfvbhdfdfvhbdfhfvbdvbhfdvbh")]
    public void ShouldReturnWrongName(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = name;
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaa")]
    [InlineData("aaaaaaaaa")]
    [InlineData("aakbvhfbvjhfbvbfvbdfh")]
    public void ShouldReturnValidName(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = name;
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(5.1)]
    [InlineData(10)]
    [InlineData(5.5)]
    [InlineData(6)]
    [InlineData(8)]
    public void ShouldReturnWrongImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024 + 1);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(2.5)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3.4)]
    [InlineData(4.5)]
    public void ShouldReturnValidImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.zip")]
    [InlineData("file.mp3")]
    [InlineData("file.mp4")]
    [InlineData("file.avi")]
    [InlineData("file.pgred")]
    [InlineData("file.html")]
    [InlineData("file.cs")]
    [InlineData("file.sln")]
    public void ShouldReturnWrongImageExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("file.bmp")]
    [InlineData("file.jpg")]
    [InlineData("file.png")]
    [InlineData("file.jpeg")]
    [InlineData("file.svg")]
    public void ShouldReturnValidImageExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-15)]
    public void ShouldReturnWrongPrice(int price)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = price;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(1200000)]
    [InlineData(15522)]
    public void ShouldReturnValidPrice(int price)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = price;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("f")]
    [InlineData("dd")]
    [InlineData("sss")]
    [InlineData("sssa")]
    public void ShouldReturnWrongRegion(string region)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = region;
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaaaaa")]
    [InlineData("ddaaa")]
    [InlineData("fnkjnjfnjbnjgbkdfjd")]
    public void ShouldReturnValidRegion(string region)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = region;
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("f")]
    [InlineData("dd")]
    [InlineData("sss")]
    [InlineData("sssa")]
    public void ShouldReturnWrongAddress(string address)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = address;
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaaaaa")]
    [InlineData("ddaaa")]
    [InlineData("fnkjnjfnjbnjgbkdfjd")]
    public void ShouldReturnValidAddress(string address)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = address;
        dto.District = "Olmazor";
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("f")]
    [InlineData("dd")]
    [InlineData("sss")]
    [InlineData("sssa")]
    public void ShouldReturnWrongDistrict(string district)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = district;
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("aaaaaa")]
    [InlineData("ddaaa")]
    [InlineData("fnkjnjfnjbnjgbkdfjd")]
    public void ShouldReturnValidDistrict(string district)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = district;
        dto.PhoneNumber = "+998998545977";

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("998998545977")]
    [InlineData("9989985459")]
    [InlineData("+9989985459")]
    [InlineData("8545977")]
    [InlineData("998545977")]
    public void ShouldReturnWrongPhoneNumber(string phonenumber)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = phonenumber;

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("+998998545977")]
    [InlineData("+998338545977")]
    [InlineData("+998938545977")]
    [InlineData("+998948545977")]
    public void ShouldReturnValidPhoneNumber(string phonenumber)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new InstrumentCreateDto();

        dto.Name = "aaaaaaa";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerDay = 15000;
        dto.Region = "Toshkent";
        dto.Address = "Beshqo'rg'on - 3 30 - 65";
        dto.District = "Olmazor";
        dto.PhoneNumber = phonenumber;

        var validator = new InstrumentCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}