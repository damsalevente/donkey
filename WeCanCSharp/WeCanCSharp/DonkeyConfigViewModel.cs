using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    public class DonkeyConfigViewModel
    {
       
        public MyCarConfiguration donkeyConfig;
        public DonkeyConfigViewModel(MyCarConfiguration donkey)
        {
            this.donkeyConfig = donkey;
        }
        public int MaxLeftSteeringPWM {
            get
            {
                return donkeyConfig.maxLeftSteeringPWM * 255 / 100;
            }
            set
            {
                donkeyConfig.maxLeftSteeringPWM = value * 100 / 255;
            }
            
            }
        public int MaxRightSteeringPWM { get; set; }
        public int MaxThrottle
        {
            get; set;
        }
    }
}
