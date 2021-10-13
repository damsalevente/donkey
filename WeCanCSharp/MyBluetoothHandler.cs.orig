using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;

namespace WeCanCSharp
{
    class MyBluetoothHandler
    {
        public bool isBluetoothConnected = false;
        public const string url= "https://192.168.1.234:8887/";
        public string urlParameters = "video";

<<<<<<< HEAD
        public void ConnectDevice(string address)
        { 
            
        }
=======
        public async Task connectDeviceAsync(double throttle, double steering, string address = "https://192.168.1.234:8887/")
        {

            using (ClientWebSocket ws = new ClientWebSocket())
            {

                try
                {
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    
                    String datatosend = JsonConvert.SerializeObject(new DonkeyControl(steering,throttle));
                    byte[] array = Encoding.ASCII.GetBytes(datatosend);
                    await ws.ConnectAsync(new Uri("ws://192.168.1.234:8887/wsDrive"), CancellationToken.None);
                    await ws.SendAsync(array, 0, true, token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error - {ex.Message}");
                }
            } 
    }   
>>>>>>> donkeycar_connection

        public void RequestData()
        {
            /* TODO: Send request data */
        }

        public int ReceiveData()
        {
            /* TODO: Receive the raw data - Read out from the buffer, and return. Return value is not specified yet. */
            return 0;
        }
    }
}
