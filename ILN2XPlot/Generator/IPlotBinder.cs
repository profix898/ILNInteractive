using System.Collections.Generic;
using ILNumerics.Drawing;
using XPlot.Plotly;

namespace ILN2XPlot.Generator
{
    public interface IPlotBinder
    {
        void Bind(Group group, List<Trace> traces, List<string> labels, Layout.Layout layout);
    }
}