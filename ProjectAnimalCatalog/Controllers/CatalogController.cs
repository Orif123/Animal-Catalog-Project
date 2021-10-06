using Microsoft.AspNetCore.Mvc;
using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.Repositories;

namespace ProjectAnimalCatalog.Cotrollers
{
    public class CatalogController : Controller
    {
        #region Dependency Injection
        private readonly IRepository _repository;
        private readonly ICommentRep _commentRep;
        public CatalogController(IRepository repository, ICommentRep commentRep)
        {
            _repository = repository;
            _commentRep = commentRep;
        }
        #endregion
        #region Catalog Actions
        public IActionResult HomeCatalog()
        {
            return View(_repository.GetAll());
        }
        public IActionResult CategoryCatalog(int id)
        {
            return View(_repository.GetAnimalsByCategory(id));
        }
        public IActionResult Details(int id)
        {
            return View(_repository.GetAnimalDetails(id));
        }
        #endregion
        #region Comment Actions
        public IActionResult NewComment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRep.NewComment(comment);
                return RedirectToAction("Details", "Catalog", new {id=comment.AnimalId });
            }
            return View("NewComment", new {id=comment.AnimalId });
        }
        #endregion
    }
}
