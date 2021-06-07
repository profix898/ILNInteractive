using System;
using System.Collections.Generic;
using ILN2XPlot.Generator;
using ILN2XPlot.Generator.Elements;
using ILNumerics.Drawing.Plotting;
using XPlot.Plotly;
using Scene = ILNumerics.Drawing.Scene;

namespace ILN2XPlot
{
    public static class ILN2XPlotExport
    {
        public static PlotlyChart Bind(Scene scene)
        {
            if (scene == null)
                throw new ArgumentNullException(nameof(scene));

            var traces = new List<Trace>();
            var labels = new List<string>();
            var layout = new Layout.Layout();

            var plotCube = scene.First<PlotCube>();
            if (plotCube != null)
                plotCube.Bind<PlotCubeBinder>(traces, labels, layout);

            var plotlyChart = new PlotlyChart();
            plotlyChart.Plot(traces, layout, labels);

            return plotlyChart;
        }
    }
}