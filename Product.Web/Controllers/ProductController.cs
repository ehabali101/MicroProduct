using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Web.Models;

namespace Product.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");

                //HTTP GET
                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<ProductViewModel>>();
                    //readTask.Wait();

                    //products = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    products = Enumerable.Empty<ProductViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }
            
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/product");

                //HTTP POST
                //var response = client.PostAsync<ProductViewModel>("product", viewModel);
                //response.Wait();

                //var result = response.Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(viewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}