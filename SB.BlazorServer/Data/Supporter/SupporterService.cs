using SB.BlazorServer.Data.Auth;

namespace SB.BlazorServer.Data.Supporter;

public class SupporterService
{
    private HttpClient _http;
    private AuthService _authService;

    public SupporterService(HttpClient httpClient, AuthService authService)
    {
        _http = httpClient;
        _authService = authService;
    }

    public async Task<Models.Supporter[]> GetSupportersAsync()
    {
        await AddAuthHeader();
        try
        {
            return await _http.GetFromJsonAsync<Models.Supporter[]>("");
        }
        catch
        {
            return Array.Empty<Models.Supporter>();
        }
    }

    public async Task<Models.Supporter> GetSupporterAsync(int id)
    {
        await AddAuthHeader();
        try
        {
            return await _http.GetFromJsonAsync<Models.Supporter>("" + id);
        }
        catch
        {
            return new Models.Supporter();
        }
    }
    
    public async Task<Models.Supporter> PostSupporterAsync(Models.CreateSupporterModel obj)
    {
        await AddAuthHeader();
        
        try
        {
            var response = await _http.PostAsJsonAsync("", obj);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Models.Supporter>();
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }
    
    public async Task<Models.Supporter> DeleteSupporterAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.DeleteAsync("" + id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Models.Supporter>();

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