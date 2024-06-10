using Kolos.Context;
using Kolos.DTO;
using Kolos.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolos.Repository;

public class ClientRepo : IClientRepo
{
    private readonly AppDbContext _context;

    public ClientRepo(AppDbContext con)
    {
        _context = con;
    }
    
    public Task<Client> GetClientWithSubscriptionsAsync(int idClient)
    {
        return  Task.FromResult(_context.Clients
            .Include(c=>c.Sales).ThenInclude(s=>s.Subscription).FirstOrDefault(c => c.IdClient == idClient)!);
    }

    public async Task AddPaymentAsync(int IdClient, int idSubscription, Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }
}