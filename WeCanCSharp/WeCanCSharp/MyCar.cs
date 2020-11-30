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

        public MyInputData myInputData = new MyInputData();

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

    public class MyInputData
    {
        public int MotorVoltage { set; get; }
        public int ServoPosition { set; get; }
        public int LidarValue { set; get; }
        public int SpeedValue { set; get; }
    }
}
