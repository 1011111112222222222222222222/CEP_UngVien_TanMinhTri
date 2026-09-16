namespace CustomerManagement.Client.Models;

public class CustomerDto
{
    public int Id { get; set; }

    public string Code { get; set; } = "";

    public string FullName { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public DateTime? DateOfBirth { get; set; }

    public bool IsActive { get; set; }
}