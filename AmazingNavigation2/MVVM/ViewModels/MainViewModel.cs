using AmazingNavigation2.Commands;
using AmazingNavigation2.Services;

namespace AmazingNavigation2.MVVM.ViewModels;

public class MainViewModel : ViewModelBase
{
    private INavigationService _navigationService;

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateToHomeCommand = new RelayCommand((_ =>true),
            _ => NavigationService.NavigateTo<HomeViewModel>());
        NavigateToSettingCommand = new RelayCommand((_ => true),
            _ => NavigationService.NavigateTo<ServerSettingViewModel>());
        NavigationService.NavigateTo<HomeViewModel>();
    }

    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }
    
    public RelayCommand NavigateToHomeCommand { get; }
    public RelayCommand NavigateToSettingCommand { get; }
    
}