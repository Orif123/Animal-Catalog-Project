using ProjectAnimalCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAnimalCatalog.ViewModels
{
    public class AnimalCommentsDetails
    {
        public List< Animal> animals { get; set; }
        public List< Comment> comments { get; set; }
    }
}
