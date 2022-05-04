namespace SB.BlazorServer.Data.Models;

public class LiveChat
{
    public int Id { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public string Email { get; set; }
        
    public int PhoneNumber { get; set; }
        
    public string Status { get; set; }
    
    public ICollection<LiveChatMessage> Messages { get; set; }
}