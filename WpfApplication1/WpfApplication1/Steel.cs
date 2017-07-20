using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Steel : IMaterial
    {
        private string _class;
        private double _density;
        private double _ductility;
        public string Class { get { return _class; } }
        public double Density { get { return _density; } }
        public double Ductility { get { return _ductility; } }


        public double Weight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double FlexuralStrenght
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double ShearStrenght
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Steel(string _class, double _density)
        {
            this._class = _class;
            this._density = _density;
            _ductility = (double.Parse(Class)) / 0.9;
        }

    }
}
