using Market.DataAccess.Repository.IRepository;
using Market.Models;
using Market.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Data;


namespace ComputersStore.Controllers
{
  
        [Area("Admin")]
        [Authorize(Roles = SD.Role_Admin)]
        public class MarketController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IVatCalculator _vatCalculator;
            public MarketController(IUnitOfWork unitOfWork, IVatCalculator vatCalculator)
            {
                _unitOfWork = unitOfWork;
                _vatCalculator = vatCalculator;
            }
            public IActionResult Index()
            {
                IEnumerable<Product> products = _unitOfWork.Product.GetAll();
                IEnumerable<ProductViewModel> productViewModels = _vatCalculator.CalculateTotalPriceWithVAT(products);
                return View(productViewModels);

            }


            //Get
            public IActionResult Create()
            {

                return View();
            }

            // POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Product pro)
            {

                _unitOfWork.Product.Add(pro);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            //Get
            public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();

                }
                //  var productFromDb = _db.Products.Find(id);
                var productFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                if (productFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(productFromDbFirst);
            }
            // POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Product pro)
            {


                _unitOfWork.Product.Update(pro);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }




            //Get
            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();

                }
                // var productFromDb = _db.Products.Find(id);
                var productFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                if (productFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(productFromDbFirst);
            }
            // POST
            [HttpPost, ActionName("DeletePost")]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePost(int? id)
            {
                var mar = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                if (mar == null)
                {
                    return NotFound();
                }

                _unitOfWork.Product.Remove(mar);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


        }
    }

