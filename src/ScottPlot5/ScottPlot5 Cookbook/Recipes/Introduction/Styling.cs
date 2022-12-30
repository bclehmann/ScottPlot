﻿namespace ScottPlotCookbook.Recipes.Introduction;

internal class Styling : RecipePageBase
{
    public override RecipePageDetails PageDetails => new()
    {
        Chapter = Chapter.Introduction,
        PageName = "Styling Plots",
        PageDescription = "How to customize plots",
    };

    internal class BackgroundColors : RecipeTestBase
    {
        public override string Name => "Background Colors";
        public override string Description => "Figure and data area background colors can be customized.";

        [Test]
        public override void Recipe()
        {
            myPlot.Add.Signal(Generate.Sin(51));
            myPlot.Add.Signal(Generate.Cos(51));

            myPlot.FigureBackground = Colors.DarkGray;
            myPlot.DataBackground = Colors.LightGray;
        }
    }

    internal class AxisCustom : RecipeTestBase
    {
        public override string Name => "Axis Customization";
        public override string Description => "Axis labels, tick marks, and frame can all be customized";

        [Test]
        public override void Recipe()
        {
            myPlot.Add.Signal(Generate.Sin(51));
            myPlot.Add.Signal(Generate.Cos(51));

            myPlot.Title.Label.Text = "Plot Title";
            myPlot.Title.Label.Color = Colors.RebeccaPurple;
            myPlot.Title.Label.FontSize = 32;
            myPlot.Title.Label.Rotation = -5;
            myPlot.Title.Label.FontName = Font.SerifFontName;
            myPlot.Title.Label.Bold = false;

            myPlot.YAxis.Label.Text = "Vertical Axis";
            myPlot.YAxis.Label.Color = Colors.Magenta;
            myPlot.YAxis.Label.Italic = true;

            myPlot.XAxis.Label.Text = "Horizontal Axis";
            myPlot.XAxis.Label.Bold = false;
            myPlot.XAxis.Label.FontName = Font.MonospaceFontName;

            myPlot.XAxis.MajorTickLength = 10;
            myPlot.XAxis.MajorTickLineWidth = 3;
            myPlot.XAxis.MajorTickColor = Colors.Magenta;
            myPlot.XAxis.MinorTickLength = 5;
            myPlot.XAxis.MinorTickLineWidth = 0.5f;
            myPlot.XAxis.MinorTickColor = Colors.Green;
            myPlot.XAxis.FrameColor = Colors.LightBlue;
        }
    }

    internal class GridCustom : RecipeTestBase
    {
        public override string Name => "Grid Customization";
        public override string Description => "Grid lines can be customized. " +
            "Custom grid systems can be created to give developers full control of grid rendering, " +
            "but the default grid can be interacted with to customize its appearance.";

        [Test]
        public override void Recipe()
        {
            myPlot.Add.Signal(Generate.Sin(51));
            myPlot.Add.Signal(Generate.Cos(51));

            ScottPlot.Grids.DefaultGrid grid = myPlot.GetDefaultGrid();

            grid.MajorGridLineColor = Colors.Green.WithOpacity(.5);
            grid.MinorGridLineColor = Colors.Green.WithOpacity(.1);
            grid.MinorGridLineWidth = 1;
        }
    }

    internal class GridAbove : RecipeTestBase
    {
        public override string Name => "Grid Above Data";
        public override string Description => "Grid lines are typically drawn beneath " +
            "data, but grids can be configured to render on top of plottables too.";

        [Test]
        public override void Recipe()
        {
            var sig = myPlot.Add.Signal(Generate.Sin(51));
            sig.LineWidth = 10;

            ScottPlot.Grids.DefaultGrid grid = myPlot.GetDefaultGrid();
            grid.MajorGridLineWidth = 3;
            grid.MajorGridLineColor = Colors.WhiteSmoke;
            grid.IsBeneathPlottables = false;
        }
    }
}
