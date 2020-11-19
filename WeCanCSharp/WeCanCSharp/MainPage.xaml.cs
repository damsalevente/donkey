using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Threading.Tasks;
using System.ComponentModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /* FunctionSeries for data storage. */
        FunctionSeries lidarSensorFunctionSeries = new FunctionSeries();
        FunctionSeries motorVoltageFunctionSeries = new FunctionSeries();
        FunctionSeries servoPositionFunctionSeries = new FunctionSeries();
        FunctionSeries speedValueFunctionSeries = new FunctionSeries();

        /* The data model */
        MySimulation mySimulation;

        MyViewCreator myViewCreator = new MyViewCreator();

        MyPlotModelCreator myPlotModelCreator = new MyPlotModelCreator();

        public MainPage()
        {
            this.InitializeComponent();

            setMyPlotModels();
        }

        public void RefreshData(object sg, PropertyChangedEventArgs name)
        {
            /* Add the newly received points. */
            lidarSensorFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.lidarValue));
            motorVoltageFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.motorVoltage));
            servoPositionFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.servoPosition));
            speedValueFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.speedValue));

            /* TODO: remove the comment, if the threading problem is fixed. */
            //refreshPlot();
        }

        private void refreshPlot()
        {
            /* Refresh te maximum time */
            myLidarValuePlotView.Model.DefaultXAxis.Maximum = mySimulation.myTime;
            myMotorVoltagePlotView.Model.DefaultXAxis.Maximum = mySimulation.myTime;
            myServoPositionPlotView.Model.DefaultXAxis.Maximum = mySimulation.myTime;
            mySpeedValuePlotView.Model.DefaultXAxis.Maximum = mySimulation.myTime;

            /* Refresh the plot */
            myLidarValuePlotView.InvalidatePlot(true);
            myMotorVoltagePlotView.InvalidatePlot(true);
            myServoPositionPlotView.InvalidatePlot(true);
            mySpeedValuePlotView.InvalidatePlot(true);
        }

        private void setMyPlotModels()
        {
            myLidarValuePlotView.Model = myPlotModelCreator.createNewPlotModel("Lidar Value", "[DEC]", 0, 1000);
            myLidarValuePlotView.Model.Series.Add(lidarSensorFunctionSeries);

            myMotorVoltagePlotView.Model = myPlotModelCreator.createNewPlotModel("Motor Voltage", "[V]", 0, 6);
            myMotorVoltagePlotView.Model.Series.Add(motorVoltageFunctionSeries);

            myServoPositionPlotView.Model = myPlotModelCreator.createNewPlotModel("Servo Position", "[DEC]", 0, 65535);
            myServoPositionPlotView.Model.Series.Add(servoPositionFunctionSeries);

            mySpeedValuePlotView.Model = myPlotModelCreator.createNewPlotModel("Speed Value", "[m/s]", 0, 30);
            mySpeedValuePlotView.Model.Series.Add(speedValueFunctionSeries);
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MyAboutPage myAboutPage = new MyAboutPage();

            myViewCreator.createNewView(myAboutPage, null);
        }

        private void configuration_Click(object sender, RoutedEventArgs e)
        {
            MyConfigurationPage myConfigurationPage = new MyConfigurationPage();

            myViewCreator.createNewView(myConfigurationPage, mySimulation);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySimulation = (MySimulation)e.Parameter;

            mySimulation.PropertyChanged += RefreshData;

            base.OnNavigatedTo(e);
        }
    }
}
