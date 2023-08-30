using AmazingNavigation2.Commands;
using AmazingNavigation2.MVVM.Models;
using AmazingNavigation2.Services;
using AmazingNavigation2.Store;

namespace AmazingNavigation2.MVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    private readonly Device _device;
    public RelayCommand NavigateToSettingCommand { get; set; }
    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }

    public HomeViewModel(INavigationService navigationService, DeviceStore deviceStore)
    {
        _navigationService = navigationService;
        _device = deviceStore.Device;
        NavigateToSettingCommand = new RelayCommand((_ => true),
            ExecuteCommand);
    }

    private void ExecuteCommand(object? obj)
    {
        if (obj is not string parameter) return;
        switch (parameter)
        {
            case "Client":
                _device.IsServer = false;
                _navigationService.NavigateTo<ClientSettingViewModel>();
                break;
            case "Server":
                _device.IsServer = true;
                _navigationService.NavigateTo<ServerSettingViewModel>();
                break;
        }
    }
}