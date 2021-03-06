using MjpegProcessor;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.ComponentModel;
using System.IO;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /* FunctionSeries for data storage. */
        private readonly FunctionSeries lidarSensorFunctionSeries = new FunctionSeries();
        private readonly FunctionSeries motorVoltageFunctionSeries = new FunctionSeries();
        private readonly FunctionSeries servoPositionFunctionSeries = new FunctionSeries();
        private readonly FunctionSeries speedValueFunctionSeries = new FunctionSeries();
        /* try to connect to wifi */
        private readonly HttpHandler myHttpHandler = new HttpHandler();
        private readonly HttpConverter httpConverter = new HttpConverter();
        /* Stream */
        private MjpegDecoder _mjpeg;
        /* The data model */
        private MySimulation mySimulation;

        public MenuCommand MenuCommand;

        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        private readonly MyPlotModelCreator myPlotModelCreator = new MyPlotModelCreator();

        private DonkeyControl donkeyControl = new DonkeyControl();

        public MainPage()
        {
            this.InitializeComponent();

            setMyPlotModels();
            _mjpeg = new MjpegDecoder();
            donkeyControl.Angle = 200;
            this.DataContext = donkeyControl;
        }

        public void RefreshData(object sg, PropertyChangedEventArgs name)
        {
            /* recieve new data */

            /* Add the newly received points. */
            lidarSensorFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.Throttle));
            motorVoltageFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.Voltage));
            servoPositionFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.Angle));
            speedValueFunctionSeries.Points.Add(new DataPoint(mySimulation.MyTime, mySimulation.myCar.myInputData.Speed));

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
            myLidarValuePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Throttle", "%", -10, 10);
            myLidarValuePlotView.Model.Series.Add(lidarSensorFunctionSeries);

            myMotorVoltagePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Motor Voltage", "[V]", 0, 10);
            myMotorVoltagePlotView.Model.Series.Add(motorVoltageFunctionSeries);

            myServoPositionPlotView.Model = myPlotModelCreator.CreateNewPlotModel("Servo Position", "%", -10, 10);
            myServoPositionPlotView.Model.Series.Add(servoPositionFunctionSeries);

            mySpeedValuePlotView.Model = myPlotModelCreator.CreateNewPlotModel("Speed Value", "[m/s]", -10, 10);
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
            this.DataContext = mySimulation.myCar.myInputData;
            MenuCommand = new MenuCommand(mySimulation);
            base.OnNavigatedTo(e);
        }

        private void mjpeg_Error(object sender, MjpegProcessor.ErrorEventArgs e)
        {
            string msg = e.Message;
            _mjpeg.StopStream();
        }

        private async void Mjpeg_FrameReadyAsync(object sender, FrameReadyEventArgs e)
        {
            using (var ms = new MemoryStream(e.FrameBuffer))
            {
                var bmp = new BitmapImage();
                await bmp.SetSourceAsync(ms.AsRandomAccessStream());
                
                img.Source = bmp;
            }
        }

        /*Send steer and throttle values*/

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DonkeyControl dk = new DonkeyControl(Steering.Value, Throttle.Value);
            dk.Voltage = mySimulation.myCar.myInputData.Voltage; // for confirmation
            dk.Speed = mySimulation.myCar.myInputData.Speed;
            dk.Angle = Steering.Value;
            dk.Throttle = Throttle.Value;
            string msg = httpConverter.ConvertDataToDonkeyCarMessage(dk);
            await myHttpHandler.SendDriveDataAsync(msg);
        }

        /* Start Video Stream */

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mjpeg.FrameReady += Mjpeg_FrameReadyAsync;
            _mjpeg.Error += mjpeg_Error;
            _mjpeg.ParseStream(new Uri("http://192.168.1.234:8887/video"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HistoricData myConfigurationPage = new HistoricData();

            myViewCreator.CreateNewView(myConfigurationPage, mySimulation);
        }
    }
}