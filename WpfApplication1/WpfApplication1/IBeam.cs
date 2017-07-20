using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public interface IBeam
    {
        double Lenght { get;  }

        void Reactions(ILoad load);
        double maxMoment(ILoad load);
        double maxForce(ILoad load);
        IEnumerable <string> GetResults(ILoad load);

    }
}
