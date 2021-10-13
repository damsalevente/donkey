using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    class MyBluetoothConverter
    {
        public MyInputData GetDataFromBluetoothMessage(int bluetoothInput)
        {
            MyInputData myInputData = new MyInputData
            {
                /* TODO: Converting takes place here... */
                LidarValue = 0,
                MotorVoltage = 0,
                ServoPosition = 0,
                SpeedValue = 0
            };

            return myInputData;
        }
    }
}
