using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Task.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]

        public int Product_Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]

        public int Price { get; set; }
    }
}