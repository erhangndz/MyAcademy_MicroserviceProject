using ECommerce.Order.Application.Features.Addresses.Results;
using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Queries
{
    public class GetAddressesQuery: IRequest<List<GetAddressesQueryResult>>
    {
    }
}
