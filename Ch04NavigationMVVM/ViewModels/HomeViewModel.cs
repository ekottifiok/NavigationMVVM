using System.Windows.Input;
using Ch04NavigationMVVM.Commands;
using Ch04NavigationMVVM.Services;

namespace Ch04NavigationMVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public NavigationBarViewModel NavigationBarViewModel { get; }

    public HomeViewModel(NavigationBarViewModel navigationBarViewModel,
        NavigationService<LoginViewModel> navigationService)
    {
        NavigationBarViewModel = navigationBarViewModel;
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationService);
    }
    public string WelcomeMessage => "Welcome to my application";
    public ICommand NavigateLoginCommand { get; }
    
}