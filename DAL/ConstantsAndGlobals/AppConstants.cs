using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConstantsAndGlobals
{
    public static class AppConstants
    {
        public const int MinAge = 18;

        public const int MaxAge = 70;

        public const int RequestTimeLimit = 1;

        public const string RequestTimeOutMessage = "The request took time more than allowed 1 minute.";

    }

}
