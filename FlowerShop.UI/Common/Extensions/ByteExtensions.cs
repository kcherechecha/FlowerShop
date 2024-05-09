namespace FlowerShop.UI.Common.Extensions
{
    public static class ByteExtensions
    {
        public static IFormFile ToIFormFile(this byte[] photo)
        {
            return new FormFile(new MemoryStream(photo), 0, photo.Length, "Photo", "photo.jpg");
        }
    }
}
