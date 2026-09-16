using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Api.DTOs;

public class UpdateCustomerDto
{
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [RegularExpression(
        @"^(0|\+84)[0-9]{9,10}$")]
    public string Phone { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public bool IsActive { get; set; }
}