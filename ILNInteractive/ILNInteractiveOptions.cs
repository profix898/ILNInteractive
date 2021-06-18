using System.Drawing;

namespace ILNInteractive
{
    public static class ILNInteractiveOptions
    {
        public static ILNGraphMode GraphMode { get; set; } = ILNGraphMode.SVG;

        public static Point GraphSize { get; set; } = new Point(600, 400);
    }
}