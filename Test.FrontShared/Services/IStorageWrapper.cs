using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FrontShared.Services
{
    public interface IStorageWrapper
    {
        public Task<string?> GetItemAsync(string key);
        public Task SetItemAsync(string key,string value);
        public Task RemoveItemAsync(string key);
    }
}
