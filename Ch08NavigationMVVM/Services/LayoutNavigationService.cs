using System;
using Ch08NavigationMVVM.Stores;
using Ch08NavigationMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Ch08NavigationMVVM.Services;

public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<HomeViewModel> _createViewModel;
    private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

    public LayoutNavigationService(IServiceProvider serviceProvider)
    {
        _navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
        _createViewModel = serviceProvider.GetRequiredService<HomeViewModel>;
        _createNavigationBarViewModel = serviceProvider.GetRequiredService<NavigationBarViewModel>;
    }

    public override void Navigate() =>
        _navigationStore.SetCurrentViewModel(new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel()));
}