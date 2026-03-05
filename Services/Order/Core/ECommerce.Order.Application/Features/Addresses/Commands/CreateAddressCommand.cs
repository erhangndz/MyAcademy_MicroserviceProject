using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Commands;

public record CreateAddressCommand(string UserId,
                                  string FirstName,
                                  string LastName,
                                  string City,
                                  string District,
                                  string AddressLine): IRequest;

