using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlogBlazorUI.Utils
{
    public static class LocalStorageHelper
    {
       
        public static async Task SaveItemEncryptedAsync<T>(this ILocalStorageService localStorageService,string key,T item)
        {
            string itemJson = JsonConvert.SerializeObject(item);
            byte[] itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
            string base64Json = Convert.ToBase64String(itemJsonBytes);
            await localStorageService.SetItemAsync(key, base64Json);
        }
        public static async Task<T> ReadEncryptedItemAsync<T>(this ILocalStorageService localStorageService,string key)
        {
            string base64Json = await localStorageService.GetItemAsync<string>(key);
            byte[] itemJsonBytes = Convert.FromBase64String(base64Json);
            string itemJson = Encoding.UTF8.GetString(itemJsonBytes);
            T item = JsonConvert.DeserializeObject<T>(itemJson);

            return item;
        }
    }
}
