using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    internal class HttpHandler
    {
        private static readonly Uri driveuri = new Uri("ws://192.168.1.234:8887/wsDrive");
        private static readonly Uri datauri = new Uri("http://192.168.1.234:8887/drive");
        private static HttpClient httpclient = new HttpClient();

        public async Task SendDriveDataAsync(String datatosend)
        {
            using (ClientWebSocket ws = new ClientWebSocket())
            {
                try
                {
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    byte[] array = Encoding.ASCII.GetBytes(datatosend);
                    await ws.ConnectAsync(driveuri, CancellationToken.None);
                    await ws.SendAsync(array, 0, true, token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error - {ex.Message}");
                }
            }
        }

        public async Task<string> ReceiveDataAsync()
        {
            try
            {
                using (var response = await httpclient.GetAsync(datauri))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}