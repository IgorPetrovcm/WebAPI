namespace Domain;

public class Note
{
    public Guid UserId { get; set; }
    
    public Guid Id { get; set; } 
    
    public string Title { get; set;  }
    
    public string Details { get; set; }
    
    public DateTime DateCreation { get; set; }
    
    public DateTime? DateEdit { get; set; }
}