using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WeCanCSharp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /* The simulation */
        MySimulation mySimulation;
      
        /* TODO: I think this will be refactored. */
        HttpHandler myHttpHandler = new HttpHandler();
        /* TODO: I think this will be refactored. */
        HttpConverter myHttpConverter = new HttpConverter();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /* This function is an infinite loop which runs with refreshRate ms */
        private async void cyclicRefreshData(int refreshRate)
        {
            while (true)
            {


                string msg = await myHttpHandler.ReceiveDataAsync();

                mySimulation.myCar.myInputData = myHttpConverter.ConvertDataFromDonkeyCarMessage(msg);
               
                mySimulation.MyTime += (UInt64)mySimulation.RefreshRate;

                await Task.Delay(refreshRate);
            }
        }

        async private void createWarning(string input)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Warning",
                Content = input,
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                /* Get the configuration from .xml */
                MyConfiguration myConfiguration = new MySerializer().Deserialize(Config.filepath);

                /* Check if the configuration exsists, if not, create default settings */
                if (myConfiguration == null)
                {
                    /* Create the Data model with default values. */
                    this.mySimulation = new MySimulation(new MyCar(new MyCarConfiguration()), Config.defaultRefreshRate);

                    /* Throw a warning. */
                    createWarning("The configuration is not loaded.\nCheck '" + Config.filepath + "'!");
                }
                else
                {
                    this.mySimulation = new MySimulation(new MyCar(myConfiguration.myCarConfiguration), myConfiguration.refreshRate);
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    /* Passing myCar object to mainpage */
                    rootFrame.Navigate(typeof(MainPage), mySimulation);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
            /* database management */
            using(var db = new DonkeyClassLib.DonkeyContext())
            {
                db.Database.Migrate();
            }
            /* Start the cyclic refresh */
            cyclicRefreshData(mySimulation.RefreshRate);
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
