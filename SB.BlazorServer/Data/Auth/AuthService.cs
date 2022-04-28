using SB.BlazorServer.Data.Models;

namespace SB.BlazorServer.Data.Auth;
using System.Net.Http;

public class AuthService
{
    private HttpClient _http;
    public static string AuthString;

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
                var toReturn = await response.Content.ReadFromJsonAsync<LoginReturnModel>();
                AuthString = toReturn.BasicAuthString;
                return toReturn;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}