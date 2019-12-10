using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nile.Web.Models
{
    public static class ViewModelExtension
    {
        public static ViewModel ToModel ( this Product source )
        {
            if (source == null)
                return null;

            return new ViewModel () 
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                IsDiscontinued = source.IsDiscontinued,
                Price = source.Price
            };
        }
        public static Product ToDomain ( this ViewModel source )
        {
            if (source == null)
                return null;

            return new Product () 
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                IsDiscontinued = source.IsDiscontinued,
                Price = source.Price
            };
        }
    }
}