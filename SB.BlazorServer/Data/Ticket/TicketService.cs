namespace SB.BlazorServer.Data.Ticket;
using System.Net.Http;

public class TicketService
{
    private HttpClient _http;
    
    private const string API_URL = "http://vps.qvistgaard.me:8980/api/ticket/";

    public TicketService(HttpClient httpClient)
    {
        _http = httpClient;
    }
    
    public async Task<Ticket[]> GetTicketsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<Ticket[]>("");
        }
        catch
        {
            return Array.Empty<Ticket>();
        }
    }

    public async Task<Ticket> PostTicketAsync(Ticket obj)
    {
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
}