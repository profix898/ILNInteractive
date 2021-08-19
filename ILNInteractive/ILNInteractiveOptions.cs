﻿using System.Drawing;

namespace ILNInteractive
{
    public static class ILNInteractiveOptions
    {
        public static ILNGraphMode GraphMode { get; set; } = ILNGraphMode.XPlotPlotly;

        public static Point GraphSize { get; set; } = new Point(600, 400);

        public static int MaxArrayElements { get; set; } = 100;
    }
}