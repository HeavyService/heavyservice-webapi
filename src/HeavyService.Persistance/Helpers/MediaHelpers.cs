namespace HeavyService.Service.Helpers;

public class MediaHelpers
{
    public static string MakeImageName(string filename)
    {
        var fileinfo = new FileInfo(filename);
        var extension = fileinfo.Extension;
        var ImageName = "IMG" + Guid.NewGuid() + extension;

        return ImageName;
    }

    public static string[] GetImageExtension()
    {
        return new string[]
        {
            //JPG file
            ".jpg", ".jpeg",
            //PNG file
            ".png",
            //SVG file
            ".svg",
            //Bitmap
            ".bmp"
        };
    }
}
