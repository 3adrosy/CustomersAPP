using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomAttributes
{
    public class From18To70Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            return (customer.Age >= 18 && customer.Age <= 70)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be from 18 to 70 years old.");
        }
    }
}
