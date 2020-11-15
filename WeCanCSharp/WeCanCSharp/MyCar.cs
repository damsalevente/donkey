using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    class MyCar
    {
        /* MyCar configuration */
        private MyCarConfiguration myCarConfiguration = new MyCarConfiguration();

        /* Input data */
        public MyInputData myInputData = new MyInputData();
        
        public MyCar(int maxThrottle, int maxLeftSteeringPWM, int maxRightSteeringPWM)
        {
            this.myCarConfiguration.maxThrottle = maxThrottle;
            this.myCarConfiguration.maxLeftSteeringPWM = maxLeftSteeringPWM;
            this.myCarConfiguration.maxRightSteeringPWM = maxRightSteeringPWM;
        }
    }

    class MyCarConfiguration
    {
        public int maxThrottle;
        public int maxLeftSteeringPWM;
        public int maxRightSteeringPWM;
    }

    class MyInputData
    {
        public int motorVoltage { set; get; }
        public int servoPosition { set; get; }
        public int lidarValue { set; get; }
        public int speedValue { set; get; }
    }
}
