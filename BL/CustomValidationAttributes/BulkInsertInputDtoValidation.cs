using BL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CustomValidationAttributes
{
    public class BulkInsertInputDtoValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = (BulkInsertInputDto)validationContext.ObjectInstance;

            return (obj.BulkNumber >= 100)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be from 18 to 70 years old.");
        }


    }
}
