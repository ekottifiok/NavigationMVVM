using System.Net;
using System.Net.Sockets;

namespace AmazingNavigation2.MVVM.Models;

public class Peer
{
    public string? DeviceName { get; set; }
    public string? IpAddress { get; set; }
    public Socket? PeerSocket { get; set; }
}