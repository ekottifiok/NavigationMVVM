using AmazingNavigation.Commands;
using AmazingNavigation.MVVM.Models;
using AmazingNavigation.Services;
using AmazingNavigation.Store;

namespace AmazingNavigation.MVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    private readonly PeopleStore _peopleStore;
    public RelayCommand NavigateToSettingCommand { get; set; }
    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetField(ref _navigationService, value);
    }

    public HomeViewModel(INavigationService navigationService, PeopleStore peopleStore)
    {
        _navigationService = navigationService;
        _peopleStore = peopleStore;
        NavigateToSettingCommand = new RelayCommand((_ => true),
            ExecuteCommand);
    }

    private void ExecuteCommand(object? obj)
    {
        _peopleStore.AddNewPeople(new People("Hello", "Caleb"));
        _navigationService.NavigateTo<SettingViewModel>();
    }
}