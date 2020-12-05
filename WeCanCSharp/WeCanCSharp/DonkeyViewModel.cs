using DonkeyClassLib;
using System.Collections.ObjectModel;
using System.Linq;

namespace WeCanCSharp
{
    public class DonkeyViewModel
    {
        private ModelDonkeyData Donkey;
        public string TimeStamp => $"{Donkey.TimeStamp / 1000} s ";
        public string Angle => $"{Donkey.Angle * 120} degree";
        public string Throttle => $"{Donkey.Throttle * 5} m/s";
        public DonkeyViewModel(ModelDonkeyData modelDonkey)
        {
            this.Donkey = modelDonkey;
        }
    }
}