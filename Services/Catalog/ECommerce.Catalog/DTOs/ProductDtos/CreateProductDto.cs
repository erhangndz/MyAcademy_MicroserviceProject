namespace ECommerce.Catalog.DTOs.ProductDtos;

public record CreateProductDto(
                               string Name,
                               string Description,
                               string ImageUrl,
                               decimal Price,
                               int Stock,
                               string CategoryName);

