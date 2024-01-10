using ECommerceProject.DataAccess.Data;
using ECommerceProject.DataAccess.Repository;
using ECommerceProject.DataAccess.Repository.IRepository;
using ECommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Areas.Admin.Controllers
{
    //the : is like extends for Java. inheritance
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList(); //how can i transfer this to the view? pass this as param then use @model sa view
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();

        }

        //we need to pass the id that the user wants to edit
        public IActionResult Edit(int? id)
        {
            Category? category = _categoryRepo.GetValue(category => category.Id == id);
            if (id == null || id == 0 || category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //do i need a post handler for this?
        public IActionResult Delete(int? id)
        {
            //Category? category = _categoryRepo.Categories.FirstOrDefault(category => category.Id == id);
            Category? category = _categoryRepo.GetValue(category => category.Id == id);
            if (id == null || id == 0 || category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //use this annotation to handle post requests for category/create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //validation check -> ModelState checks if the obejct(parameter) is valid, it will go to the class, check for validation
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save(); //this is needed to perform the Add method above
                //use this for notification, temporary data to be rendered to the next page
                TempData["success"] = "Category created successfully";
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //validation check -> ModelState checks if the obejct(parameter) is valid, it will go to the class, check for validation
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category); //using the primary key, this will update the catogry sa database
                _categoryRepo.Save(); //this is needed to perform the Add method above
                                      //use this for notification, temporary data to be rendered to the next page
                TempData["success"] = "Category updated successfully";
            }

            return RedirectToAction("Index", "Category");

        }

        [HttpPost, ActionName("Delete")]//ActionName is used para ma set na yung Delete yung nag trigger ng action
        public IActionResult DeletePOST(Category category)
        {
            _categoryRepo.Delete(category);
            _categoryRepo.Save();
            TempData["success"] = "Category removed successfully";
            return RedirectToAction("Index", "Category");

        }
    }
}
