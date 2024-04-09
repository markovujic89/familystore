namespace FamilyStore.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    // Navigation property for one-to-many relationship with Subscription
    public ICollection<Subscription> Subscriptions { get; set; }
}