using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;

namespace WeCanCSharp
{
    class MyBluetoothHandler
    {
        public bool isBluetoothConnected = false;

        public void connectDevice(string address)
        { 
            
        }

        public void requestData()
        {
            /* TODO: Send request data */
        }

        public int receiveData()
        {
            /* TODO: Receive the raw data - Read out from the buffer, and return. Return value is not specified yet. */
            return 0;
        }
    }
}
