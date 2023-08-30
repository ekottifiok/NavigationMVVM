using System;
using System.Windows;
using AmazingNavigation.MVVM.ViewModels;
using AmazingNavigation.Services;
using AmazingNavigation.Store;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = GetServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainView>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        
        private static ServiceProvider GetServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            
            serviceCollection.AddSingleton<MainView>(provider => new MainView()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            serviceCollection.AddSingleton<PeopleStore>();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<HomeViewModel>();
            serviceCollection.AddSingleton<SettingViewModel>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            serviceCollection.AddSingleton<Func<Type, ViewModelBase>>(provider =>
                viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
            return serviceCollection.BuildServiceProvider();
        }
    }
}