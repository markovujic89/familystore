namespace FamilyStore.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }

    // Navigation property for one-to-many relationship with Subscription
    public ICollection<Subscription> Subscriptions { get; set; }
}