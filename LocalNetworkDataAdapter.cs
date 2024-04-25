using System;
using System.Collections.Generic;
using System.Text;

namespace LNDa
{
    internal class LocalNetworkDataAdapter
    {
        public delegate void DataRecived(string data);

        public static void SendData(string ip, string data)
        {
            throw new NotImplementedException();
        }

        public static void StartPolling(DataRecived dataRecived)
        {
            throw new NotImplementedException();

        }
    }
}
