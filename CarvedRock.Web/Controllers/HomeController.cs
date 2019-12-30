using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarvedRock.Web.Models;
using CarvedRock.Web.Clients;

namespace CarvedRock.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductHttpClient _httpClient;
        private readonly ProductGraphClient _graphClient;

        public HomeController(ProductHttpClient httpClient, ProductGraphClient graphClient)
        {
            _httpClient = httpClient;
            _graphClient = graphClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetProducts();
            response.ThrowErrors();
            return View(response.Data.Products);
        }

        public async Task<IActionResult> ProductDetail(int productId = 8)
        {
            var product = await _graphClient.GetProduct(productId);
            return View(product); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
