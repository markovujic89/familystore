namespace FamilyStore.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    // Navigation property for one-to-many relationship with Subscription
    public ICollection<Subscription> Subscriptions { get; set; }
}