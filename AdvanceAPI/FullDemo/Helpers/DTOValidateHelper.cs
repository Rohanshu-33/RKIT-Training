using FullDemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullDemo.Helpers
{
    internal class DTOValidateHelper
    {
        internal static List<string> ValidateDTO<DTO>(DTO dto) where DTO : class
        {
            var context = new ValidationContext(dto, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, true))
            {
                return results.Select(r => r.ErrorMessage).ToList();
            }

            return new List<string>(); // No errors
        }

    }
}
