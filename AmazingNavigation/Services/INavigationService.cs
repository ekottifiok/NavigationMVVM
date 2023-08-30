using AmazingNavigation.MVVM.ViewModels;

namespace AmazingNavigation.Services;

public interface INavigationService
{
    ViewModelBase CurrentView { get; }
    void NavigateTo<T>() where T : ViewModelBase;
}