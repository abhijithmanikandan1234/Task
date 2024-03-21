using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]

        public int Department_Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]

        public string Employees { get; set; }
    }
}