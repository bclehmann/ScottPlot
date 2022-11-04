﻿using ScottPlot.Style;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot
{
    internal static class PaintExtensions
    {
        public static void SetStroke(this SKPaint paint, Stroke stroke)
        {
            paint.StrokeWidth = (float)stroke.Width;
            paint.Color = stroke.Color.ToSKColor();
            paint.PathEffect = null;
            paint.Style = SKPaintStyle.Stroke;
        }

        public static void SetFill(this SKPaint paint, Fill fill, byte alpha = 255)
        {
            paint.Color = fill.Color.WithAlpha(alpha).ToSKColor();
            paint.PathEffect = fill.Hatch?.GetPathEffect();
            paint.Style = SKPaintStyle.Fill;
        }
    }
}
