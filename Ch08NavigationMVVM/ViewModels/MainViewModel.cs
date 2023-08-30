using Ch08NavigationMVVM.Stores;

namespace Ch08NavigationMVVM.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly ModalNavigationStore _modalNavigationStore;
    public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;
    public ViewModelBase? CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
    public bool IsModalOpen => _modalNavigationStore.IsOpen;
    public MainViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += () => OnPropertyChanged(nameof(CurrentViewModel));
        _modalNavigationStore = modalNavigationStore;
        _modalNavigationStore.CurrentViewModelChanged += () =>
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        };
    }

}