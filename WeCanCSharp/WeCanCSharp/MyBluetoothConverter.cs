using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    class MyBluetoothConverter
    {
        public MyInputData getDataFromBluetoothMessage(int bluetoothInput)
        {
            MyInputData myInputData = new MyInputData
            {
                /* TODO: Converting takes place here... */
                lidarValue = 0,

                motorVoltage = 0,

                servoPosition = 0,

                speedValue = 0
            };

            return myInputData;
        }
    }
}
