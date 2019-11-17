/*
 * Mark Dobbins
 * Lab 4
 * ITSE 1430
 */

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