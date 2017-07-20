using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   public class ContinuousLoad  : ILoad
    {

        private double _value;
        private double _center_of_gravity;

       public double Value { get { return _value; } }
       public double CenterOfGravity { get { return _center_of_gravity; } }


        public ContinuousLoad (IBeam beam, double valueFromTextbox1)
        {
            _value = valueFromTextbox1 * beam.Lenght;
            _center_of_gravity = beam.Lenght / 2;
        }

    

    }
}
 