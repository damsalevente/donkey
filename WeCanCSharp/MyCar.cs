using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    public class MyCar
    {
        public MyCarConfiguration myCarConfiguration;

        public DonkeyControl myInputData = new DonkeyControl();

        public MyCar(MyCarConfiguration myCarConfiguration)
        {
            this.myCarConfiguration = myCarConfiguration;
        }

        public MyCarConfiguration GetMyCarConfiguration()
        {
            return myCarConfiguration;
        }

        public void SetMyCarConfiguration(MyCarConfiguration myCarConfiguration)
        {
            this.myCarConfiguration = myCarConfiguration;
        }
    }

    public class MyCarConfiguration
    {
        public int maxThrottle;
        public int maxLeftSteeringPWM;
        public int maxRightSteeringPWM;
    }
}
