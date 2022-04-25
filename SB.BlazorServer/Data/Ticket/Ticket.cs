namespace SB.BlazorServer.Data.Ticket;

public class Ticket
{
    public int Id { get; set; }
        
    public string Status { get; set; }
        
    public string Subject { get; set; }
        
    public string Message { get; set; }
        
    public string Email { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public int PhoneNumber { get; set; }
    
    public ICollection<Answer> Answers { get; set; }

    public DateTime TimeStamp { get; set; }
}