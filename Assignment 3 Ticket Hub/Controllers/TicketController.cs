using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Assignment_3_Ticket_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private const string QueueName = "tickethub";

        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
public async Task<IActionResult> PurchaseTicket([FromBody] TicketPurchase purchase)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    string? connectionString = _configuration["AzureStorageConnectionString"];
    if (string.IsNullOrEmpty(connectionString))
    {
        return BadRequest("Connection string is not configured properly.");
    }

    try
    {
        QueueClient queueClient = new QueueClient(connectionString, QueueName);
        await queueClient.CreateIfNotExistsAsync();
        string message = JsonSerializer.Serialize(purchase);
        await queueClient.SendMessageAsync(message);
        return Ok("Ticket purchase submitted successfully.");
    }
    catch (Exception ex)
    {
        // For debugging only! In production, log this error instead.
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}

    }
}
