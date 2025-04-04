using Blazored.LocalStorage;
using Test.FrontShared.Services;
using static System.Net.WebRequestMethods;

namespace Test.WebAssemblyClient.Services
{
    public class LocalStorageWrapper : IStorageWrapper
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorageWrapper(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task RemoveItemAsync(string key)
        {
            await _localStorage.RemoveItemAsync(key);
        }

        public async Task<string?> GetItemAsync(string key)
        {
            var item = await _localStorage.GetItemAsStringAsync(key);
            return item;
        }

        public async Task SetItemAsync(string key, string value)
        {
            await _localStorage.SetItemAsync(key, value);
        }
    }
}
