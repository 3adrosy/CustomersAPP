using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConstantsAndGlobals
{
    public static class Enums
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DepartmentNames
        {
            Female,
            Male
        }

    }
}
