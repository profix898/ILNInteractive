using System;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using static ILNumerics.ILMath;

namespace ILNInteractive.QuickPlot
{
    public static partial class QuickPlot
    {
        public static Scene Surf(InArray<float> ZXYPositions, InArray<float> C = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            using (Scope.Enter(ZXYPositions))
            {
                if (isnull(ZXYPositions))
                    throw new ArgumentNullException(nameof(ZXYPositions));
                if (!ZXYPositions.IsMatrix)
                    throw new ArgumentException("Argument 'ZXYPositions' must be a matrix of size [m x n x [1|2|3]].");

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new Surface(ZXYPositions, C));
                plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

                // AxisScale
                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;
                plotCube.ScaleModes.ZAxisScale = zAxisScale;

                return scene;
            }
        }

        public static Scene Surf(InArray<double> ZXYPositions, InArray<float> C = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            using (Scope.Enter(ZXYPositions, C))
            {
                if (isnull(ZXYPositions))
                    throw new ArgumentNullException(nameof(ZXYPositions));
                if (!ZXYPositions.IsMatrix)
                    throw new ArgumentException("Argument 'ZXYPositions' must be a matrix of size [m x n x [1|2|3]].");

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new Surface(tosingle(ZXYPositions), C));
                plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;
                plotCube.ScaleModes.ZAxisScale = zAxisScale;

                return scene;
            }
        }

        public static Scene Surf(InArray<float> Z, InArray<float> X, InArray<float> Y, InArray<float> C = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            using (Scope.Enter(Z, X, Y, C))
            {
                if (!isnull(Z) && !Z.IsVector && !Z.IsMatrix)
                    throw new ArgumentException("Argument 'X' must be null, a vector of length n or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");
                if (!isnull(X) && !X.IsVector && !X.IsMatrix)
                    throw new ArgumentException("Argument 'X' must be null, a vector of length n or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");
                if (!isnull(Y) && !Y.IsVector && !Y.IsMatrix)
                    throw new ArgumentException("Argument 'Y' must be null, a vector of length m or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new Surface(Z, X, Y, C));
                plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;
                plotCube.ScaleModes.ZAxisScale = zAxisScale;

                return scene;
            }
        }

        public static Scene Surf(InArray<double> Z, InArray<double> X, InArray<double> Y, InArray<float> C = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            using (Scope.Enter(Z, X, Y, C))
            {
                if (!isnull(Z) && !Z.IsVector && !Z.IsMatrix)
                    throw new ArgumentException("Argument 'X' must be null, a vector of length n or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");
                if (!isnull(X) && !X.IsVector && !X.IsMatrix)
                    throw new ArgumentException("Argument 'X' must be null, a vector of length n or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");
                if (!isnull(Y) && !Y.IsVector && !Y.IsMatrix)
                    throw new ArgumentException("Argument 'Y' must be null, a vector of length m or a matrix of size [m by n], with m = Z.S[0], n = Z.S[1].");

                var scene = new Scene();
                var plotCube = scene.Add(new PlotCube());
                plotCube.Add(new Surface(tosingle(Z), tosingle(X), tosingle(Y), C));
                plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

                plotCube.ScaleModes.XAxisScale = xAxisScale;
                plotCube.ScaleModes.YAxisScale = yAxisScale;
                plotCube.ScaleModes.ZAxisScale = zAxisScale;

                return scene;
            }
        }

        public static Scene Surf(Func<float, float, float> ZFunc, float xmin = -10f, float xmax = 10f, int xlen = 50, float ymin = -10f, float ymax = 10f, int ylen = 50,
                                 Func<float, float, float> CFunc = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            var scene = new Scene();
            var plotCube = scene.Add(new PlotCube());
            plotCube.Add(new Surface(ZFunc, xmin, xmax, xlen, ymin, ymax, ylen, CFunc));
            plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

            plotCube.ScaleModes.XAxisScale = xAxisScale;
            plotCube.ScaleModes.YAxisScale = yAxisScale;
            plotCube.ScaleModes.ZAxisScale = zAxisScale;

            return scene;
        }

        public static Scene Surf(Func<double, double, double> ZFunc, double xmin = -10d, double xmax = 10d, int xlen = 50, double ymin = -10d, double ymax = 10d, int ylen = 50,
                                 Func<float, float, float> CFunc = null,
                                 AxisScale xAxisScale = AxisScale.Linear, AxisScale yAxisScale = AxisScale.Linear, AxisScale zAxisScale = AxisScale.Linear)
        {
            var scene = new Scene();
            var plotCube = scene.Add(new PlotCube());

            float ZFuncFloat(float x, float y) => (float) ZFunc(x, y);
            plotCube.Add(new Surface(ZFuncFloat, (float) xmin, (float) xmax, xlen, (float) ymin, (float) ymax, ylen, CFunc));
            plotCube.Rotation = ILNInteractiveOptions.GraphSurfRotation;

            plotCube.ScaleModes.XAxisScale = xAxisScale;
            plotCube.ScaleModes.YAxisScale = yAxisScale;
            plotCube.ScaleModes.ZAxisScale = zAxisScale;

            return scene;
        }
    }
}
