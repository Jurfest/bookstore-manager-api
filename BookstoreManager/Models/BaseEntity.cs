namespace BookstoreManager.Models;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; protected set; }
    
    protected void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}