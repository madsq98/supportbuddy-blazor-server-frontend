namespace SB.BlazorServer.Data.Auth;
using System.Net.Http;

public class AuthService
{
    private HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<LoginReturnModel> PostAuthenticate(LoginModel obj)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("authenticate", obj);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginReturnModel>();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}