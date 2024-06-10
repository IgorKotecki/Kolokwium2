namespace Kolos.Model;

public class Sale
{
    public int IdSale { get; set; }
    public int IdClient { get; set; }
    public Client Client { get; set; }
    public int IdSubscription { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; }
    public virtual Subscription Subscription { get; set; }
    public DateTime CreatedAt { get; set; }
}