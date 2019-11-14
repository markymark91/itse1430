using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidateObject(IValidatableObject value)
        {
            var context = new ValidationContext (value);

            var results = new List<ValidationResult>();

            Validator.TryValidateObject (value, context, results, true);

            foreach (var result in results)
                yield return result;
        }
    }
}
