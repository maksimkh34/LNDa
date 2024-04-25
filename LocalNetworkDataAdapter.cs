using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LNDa
{
    internal class LocalNetworkDataAdapter
    {
        public delegate void DataRecived(string data);

        public static void SendData(string ip, string data)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, 13000);
                NetworkStream stream = client.GetStream();
                stream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
    }

        public static void StartPolling(DataRecived dataRecived)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
                server.Start();

                Byte[] bytes = new Byte[256];
                String data = null;

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int n;
                    while ((n = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data += System.Text.Encoding.ASCII.GetString(bytes, 0, n);
                    }
                    Console.Write(data);
                    //DataRecived(data);
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            server.Stop();
        }
    }
}
