namespace CustomerManagement.Api.DTOs;

public class CustomerDto
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public bool IsActive { get; set; }
}