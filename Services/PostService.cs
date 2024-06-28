using Auth0_Blazor.Models;
using Auth0_Blazor.Utils;
using Newtonsoft.Json;

namespace Auth0_Blazor.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        private readonly DecryptSymmetricService _decryptSymmetricService;

        public PostService(HttpClient httpClient, DecryptSymmetricService decryptSymmetricService)
        {
            _httpClient = httpClient;
            _decryptSymmetricService = decryptSymmetricService;
        }

        public async Task<List<UserPost>> GetUserPostsAsync()
        {
            var encryptedData = await _httpClient.GetStringAsync("https://localhost:7014/api/share/get-posts");

            if (IsBase64String(encryptedData))
            {
                var decryptedData = _decryptSymmetricService.DecryptSymmetric(encryptedData);
                return JsonConvert.DeserializeObject<List<UserPost>>(decryptedData);
            }

            return null;
            
        }

        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out _);
        }
    }
}
