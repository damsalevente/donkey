using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeCanCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoricData : Page
    {
        public DonkeyViewModel DonkeyView = new DonkeyViewModel();

        public HistoricData()
        {
            this.InitializeComponent();
            historicaldatalist.ItemsSource = DonkeyView.HistoricalData;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /* read the database
             * no update, only the previous runs
             */
        }
    }
}