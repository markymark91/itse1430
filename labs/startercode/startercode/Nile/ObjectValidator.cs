using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidateObject ( IValidatableObject value )
        {
            var context = new ValidationContext (value);

            var results = new List<ValidationResult> ();

            Validator.TryValidateObject (value, context, results);

            foreach (var result in results)
                yield return result;
        }
    }
}