namespace FamilyStore.Entities;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
    
    public ICollection<Company> CompanySubscriptions { get; set; }
    public ICollection<User> UserSubscriptions { get; set; }
}