using System;
using System.Collections.Generic;
using System.Linq;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using static ILNumerics.ILMath;

namespace ILNInteractive.QuickPlot
{
    public static partial class QuickPlot
    {
        public static Scene Plot(InArray<float> x, InArray<float> y1, InArray<float> y2 = null, InArray<float> y3 = null, InArray<float> y4 = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, string xAxisLabel = null, string yAxisLabel = null,
                                 IEnumerable<string> labels = null)
        {
            using (Scope.Enter(x, y1, y2, y3, y4))
            {
                if (isnull(x))
                    throw new ArgumentNullException(nameof(x));
                if (!x.IsVector)
                    throw new ArgumentException("Argument 'x' must be a 1-dim vector.");

                var yArgs = new[] { y1, y2, y3, y4 }.Where(y => !isnull(y)).ToArray();
                foreach (var y in yArgs)
                {
                    if (!y.IsVector)
                        throw new ArgumentException("All arguments 'y' must be a 1-dim vector.");
                    if (x.Length != y.Length)
                        throw new ArgumentException("Arguments 'x' and all 'y' must be vectors with same length (number of elements).");
                }

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                foreach (var y in yArgs)
                    plotCube.Add(new LinePlot(x, y));

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;

                plotCube.Axes.XAxis.Label.Text = String.IsNullOrEmpty(xAxisLabel) ? "X Axis" : xAxisLabel;
                plotCube.Axes.YAxis.Label.Text = String.IsNullOrEmpty(yAxisLabel) ? "Y Axis" : yAxisLabel;

                var legendLabels = labels?.Where(label => label != null).ToArray();
                if (legendLabels != null && legendLabels.Length > 0)
                    plotCube.Add(new Legend(legendLabels));

                return scene;
            }
        }

        public static Scene Plot(InArray<double> x, InArray<double> y1, InArray<double> y2 = null, InArray<double> y3 = null, InArray<double> y4 = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, string xAxisLabel = null, string yAxisLabel = null,
                                 IEnumerable<string> labels = null)
        {
            using (Scope.Enter(x, y1, y2, y3, y4))
            {
                if (isnull(x))
                    throw new ArgumentNullException(nameof(x));
                if (!x.IsVector)
                    throw new ArgumentException("Argument 'x' must be a 1-dim vector.");

                var yArgs = new[] { y1, y2, y3, y4 }.Where(y => !isnull(y)).ToArray();
                foreach (var y in yArgs)
                {
                    if (!y.IsVector)
                        throw new ArgumentException("All arguments 'y' must be a 1-dim vector.");
                    if (x.Length != y.Length)
                        throw new ArgumentException("Arguments 'x' and all 'y' must be vectors with same length (number of elements).");
                }

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                foreach (var y in yArgs)
                    plotCube.Add(new LinePlot(x, y));

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;

                plotCube.Axes.XAxis.Label.Text = String.IsNullOrEmpty(xAxisLabel) ? "X Axis" : xAxisLabel;
                plotCube.Axes.YAxis.Label.Text = String.IsNullOrEmpty(yAxisLabel) ? "Y Axis" : yAxisLabel;

                var legendLabels = labels?.Where(label => label != null).ToArray();
                if (legendLabels != null && legendLabels.Length > 0)
                    plotCube.Add(new Legend(legendLabels));

                return scene;
            }
        }

        public static Scene Plot(InArray<float> positions, AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear,
                                 string xAxisLabel = null, string yAxisLabel = null, IEnumerable<string> labels = null)
        {
            using (Scope.Enter(positions))
            {
                if (isnull(positions))
                    throw new ArgumentNullException(nameof(positions));

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new LinePlot(positions));

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;

                plotCube.Axes.XAxis.Label.Text = String.IsNullOrEmpty(xAxisLabel) ? "X Axis" : xAxisLabel;
                plotCube.Axes.YAxis.Label.Text = String.IsNullOrEmpty(yAxisLabel) ? "Y Axis" : yAxisLabel;

                var legendLabels = labels?.Where(label => label != null).ToArray();
                if (legendLabels != null && legendLabels.Length > 0)
                    plotCube.Add(new Legend(legendLabels));

                return scene;
            }
        }

        public static Scene Plot(InArray<double> positions, AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear,
                                 string xAxisLabel = null, string yAxisLabel = null, IEnumerable<string> labels = null)
        {
            using (Scope.Enter(positions))
            {
                if (isnull(positions))
                    throw new ArgumentNullException(nameof(positions));

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new LinePlot(tosingle(positions)));

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;

                plotCube.Axes.XAxis.Label.Text = String.IsNullOrEmpty(xAxisLabel) ? "X Axis" : xAxisLabel;
                plotCube.Axes.YAxis.Label.Text = String.IsNullOrEmpty(yAxisLabel) ? "Y Axis" : yAxisLabel;

                var legendLabels = labels?.Where(label => label != null).ToArray();
                if (legendLabels != null && legendLabels.Length > 0)
                    plotCube.Add(new Legend(legendLabels));

                return scene;
            }
        }
    }
}
