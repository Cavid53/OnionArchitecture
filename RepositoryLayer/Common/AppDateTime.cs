using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Common
{
    public class AppDateTime
    {
        public static DateTime Now => DateTime.UtcNow.AddHours(4);
        public static int CurrentYear => Now.Year;
    }
}
