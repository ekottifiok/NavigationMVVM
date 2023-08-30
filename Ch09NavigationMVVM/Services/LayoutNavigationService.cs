using System;
using System.Windows;
using Ch09NavigationMVVM.Stores;
using Ch09NavigationMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Ch09NavigationMVVM.Services;

public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<ViewModelBase> _createViewModel;
    private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

    public LayoutNavigationService(IServiceProvider serviceProvider)
    {
        _navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
        switch (typeof(TViewModel).ToString().Split('.')[2])
        {
            case "AccountViewModel":
                _createViewModel = serviceProvider.GetRequiredService<AccountViewModel>;
                break;
            case "HomeViewModel":
                _createViewModel = serviceProvider.GetRequiredService<HomeViewModel>;
                break;
            case "PeopleListingViewModel":
                _createViewModel = serviceProvider.GetRequiredService<PeopleListingViewModel>;
                break;
            default:
                throw new Exception("ViewModel not found");
        }
        _createNavigationBarViewModel = serviceProvider.GetRequiredService<NavigationBarViewModel>;
    }

    public override void Navigate() =>
        _navigationStore.SetCurrentViewModel(new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel()));
}