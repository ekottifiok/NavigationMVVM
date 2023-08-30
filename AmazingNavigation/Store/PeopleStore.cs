using System;
using System.Collections.ObjectModel;
using AmazingNavigation.MVVM.Models;

namespace AmazingNavigation.Store;

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
