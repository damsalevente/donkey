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
        public MyCarConfiguration myCarConfiguration = new MyCarConfiguration();
        /* Input data */
        public MyInputData myInputData = new MyInputData();
        
        public MyCar(int maxThrottle, int maxLeftSteeringPWM, int maxRightSteeringPWM)
        {
            this.myCarConfiguration.maxThrottle = maxThrottle;
            this.myCarConfiguration.maxLeftSteeringPWM = maxLeftSteeringPWM;
            this.myCarConfiguration.maxRightSteeringPWM = maxRightSteeringPWM;
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
