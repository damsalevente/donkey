using Newtonsoft.Json;
using System;

namespace WeCanCSharp
{
    /* this should be the model */

    public class DonkeyControl
    {
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
    }
}