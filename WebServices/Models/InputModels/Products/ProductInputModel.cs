using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServices.Models.InputModels.Products
{
    public class ProductInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}