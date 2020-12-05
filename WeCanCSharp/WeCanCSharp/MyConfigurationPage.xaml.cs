using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        public MenuCommand MenuCommand;

        //Frame frame;
        public MyConfigurationPage()
        {
            MenuCommand = new MenuCommand(mySimulation);
            this.InitializeComponent();
        }

        private void TextBoxOnBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            /* Check if the entered value is number. */
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MySerializer mySerializer = new MySerializer();

            /* Create the myConfiguration object, which will be serialized */
            MyConfiguration myConfiguration = new MyConfiguration();
            myConfiguration.myCarConfiguration = mySimulation.myCar.myCarConfiguration;
            myConfiguration.refreshRate = mySimulation.RefreshRate;

            mySerializer.Serialize(myConfiguration, Config.filepath);

            mySerializer.Deserialize(Config.filepath);
        }

        /* Get mySimulation data model. */

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySimulation = (MySimulation)e.Parameter;

            base.OnNavigatedTo(e);
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}