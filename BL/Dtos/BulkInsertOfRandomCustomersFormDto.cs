using BL.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class BulkInsertOfRandomCustomersFormDto
    {
        // [BulkInsertInputDtoValidation]  // custom validation Attribute
        [Range(100, int.MaxValue)]
        [Display(Name = "Number Of new Customers")]
        public int BulkNumber { get; set; }
        public string ResultMessage { get; set; }
        public bool IsFailed { get; set; }

        public DateTime RequestTime { get; set; }


        public BulkInsertOfRandomCustomersFormDto()
        {
            if (RequestTime == null || RequestTime.Date != DateTime.UtcNow.Date)
            {
                RequestTime = DateTime.UtcNow;

            }
        }

    }

}
