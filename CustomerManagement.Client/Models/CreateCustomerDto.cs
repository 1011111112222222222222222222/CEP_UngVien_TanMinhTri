using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Client.Models;

public class CreateCustomerDto
{
    [Required(ErrorMessage = "Vui lòng nhập họ tên")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    public string Phone { get; set; } = "";

    public DateTime? DateOfBirth { get; set; }
}