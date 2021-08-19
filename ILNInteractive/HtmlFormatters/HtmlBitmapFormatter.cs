using System;
using System.Drawing;
using Microsoft.DotNet.Interactive.Formatting;
using static ILNInteractive.HtmlContentUtility;

namespace ILNInteractive.HtmlFormatters
{
    public class HtmlBitmapFormatter : ITypeFormatter
    {
        public string MimeType => HtmlFormatter.MimeType;

        public Type Type => typeof(Bitmap);

        public bool Format(object instance, FormatContext context)
        {
            if (instance is not Bitmap bitmap)
                return false;

            var graphSize = ILNInteractiveOptions.GraphSize;
            context.Writer.Write(WritePNG(bitmap, graphSize.X, graphSize.Y));

            return true;
        }
    }
}
