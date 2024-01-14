using System.ComponentModel.DataAnnotations;

namespace PaparaApp.API.Models.Products.DTOs
{
    public class ProductAddDtoRequest
    {
        //Referance Type => class,interface,array
        //Value Type => int,decimal,float,bool,s
        [Range(2, 100, ErrorMessage = "Ürün adı 2 ile 100 arasında olmalıdır!")]
        [Required(ErrorMessage ="Ürün Adı Boş Geçilemez!")]
        public string Name { get; set; } = null!;

        [Range(10,100,ErrorMessage ="Ürün fiyatı 10 ile 100 arasında olmalıdır!")]
        [Required(ErrorMessage = "Ürün Fiyatı Boş Geçilemez!")]
        public decimal? Price { get; set; }
    }
}
