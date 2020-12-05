using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Media.Animation;

namespace WeCanCSharp
{
    public class MenuCommand : BaseCommand
    {
        MySimulation mySimulation;
        private Frame frame;
        
        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        public MenuCommand() {}
        public MenuCommand(MySimulation ms)
        {
            this.mySimulation = ms;
            frame = Window.Current.Content as Frame;
        }
        public override void Execute(object parameter)
        {
            string In = parameter as String;

            if (Equals(In, "Menu"))
            {
                MyConfigurationPage myConfigurationPage = new MyConfigurationPage();
                myViewCreator.CreateNewView(myConfigurationPage, mySimulation);
            }
            if (Equals(In, "Configuration"))
            {
                frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MyConfigurationPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
            }
            if (Equals(In, "About"))
            {
                frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MyAboutPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            }
            if (Equals(In, "Exit"))
            {
                CoreApplication.Exit();
            }
            //throw new NotImplementedException();
        }
    }
}
