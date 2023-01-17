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
        public ProductsWithTypesAndBrandsSpecifications()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
        // Constructor For Get Singe Producte With ID , We Need a parameter ID Here
        // Get Product By Name 
        public ProductsWithTypesAndBrandsSpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}