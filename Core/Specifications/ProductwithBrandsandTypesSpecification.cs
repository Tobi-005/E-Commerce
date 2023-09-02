

using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductwithBrandsandTypesSpecification : BaseSpecification<Product>
    {
        public ProductwithBrandsandTypesSpecification()
        {

            AddInlude(x => x.ProductType);
            AddInlude(y => y.ProductBrand);
        }

        public ProductwithBrandsandTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInlude(x => x.ProductType);
            AddInlude(y => y.ProductBrand);
        }
    }
}