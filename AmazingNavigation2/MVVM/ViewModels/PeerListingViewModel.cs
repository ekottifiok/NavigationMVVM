using System.Collections.Generic;
using AmazingNavigation2.MVVM.Models;
using AmazingNavigation2.Store;

namespace AmazingNavigation2.MVVM.ViewModels;

public class PeerListingViewModel : ViewModelBase
{
    private readonly PeersStore _peerStore;
    public IEnumerable<Peer>? PeersList => _peerStore.Peers;

    public PeerListingViewModel(PeersStore peersStore)
    {
        _peerStore = peersStore;
    }
}