

using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductwithBrandsandTypesSpecification : BaseSpecification<Product>
    {
        public ProductwithBrandsandTypesSpecification(ProductSpecParams productparams) : base(X=>
             (string.IsNullOrEmpty(productparams.Search) || X.Name.ToLower().Contains(productparams.Search)) &&
             (!productparams.BrandID.HasValue || X.ProductBrandId ==productparams.BrandID) &&
            (!productparams.TypeID.HasValue || X.ProductTypeId==productparams.TypeID)
        )
        {

            AddInlude(x => x.ProductType);
            AddInlude(y => y.ProductBrand);
            AddOrderBy(z => z.Name);
            AddPagination(productparams.PageSize*(productparams.PageIndex-1),productparams.PageSize);
            

            if (!string.IsNullOrEmpty(productparams.Sort))
            {
                switch (productparams.Sort)
                {
                    case "priceAsc" : AddOrderBy(x => x.Price);break;
                                      
                    case "priceDsc" : AddOrderByDesc(x => x.Price); break;

                    default         : AddOrderBy(x => x.Name); break;


                };
            }
        }

        public ProductwithBrandsandTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInlude(x => x.ProductType);
            AddInlude(y => y.ProductBrand);
        }
    }
}