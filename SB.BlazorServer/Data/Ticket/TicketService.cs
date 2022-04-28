using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SB.BlazorServer.Data.Auth;

namespace SB.BlazorServer.Data.Ticket;
using System.Net.Http;

public class TicketService
{
    private HttpClient _http;
    private AuthService _authService;
    private NavigationManager _navigationManager;
    public TicketService(HttpClient httpClient, AuthService authService, NavigationManager navigationManager)
    {
        _http = httpClient;
        _authService = authService;
        _navigationManager = navigationManager;
    }
    
    public async Task<Models.Ticket[]> GetTicketsAsync()
    {
        await AddAuthHeader();
        
        try
        {
            return await _http.GetFromJsonAsync<Models.Ticket[]>("");
        }
        catch
        {
            return Array.Empty<Models.Ticket>();
        }
    }

    public async Task<Models.Ticket> GetTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            return await _http.GetFromJsonAsync<Models.Ticket>("" + id);
        }
        catch
        {
            return new Models.Ticket();
        }
    }

    public async Task<Models.Ticket> PostTicketAsync(Models.Ticket obj)
    {
        await AddAuthHeader();
        
        try
        {
            var response = await _http.PostAsJsonAsync("", obj);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Models.Ticket>();
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Models.Ticket> AddAnswerAsync(int id, AddAnswer obj)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.PostAsJsonAsync("" + id, obj);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Models.Ticket>();

            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Models.Ticket> CloseTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.PostAsJsonAsync(id + "/close", new Models.Ticket());
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Models.Ticket>();

            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Models.Ticket> DeleteTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.DeleteAsync("" + id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Models.Ticket>();

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