using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nile.Web.Models
{
    public class ViewModel
    {
        //ID, Name, Price, Description, IsDiscontinued
        [Range (0.0, Int32.MaxValue, ErrorMessage = "ID must be equal to or greater than 0")]
        public int Id { get; set; }
        
        [Required (AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range (0.0, Int32.MaxValue, ErrorMessage = "Price must be equal to or greater than 0")]
        public decimal Price { get; set; }

        public bool IsDiscontinued { get; set; }
    }
}
