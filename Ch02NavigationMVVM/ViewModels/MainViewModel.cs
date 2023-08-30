using Ch02NavigationMVVM.Stores;

namespace Ch02NavigationMVVM.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += (() => OnPropertyChanged(nameof(CurrentViewModel)));
    }

}