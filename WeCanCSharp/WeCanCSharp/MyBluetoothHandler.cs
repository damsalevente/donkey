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

        public async Task connectDeviceAsync(string address="nothing")
        {

            using (ClientWebSocket ws = new ClientWebSocket())
            {

                try
                {
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    String datatosend = "{\"throttle\":40, \"angle\":40, \"throttle\":40, \"throttle\":40, \"throttle\":40, \"recording\":\"false\", \"drive_mode\":\"user\" }";
                    byte[] array = Encoding.ASCII.GetBytes(datatosend);
                    await ws.ConnectAsync(new Uri("ws://192.168.1.234:8887/wsDrive"), CancellationToken.None);
                    await ws.SendAsync(array, 0, true, token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error - {ex.Message}");
                }
            }
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();
 

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
