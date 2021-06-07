using System;
using System.Collections.Generic;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using XPlot.Plotly;
using Surface = ILNumerics.Drawing.Plotting.Surface;

namespace ILN2XPlot.Generator.Elements
{
    public class SurfaceBinder : IPlotBinder
    {
        public void Bind(Group group, List<Trace> traces, List<string> labels, Layout.Layout layout)
        {
            if (!(group is Surface surface))
                return;

            // TODO: Colormap, etc.
        }

        #region FormatHelper

        private static IEnumerable<string> DataTable(Surface surface)
        {
            var scaleModes = surface.FirstUp<PlotCubeDataGroup>().ScaleModes;

            yield return "  table[row sep=crcr]{";

            Array<float> positions = surface.Positions; // n x n x 3 (z, x, y)
            for (var i = 0; i < positions.S[0]; i++)
            {
                for (var j = 0; j < positions.S[1]; j++)
                {
                    Array<float> xyz = positions[i, j, Globals.full];
                    var x = (float) xyz[1];
                    if (scaleModes.XAxisScale == AxisScale.Logarithmic)
                        x = (float) Math.Pow(10.0, x);
                    var y = (float) xyz[2];
                    if (scaleModes.YAxisScale == AxisScale.Logarithmic)
                        y = (float) Math.Pow(10.0, y);
                    var z = (float) xyz[0];
                    if (scaleModes.ZAxisScale == AxisScale.Logarithmic)
                        z = (float) Math.Pow(10.0, z);

                    yield return FormattableString.Invariant($"  {x}  {y} {z}\\\\");
                }
            }

            yield return "};";
        }

        #endregion
    }
}