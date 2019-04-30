using BL.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class BulkInsertInputDto
    {
       // [BulkInsertInputDtoValidation]  // custom validation Attribute
        [Range(100, int.MaxValue)]
        public int BulkNumber { get; set; }
    }

}
