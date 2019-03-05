using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SO
{
    class MQTTTest
    {
        private static async Task<bool> ReceiveBin(MQTT.Broker myClient,
            CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[100]);

            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result = null;
                try
                {
                    do
                    {
                        ct.ThrowIfCancellationRequested();
                        result = await myClient.socket.ReceiveAsync(buffer, ct); //  <== Unhandled exception breaks here
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    } while (!result.EndOfMessage);
                }
                catch (Exception ex) // v1 ASP Core sometimes throw errors when client aborts session
                {
                    //CloseWSSess(myClient, "Error receiving from client - resetting session. Error: " + ex.Message);
                    return false;
                }
            }

            return true;
        }
    }
}
