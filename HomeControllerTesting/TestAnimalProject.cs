using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectAnimalCatalog.Controllers;
using ProjectAnimalCatalog.Cotrollers;
using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.Repositories;
using ProjectAnimalCatalog.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace TestAnimalProject
{
    [TestClass]
    public class HomeControllerTest
    {
        #region Home controller tests
        [TestMethod]
        public void HomePageRepositoryShouldReturnTwoAnimals()
        {
            var repository = new Mock<IRepository>();
            List<Animal> animalList = GetAnimals();
            repository.Setup(rep => rep.GetFirstTwoAnimals()).Returns(animalList);
            HomeController controller = new HomeController(repository.Object);

            var result = controller.HomePage();
            var myresult = result as ViewResult;
            var listResult = (List<Animal>)myresult.Model;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(listResult[i], animalList[i]);
            }
        }
        #endregion
        #region Validadion Add Tests
        [TestMethod]
        public void AddModelStateValidCreateAnimalOnce()
        {
            var mockRepo = new Mock<IRepository>();
            Animal animal = null;
            mockRepo.Setup(r => r.Insert(It.IsAny<Animal>()))
                .Callback<Animal>(x => animal = x);
            var newanimal = new Animal()
            {
                AnimalsId = 1,
                Age = 1,
                Name = "testname",
                CategoryId = 2,
                Description = "This is an animal for testing",
                PictureName = "afafsdfsdfs"

            };
            var controller = new ManagementController(mockRepo.Object);
            controller.Add(newanimal);
            mockRepo.Verify(x => x.Insert(It.IsAny<Animal>()), Times.Once);
            Assert.AreEqual(animal.Name, newanimal.Name);
            Assert.AreEqual(animal.Age, newanimal.Age);
            Assert.AreEqual(animal.AnimalsId, newanimal.AnimalsId);
            Assert.AreEqual(animal.CategoryId, newanimal.CategoryId);
            Assert.AreEqual(animal.Description, newanimal.Description);
            Assert.AreEqual(animal.PictureName, newanimal.PictureName);
        }
        [TestMethod]
        public void Add_InvalidModelState_AddAnimalNeverExecutes()
        {
            var mockRepo = new Mock<IRepository>();
            var controller = new ManagementController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Name is required");
            var animal = new Animal { Age = 34, AnimalsId = 3, CategoryId = 3, Description = "mikjmiuml", PictureName = "dtfdgg" };
            controller.Add(animal);
            mockRepo.Verify(x => x.Insert(It.IsAny<Animal>()), Times.Never);
        }
        #endregion
        #region Validation Update Tests
        [TestMethod]
        public void UpdateModelStateValidUpdateAnimalOnce()
        {
            var mockRepo = new Mock<IRepository>();
            Animal animal = null;
            mockRepo.Setup(r => r.Update(It.IsAny<Animal>()))
                .Callback<Animal>(x => animal = x);
            var newanimal = new Animal()
            {
                AnimalsId = 1,
                Age = 1,
                Name = "testname",
                CategoryId = 2,
                Description = "This is an animal for testing",
                PictureName = "afafsdfsdfs"
            };
            var controller = new ManagementController(mockRepo.Object);
            controller.UpdateData(newanimal);
            mockRepo.Verify(x => x.Update(It.IsAny<Animal>()), Times.Once);
            Assert.AreEqual(animal.Name, newanimal.Name);
            Assert.AreEqual(animal.Age, newanimal.Age);
            Assert.AreEqual(animal.AnimalsId, newanimal.AnimalsId);
            Assert.AreEqual(animal.CategoryId, newanimal.CategoryId);
            Assert.AreEqual(animal.Description, newanimal.Description);
            Assert.AreEqual(animal.PictureName, newanimal.PictureName);
        }
        [TestMethod]
        public void Update_InvalidModelState_UpdateAnimalNeverExecutes()
        {
            var mockRepo = new Mock<IRepository>();
            var controller = new ManagementController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Name is required");
            var animal = new Animal { Age = 34, AnimalsId = 8, CategoryId = 3, Description = "mikjmiuml", PictureName = "dtfdgg" };
            controller.Update(animal.AnimalsId);
            mockRepo.Verify(x => x.Update(It.IsAny<Animal>()), Times.Never);
        }
        #endregion
        #region Validation Comment Test
        [TestMethod]
        public void NewCommentStateValidAddCommentOnce()
        {
            var mockRepo = new Mock<IRepository>();
            var commentmockRepo = new Mock<ICommentRep>();
            Comment comment = null;
            commentmockRepo.Setup(r => r.NewComment(It.IsAny<Comment>()))
                .Callback<Comment>(x => comment = x);
            var newcom = new Comment()
            {
                CommentId=1,
                AnimalId=3,
                Comment1="This is comment for testing"
            };
            var controller = new CatalogController(mockRepo.Object, commentmockRepo.Object);
            controller.AddComment(newcom);
            commentmockRepo.Verify(x => x.NewComment(It.IsAny<Comment>()), Times.Once);
            Assert.AreEqual(comment.CommentId, newcom.CommentId);
            Assert.AreEqual(comment.AnimalId, newcom.AnimalId);
            Assert.AreEqual(comment.Comment1, newcom.Comment1);
        }
        [TestMethod]
        public void Update_InvalidModelState_NewCommentNeverExecutes()
        {
            var mockRepo = new Mock<IRepository>();
            var commentmockRepo = new Mock<ICommentRep>();
            var controller = new CatalogController(mockRepo.Object, commentmockRepo.Object);
            controller.ModelState.AddModelError("comment1", "you need comment");
            var comment = new Comment { CommentId=1, AnimalId=1 };
            controller.AddComment(comment);
            mockRepo.Verify(x => x.Update(It.IsAny<Animal>()), Times.Never);
        }
        #endregion
        #region Catalog Tests
        [TestMethod]
        public void GetAllAnimalsInCatalog()
        {
            var mockRepo = new Mock<IRepository>();
            var commentMockRepo = new Mock<ICommentRep>();
            var animaltochecklist = GetAnimals();
            mockRepo.Setup(rep => rep.GetAll()).Returns(animaltochecklist);
            var controller = new CatalogController(mockRepo.Object, commentMockRepo.Object);

            var result = controller.HomeCatalog();
            var myresult = result as ViewResult;
            var listresult = (List<Animal>)myresult.Model;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            for (int i = 0; i < GetAnimals().Count(); i++)
            {
                Assert.AreEqual(animaltochecklist[i], listresult[i]);
            }
        }
        [TestMethod]
        public void GetAnimalsInCatalogByCategory()
        {
            var numcategory = 2;
            var mockRepo = new Mock<IRepository>();
            var commentMockRepo = new Mock<ICommentRep>();
            var animaltochecklist = GetAnimals();
            mockRepo.Setup(rep => rep.GetAnimalsByCategory(numcategory)).Returns(animaltochecklist);
            var controller = new CatalogController(mockRepo.Object, commentMockRepo.Object);

            var result = controller.CategoryCatalog(numcategory);
            var myresult = result as ViewResult;
            var listresult = (List<Animal>)myresult.Model;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            for (int i = 0; i < GetAnimals().Count(); i++)
            {
                Assert.AreEqual(animaltochecklist[i], listresult[i]);
            }
        }
        [TestMethod]
        public void AnimalPage_retunrViewWithAnimalId()
        {
            var mockRepo = new Mock<IRepository>();
            var commentMockRepo = new Mock<ICommentRep>();
            var animaldetailslist = GetAnimalCommentsDetails();
            var controller = new CatalogController(mockRepo.Object, commentMockRepo.Object);
            mockRepo.Setup(repo => repo.GetAnimalDetails(1)).Returns(animaldetailslist);
            var result = controller.Details(1);
            var MyViewResult = controller.Details(1) as ViewResult;
            var mymodelResultAnimal = (AnimalCommentsDetails)MyViewResult.Model;
            Assert.AreEqual(animaldetailslist.animals.Take(1).GetType(), mymodelResultAnimal.animals.Take(1).GetType());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        #endregion
        public List<Animal> GetAnimals()
        {
            var comments = new List<Comment>()
            {
                new Comment{CommentId=1, AnimalId=1, Comment1="dsaofdsoifha"},
                new Comment{CommentId=2, AnimalId=1, Comment1="dsaofdsoifha"}
            };
            var otherComments = new List<Comment>()
            {
                new Comment{CommentId=3, AnimalId=2, Comment1="joijasod"}
            };
            var list = new List<Animal>()
            {
                new Animal{AnimalsId=1, Age=2, CategoryId=3, Description="dsasfsds", Name="FASDF", PictureName="https://www.youtube.com/watch?v=R3wpqKClxjU&t=679s",Comments=comments},
                new Animal{AnimalsId=2, Age=2, CategoryId=3, Description="dsasfsds", Name="FASDF", PictureName="https://www.youtube.com/watch?v=R3wpqKClxjU&t=679s", Comments=otherComments},
                new Animal{AnimalsId=3, Age=2, CategoryId=3, Description="dsasfsds", Name="FASDF", PictureName="https://www.youtube.com/watch?v=R3wpqKClxjU&t=679s"}
            };
            return list;
        }
        public AnimalCommentsDetails GetAnimalCommentsDetails()
        {
            var animalCommentDetails = new AnimalCommentsDetails()
            {
                animals = new List<Animal>()
                {
                    new Animal { AnimalsId = 1, Age = 2, CategoryId = 3, Description = "hkiuykjjfhdhf", Name = "ori", PictureName = "carscasdrasda" }, 
                    new Animal { AnimalsId = 2, Age = 2, CategoryId = 3, Description = "hkiuykjjfhdhf", Name = "othername", PictureName = "carscasdrasda" }
                },
            
                comments = new List<Comment>()
                {
                    new Comment{CommentId=1, AnimalId=1, Comment1="this is test method"}
                }
            };
            return animalCommentDetails;
        }
    }
}
