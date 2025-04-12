using System.ComponentModel.DataAnnotations;

namespace Assignment_3_Ticket_Hub
{
    public class TicketPurchase
    {
        [Required(ErrorMessage = "Concert ID is required.")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 8, ErrorMessage = "Quantity must be between 1 and 8.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public required string CreditCard { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Expiration date must be in MM/YY format.")]
        public required string Expiration { get; set; }

        [Required(ErrorMessage = "Security code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be 3 or 4 digits.")]
        public required string SecurityCode { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        public required string Province { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]{3,10}$", ErrorMessage = "Postal code format is invalid.")]
        public required string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public required string Country { get; set; }
    }
}
