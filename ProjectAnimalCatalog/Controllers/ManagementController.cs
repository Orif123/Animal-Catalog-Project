using Microsoft.AspNetCore.Mvc;
using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.Repositories;

namespace ProjectAnimalCatalog.Controllers
{
    public class ManagementController : Controller
    {
        #region Dependency Injection
        private readonly IRepository _repository;
        public ManagementController(IRepository repository)
        {
            _repository = repository;
        }
        #endregion
        #region Manager Representation
        public IActionResult Edit()
        {
            return View(_repository.GetAll());
        }
        #endregion
        #region Add Animal
        public IActionResult NewAnimal()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add( Animal animal)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(animal);
                return RedirectToAction("Edit");
            }
            return View("NewAnimal");
        }
        #endregion
        #region Delete Animal
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Edit");
        }
        #endregion
        #region Update Animal
        public IActionResult Update(int id)
        {
            return View(_repository.GetById(id));
        }
        [HttpGet]
        public IActionResult UpdateData(Animal animal)
        {
            if (ModelState.IsValid)
            {

                _repository.Update(animal);
                return RedirectToAction("Edit");
            }
            return View("Update", new {id=animal.AnimalsId });
        }
        #endregion
    }
}
