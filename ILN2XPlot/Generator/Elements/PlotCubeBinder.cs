using System;
using System.Collections.Generic;
using System.Drawing;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using XPlot.Plotly;

namespace ILN2XPlot.Generator.Elements
{
    public class PlotCubeBinder : IPlotBinder
    {
        public void Bind(Group group, List<Trace> traces, List<string> labels, Layout.Layout layout)
        {
            if (!(group is PlotCube plotCube))
                return;

            // TODO: Font: Family, Size, Bold/Italic, Color

            //// Global
            //var title = group.First<Title>();
            //layout.title = title?.Label?.Text ?? String.Empty;

            //// XAxis
            //layout.xaxis.title = plotCube.Axes.XAxis.Label.Text;
            //layout.xaxis.type = (plotCube.ScaleModes.XAxisScale == AxisScale.Linear) ? "linear" : "log";
            //var xMin = plotCube.Axes.XAxis.Min ?? plotCube.Plots.Limits.XMin;
            //var xMax = plotCube.Axes.XAxis.Max ?? plotCube.Plots.Limits.XMax;
            //layout.xaxis.range = (plotCube.ScaleModes.XAxisScale == AxisScale.Linear) ? $"{xMin}:{xMax}" : $"{Math.Pow(10.0, xMin)}:{Math.Pow(10.0, xMax)}";
            //layout.xaxis.showgrid = plotCube.Axes.XAxis.GridMajor.Visible;
            //layout.xaxis.gridcolor = (plotCube.Axes.XAxis.GridMajor.Color ?? Color.FromArgb(230, 230, 230)).FormatXPlotColor();
            //layout.xaxis.gridwidth = plotCube.Axes.XAxis.GridMajor.Width;

            //// YAxis
            //layout.yaxis.title = plotCube.Axes.YAxis.Label.Text;
            //layout.yaxis.type = (plotCube.ScaleModes.YAxisScale == AxisScale.Linear) ? "linear" : "log";
            //var yMin = plotCube.Axes.YAxis.Min ?? plotCube.Plots.Limits.XMin;
            //var yMax = plotCube.Axes.YAxis.Max ?? plotCube.Plots.Limits.XMax;
            //layout.yaxis.range = (plotCube.ScaleModes.YAxisScale == AxisScale.Linear) ? $"{yMin}:{yMax}" : $"{Math.Pow(10.0, yMin)}:{Math.Pow(10.0, yMax)}";
            //layout.yaxis.showgrid = plotCube.Axes.YAxis.GridMajor.Visible;
            //layout.yaxis.gridcolor = (plotCube.Axes.YAxis.GridMajor.Color ?? Color.FromArgb(230, 230, 230)).FormatXPlotColor();
            //layout.yaxis.gridwidth = plotCube.Axes.YAxis.GridMajor.Width;
            
            //// ZAxis
            //layout.zaxis.title = plotCube.Axes.ZAxis.Label.Text;
            //layout.zaxis.type = (plotCube.ScaleModes.ZAxisScale == AxisScale.Linear) ? "linear" : "log";
            //var zMin = plotCube.Axes.ZAxis.Min ?? plotCube.Plots.Limits.XMin;
            //var zMax = plotCube.Axes.ZAxis.Max ?? plotCube.Plots.Limits.XMax;
            //layout.zaxis.range = (plotCube.ScaleModes.ZAxisScale == AxisScale.Linear) ? $"{zMin}:{zMax}" : $"{Math.Pow(10.0, zMin)}:{Math.Pow(10.0, zMax)}";
            //layout.zaxis.showgrid = plotCube.Axes.ZAxis.GridMajor.Visible;
            //layout.zaxis.gridcolor = (plotCube.Axes.ZAxis.GridMajor.Color ?? Color.FromArgb(230, 230, 230)).FormatXPlotColor();
            //layout.zaxis.gridwidth = plotCube.Axes.ZAxis.GridMajor.Width;

            //// Legend
            //var legend = plotCube.First<Legend>();
            //if (legend != null)
            //{
            //    LegendVisible = legend.Visible;
            //    LegendLocation = legend.Location;
            //    LegendBorderColor = legend.Border.Color ?? Color.Black;
            //    layout.Colors.Add(LegendBorderColor);
            //    LegendBackgroundColor = legend.Background.Color ?? Color.White;
            //    layout.Colors.Add(LegendBackgroundColor);
            //}
            
            // Map plots (LinePlot, Surface, etc.)
            // LinePlots
            foreach (var linePlot in plotCube.Find<LinePlot>())
                linePlot.Bind<LinePlotBinder>(traces, labels, layout);

            //// SurfacePlots
            //foreach (var surface in plotCube.Find<ILNumerics.Drawing.Plotting.Surface>())
            //    surface.Bind<SurfaceBinder>(traces, labels, layout);
        }
    }
}
