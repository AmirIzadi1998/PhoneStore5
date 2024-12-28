using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore5.Models;
using PhoneStore5.Repository;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace PhoneStore5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _product;

        public HomeController(IProduct product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _product.GetAll();

            return View(result);
        }

        public async Task<IActionResult> Insert()
        {

            return View();
        }
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _product.GetById(Id);
            return View(result);
        }
        public async Task<IActionResult> Search(int Id)
        {

            if (ModelState.IsValid)
            {
                var result = await _product.GetById(Id);
                if (result == null)
                {
                    TempData["error"] = "مقدار وارد شده یافت نشد";
                    return RedirectToAction(nameof(Index));

                }
                return View(result);
            }
            TempData["error"] = "مقدار وارد شده یافت نشد";
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _product.Delete(Id);

            TempData["success"] = "با موفقیت حذف شد";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Insert(PhoneProduct phoneProduct)
        {
            await _product.Insert(phoneProduct);
            TempData["success"] = "با موفقیت اضافه شد";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Update(PhoneProduct phoneProduct)
        {
            await _product.Update(phoneProduct);
            TempData["success"] = "با موفقیت ویرایش شد";
            return RedirectToAction(nameof(Index));
        }


    }
}


