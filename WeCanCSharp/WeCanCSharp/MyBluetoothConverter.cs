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
            MyInputData myInputData = new MyInputData();

            /* TODO: Converting takes place here... */
            myInputData.lidarValue = 0;

            myInputData.motorVoltage = 0;

            myInputData.servoPosition = 0;

            myInputData.speedValue = 0;

            return myInputData;
        }
    }
}
