using System.Net;
using System.Net.Sockets;
using AmazingNavigation2.Core;
using AmazingNavigation2.MVVM.Models;

namespace AmazingNavigation2.Store;

public class DeviceStore
{
    public DeviceStore()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        Device = new Device()
        {
            IpAddress = host.AddressList[1], 
             SocketInstance= new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp)
        };
    }

    public Device Device { get; }
}