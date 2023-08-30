using Ch09NavigationMVVM.Stores;

namespace Ch09NavigationMVVM.Services;

public class CloseModalNavigationService : INavigationService
{
    private readonly ModalNavigationStore _modalNavigationStore;

    public CloseModalNavigationService(ModalNavigationStore modalNavigationStore)
    {
        _modalNavigationStore = modalNavigationStore;
    }

    public override void Navigate() => _modalNavigationStore.Close();
}