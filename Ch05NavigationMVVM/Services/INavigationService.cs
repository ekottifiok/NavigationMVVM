using System;
using Ch05NavigationMVVM.Stores;
using Ch05NavigationMVVM.ViewModels;

namespace Ch05NavigationMVVM.Services;

public abstract class INavigationService<TViewModel> where TViewModel : ViewModelBase
{
    public abstract void Navigate();
}