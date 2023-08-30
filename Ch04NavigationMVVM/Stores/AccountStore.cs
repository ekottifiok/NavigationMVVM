using Ch04NavigationMVVM.Models;

namespace Ch04NavigationMVVM.Stores;

public class AccountStore
{
    private Account? _currentAccount;
    public Account? CurrentAccount { get; set; }

    public bool IsLoggedIn => CurrentAccount != null;
}