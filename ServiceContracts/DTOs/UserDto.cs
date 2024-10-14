
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage ="Provide a valid email address.")]
        [Required(ErrorMessage ="{0} is required.")]
        public required string Email { get; set; }
        [Required(ErrorMessage ="{0} is required.")]
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
    }
}