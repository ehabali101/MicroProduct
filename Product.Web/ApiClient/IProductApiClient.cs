using Product.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Web.ApiClient
{
    public interface IProductApiClient
    {
        Task<ProductViewModel> Create(ProductViewModel viewModel);
    }
}
