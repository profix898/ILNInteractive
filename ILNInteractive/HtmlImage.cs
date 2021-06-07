using System.Drawing;
using Microsoft.AspNetCore.Html;

namespace ILNInteractive
{
    public static class HtmlImage
    {
        public static IHtmlContent DrawNotImplemented()
        {
            return new HtmlString("<h1>MPIPad.NotImplemented</h1>");
        }

        public static IHtmlContent DrawBitmap(Bitmap image)
        {
            return new HtmlString("<h1>MPIPad.DrawBitmap</h1>");
        }

        public static IHtmlContent DrawSvg(byte[] svgImage)
        {
            return new HtmlString("<h1>MPIPad.DrawSvg</h1>");
        }
    }
}