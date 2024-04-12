using eKota.DataAccess.Data;
using eKota.DataAccess.Repository.CategoryRepository;
using eKota.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace eKotaApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _categoryRepo.GetAll();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["notify"] = "New Category Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? catFromDb = _categoryRepo.Get(c => c.Id == id);
            if(catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                TempData["notify"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? catFromDb = _categoryRepo.Get(c => c.Id == id);
            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _categoryRepo.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(category);
            _categoryRepo.Save();
            TempData["notify"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            
        }
    }
}
