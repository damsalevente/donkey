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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyConfigurationPage : Page
    {
        public MySimulation mySimulation;

        public MyConfigurationPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_OnBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            /* Check if the entered value is number. */
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySerializer mySerializer = new MySerializer();

            /* Create the myConfiguration object, which will be serialized */
            MyConfiguration myConfiguration = new MyConfiguration();
            myConfiguration.myCarConfiguration = mySimulation.myCar.myCarConfiguration;
            myConfiguration.refreshRate = mySimulation.refreshRate;

            mySerializer.mySerializerRoutine(myConfiguration, Config.filepath);

            mySerializer.myDeserializerRoutine(Config.filepath);
        }

        /* Get mySimulation data model. */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySimulation = (MySimulation)e.Parameter;

            base.OnNavigatedTo(e);
        }
    }
}
