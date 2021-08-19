﻿using System;
using System.IO;
using ILN2XPlot;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive.Formatting;
using XPlot.Plotly;
using Scene = ILNumerics.Drawing.Scene;

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
                case ILNGraphMode.SVG:
                    RenderSVG(context, scene);
                    break;
                case ILNGraphMode.XPlot:
                    RenderXPlot(context, scene);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        private void RenderSVG(FormatContext context, Scene scene)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Render SVG into memory stream
                new SVGDriver(memoryStream, ILNInteractiveOptions.GraphSize.X, ILNInteractiveOptions.GraphSize.Y, scene).Render();

                // Embed as HTML content
                context.Writer.Write(HtmlContentUtility.WriteSVG(memoryStream.ToArray()));
            }
        }

        private void RenderXPlot(FormatContext context, Scene scene)
        {
            var plotlyChart = ILN2XPlotExport.Export(scene);
            if (plotlyChart != null)
                plotlyChart.FormatTo(context, MimeType);
            else
                RenderSVG(context, scene); // Fallback to SVG output
        }
    }
}