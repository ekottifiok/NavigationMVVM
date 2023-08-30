using Ch04NavigationMVVM.Stores;

namespace Ch04NavigationMVVM.ViewModels;

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