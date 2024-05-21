﻿using BookStore.RazorPages.Contracts;
using Hanssens.Net;

namespace BookStore.RazorPages.Services;

public class LocalStorageService : ILocalStorageService
{
    private LocalStorage _localStorage;

    public LocalStorageService()
    {
        var config = new LocalStorageConfiguration
        {
            AutoLoad = true,
            AutoSave = true,
            Filename = "Bookstore"
        };

        _localStorage = new LocalStorage(config);

    }

    public void ClearStorage(List<string> keys)
    {
        foreach (var key in keys)
        {
            _localStorage.Remove(key);
        }
    }

    public bool Exists(string key)
    {
        return _localStorage.Exists(key);
    }

    public T GetStorageValue<T>(string key)
    {
        return (T)_localStorage.Get(key);
    }

    public void SetStorageValue<T>(string key, T value)
    {
        _localStorage.Store(key, value);
        _localStorage.Persist();
    }
}