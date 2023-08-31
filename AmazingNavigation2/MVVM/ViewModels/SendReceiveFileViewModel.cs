using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AmazingNavigation2.MVVM.Models;
using AmazingNavigation2.Services;
using AmazingNavigation2.Store;

namespace AmazingNavigation2.MVVM.ViewModels;

public class SendReceiveFileViewModel : ViewModelBase
{
    private readonly Device _device;
    private readonly Thread listenThread;
    private readonly PeersStore _peerStore;
    public ViewModelBase Activity { get; set; }
    public IEnumerable<Peer>? PeersList => _peerStore.Peers;
    public ViewModelBase UsersListing { get; set; }
    
    public SendReceiveFileViewModel(INavigationService navigationService,
        DeviceStore deviceStore, PeersStore peerStore)
    {
        /*Task.Run(() => Activity = new PeerActivity(deviceStore));
        Task.Run(() => UsersListing = new PeerListingViewModel(peerStore));*/
        if (deviceStore.Device is null || deviceStore.Device.SocketInstance is null) throw new Exception(
            "Device or the SocketInstance should not be null");
        _peerStore = peerStore;
        _peerStore.PeerUpdated += (_, _) => OnPropertyChanged(nameof(PeersList));
        _device = deviceStore.Device;
        if (!_device.IsServer)
        {
            _device.SocketInstance.Send(Encoding.ASCII.GetBytes(_device.DeviceName ?? "Client"));
            return;
        };
        _device.SocketInstance?.Listen(10);
        listenThread = new Thread(ListenForClients);
        listenThread.Start();
    }

    private void ListenForClients()
    {
        while (true)
        {
             var clientSocket = _device.SocketInstance?.Accept();
             if (clientSocket is null) continue;
             IPEndPoint? endPoint = clientSocket.RemoteEndPoint as IPEndPoint;
             IPAddress? ipAddress = endPoint?.Address as IPAddress;
             Peer newPeer = new Peer() { PeerSocket = clientSocket, IpAddress = ipAddress?.ToString() };
             byte[] bytes = new byte[1024];
             int bytesRead = clientSocket.Receive(bytes);
             newPeer.DeviceName = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            _peerStore.AddNewPeer(newPeer);
        }
    }
}