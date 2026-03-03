namespace ECommerce.Catalog.DTOs.ProductDtos;

public record ResultProductDto(string Id,
                               string Name,
                               string Description,
                               string ImageUrl,
                               decimal Price,
                               int Stock,
                               string CategoryName);

