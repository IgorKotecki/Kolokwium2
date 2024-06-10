using System.Xml.Serialization;
using Kolos.Context;
using Kolos.DTO;
using Kolos.Model;
using Kolos.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolos.Controller;


[ApiController]
[Route("/api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly AppDbContext _context;

    public ClientController(IClientService service,AppDbContext context)
    {
        _clientService = service;
        _context = context;
    }
    
    [HttpGet("{idClient}/reservations")]
    public async Task<IActionResult> GetClientPayment(int id)
    {
        var client =  _clientService.GetClientWithSubscriptionAsync(id);

        if (client == null)
        {
            return NotFound("Client not found");
        }

        return Ok(client);
    }

    [HttpPost("payments")]
    public async Task<IActionResult> AddPayment([FromBody] PaymentDTO paymentDto, int IdClient, int IdSubscription)
    {
        if (paymentDto == null)
        {
            return BadRequest();
        }

        var client = _context.Clients.FirstOrDefault(c => c.IdClient == IdClient);
        if (client == null)
        {
            return BadRequest();
        }

        var subscription = _context.Subscriptions.FirstOrDefault(s => s.IdSubscription == IdSubscription);
        if (subscription == null)
        {
            return BadRequest();
        }

        var subActive = subscription.EndTime;
        if (subActive < DateTime.Today)
        {
            return BadRequest();
        }
        

        var payment = new Payment()
        {
            IdPayment = paymentDto.IdPayment,
            Date = paymentDto.Date,
            IdClient = paymentDto.IdClient,
            IdSubscription = paymentDto.IdSubscription
        };

        await _clientService.AddPaymentAsync(IdClient, IdSubscription, payment);
        return CreatedAtAction(nameof(GetClientPayment), new { idClient = payment.IdClient }, payment);
    }
}