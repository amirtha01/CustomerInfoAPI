using System.ComponentModel.DataAnnotations;


namespace CustomerInfoAPI.Model
{
    /// <summary>
    /// Model for the Customer Data
    /// </summary>
    public class Customer
    {
        public string? FirstName { get; set; } 
        
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email Address is not valid.")]
        public string EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
