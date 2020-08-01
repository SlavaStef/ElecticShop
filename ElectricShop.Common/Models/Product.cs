namespace ElectricShop.Common.Models
{
    public class Product
    {
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        //[Range(0.01, double.MaxValue, ErrorMessage = "Plase enter a positive number")]
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public virtual ProductBrand Brand { get; set; }

        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Please specify a category")]
        public virtual ProductCategory Category { get; set; }
    }
}