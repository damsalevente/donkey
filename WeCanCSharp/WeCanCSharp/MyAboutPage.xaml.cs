using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAboutPage : Page
    {
        public MenuCommand MenuCommand;

        public MySimulation mySimulation;

        public MyAboutPage()
        {
            MenuCommand = new MenuCommand(mySimulation);
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySimulation = (MySimulation)e.Parameter;
            MenuCommand = new MenuCommand(mySimulation);
            base.OnNavigatedTo(e);
        }
    }
}