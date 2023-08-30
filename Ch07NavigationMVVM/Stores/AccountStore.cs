using System;
using Ch07NavigationMVVM.Models;

namespace Ch07NavigationMVVM.Stores;

public class AccountStore
{
    private Account? _currentAccount;
    public event Action? CurrentAccountChanged;
    public Account? CurrentAccount => _currentAccount;

    public bool IsLoggedIn=> _currentAccount != null;
    public void Logout() => SetCurrentAccount(null);

    public void SetCurrentAccount(Account? value)
    {
        _currentAccount = value;
        CurrentAccountChanged?.Invoke();
    }
}