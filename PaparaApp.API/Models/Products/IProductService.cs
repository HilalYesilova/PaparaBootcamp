using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        void Delete(int id);
        ResponseDto<int> Add(ProductAddDtoRequest request);
        void Update(ProductUpdateDtoRequest request);
    }
}
