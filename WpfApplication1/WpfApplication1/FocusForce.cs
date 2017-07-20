using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class FocusForce : ILoad
    {

        private double _value;
        private double _center_of_gravity;

        public double Value { get { return _value; } }
        public double CenterOfGravity { get { return _center_of_gravity; } }


        public FocusForce(IBeam beam, double valueFromTextbox1, double valueFromTextbox2)
        {
            _value = valueFromTextbox1;
            if (beam.Lenght<valueFromTextbox2) { throw new XException(beam.Lenght); }
            else
            _center_of_gravity = valueFromTextbox2;
        }


    }
}
