using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Basics.Core.Utils
{
    public static class AppUtils
    {
        public static bool IsValidGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
