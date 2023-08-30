using System;
using Ch07NavigationMVVM.Stores;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Services;

public class ModalNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public ModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TViewModel> createViewModel)
    {
        _modalNavigationStore = modalNavigationStore;
        _createViewModel = createViewModel;
    }

    public override void Navigate() => _modalNavigationStore.SetCurrentViewModel(_createViewModel());
}