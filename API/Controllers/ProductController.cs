using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Errors;
using System.Net;

namespace API.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productrepo;
        private readonly IGenericRepository<ProductBrand> _productbrandrepo;
        private readonly IGenericRepository<ProductType> _producttyperepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productrepo,
                                IGenericRepository<ProductBrand> productbrandrepo,
                                IGenericRepository<ProductType> producttyperepo,
                                IMapper mapper)
        {
            _producttyperepo = producttyperepo;
            _mapper = mapper;
            _productrepo = productrepo;
            _productbrandrepo = productbrandrepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductwithBrandsandTypesSpecification();

            var products = await _productrepo.ListAsync(spec);
    
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
            var spec = new ProductwithBrandsandTypesSpecification(id);
            var product = await _productrepo.GetEntityWithSpec(spec);

            if (product == null)
            {
                return NotFound(new APIResponse(404));
            }

            return _mapper.Map<Product,ProductToReturnDto>(product);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands=await _productbrandrepo.ListALLAsync();
            return  Ok(productBrands);
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes=await _producttyperepo.ListALLAsync();
            return Ok(productTypes);
        }

    



    }
}