using Kolos.Model;

namespace Kolos.Service;

public interface IClientService
{
    Task<Client> GetClientWithSubscriptionAsync(int id);
    
    Task AddPaymentAsync(int IdClient ,int idSubscription,Payment payment);
}