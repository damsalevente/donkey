using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    public class MyCar
    {
        /* MyCar configuration */
        public MyCarConfiguration myCarConfiguration;
        /* Input data */
        public MyInputData myInputData = new MyInputData();
        
        public MyCar(MyCarConfiguration myCarConfiguration)
        {
            this.myCarConfiguration = myCarConfiguration;
        }

        public MyCarConfiguration getMyCarConfiguration()
        {
            return myCarConfiguration;
        }

        public void setMyCarConfiguration(MyCarConfiguration myCarConfiguration)
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

    public class MyInputData
    {
        public int motorVoltage { set; get; }
        public int servoPosition { set; get; }
        public int lidarValue { set; get; }
        public int speedValue { set; get; }
    }
}
