using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Utilities
{
    public class DateUtils
    {
        public static DateTime GetDateNow()
        {
            return DateTime.UtcNow.AddHours(7);
        }
    }
}
