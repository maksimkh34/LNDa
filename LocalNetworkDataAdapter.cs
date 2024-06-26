﻿using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace LNDa
{
    internal class LocalNetworkDataAdapter
    {
        const int DEFAULT_PORT = 13000;

        public delegate void DataRecived(string data);

        public static void SendData(string ip, string data, int port=DEFAULT_PORT)  // ArgumentNull SocketException
        {
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            NetworkStream stream = client.GetStream();
            stream.Write(Encoding.Default.GetBytes(data), 0, data.Length);
            stream.Close();
            client.Close();
        }

        public static void StartPolling(DataRecived dataRecived)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse(GetLocalIP()), DEFAULT_PORT);
                server.Start();

                byte[] bytes = new byte[1048576];
                string data = null;

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    data = null;
                    NetworkStream stream = client.GetStream();

                    int n;
                    while ((n = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data += Encoding.Default.GetString(bytes, 0, n);
                    }
                    Console.Write(data);
                    dataRecived(data);
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            server.Stop();
        }

        public static string GetLocalIP()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation gateway in ni.GetIPProperties().GatewayAddresses)
                    {
                        if (gateway.Address.ToString().Split('.')[0] == "192")
                        {
                            return GetIPv4ByGate(gateway.Address.ToString());
                        }
                    }
                }
            }
            throw new Exception("Local NI 192.*.*.* not found. ");
        }

        static string GetIPv4ByGate(string gate)
        {
            var HostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach(var ip in HostEntry.AddressList) 
            {
                try
                {
                    if (ip.ToString().Split('.')[1] == "168" && ip.ToString().Split('.')[2] == gate.Split('.')[2])
                        return ip.ToString();
                }
                catch (IndexOutOfRangeException) { }
            }
            throw new NetworkInitError("IPv4 by gate not found");
        }

        public class NetworkInitError : Exception
        {
            public NetworkInitError()
            {
            }

            public NetworkInitError(string message)
                : base(message)
            {
            }

            public NetworkInitError(string message, Exception inner)
                : base(message, inner)
            {

            }

        }
    }
}
