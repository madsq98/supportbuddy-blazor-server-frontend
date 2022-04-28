namespace SB.BlazorServer.Data.Models;

public class Answer
{
    public int Id { get; set; }
        
    public string AuthorFirstName { get; set; }
        
    public string AuthorLastName { get; set; }
        
    public string Message { get; set; }
        
    public DateTime TimeStamp { get; set; }
}