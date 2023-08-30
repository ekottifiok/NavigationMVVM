using System;
using Ch07NavigationMVVM.ViewModels;

namespace Ch07NavigationMVVM.Stores;

public class ModalNavigationStore
{
    public event Action? CurrentViewModelChanged;
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel => _currentViewModel;

    public bool IsOpen => _currentViewModel != null;
    
    /*Methods*/
    public void Close() => SetCurrentViewModel(null);

    public void SetCurrentViewModel(ViewModelBase? value)
    {
        _currentViewModel?.Dispose();
        _currentViewModel = value;
        CurrentViewModelChanged?.Invoke();
    }
}