using System.Collections.ObjectModel;
using System.Linq;

namespace WeCanCSharp
{
    public class DonkeyViewModel
    {
        public ObservableCollection<DonkeyClassLib.ModelDonkeyData> HistoricalData;
        private DonkeyClassLib.ModelDonkeyData currentDonkey;

        public DonkeyViewModel()
        {
            LoadDonkeys();
        }

        private void LoadDonkeys()
        {
            ObservableCollection<DonkeyClassLib.ModelDonkeyData> historicalData = new ObservableCollection<DonkeyClassLib.ModelDonkeyData>();
            using (var db = new DonkeyClassLib.DonkeyContext())
            {
                db.Donkeys.ToList().ForEach(historicalData.Add);
            }
            HistoricalData = historicalData;
        }
    }
}