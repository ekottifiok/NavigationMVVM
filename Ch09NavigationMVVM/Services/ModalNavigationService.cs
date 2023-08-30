using System;
using Ch09NavigationMVVM.Stores;
using Ch09NavigationMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Ch09NavigationMVVM.Services;

public class ModalNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly Func<ViewModelBase> _createViewModel;

    public ModalNavigationService(IServiceProvider serviceProvider)
    {
        _modalNavigationStore = serviceProvider.GetRequiredService<ModalNavigationStore>();
        switch (typeof(TViewModel).ToString().Split('.')[2])
        {
            case "LoginViewModel":
                _createViewModel = serviceProvider.GetRequiredService<LoginViewModel>;
                break;
            case "AddPeopleListViewModel":
                _createViewModel = serviceProvider.GetRequiredService<AddPeopleListViewModel>;
                break;
            default:
                throw new Exception("ViewModel not found");
        }
    }

    public override void Navigate() => _modalNavigationStore.SetCurrentViewModel(_createViewModel());
}