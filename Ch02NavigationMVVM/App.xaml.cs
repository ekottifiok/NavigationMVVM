using System.Windows;
using Ch02NavigationMVVM.Stores;
using Ch02NavigationMVVM.ViewModels;
using Ch02NavigationMVVM.Views;

namespace Ch02NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.SetCurrentViewModel(new HomeViewModel(navigationStore)); 
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}