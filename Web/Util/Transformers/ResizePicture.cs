using System;
using System.IO;
using SkiaSharp;

namespace Web.Util.Transformers
{
    public static class ResizePicture 
    {
        public static byte[] Resize(byte[] fileContents, int maxWidth, int maxHeight)
        {
            using var ms = new MemoryStream(fileContents);
            using var sourceBitmap = SKBitmap.Decode(ms);

            var height = Math.Min(maxHeight, sourceBitmap.Height);
            var width = Math.Min(maxWidth, sourceBitmap.Width);

            using var scaledBitmap = sourceBitmap.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);
            using var scaledImage = SKImage.FromBitmap(scaledBitmap);
            using var data = scaledImage.Encode();

            return data.ToArray();
        }

    }
}