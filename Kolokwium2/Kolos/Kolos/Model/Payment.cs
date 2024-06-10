namespace Kolos.Model;

public class Payment
{
    public int IdPayment { get; set; }
    public DateTime Date { get; set; }
    public int IdClient { get; set; }
    public virtual Client Client { get; set; }
    public int IdSubscription { get; set; }
    public virtual Subscription SySubscription { get; set; }
}