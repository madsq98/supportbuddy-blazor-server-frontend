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
    
    public async Task<Ticket[]> GetTicketsAsync()
    {
        await AddAuthHeader();
        
        try
        {
            return await _http.GetFromJsonAsync<Ticket[]>("");
        }
        catch
        {
            return Array.Empty<Ticket>();
        }
    }

    public async Task<Ticket> GetTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            return await _http.GetFromJsonAsync<Ticket>("" + id);
        }
        catch
        {
            return new Ticket();
        }
    }

    public async Task<Ticket> PostTicketAsync(Ticket obj)
    {
        await AddAuthHeader();
        
        try
        {
            var response = await _http.PostAsJsonAsync("", obj);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Ticket>();
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Ticket> AddAnswerAsync(int id, AddAnswer obj)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.PostAsJsonAsync("" + id, obj);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Ticket>();

            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Ticket> CloseTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.PostAsJsonAsync(id + "/close", new Ticket());
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Ticket>();

            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Ticket> DeleteTicketAsync(int id)
    {
        await AddAuthHeader();

        try
        {
            var response = await _http.DeleteAsync("" + id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Ticket>();

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