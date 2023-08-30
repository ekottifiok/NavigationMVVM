using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace AmazingNavigation2.MVVM.Models;

public class Device
{
    public IPAddress? IpAddress { get; set; }
    public string? DeviceName { get; set; }
    public Socket? SocketInstance { get; set; }
    public bool IsServer { get; set; }
    public int Port { get; set; }
    public IPAddress? ServerAddress { get; set; }
    public Dictionary<string, string>? AdditionalInfo { get; set; }
}