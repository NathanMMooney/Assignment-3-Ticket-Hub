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
            // Validate the incoming payload.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the Azure Storage connection string from User Secrets.
            string? connectionString = _configuration["AzureStorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("Connection string is not configured properly.");
            }

            // Create a QueueClient for the specified queue.
            QueueClient queueClient = new QueueClient(connectionString, QueueName);

            // Ensure that the queue exists.
            await queueClient.CreateIfNotExistsAsync();

            // Serialize the purchase object to JSON.
            string message = JsonSerializer.Serialize(purchase);

            // Send the message to the Azure Storage Queue.
            await queueClient.SendMessageAsync(message);

            // Return a success response.
            return Ok("Ticket purchase submitted successfully.");
        }
    }
}
