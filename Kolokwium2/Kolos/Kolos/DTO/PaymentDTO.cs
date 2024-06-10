using Kolos.Model;

namespace Kolos.DTO;

public class PaymentDTO
{
    public int IdPayment { get; set; }
    public DateTime Date { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
}