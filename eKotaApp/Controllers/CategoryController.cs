using eKota.DataAccess.Data;
using eKota.DataAccess.Repository.CategoryRepository;
using eKota.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace eKotaApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDatabaseTransaction _dbTransaction;
        public CategoryController(IDatabaseTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _dbTransaction.CategoryRepository.GetAll();
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
                _dbTransaction.CategoryRepository.Add(category);
                _dbTransaction.Commit();
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
            Category? catFromDb = _dbTransaction.CategoryRepository.Get(c => c.Id == id);
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
                _dbTransaction.CategoryRepository.Update(category);
                _dbTransaction.Commit();
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
            Category? catFromDb = _dbTransaction.CategoryRepository.Get(c => c.Id == id);
            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _dbTransaction.CategoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _dbTransaction.CategoryRepository.Remove(category);
            _dbTransaction.Commit();
            TempData["notify"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            
        }
    }
}
