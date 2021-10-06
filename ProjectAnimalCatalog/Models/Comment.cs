using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectAnimalCatalog.Models
{
    public partial class Comment
    {
        
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [Required]
        [DisplayName("Comment")]
        public string Comment1 { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
