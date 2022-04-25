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
            Console.WriteLine(API_URL);
            return await _http.GetFromJsonAsync<Ticket[]>("");
        }
        catch
        {
            return Array.Empty<Ticket>();
        }
    }
}