namespace ECommerce.Order.Application.Features.Addresses.Results;

public record GetAddressesQueryResult(int Id,
                                      string UserId,
                                      string FirstName,
                                      string LastName,
                                      string City,
                                      string District,
                                      string AddressLine);

