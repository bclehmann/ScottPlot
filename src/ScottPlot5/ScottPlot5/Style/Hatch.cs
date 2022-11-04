using SkiaSharp;
using System.IO;
using System;

namespace ScottPlot.Style;

public struct Hatch
{
    public Color Color { get; set; } = Colors.Gray;
    public float Scale { get; set; } = 1;
    public HatchPattern Pattern { get; set; } = HatchPattern.DiagnalUp;

    public Hatch()
    {
    }
    
    public SKPathEffect? GetPathEffect()
    {
        return Pattern switch
        {
            HatchPattern.DiagnalUp => DiagonalUp(),
            HatchPattern.DiagnalDown => DiagonalDown(),
            HatchPattern.HorizontalLines => HorizontalLines(),
            HatchPattern.VerticalLines => VerticalLines(),
            HatchPattern.None => null,
            _ => throw new NotImplementedException(),
        };
    }

    private static (SKPath path, SKMatrix mat) Stripe()
    {
        var path = new SKPath();

        path.AddRect(new SKRect(0, 0, 2, 2));

        return (path, SKMatrix.CreateScale(2, 5));
    }

    public static SKPathEffect DiagonalUp()
    {
        (SKPath path, SKMatrix mat) = Stripe();
        mat = mat.PostConcat(SKMatrix.CreateRotationDegrees(-45)); // Rotate the stripes

        return SKPathEffect.Create2DPath(mat, path);
    }

    public static SKPathEffect DiagonalDown()
    {
        (SKPath path, SKMatrix mat) = Stripe();
        mat = mat.PostConcat(SKMatrix.CreateRotationDegrees(45)); // Rotate the stripes

        return SKPathEffect.Create2DPath(mat, path);
    }

    public static SKPathEffect HorizontalLines()
    {
        (SKPath path, SKMatrix mat) = Stripe();
        return SKPathEffect.Create2DPath(mat, path);
    }

    public static SKPathEffect VerticalLines()
    {
        (SKPath path, SKMatrix mat) = Stripe();
        mat = mat.PostConcat(SKMatrix.CreateRotationDegrees(90)); // Rotate the stripes

        return SKPathEffect.Create2DPath(mat, path);
    }
}
