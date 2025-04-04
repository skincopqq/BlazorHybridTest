using Test.WpfClient;
using Test.FrontShared.Services;

namespace Test.WpfClient.Services
{
    public class SettingsStorageWrapper : IStorageWrapper
    {
        public Task<string?> GetItemAsync(string key)
        {
            var value = Settings.Default[key]?.ToString();
            return Task.FromResult(value);
        }

        public Task SetItemAsync(string key, string value)
        {
            Settings.Default[key] = value;
            Settings.Default.Save();
            return Task.CompletedTask;
        }

        public Task RemoveItemAsync(string key)
        {
            Settings.Default[key] = null;
            Settings.Default.Save();
            return Task.CompletedTask;
        }
    }
}
