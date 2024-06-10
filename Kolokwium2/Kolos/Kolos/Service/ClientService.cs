using Kolos.Model;
using Kolos.Repository;

namespace Kolos.Service;

public class ClientService : IClientService
{
    private readonly IClientRepo _clientRepo;
    
    
    public ClientService(IClientRepo clientRepository)
    {
        _clientRepo = clientRepository;
    }
    
    public Task<Client> GetClientWithSubscriptionAsync(int id)
    {
        return  _clientRepo.GetClientWithSubscriptionsAsync(id);
    }

    public async Task AddPaymentAsync(int IdClient, int idSubscription, Payment payment)
    {
        await _clientRepo.AddPaymentAsync(IdClient, idSubscription, payment);
    }
}