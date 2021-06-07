using System.Drawing;

namespace ILN2XPlot.Generator
{
    public static class XPlotFormatUtility
    {
        public static string FormatXPlotColor(this Color color)
        {
            return $"rgb({color.R}, {color.G}, {color.B})";
        }
    }
}
