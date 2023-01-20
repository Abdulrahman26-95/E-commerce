using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : BaseSpecification<Product>
    {
        // Constructor For Get All Products , We Dont Need a parameter ID Here
        // Get All Products
        public ProductsWithTypesAndBrandsSpecifications(ProductSpecParams productParams)
        : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
                &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
                &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddOrderBy(n => n.Name);
            // applyPaging Take Two Parameter ( Skip , Take )
            applyPaging(productParams.PageSize * (productParams.PageIndex - 1),
            productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddORderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        // Constructor For Get Singe Producte With ID , We Need a parameter ID Here
        // Get Product By Name 
        public ProductsWithTypesAndBrandsSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}