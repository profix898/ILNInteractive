﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Html;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive
{
    public static class HtmlContentUtility
    {
        public static IHtmlContent WritePNG(Bitmap bitmap, int width, int height)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);

                return WritePNG(memoryStream.ToArray(), width, height);
            }
        }

        public static IHtmlContent WritePNG(byte[] pngBytes, int width, int height)
        {
            var imageSource = $"data:image/png;base64,{Convert.ToBase64String(pngBytes)}";

            return img[src: imageSource, width: width, height: height]();
        }

        public static IHtmlContent WriteSVG(byte[] svgBytes)
        {
            return WriteSVG(Encoding.UTF8.GetString(svgBytes, 0, svgBytes.Length));
        }
        
        public static IHtmlContent WriteSVG(string svgContent)
        {
            svgContent = svgContent.Replace("<?xml version='1.0' encoding='UTF-8'?>", ""); // Strip XML header
            svgContent = svgContent.Replace("<!DOCTYPE svg PUBLIC '-//W3C//DTD SVG 1.1//EN' 'http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd'>", ""); // Strip DocType header
            svgContent = svgContent.Replace("\r\n", ""); // Strip all line breaks

            return div[id: GetId("svg-")](new HtmlString(svgContent));
        }

        #region Private

        private static string GetId(string type)
        {
            return type + Guid.NewGuid().ToString("N");
        }

        #endregion
    }
}
