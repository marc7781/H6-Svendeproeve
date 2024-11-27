using Microsoft.JSInterop;

namespace BlazorWebsite.Utils
{
    public class LocalStorageHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.save", key, value);
        }

        public async Task<string> GetAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.get", key);
        }

        public async Task RemoveAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.remove", key);
        }
    }
}