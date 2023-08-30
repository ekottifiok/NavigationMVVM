using System.Windows;
using Ch05NavigationMVVM.Services;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;
using Ch05NavigationMVVM.Views;

namespace Ch05NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
        }

        private INavigationService<AccountViewModel> CreateAccountNavigationService() =>
            new LayoutNavigationService<AccountViewModel>(_navigationStore, 
                () => new AccountViewModel(_accountStore, CreateHomeNavigationService()),
                CreateNavigationBarViewModel);
        
        private INavigationService<HomeViewModel> CreateHomeNavigationService() =>
            new LayoutNavigationService<HomeViewModel>(_navigationStore, 
                () => new HomeViewModel(CreateLoginNavigationService()),
                CreateNavigationBarViewModel);

        private NavigationBarViewModel CreateNavigationBarViewModel() => new NavigationBarViewModel(
            _accountStore,
            CreateAccountNavigationService(),
            CreateHomeNavigationService(),
            CreateLoginNavigationService());

        private INavigationService<LoginViewModel> CreateLoginNavigationService() =>
            new NavigationService<LoginViewModel>(_navigationStore,
                () => new LoginViewModel(_accountStore, CreateAccountNavigationService()));


        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService<HomeViewModel>homeNavigationService = CreateHomeNavigationService();
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