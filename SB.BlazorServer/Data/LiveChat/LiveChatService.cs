using SB.BlazorServer.Data.Auth;

namespace SB.BlazorServer.Data.LiveChat;

public class LiveChatService
{
    private HttpClient _http;
    private AuthService _authService;

    public LiveChatService(HttpClient httpClient, AuthService authService)
    {
        _http = httpClient;
        _authService = authService;
    }

    public async Task<Models.LiveChat[]> GetLiveChatsAsync()
    {
        await AddAuthHeader();

        try
        {
            return await _http.GetFromJsonAsync<Models.LiveChat[]>("");
        }
        catch
        {
            return Array.Empty<Models.LiveChat>();
        }
    }

    public async Task<Models.LiveChat> GetLiveChatAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            return await _http.GetFromJsonAsync<Models.LiveChat>("" + id);
        }
        catch
        {
            return new Models.LiveChat();
        }
    }

    public async Task<Models.LiveChat> PostLiveChatAsync(Models.CreateLiveChat data)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.PostAsJsonAsync("", data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Models.LiveChat>();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
    
    private async Task AddAuthHeader()
    {
        _http.DefaultRequestHeaders.Remove("Authorization");
        _http.DefaultRequestHeaders.Add("Authorization", "Basic " + AuthService.AuthString);
    }
}