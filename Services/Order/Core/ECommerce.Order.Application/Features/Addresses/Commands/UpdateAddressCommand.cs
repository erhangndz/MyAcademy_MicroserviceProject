using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Commands;

public record UpdateAddressCommand(int Id,
                                  string UserId,
                                  string FirstName,
                                  string LastName,
                                  string City,
                                  string District,
                                  string AddressLine ): IRequest;

