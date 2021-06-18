using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive
{
    public static class HtmlContentUtility
    {
        public static IHtmlContent NotImplemented()
        {
            return new HtmlString("<h1>ILNInteractive.NotImplemented</h1>");
        }
        
        public static IHtmlContent WriteSVG(byte[] svgBytes)
        {
            return WriteSVG(Encoding.UTF8.GetString(svgBytes, 0, svgBytes.Length));
        }

        public static IHtmlContent WriteSVG(string svgContent)
        {
            svgContent = svgContent.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", ""); // Strip XML header

            return new HtmlString(div[id: GetId("svg-")](svgContent));
        }

        #region Private

        private static string GetId(string type)
        {
            return type + Guid.NewGuid().ToString("N");
        }

        #endregion
    }
}
