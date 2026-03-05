using ECommerce.Order.Application.Features.Addresses.Queries;
using ECommerce.Order.Application.Features.Addresses.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Handlers
{
    internal class GetAddressesQueryHandler(IRepository<Address> _repository) : IRequestHandler<GetAddressesQuery, List<GetAddressesQueryResult>>
    {
        public async Task<List<GetAddressesQueryResult>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.Adapt<List<GetAddressesQueryResult>>();
        }
    }
}
