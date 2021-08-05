using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using XPlot.Plotly;
using Legend = ILNumerics.Drawing.Plotting.Legend;
using Line = XPlot.Plotly.Line;
using Marker = XPlot.Plotly.Marker;

namespace ILN2XPlot.Generator.Elements
{
    public class LinePlotBinder : IPlotBinder
    {
        #region IPlotBinder Members

        public void Bind(Group group, List<Trace> traces, List<string> labels, Layout.Layout layout)
        {
            if (!(group is LinePlot linePlot))
                return;

            var scatter = new Scatter();
            scatter.x = linePlot.Positions[0, Globals.full].ToArray();
            scatter.y = linePlot.Positions[1, Globals.full].ToArray();

            // Line
            scatter.line = new Line
            {
                width = linePlot.Line.Width,
                color = (linePlot.Line.Color ?? Color.Black).FormatXPlotColor()
                //dash = linePlot.Line.DashStyle
            };

            //// Marker
            //scatter.marker = new Marker
            //{
            //    size = Math.Max(linePlot.Marker.Size / 2, 1),
            //    color = (linePlot.Marker.Fill.Color ?? linePlot.Line.Color ?? Color.Black).FormatXPlotColor()
            //};

            //// LegendEntry
            //var legend = linePlot.FirstUp<PlotCube>().First<Legend>();
            //if (legend != null)
            //    scatter.name = legend.Find<LegendItem>().FirstOrDefault(legendItem => legendItem.ProviderID == linePlot.ID)?.Text;

            traces.Add(scatter);
        }

        #endregion
    }
}
