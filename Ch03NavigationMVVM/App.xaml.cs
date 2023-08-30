using System.Windows;
using Ch03NavigationMVVM.Stores;
using Ch03NavigationMVVM.ViewModels;
using Ch03NavigationMVVM.Views;

namespace Ch03NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            AccountStore accountStore = new AccountStore();
            navigationStore.SetCurrentViewModel(new HomeViewModel(navigationStore, accountStore)); 
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}