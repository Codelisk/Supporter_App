using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Supporter_Uno.ApiClient.Helpers
{
    public class AzureServiceChecker
    {
        public static async Task<bool> CheckServiceAvailability(string serviceUrl)
        {
            bool serviceAvailable = false;
            int retryCount = 0;
            int maxRetries = 10; // Maximaler Versuchszähler
            int delayMilliseconds = 5000; // 5 Sekunden warten zwischen den Versuchen

            Uri uri = new Uri(serviceUrl);
            string host = uri.Host; // Der Hostname des Service-URLs, z.B. "example.com"

            while (!serviceAvailable && retryCount < maxRetries)
            {
                try
                {
                    // Ping an den Server senden
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = await ping.SendPingAsync(host);

                        if (reply.Status == IPStatus.Success)
                        {
                            serviceAvailable = true;
                        }
                        else
                        {
                            throw new Exception($"Ping fehlgeschlagen: {reply.Status}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    retryCount++;
                    Console.WriteLine($"Versuch {retryCount} fehlgeschlagen: {ex.Message}");

                    // Warte eine bestimmte Zeit, bevor ein erneuter Versuch gestartet wird
                    await Task.Delay(delayMilliseconds);
                }
            }

            return serviceAvailable;
        }
    }
}
