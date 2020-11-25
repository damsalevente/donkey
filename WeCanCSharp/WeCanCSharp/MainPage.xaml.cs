﻿using System;
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
using MjpegProcessor;
using System.Drawing;
using Xamarin.Forms.Platform.UWP;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

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
        /* try to connect to wifi */
        readonly MyBluetoothHandler myBluetoothHandler = new MyBluetoothHandler();

        /* Stream */
        MjpegDecoder _mjpeg;
        /* The data model */
        MySimulation mySimulation;
       
        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        private readonly MyPlotModelCreator myPlotModelCreator = new MyPlotModelCreator();

        public MainPage()
        {
            this.InitializeComponent();

            setMyPlotModels();
            _mjpeg = new MjpegDecoder();

            _mjpeg.FrameReady += mjpeg_FrameReadyAsync;
          
        }

        public void RefreshData(object sg, PropertyChangedEventArgs name)
        {
            /* recieve new data */
         
            /* Add the newly received points. */
            lidarSensorFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.lidarValue));
            motorVoltageFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.motorVoltage));
            servoPositionFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.servoPosition));
            speedValueFunctionSeries.Points.Add(new DataPoint(mySimulation.myTime, mySimulation.myCar.myInputData.speedValue));

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
            _mjpeg.ParseStream(new Uri("http://192.168.1.234:8887/video"));
            base.OnNavigatedTo(e);
        }

        private async void mjpeg_FrameReadyAsync(object sender, FrameReadyEventArgs e)
        {

            using (var ms = new MemoryStream(e.FrameBuffer))
            {

                var bmp = new BitmapImage();
                await bmp.SetSourceAsync(ms.AsRandomAccessStream());
                
                //image is the Image control in XAML
                img.Source = bmp;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myBluetoothHandler.connectDeviceAsync();
        }
    }
}
