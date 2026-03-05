using ECommerce.Order.Application.Features.Addresses.Commands;
using ECommerce.Order.Application.Features.Addresses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _mediator.Send(new GetAddressesQuery());
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
