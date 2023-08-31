using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AmazingNavigation2.Commands;
using AmazingNavigation2.MVVM.Models;
using AmazingNavigation2.Services;
using AmazingNavigation2.Store;
using AmazingNavigation2.Core;

namespace AmazingNavigation2.MVVM.ViewModels;

public class ServerSettingViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    private readonly Device _device;
    private int _port;
    private bool _isLoading;

    public IPAddress[] IpAddresses => Dns.GetHostEntry(Dns.GetHostName()).AddressList;
    public int SelectedItem { get; set; }
    public string? MyIpAddress => _device?.IpAddress?.ToString();
    public RelayCommand StartServerCommand { get; set; }

    public int Port
    {
        get => _port; 
        private set => SetField(ref _port, value); }

    public bool IsLoading
    {
        get => _isLoading; 
        private set => SetField(ref _isLoading, value);
    }
    
    public RelayCommand NavigateToHomeCommand { get; }

    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }
    
    public ServerSettingViewModel(INavigationService navigationService, 
        DeviceStore deviceStore)
    {
        SelectedItem = 0;
        _device = deviceStore.Device ?? new Device();
        _navigationService = navigationService;
        _port = 0;
        _isLoading = true;
        NavigateToHomeCommand = new RelayCommand((_ =>true),
            _ => NavigationService.NavigateTo<HomeViewModel>());
        StartServerCommand = new RelayCommand(_ => true, ExecuteStartServer);
        Task.Run(() =>
        {
            Port = Utils.OpenPort();
            _device.Port = Port; 
            IsLoading = false;
        });
        
    }

    private void ExecuteStartServer(object? obj)
    {
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _device.IpAddress = IpAddresses[SelectedItem];
        listener.Bind(new IPEndPoint(_device.IpAddress, _device.Port));
        _device.SocketInstance = listener;
        NavigationService.NavigateTo<SendReceiveFileViewModel>();
    }
}