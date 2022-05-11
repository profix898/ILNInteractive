using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ILN2Tikz;
using ILNumerics.Drawing;
using Point = System.Drawing.Point;

namespace ILNInteractive
{
    public static class ILNInteractiveUtility
    {
        #region SaveAs

        public static void SaveAsSvg(this Scene scene, string filePath, Point? graphSize = null)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            filePath = Path.ChangeExtension(filePath, ".svg");
            graphSize ??= ILNInteractiveOptions.GraphSize;

            using var fileStream = new FileStream(filePath, FileMode.Create);
            new SVGDriver(fileStream, graphSize.Value.X, graphSize.Value.Y, scene).Render();

            Console.WriteLine($"Scene saved as SVG at '{filePath}'.");
        }

        public static void SaveAsTikz(this Scene scene, string filePath, Point? graphSize = null)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            filePath = Path.ChangeExtension(filePath, ".tikz");
            graphSize ??= ILNInteractiveOptions.GraphSize;

            using var fileStream = new FileStream(filePath, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);
            ILN2TikzExport.Export(scene, streamWriter, new Size(graphSize.Value));
            streamWriter.Flush();

            Console.WriteLine($"Scene saved as TIKZ at '{filePath}'.");
        }

        public static void SaveAsPng(this Scene scene, string filePath, Point? graphSize = null, int resolution = 300)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            filePath = Path.ChangeExtension(filePath, ".png");
            graphSize ??= ILNInteractiveOptions.GraphSize;

            var driver = new GDIDriver(graphSize.Value.X, graphSize.Value.Y, scene);
            driver.Render();
            driver.BackBuffer.Bitmap.SetResolution(resolution, resolution);
            driver.BackBuffer.Bitmap.Save(filePath, ImageFormat.Png);

            Console.WriteLine($"Scene saved as PNG at '{filePath}'.");
        }

        #endregion
    }
}
