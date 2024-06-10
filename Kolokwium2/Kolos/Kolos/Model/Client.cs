namespace Kolos.Model;

public class Client
{
    public int IdClient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phoen { get; set; }
    public int IdSale { get; set; }

    public virtual Sale sale{
        get;
        set;
    }

    public ICollection<Sale> Sales { get; set; }
}