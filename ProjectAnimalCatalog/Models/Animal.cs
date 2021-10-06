using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectAnimalCatalog.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Comments = new HashSet<Comment>();
        }
        [DisplayName("Catalog number")]
        public int AnimalsId { get; set; }
        [Required]
        [Display]
        [RegularExpression("^[A-Z].+", ErrorMessage = "Name must start with capital letter")]
        public string Name { get; set; }
        [Required]
        [Range(0, 150)]
        public byte Age { get; set; }
        [Required]
        [RegularExpression("^(http|https)://.+", ErrorMessage = "url must start with https://(or http...) ")]
        [DisplayName("Photo")]
        [Bindable(true)]
        public string PictureName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage ="Its too long")]
        public string Description { get; set; }
        [Required]
        [Range(0,5, ErrorMessage ="This id has no category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual  ICollection<Comment> Comments { get; set; }
    }
}
