using ECommerce.Order.Application.Features.Addresses.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Handlers
{
    public class UpdateAddressCommandHandler(IRepository<Address> _repository) : IRequestHandler<UpdateAddressCommand>
    {
        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id); 
            if(address is null)
            {
                throw new Exception("Address Not Found");
            }

            request.Adapt(address);
            await _repository.UpdateAsync(address);
        }
    }
}
