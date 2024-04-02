using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {

        private readonly SellersService _sellerServices;
        private readonly DepartmentService _departmentService;

        public SellersController(SellersService _sellerServices, DepartmentService _departmentService) {
            this._sellerServices = _sellerServices;
            this._departmentService = _departmentService;
        }

        public IActionResult Index() {

            var list = _sellerServices.FindAll();

            return View(list);
        }

        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel{ Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) { 
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {
            if(id == null) {
                return NotFound();
            }
            var obj = _sellerServices.FindById(id.Value);
            if(obj == null) {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
