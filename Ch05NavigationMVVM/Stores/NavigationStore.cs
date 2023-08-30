using System;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Stores;

public class NavigationStore
{
    public event Action? CurrentViewModelChanged;
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set => SetCurrentViewModel(value);
    }

    public void SetCurrentViewModel(ViewModelBase? value)
    {
        if (value is null) return;
        _currentViewModel?.Dispose();
        _currentViewModel = value;
        CurrentViewModelChanged?.Invoke();
    }

}