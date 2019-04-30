using DAL.CustomAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.ConstantsAndGlobals.Enums;

namespace DAL.Models
{
    public class Customer : BaseEntity
    {
        [From18To70Years] //Custome Validation
        public int Age { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DepartmentNames Gender { get; set; }

        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public virtual CustomerType CustomerType { get; set; }
    }

}
