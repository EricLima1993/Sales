using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {

        private readonly SellersService _sellerServices;

        public SellersController(SellersService _sellerServices) {
            this._sellerServices = _sellerServices;
        }

        public IActionResult Index() {

            var list = _sellerServices.FindAll();

            return View(list);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) { 
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
