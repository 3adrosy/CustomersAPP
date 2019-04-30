using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helper
{
    public class BusinessCustomResponse<T>
    {
        public T response { get; set; }
        public bool Success { get; set; } = true;
        public string ErrorMsg { get; set; }

    }
}
