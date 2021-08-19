using System;
using System.IO;
using ILN2XPlot;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive.Formatting;
using Scene = ILNumerics.Drawing.Scene;
using static ILNInteractive.HtmlContentUtility;

namespace ILNInteractive.HtmlFormatters
{
    public class HtmlSceneFormatter : ITypeFormatter
    {
        public string MimeType => HtmlFormatter.MimeType;

        public Type Type => typeof(Scene);

        public bool Format(object instance, FormatContext context)
        {
            Scene scene = instance as Scene;
            if (scene == null)
                return false;

            switch (ILNInteractiveOptions.GraphMode)
            {
                case ILNGraphMode.Png:
                    RenderPng(context, scene);
                    break;
                case ILNGraphMode.Svg:
                    RenderSvg(context, scene);
                    break;
                case ILNGraphMode.XPlotPlotly:
                    RenderXPlotPlotly(context, scene);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        private void RenderPng(FormatContext context, Scene scene)
        {
            // Render bitmap
            var graphSize = ILNInteractiveOptions.GraphSize;
            var driver = new GDIDriver(graphSize.X, graphSize.Y, scene);
            driver.Render();
            driver.BackBuffer.Bitmap.SetResolution(300, 300);
            var bitmap = driver.BackBuffer.Bitmap;

            // Embed base64-encoded PNG as HTML content
            context.Writer.Write(WritePNG(bitmap, graphSize.X, graphSize.Y));
        }

        private void RenderSvg(FormatContext context, Scene scene)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Render SVG into memory stream
                var graphSize = ILNInteractiveOptions.GraphSize;
                new SVGDriver(memoryStream, graphSize.X, graphSize.Y, scene).Render();

                // Embed SVG as HTML content
                context.Writer.Write(WriteSVG(memoryStream.ToArray()));
            }
        }

        private void RenderXPlotPlotly(FormatContext context, Scene scene)
        {
            var plotlyChart = ILN2XPlotExport.Export(scene);
            if (plotlyChart != null)
                plotlyChart.FormatTo(context, MimeType);
            else
                RenderSvg(context, scene); // Fallback to SVG output
        }
    }
}