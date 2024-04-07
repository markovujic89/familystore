namespace FamilyStore.Models;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }

    // Foreign key property for Company
    public Guid CompanyId { get; set; }
    
    // Navigation property for the related Company
    public Company Company { get; set; }

    // Foreign key property for User
    public Guid UserId { get; set; }
    
    // Navigation property for the related User
    public User User { get; set; }
}