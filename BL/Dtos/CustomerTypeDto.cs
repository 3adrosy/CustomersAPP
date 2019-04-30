using DAL.CustomAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.ConstantsAndGlobals.Enums;

namespace BL.Dtos
{
    public class CustomerTypeDto
    {
       // [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<CustomerDto> Customers { get; set; }


    }
}
