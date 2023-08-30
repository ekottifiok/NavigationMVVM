using System;
using System.Windows;
using AmazingNavigation2.MVVM.ViewModels;
using AmazingNavigation2.MVVM.Views;
using AmazingNavigation2.Services;
using AmazingNavigation2.Store;
using Microsoft.Extensions.DependencyInjection;
using SendReceiveFileViewModel = AmazingNavigation2.MVVM.ViewModels.SendReceiveFileViewModel;

namespace AmazingNavigation2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = GetServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainView>().Show();
            base.OnStartup(e);
        }
        
        private static ServiceProvider GetServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            
            serviceCollection.AddSingleton<MainView>(provider => new MainView()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            serviceCollection.AddSingleton<DeviceStore>();
            serviceCollection.AddSingleton<PeersStore>();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<HomeViewModel>();
            serviceCollection.AddSingleton<ServerSettingViewModel>();
            serviceCollection.AddSingleton<ClientSettingViewModel>();
            serviceCollection.AddSingleton<SendReceiveFileViewModel>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            serviceCollection.AddSingleton<Func<Type, ViewModelBase>>(provider =>
                viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
            return serviceCollection.BuildServiceProvider();
        }
    }
}