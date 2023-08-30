using System.Windows;
using Ch04NavigationMVVM.Services;
using Ch04NavigationMVVM.Stores;
using Ch04NavigationMVVM.ViewModels;
using Ch04NavigationMVVM.Views;

namespace Ch04NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;
        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(
                _accountStore,
                CreateAccountNavigationService(),
                CreateHomeNavigationService(),
                CreateLoginNavigationService());
        }

        private NavigationService<AccountViewModel> CreateAccountNavigationService() =>
            new(_navigationStore,
                () => new AccountViewModel(_accountStore, _navigationBarViewModel, CreateHomeNavigationService()));
        
        private NavigationService<HomeViewModel> CreateHomeNavigationService() =>
            new(_navigationStore,
                () => new HomeViewModel(_navigationBarViewModel, CreateLoginNavigationService()));
        
        private NavigationService<LoginViewModel> CreateLoginNavigationService() =>
            new(_navigationStore,
                () => new LoginViewModel(_accountStore, CreateAccountNavigationService()));
        

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}