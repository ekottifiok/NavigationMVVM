using System.Windows;
using Ch07NavigationMVVM.Services;
using Ch07NavigationMVVM.Stores;
using Ch07NavigationMVVM.ViewModels;
using Ch07NavigationMVVM.Views;

namespace Ch07NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
        }

        private INavigationService CreateAccountNavigationService() =>
            new LayoutNavigationService<AccountViewModel>(_navigationStore,
                () => new AccountViewModel(_accountStore, CreateHomeNavigationService()),
                CreateNavigationBarViewModel);

        private INavigationService CreateHomeNavigationService() =>
            new LayoutNavigationService<HomeViewModel>(_navigationStore,
                () => new HomeViewModel(CreateLoginNavigationService()),
                CreateNavigationBarViewModel);

        private INavigationService CreateLoginNavigationService() =>
            new ModalNavigationService<LoginViewModel>(_modalNavigationStore,
                () => new LoginViewModel(
                    _accountStore,
                    new CompositeNavigationService(
                        new CloseModalNavigationService(_modalNavigationStore),
                        CreateAccountNavigationService())));

        private NavigationBarViewModel CreateNavigationBarViewModel() =>
            new(_accountStore, CreateAccountNavigationService(),
                CreateHomeNavigationService(), CreateLoginNavigationService());

        protected override void OnStartup(StartupEventArgs e)
        {
            CreateHomeNavigationService().Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}