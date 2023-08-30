using AmazingNavigation2.MVVM.ViewModels;

namespace AmazingNavigation2.Services;

public interface INavigationService
{
    ViewModelBase CurrentView { get; }
    void NavigateTo<T>() where T : ViewModelBase;
}