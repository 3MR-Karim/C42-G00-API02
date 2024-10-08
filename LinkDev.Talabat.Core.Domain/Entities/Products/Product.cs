﻿

namespace LinkDev.Talabat.Core.Domain.Entities.Products
{
    public class Product : BaseEntity<int>
    {

        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int? BrandId { get; set; }   // Foriegn Key -->>  ProductBrands Entity
        public virtual ProductBrand? Brand { get; set; }

        public int?  CategoryId  {get;set;} // /// Foreing Key --> ProductCategory Entity
        public virtual ProductCategory?  Category { get; set; }







    }
}
