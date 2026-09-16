using CustomerManagement.Api.Data;
using CustomerManagement.Api.DTOs;
using CustomerManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerDto>> GetAllAsync(
        string? search)
    {
        var query = _context.Customers
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();

            query = query.Where(x =>
                x.FullName.Contains(search) ||
                x.Phone.Contains(search));
        }

        return await query
            .OrderByDescending(x => x.Id)
            .Select(x => new CustomerDto
            {
                Id = x.Id,
                Code = x.Code,
                FullName = x.FullName,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.DateOfBirth,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        return await _context.Customers
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new CustomerDto
            {
                Id = x.Id,
                Code = x.Code,
                FullName = x.FullName,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.DateOfBirth,
                IsActive = x.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CustomerDto> CreateAsync(
        CreateCustomerDto request)
    {
        var customer = new Customer
        {
            Code = await GenerateCodeAsync(),
            FullName = request.FullName.Trim(),
            Email = request.Email.Trim(),
            Phone = request.Phone.Trim(),
            DateOfBirth = request.DateOfBirth,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return (await GetByIdAsync(customer.Id))!;
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateCustomerDto request)
    {
        var customer =
            await _context.Customers.FindAsync(id);

        if (customer == null)
            return false;

        customer.FullName =
            request.FullName.Trim();

        customer.Email =
            request.Email.Trim();

        customer.Phone =
            request.Phone.Trim();

        customer.DateOfBirth =
            request.DateOfBirth;

        customer.IsActive =
            request.IsActive;

        customer.UpdatedAt =
            DateTime.Now;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer =
            await _context.Customers.FindAsync(id);

        if (customer == null)
            return false;

        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<string> GenerateCodeAsync()
    {
        var maxId =
            await _context.Customers
                .MaxAsync(x => (int?)x.Id) ?? 0;

        return $"KH{maxId + 1:0000}";
    }
}