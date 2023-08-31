using System.Net;
using System.Net.Sockets;
using AmazingNavigation2.Core;
using AmazingNavigation2.MVVM.Models;

namespace AmazingNavigation2.Store;

public class DeviceStore
{
    public DeviceStore()
    {
        Device = new Device()
        {
            SocketInstance= new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp)
        };
    }

    public Device Device { get; }
}