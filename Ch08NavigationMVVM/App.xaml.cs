using System;
using System.Windows;
using Ch08NavigationMVVM.Services;
using Ch08NavigationMVVM.Stores;
using Ch08NavigationMVVM.ViewModels;
using Ch08NavigationMVVM.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Ch08NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private ServiceProvider _buildServiceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            /* singletons */
            serviceCollection.AddSingleton<AccountStore>();
            serviceCollection.AddSingleton<NavigationStore>();
            serviceCollection.AddSingleton<ModalNavigationStore>();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            serviceCollection.AddSingleton(CreateHomeNavigationService);
            serviceCollection.AddSingleton<CloseModalNavigationService>(s =>
                new CloseModalNavigationService(s.GetRequiredService<ModalNavigationStore>()));

            /* transients */
            serviceCollection.AddTransient<HomeViewModel>(s => new HomeViewModel(
                CreateLoginNavigationService(s)));
            serviceCollection.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(), CreateHomeNavigationService(s)));
            serviceCollection.AddTransient<LoginViewModel>(s => new LoginViewModel(
                s.GetRequiredService<AccountStore>(), new CompositeNavigationService(
                    s.GetRequiredService<CloseModalNavigationService>(),
                    CreateAccountNavigationService(s))));
            serviceCollection.AddTransient(CreateNavigationBarViewModel);
            _buildServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<AccountViewModel>(serviceProvider);

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<HomeViewModel>(serviceProvider);

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<LoginViewModel>(serviceProvider);

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider) => new(
            serviceProvider.GetRequiredService<AccountStore>(),
            CreateAccountNavigationService(serviceProvider),
            CreateHomeNavigationService(serviceProvider),
            CreateLoginNavigationService(serviceProvider));

        protected override void OnStartup(StartupEventArgs e)
        {
            _buildServiceProvider.GetRequiredService<INavigationService>().Navigate();
            MainWindow = _buildServiceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}