using DAL.CustomAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.ConstantsAndGlobals.Enums;

namespace BL.Dtos
{
    public class CustomerDto
    {
       // [JsonIgnore]
        public int Id { get; set; }

        [From18To70Years]
        public int Age { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DepartmentNames Gender { get; set; }

        public string GenderName { get; set; }
        
        public int CustomerTypeId { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Created On")]
        //[JsonConverter(typeof(DateFormatConverter))]
        public DateTime CreationDate { get; set; }

        public string CreatingDate { get; set; }
        
        public string CustomerTypeName { get; set; }
        public virtual CustomerTypeDto CustomerType { get; set; }


    }
}
