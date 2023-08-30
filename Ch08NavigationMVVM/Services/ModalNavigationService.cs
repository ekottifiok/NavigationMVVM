using System;
using Ch08NavigationMVVM.Stores;
using Ch08NavigationMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Ch08NavigationMVVM.Services;

public class ModalNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly Func<LoginViewModel> _createViewModel;

    public ModalNavigationService(IServiceProvider serviceProvider)
    {
        _modalNavigationStore = serviceProvider.GetRequiredService<ModalNavigationStore>();
        _createViewModel = serviceProvider.GetRequiredService<LoginViewModel>;
    }

    public override void Navigate() => _modalNavigationStore.SetCurrentViewModel(_createViewModel());
}