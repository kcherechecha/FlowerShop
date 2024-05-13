﻿namespace FlowerShop.UI.Common.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
