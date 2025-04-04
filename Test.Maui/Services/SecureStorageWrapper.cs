using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.FrontShared.Services;

namespace Test.Maui.Services
{
    public class SecureStorageWrapper : IStorageWrapper
    {
        public Task RemoveItemAsync(string key)
        {
            SecureStorage.Remove(key);
            return Task.CompletedTask;
        }

        public async Task<string?> GetItemAsync(string key)
        {
            var item = await SecureStorage.GetAsync(key);
            return item;
        }

        public async Task SetItemAsync(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }
    }
}
