using Ch09NavigationMVVM.Models;
using Ch09NavigationMVVM.Services;
using Ch09NavigationMVVM.Stores;
using Ch09NavigationMVVM.ViewModels;

namespace Ch09NavigationMVVM.Commands;

public class AddPersonCommand : CommandBase
{
    private readonly AddPeopleListViewModel _viewModel;
    private readonly PeopleStore _peopleStore;
    private readonly INavigationService _navigationService;

    public AddPersonCommand(AddPeopleListViewModel viewModel,
        PeopleStore peopleStore,
        INavigationService navigationService)
    {
        _peopleStore = peopleStore;
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        _peopleStore.AddNewPeople(new People(
            _viewModel.FirstName, _viewModel.LastName));
        _navigationService.Navigate();
    }
}