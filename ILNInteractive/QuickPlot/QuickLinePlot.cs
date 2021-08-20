using System;
using System.Linq;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using static ILNumerics.ILMath;

namespace ILNInteractive.QuickPlot
{
    public static partial class QuickPlot
    {
        public static Scene Plot(InArray<float> x, InArray<float> y1, InArray<float> y2 = null, InArray<float> y3 = null, InArray<float> y4 = null)
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

                return scene;
            }
        }

        public static Scene Plot(InArray<double> x, InArray<double> y1, InArray<double> y2 = null, InArray<double> y3 = null, InArray<double> y4 = null)
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

                return scene;
            }
        }

        public static Scene Plot(InArray<float> positions)
        {
            using (Scope.Enter(positions))
            {
                if (isnull(positions))
                    throw new ArgumentNullException(nameof(positions));

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new LinePlot(positions));

                return scene;
            }
        }

        public static Scene Plot(InArray<double> positions)
        {
            using (Scope.Enter(positions))
            {
                if (isnull(positions))
                    throw new ArgumentNullException(nameof(positions));

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new LinePlot(tosingle(positions)));

                return scene;
            }
        }
    }
}
