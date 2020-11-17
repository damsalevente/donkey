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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MyCar myCar;

        MyViewCreator myViewCreator = new MyViewCreator();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MyAboutPage myAboutPage = new MyAboutPage();

            myViewCreator.createNewView(myAboutPage, myCar);
        }

        private void configuration_Click(object sender, RoutedEventArgs e)
        {
            MyConfigurationPage myConfigurationPage = new MyConfigurationPage();


            myViewCreator.createNewView(myConfigurationPage, myCar);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.myCar = (MyCar)e.Parameter;

            base.OnNavigatedTo(e);
        }
    }
}
