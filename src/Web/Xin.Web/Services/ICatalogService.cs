using Xin.Web.Models.Catalog;

namespace Xin.Web.Services;

public interface ICatalogService
{
    [Get("/catalog-service/products?page={page}&size={size}")]
    Task<GetProductsResponse> GetProducts(int? page = 1, int? size = 10);

    [Get("/catalog-service/products/{Id}")]
    Task<GetProductByIdResponse> GetProductById(Guid Id);

    [Get("/catalog-service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductByCategory(string category);
    Task GetProduct(Guid productId);
}
