using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public interface IProfile
    {

        double Area { get; }
        double MomentOFInertia { get; }
        double FlexuralTension { get; }
        double ShearTension { get; }
        double Weight { get; }
        double FlexuralEffort { get; }
        double ShearEffort { get; }
        IEnumerable<string> GetResults();
    }
}
