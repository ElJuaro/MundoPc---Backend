using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
