using Kolos.Model;

namespace Kolos.Repository;

public interface IClientRepo
{
    Task<Client> GetClientWithSubscriptionsAsync(int id);

    Task AddPaymentAsync(int IdClient ,int idSubscription,Payment payment);
    
}