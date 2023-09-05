using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductswithCountSpecification : BaseSpecification<Product>
    {
        public ProductswithCountSpecification(ProductSpecParams productparams) : base(X=>
            (string.IsNullOrEmpty(productparams.Search) || X.Name.ToLower().Contains(productparams.Search)) &&
             (!productparams.BrandID.HasValue || X.ProductBrandId ==productparams.BrandID) &&
            (!productparams.TypeID.HasValue || X.ProductTypeId==productparams.TypeID))
        {
        }
    }
}