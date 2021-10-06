using Microsoft.AspNetCore.Mvc;
using ProjectAnimalCatalog.Repositories;

namespace ProjectAnimalCatalog.Controllers
{
    
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        #endregion
        #region Home Page Action
        public IActionResult HomePage()
        {
            return View(_repository.GetFirstTwoAnimals());
        }
        #endregion
    }
}
