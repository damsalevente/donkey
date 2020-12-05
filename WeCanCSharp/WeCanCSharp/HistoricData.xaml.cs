using System.Collections.ObjectModel;
using System.Linq;
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
        public DonkeyClassLib.DonkeyContext DonkeyModel = new DonkeyClassLib.DonkeyContext();

        public HistoricData()
        {
            this.InitializeComponent();
            historicaldatalist.ItemsSource = LoadDonkeysFromDataBase().Select(donkey => new DonkeyViewModel(donkey));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /* read the database
             * no update, only the previous runs
             */
        }
        private System.Collections.Generic.List<DonkeyClassLib.ModelDonkeyData> LoadDonkeysFromDataBase()
        {
            using (var db = new DonkeyClassLib.DonkeyContext())
            {
                return db.Donkeys.ToList();
            }
        }
    }
}