using System.Windows.Input;
using Ch09NavigationMVVM.Commands;
using Ch09NavigationMVVM.Services;
using Ch09NavigationMVVM.Stores;

namespace Ch09NavigationMVVM.ViewModels;

public class AddPeopleListViewModel : ViewModelBase
{
    private string _firstName;
    private string _lastName;
    public ICommand AddPersonCommand { get; }
    public ICommand CancelPeopleListingViewCommand { get; }

    public AddPeopleListViewModel(PeopleStore peopleStore, 
        INavigationService navigationService)
    {
        _firstName = _lastName = "";
        AddPersonCommand = new AddPersonCommand(this, peopleStore, navigationService);
        CancelPeopleListingViewCommand = new NavigateCommand(navigationService);
    }
    
    public string FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }
    
}