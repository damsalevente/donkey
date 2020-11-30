using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace WeCanCSharp
{
    class MyViewCreator
    {
        /* This function creates a new standalone view. 
         * input - decides which page derived class will be created.
         * param - an object which can be sent to the created page as parameter. */
        public async void CreateNewView(Page input, object param)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            
            int newViewId = 0;
            
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { newViewId = frameHandler(input, param); });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        /* This function creates a new frame, and adds it to the application window. 
         * Then the window will be activated, and the view id will be returned. */
        private int frameHandler(Page input, object param)
        {
            Frame frame = new Frame();

            frame.Navigate(input.GetType(), param);

            Window.Current.Content = frame;

            Window.Current.Activate();

            return ApplicationView.GetForCurrentView().Id;
        }
    }
}
