﻿using System;
using System.IO;
using ILN2XPlot;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive.Formatting;
using XPlot.Plotly;
using Scene = ILNumerics.Drawing.Scene;

namespace ILNInteractive.Formatters
{
    public class HtmlSceneFormatter : ITypeFormatter
    {
        public string MimeType => "text/html";

        public Type Type => typeof(Scene);

        public bool Format(FormatContext context, object instance, TextWriter writer)
        {
            Scene scene = instance as Scene;
            if (scene == null)
                return false;

            switch (ILNInteractiveOptions.GraphMode)
            {
                case ILNGraphMode.SVG:
                    RenderSVG(context, scene, writer);
                    break;
                case ILNGraphMode.XPlot:
                    RenderXPlot(context, scene, writer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        private void RenderSVG(FormatContext context, Scene scene, TextWriter writer)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Render SVG into memory stream
                new SVGDriver(memoryStream, ILNInteractiveOptions.GraphSize.X, ILNInteractiveOptions.GraphSize.Y, scene).Render();

                // Embed as HTML content
                writer.Write(HtmlContentUtility.WriteSVG(memoryStream.ToArray()));
            }
        }

        private void RenderXPlot(FormatContext context, Scene scene, TextWriter writer)
        {
            PlotlyChart plotlyChart = ILN2XPlotExport.Bind(scene);

            plotlyChart.FormatTo(context, writer, MimeType);
        }
    }
}