using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace WeCanCSharp
{
    public class MenuCommand : BaseCommand
    {
        private MySimulation mySimulation;
        private Frame frame;
        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        private WindowCreator menuNavigator = new MenuWindowCreator();
        private WindowCreator aboutNavigator = new AboutWindowCreator();
        private WindowCreator exitNavigator = new ExitWindowCreator();
        private WindowCreator confNavigator = new ConfWindowCreator();

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
                menuNavigator.Run(mySimulation);
            }
            else if (Equals(In, "Configuration"))
            {
                confNavigator.Run(mySimulation);
            }
            else if (Equals(In, "About"))
            {
                aboutNavigator.Run(mySimulation);
            }
            else if (Equals(In, "Exit"))
            {
                exitNavigator.Run(mySimulation);
            }
        }
    }

    /* Abstract template class */

    public abstract class WindowCreator
    {
        public abstract void FetchInput(MySimulation mySimulation);

        public abstract void BuildNextPage();

        public abstract void HandleNavigation();

        /* The template method */

        public void Run(MySimulation mySimulation)
        {
            FetchInput(mySimulation);
            BuildNextPage();
            HandleNavigation();
        }
    }

    public class MenuWindowCreator : WindowCreator
    {
        private MySimulation menuSimulation;
        private MyViewCreator menuViewCreator = new MyViewCreator();
        private MyConfigurationPage menuConfigurationPage;

        public override void FetchInput(MySimulation mySimulation)
        {
            this.menuSimulation = mySimulation;
        }

        public override void BuildNextPage()
        {
            menuConfigurationPage = new MyConfigurationPage();
        }

        public override void HandleNavigation()
        {
            menuViewCreator.CreateNewView(menuConfigurationPage, menuSimulation);
        }
    }

    public class ConfWindowCreator : WindowCreator
    {
        private Frame ConfFrame;
        private MySimulation ConfSimulation;

        public override void FetchInput(MySimulation mySimulation)
        {
            this.ConfSimulation = mySimulation;
        }

        public override void BuildNextPage()
        {
            ConfFrame = Window.Current.Content as Frame;
        }

        public override void HandleNavigation()
        {
            ConfFrame.Navigate(typeof(MyConfigurationPage), ConfSimulation, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }
    }

    public class AboutWindowCreator : WindowCreator
    {
        private Frame AboutFrame;
        private MySimulation AboutSimulation;

        public override void FetchInput(MySimulation mySimulation)
        {
            this.AboutSimulation = mySimulation;
        }

        public override void BuildNextPage()
        {
            AboutFrame = Window.Current.Content as Frame;
        }

        public override void HandleNavigation()
        {
            AboutFrame.Navigate(typeof(MyAboutPage), AboutSimulation, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }
    }

    public class ExitWindowCreator : WindowCreator
    {
        public override void FetchInput(MySimulation mySimulation)
        {
            /* no data fetch needed */
        }

        public override void BuildNextPage()
        {
            /* no next page in exit */
        }

        public override void HandleNavigation()
        {
            CoreApplication.Exit();
        }
    }
}