using BL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersApp.ViewModels
{
    public class BulkInsertOfRandomCustomersFormVM
    {
        [Range(100, int.MaxValue)]
        [Display(Name = "Number Of new Customers")]
        public int BulkNumber { get; set; }
        public string ResultMessage { get; set; }
        public bool IsFailed { get; set; }

        public DateTime RequestTime { get; set; }


        public BulkInsertOfRandomCustomersFormVM()
        {
            RequestTime = DateTime.UtcNow;
        }

    }
    
     
}