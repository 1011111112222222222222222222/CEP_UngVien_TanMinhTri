using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Api.DTOs;

public class CreateCustomerDto
{
    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [RegularExpression(
        @"^(0|\+84)[0-9]{9,10}$",
        ErrorMessage = "Số điện thoại không hợp lệ")]
    public string Phone { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }
}