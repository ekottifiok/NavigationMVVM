using System;
using System.Collections.ObjectModel;
using Ch09NavigationMVVM.Models;

namespace Ch09NavigationMVVM.Stores;

public class PeopleStore
{
    private ObservableCollection<People>? _peoples { get; }
    public event Action? PeoplesChanged;

    public ObservableCollection<People>? Peoples => _peoples;

    public PeopleStore()
    {
        _peoples = new ObservableCollection<People>();
    }

    public void AddNewPeople(People value)
    {
        _peoples?.Add(value);
        PeoplesChanged?.Invoke();
    }
}
