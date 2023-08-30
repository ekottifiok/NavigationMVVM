using AmazingNavigation.Commands;
using AmazingNavigation.Services;
using AmazingNavigation.Store;

namespace AmazingNavigation.MVVM.ViewModels;

public class SettingViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    private PeopleStore _peopleStore;

    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }
    
    public SettingViewModel(INavigationService navigationService, PeopleStore peopleStore)
    {
        _navigationService = navigationService;
        _peopleStore = peopleStore;
        NavigateToHomeCommand = new RelayCommand((_ =>true),
            _ => NavigationService.NavigateTo<HomeViewModel>());
    }

    public RelayCommand NavigateToHomeCommand { get; }
}