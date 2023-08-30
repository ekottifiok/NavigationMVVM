using System;
using System.Collections.ObjectModel;
using AmazingNavigation2.MVVM.Models;

namespace AmazingNavigation2.Store;

public class PeersStore
{
    private ObservableCollection<Peer> _peers { get; }

    public event EventHandler? PeerUpdated;
    public ObservableCollection<Peer>? Peers => _peers;
    public PeersStore()
    {
        _peers = new ObservableCollection<Peer>();
    }

    public void AddNewPeer(Peer value)
    {
        _peers?.Add(value);
        PeerUpdated?.Invoke(this, EventArgs.Empty);
    }
}