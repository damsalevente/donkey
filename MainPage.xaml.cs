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
        readonly FunctionSeries lidarSensorFunctionSeries = new FunctionSeries();
        readonly FunctionSeries motorVoltageFunctionSeries = new FunctionSeries();
        readonly FunctionSeries servoPositionFunctionSeries = new FunctionSeries();
        readonly FunctionSeries speedValueFunctionSeries = new FunctionSeries();

        /* The data model */
        MySimulation mySimulation;

        public MenuCommand MenuCommand;

        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        private readonly MyPlotModelCreator myPlotModelCreator = new MyPlotModelCreator();

        public MainPage()
        {
            MenuCommand = new MenuCommand(mySimulation);
            this.InitializeComponent();

            setMyPlotModels();
        }

        public void RefreshData(object sg, PropertyChangedEventArgs name)
        {
            /* Add the newly received points. */
            lidarSensorFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.LidarValue));
            motorVoltageFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.MotorVoltage));
            servoPositionFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.ServoPosition));
            speedValueFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.SpeedValue));

            refreshPlot();
        }

        private void refreshPlot()
        {
            /* Refresh the plot */
            myLidarValuePlotView.InvalidatePlot(true);
            myMotorVoltagePlotView.InvalidatePlot(true);
            myServoPositionPlotView.InvalidatePlot(true);
            mySpeedValuePlotView.InvalidatePlot(true);
        }

        private void setMyPlotModels()
        {
            myLidarValuePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Lidar Value", "[DEC]", 0, 1000);
            myLidarValuePlotView.Model.Series.Add(lidarSensorFunctionSeries);

            myMotorVoltagePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Motor Voltage", "[V]", 0, 6);
            myMotorVoltagePlotView.Model.Series.Add(motorVoltageFunctionSeries);

            myServoPositionPlotView.Model = myPlotModelCreator.CreateNewPlotModel("Servo Position", "[DEC]", 0, 65535);
            myServoPositionPlotView.Model.Series.Add(servoPositionFunctionSeries);

            mySpeedValuePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Speed Value", "[m/s]", 0, 30);
            mySpeedValuePlotView.Model.Series.Add(speedValueFunctionSeries);
        }

        private void aboutClick(object sender, RoutedEventArgs e)
        {
            MyAboutPage myAboutPage = new MyAboutPage();

            myViewCreator.CreateNewView(myAboutPage, null);
        }

        private void configurationClick(object sender, RoutedEventArgs e)
        {
            MyConfigurationPage myConfigurationPage = new MyConfigurationPage();

            myViewCreator.CreateNewView(myConfigurationPage, mySimulation);
        }

        private void exitClick(object sender, RoutedEventArgs e)
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
