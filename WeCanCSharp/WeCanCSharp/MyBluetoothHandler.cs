using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;

namespace WeCanCSharp
{
    class MyBluetoothHandler
    {
        public bool isBluetoothConnected = false;
        public const string url= "https://192.168.1.234:8887/";
        public string urlParameters = "video";

        public void connectDevice(string address="nothing")
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
          
            //string mediaType = "ContentType", "multipart/x-mixed-replace;boundary =--boundarydonotcross"
            string mediaType = "multipart/x-mixed-replace";
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("multipart/x-mixed-replace"));
            //client.DefaultRequestHeaders.Add("ContentType", "multipart/x-mixed-replace;boundary =--boundarydonotcross");
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
           
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<string>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
 

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
