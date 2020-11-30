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
        public PlotModel CreateNewPlotModel(string plotModelTitle, string verticalAxisTitle, int minValue, int maxValue)
        {
            PlotModel plotModel = new PlotModel();

            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);
            plotModel.PlotMargins = new OxyThickness(10);
            plotModel.Title = plotModelTitle;
            plotModel.Axes.Add(createVerticalAxis(verticalAxisTitle, minValue, maxValue));
            plotModel.Axes.Add(createTimeAxis());

            return plotModel;
        }

        private LinearAxis createTimeAxis()
        {
            LinearAxis myTimeAxis = new LinearAxis();

            myTimeAxis.Minimum = 0;
            myTimeAxis.PositionAtZeroCrossing = true;
            myTimeAxis.TickStyle = TickStyle.Crossing;
            myTimeAxis.MajorGridlineStyle = LineStyle.Dash;
            myTimeAxis.MinorGridlineStyle = LineStyle.Dot;
            myTimeAxis.Position = AxisPosition.Bottom;
            myTimeAxis.Title = "Time [ms]";
            myTimeAxis.TitlePosition = 0;

            return myTimeAxis;
        }

        private LinearAxis createVerticalAxis(string verticalAxisTitle, int minValue, int maxValue)
        {
            var myVerticalAxis = new LinearAxis();

            myVerticalAxis.Maximum = maxValue;
            myVerticalAxis.Minimum = minValue;
            myVerticalAxis.PositionAtZeroCrossing = true;
            myVerticalAxis.TickStyle = TickStyle.Crossing;
            myVerticalAxis.MajorGridlineStyle = LineStyle.Dash;
            myVerticalAxis.MinorGridlineStyle = LineStyle.Dot;
            myVerticalAxis.Title = verticalAxisTitle;

            return myVerticalAxis;
        }
    }
}
