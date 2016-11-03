using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClienteODIN.NET
{
    public class HandlerConnetionAsync
    {
        private Socket HandlerAsync;
        private IPEndPoint Address;
        private bool Cicles = false;

        public void HandlerEvents(string ispX)
        {
            HandlerAsync = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string texto;
            byte[] textoEnviar;
            byte[] ByRec = ByRec = new byte[255];
            try
            {
                Address = new IPEndPoint(IPAddress.Parse(ispX), 80);
                HandlerAsync.Connect(Address);
                Console.WriteLine("Connection Ready -> ODIN READY!");

                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();

                    }
                }
                texto = localIP;

                textoEnviar = Encoding.Default.GetBytes(texto); //pasamos el texto a array de bytes
                HandlerAsync.Send(textoEnviar, 0, textoEnviar.Length, 0); // y lo enviamos

                Cicles = true;
                while (Cicles)
                {
                    int a = HandlerAsync.Receive(ByRec, 0, ByRec.Length, 0);
                    Array.Resize(ref ByRec, a);
                    Console.WriteLine("Dice: " + Encoding.Default.GetString(ByRec));
                    Handler events = new Handler();
                    events.MainCMD(Convert.ToString(Encoding.Default.GetString(ByRec)));

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("ERROR -> {0}", e.ToString());
            }
        }
    }
}
