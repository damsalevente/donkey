using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    class DonkeyControl
    {
        [JsonProperty("angle")]
        public double Angle { get; set; }
        [JsonProperty("throttle")]
        public double Throttle { get; set; }
        [JsonProperty("recording")]
        public bool Recording { get; set; }
        [JsonProperty("drive_mode")]
        public String Drive_mode { get; set; }
        public DonkeyControl(double _angle, double _throttle)
        {
            this.Angle = _angle;
            this.Throttle = _throttle;
            this.Recording = false;
            this.Drive_mode = "user";
        }
        
    }
}
