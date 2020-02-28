using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServices.Models.InputModels.Categories
{
    public class CategoryInputModel
    {
        [Required(ErrorMessage = "Field name is required and can't be empty.")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}