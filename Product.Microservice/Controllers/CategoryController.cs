using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core;
using Product.Microservice.ViewModels;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _unitOfWork.Categories.GetAll();
            var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories.Result);
            return Ok(viewModel);
        }   
    }
}
