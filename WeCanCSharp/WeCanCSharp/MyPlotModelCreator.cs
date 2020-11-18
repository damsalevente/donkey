using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;

namespace WeCanCSharp
{
    class MyPlotModelCreator
    {
        public PlotModel createNewPlotModel()
        {
            var plotModel = new PlotModel();

            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);

            plotModel.PlotMargins = new OxyThickness(10);





            var linearAxis = new LinearAxis();

            linearAxis.Maximum = 1000;

            linearAxis.Minimum = 0;

            linearAxis.PositionAtZeroCrossing = true;

            linearAxis.TickStyle = TickStyle.Crossing;

            linearAxis.MajorGridlineStyle = LineStyle.Dash;

            linearAxis.MinorGridlineStyle = LineStyle.Dot;

            plotModel.Axes.Add(linearAxis);



            var secondLinearAxis = new LinearAxis();

            secondLinearAxis.Maximum = 1000;

            secondLinearAxis.Minimum = 0;

            secondLinearAxis.PositionAtZeroCrossing = true;

            secondLinearAxis.TickStyle = TickStyle.Crossing;

            secondLinearAxis.Position = AxisPosition.Bottom;

            secondLinearAxis.MajorGridlineStyle = LineStyle.Dash;

            secondLinearAxis.MinorGridlineStyle = LineStyle.Dot;

            plotModel.Axes.Add(secondLinearAxis);

            plotModel.Title = "myMotorVoltagePlotView";





            return plotModel;
        }
    }
}
