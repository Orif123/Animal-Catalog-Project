using Microsoft.EntityFrameworkCore;
using ProjectAnimalCatalog.Data;
using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAnimalCatalog.Repositories
{
   
    public class MyRepository : IRepository
    {
        #region Dependency Injection
        private readonly ASPNETCOREPROJECTContext _context;
        public MyRepository(ASPNETCOREPROJECTContext context)
        {
            _context = context;
        }
        #endregion
        #region Home Page Functions
        public List <Animal> GetFirstTwoAnimals()
        {
            var list = _context.Animals.OrderByDescending(animal => animal.Comments.Count()).Take(2).ToList();
            return list;
        }
        #endregion
        #region Catalog Functions
        public IEnumerable<Animal> GetAll()
        {
            var list = _context.Animals.ToList();
            return list;
        }
        public AnimalCommentsDetails GetAnimalDetails(int id)
        {
            AnimalCommentsDetails cd = new AnimalCommentsDetails();
            cd.animals = _context.Animals.FromSqlRaw($"select * from Animals where AnimalsID={id}").ToList(); /*_context.Animals.FromSqlRaw($"select * from Animals where AnimalsID={id}").ToList();*/
            cd.comments = _context.Comments.FromSqlRaw($"select * from Comments where AnimalID={id}").ToList();
            return cd;
        }
        public List <Animal> GetAnimalsByCategory(int id)
        {
            var list = _context.Animals.FromSqlRaw($"select * from Animals where Animals.CategoryID ={id}").ToList();
            return list;
        }
        public Animal GetById(int id)
        {
            Animal animal = _context.Animals.SingleOrDefault(a => a.AnimalsId == id);
            return animal;
        }
        #endregion
        #region Management Functions
        public void Insert(Animal animal)
        {
            if (_context.Animals.Any() != true)
            {
                animal.AnimalsId = 1;
                _context.Animals.Add(animal);
                _context.SaveChanges();
            }
            else
            {
                animal.AnimalsId = _context.Animals.Max(animal => animal.AnimalsId) + 1;
                _context.Animals.Add(animal);
                _context.SaveChanges();
            }
        }
        public void Update(Animal animal)
        {
            Animal updatedanimal = _context.Animals.SingleOrDefault(a => a.AnimalsId == animal.AnimalsId);
            updatedanimal.AnimalsId = animal.AnimalsId;
            updatedanimal.Name = animal.Name;
            updatedanimal.Age = animal.Age;
            updatedanimal.Description = animal.Description;
            updatedanimal.PictureName = animal.PictureName;
            updatedanimal.CategoryId = animal.CategoryId;
            _context.Update(updatedanimal);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Animal animal = _context.Animals.SingleOrDefault(a => a.AnimalsId == id);
            List <Comment> comment = _context.Comments.FromSqlRaw($"Select * from Comments Where Comments.AnimalId={id}").ToList();
            _context.Comments.RemoveRange(comment);
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
        #endregion
    }
}
