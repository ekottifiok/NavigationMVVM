using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using AmazingNavigation2.Commands;
using AmazingNavigation2.MVVM.Models;
using AmazingNavigation2.Services;
using AmazingNavigation2.Store;

namespace AmazingNavigation2.MVVM.ViewModels;

public class ClientSettingViewModel : ViewModelBase
{
    private readonly Device? _device;
    private INavigationService _navigationService;

    public string? ServerIpAddress { get; set; }
    public string? ServerPort { get; set; }
    public RelayCommand SubmitServerCommand { get; }
    public RelayCommand NavigateToHomeCommand { get; }
    public string? MyIpAddress => _device?.IpAddress?.ToString();
    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }
    
    public ClientSettingViewModel(INavigationService navigationService,
        DeviceStore deviceStore)
    {
        _device = deviceStore.Device;
        _navigationService = navigationService;
        NavigateToHomeCommand = new RelayCommand((_ =>true),
            _ => NavigationService.NavigateTo<HomeViewModel>());
        SubmitServerCommand = new RelayCommand(_ => true, ExecuteServerCommand);
    }

    private void ExecuteServerCommand(object? obj)
    {
        if (ServerIpAddress is null || ServerPort is null || _device is null || _device.SocketInstance is null) throw new Exception(
            "Server Ip and port should not be null");
        if (int.TryParse(ServerPort, out int port)) _device.Port = port;
        else throw new Exception("Failed to parse Server Port");
        if (IPAddress.TryParse(ServerIpAddress, out IPAddress? address)) _device.ServerAddress = address;
        else throw new Exception("Failed to parse server IP address");
        IPEndPoint endPoint = new IPEndPoint(address, port);
        try
        {
            _device.SocketInstance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket socket = _device.SocketInstance;
            socket.Connect(endPoint);
            if (socket.RemoteEndPoint == null)
            {
                throw new Exception("An error occured when handling the remote Endpoint");
            }
            
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            throw;
        }
        _navigationService.NavigateTo<SendReceiveFileViewModel>();
    }
}