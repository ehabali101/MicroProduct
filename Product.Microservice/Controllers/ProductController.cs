using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core;
using Product.Domain;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _unitOfWork.Products.GetAll();
            return Ok(products.Result);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _unitOfWork.Products.Get(id);
            return Ok(product.Result);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductInfo product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductInfo product)
        {
            var productDb = _unitOfWork.Products.Get(id);
            if (productDb == null)
                return BadRequest();

            productDb.Result.Name = product.Name;
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
            return new OkResult();
        }
    }
}
