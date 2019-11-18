using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Core;
using Product.Domain;
using Product.Microservice.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _unitOfWork.Products.GetProducts();
            // Mapper.Map<List<Person>, List<PersonView>>(people);
            var viewModel = _mapper.Map<IEnumerable< ProductViewModel>>(products.Result);
            return Ok(viewModel);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _unitOfWork.Products.Get(id);
            var viewModel = _mapper.Map<ProductViewModel>(product.Result);
            return Ok(viewModel);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel viewModel)
        {
            var product = _mapper.Map<ProductInfo>(viewModel);
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, viewModel);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductViewModel viewModel)
        {
            var productDb = _unitOfWork.Products.Get(id);
            if (productDb == null)
                return BadRequest();

            productDb = _mapper.Map<Task<ProductInfo>>(viewModel);
            _unitOfWork.Complete();
            return new OkResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productDb = _unitOfWork.Products.Get(id);
            if (productDb == null)
                return BadRequest();

            _unitOfWork.Products.Remove(productDb.Result);
            _unitOfWork.Complete();
            return new OkResult();
        }
    }
}
