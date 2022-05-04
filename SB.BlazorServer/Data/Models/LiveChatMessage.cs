namespace SB.BlazorServer.Data.Models;

public class LiveChatMessage
{
    public int Id { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public string Email { get; set; }
        
    public int PhoneNumber { get; set; }
        
    public string Message { get; set; }
        
    public DateTime Timestamp { get; set; }
}