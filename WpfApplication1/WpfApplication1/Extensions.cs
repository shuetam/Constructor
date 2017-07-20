using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   public static class Extensions
    {
        public static string ts3(this double value)
        {
            return value.ToString("#,###");
        }
    }
}
