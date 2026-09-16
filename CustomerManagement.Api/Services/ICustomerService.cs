using CustomerManagement.Api.DTOs;

namespace CustomerManagement.Api.Services;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync(string? search);

    Task<CustomerDto?> GetByIdAsync(int id);

    Task<CustomerDto> CreateAsync(
        CreateCustomerDto request);

    Task<bool> UpdateAsync(
        int id,
        UpdateCustomerDto request);

    Task<bool> DeleteAsync(int id);
}