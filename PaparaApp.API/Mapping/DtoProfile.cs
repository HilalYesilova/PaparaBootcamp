using AutoMapper;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Mapping
{
    public class DtoProfile:Profile
    {
        public DtoProfile() {
            CreateMap<Product, ProductDto>();
        }
    }
}
