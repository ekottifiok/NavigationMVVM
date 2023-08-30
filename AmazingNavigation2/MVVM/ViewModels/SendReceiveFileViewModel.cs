using System;
using System.Net.Sockets;
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
    public ViewModelBase UsersListing { get; set; }
    
    public SendReceiveFileViewModel(INavigationService navigationService,
        DeviceStore deviceStore, PeersStore peerStore)
    {
        Task.Run(() => Activity = new PeerActivity(deviceStore));
        Task.Run(() => UsersListing = new PeerListingViewModel(peerStore));
        if (deviceStore.Device is null || deviceStore.Device.SocketInstance is null) throw new Exception(
            "Device or the SocketInstance should not be null");
        _peerStore = peerStore;
        _device = deviceStore.Device;
        _device.SocketInstance?.Listen(10);
        listenThread = new Thread(ListenForClients);
        listenThread.Start();
    }

    private void ListenForClients()
    {
        while (true)
        {
            Socket? clientSocket = _device.SocketInstance?.Accept();
            _peerStore.AddNewPeer(new Peer());
        }
    }
}