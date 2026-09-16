using CustomerManagement.Api.DTOs;
using CustomerManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace CustomerManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(
        ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? search)
    {
        var customers =
            await _service.GetAllAsync(search);

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer =
            await _service.GetByIdAsync(id);

        if (customer == null)
        {
            return NotFound(new
            {
                message = "Không tìm thấy khách hàng"
            });
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCustomerDto request)
    {
        var customer =
            await _service.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = customer.Id },
            customer);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateCustomerDto request)
    {
        var result =
            await _service.UpdateAsync(
                id,
                request);

        if (!result)
        {
            return NotFound(new
            {
                message = "Không tìm thấy khách hàng"
            });
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _service.DeleteAsync(id);

        if (!result)
        {
            return NotFound(new
            {
                message = "Không tìm thấy khách hàng"
            });
        }

        return NoContent();
    }
}