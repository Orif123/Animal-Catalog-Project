using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.ViewModels;
using System.Collections.Generic;

namespace ProjectAnimalCatalog.Repositories
{
    public interface IRepository
    {
        #region Repository Interface
        IEnumerable<Animal> GetAll();
       Animal GetById(int id);
        void Insert(Animal animal);
        void Update(Animal animal);
        void Delete(int id);
        List<Animal> GetAnimalsByCategory(int id);
        AnimalCommentsDetails GetAnimalDetails(int id);
        List<Animal> GetFirstTwoAnimals();
        #endregion
    }
}
