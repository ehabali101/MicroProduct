using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Product.Domain;
using Product.Microservice.ViewModels;

namespace Product.Microservice.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductInfo, ProductViewModel>();
            CreateMap<ProductViewModel, ProductInfo>();
        }
    }
}
