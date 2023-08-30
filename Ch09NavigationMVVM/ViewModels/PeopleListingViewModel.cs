using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Ch09NavigationMVVM.Commands;
using Ch09NavigationMVVM.Models;
using Ch09NavigationMVVM.Services;
using Ch09NavigationMVVM.Stores;

namespace Ch09NavigationMVVM.ViewModels;

public class PeopleListingViewModel : ViewModelBase
{
    private readonly PeopleStore _peopleStore;
    public IEnumerable<People>? PeopleList => _peopleStore.Peoples;
    public ICommand NavigateAddPersonViewCommand { get; }
    public PeopleListingViewModel(PeopleStore peopleStore, 
        INavigationService navigationService)
    {
        _peopleStore = peopleStore;
        NavigateAddPersonViewCommand = new NavigateCommand(navigationService);
    }
}