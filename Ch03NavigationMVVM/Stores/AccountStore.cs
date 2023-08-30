using Ch03NavigationMVVM.Models;

namespace Ch03NavigationMVVM.Stores;

public class AccountStore
{
    private Account? _currentAccount;
    public Account? CurrentAccount { get; set; }
}