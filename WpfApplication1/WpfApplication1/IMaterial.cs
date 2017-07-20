using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   public interface IMaterial
    {
        string Class { get;  }
        double Density { get; }
        double FlexuralStrenght { get; }
        double ShearStrenght { get; }

    }
}
