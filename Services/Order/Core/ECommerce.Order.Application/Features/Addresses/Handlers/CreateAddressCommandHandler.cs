using ECommerce.Order.Application.Features.Addresses.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Handlers
{
    internal class CreateAddressCommandHandler(IRepository<Address> _repository) : IRequestHandler<CreateAddressCommand>
    {
        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = request.Adapt<Address>();
            await _repository.CreateAsync(address);
        }
    }
}
