using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeCanCSharp
{
    /* this should be the model */
    public class DonkeyControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [JsonProperty("angle")]
        public double Angle { get; set; }
        [JsonProperty("throttle")]
        public double Throttle { get; set; }
        [JsonProperty("recording")]
        public bool Recording { get; set; }
        [JsonProperty("drive_mode")]
        public String Drive_mode { get; set; }

        public DonkeyControl()
        {
            Angle = 0;
            Throttle = 0;
            Recording = false;
            Drive_mode = "user";
        }
        public DonkeyControl(double _angle, double _throttle)
        {
            this.Angle = _angle; //scale from slider input to angle output
            this.Throttle = _throttle; // scale from slider input to angle output (-10,10)->(-1,1)
            this.Recording = false;
            this.Drive_mode = "user";
        }
        public void OnPropertyChanging([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
