using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Wood : IMaterial
    {
        private string _class;
        private double _density;
        private double _fle_strength;
        private double _she_strength;
        public double FlexuralStrenght { get { return ((_fle_strength * 0.8)); } }
        public double ShearStrenght { get { return _she_strength; } }
        public string Class { get { return _class; } }
        public double Density { get { return _density; } }

    public Wood (string _class, double _fle_strength, double _she_strength, double _density)
        {
            this._class = _class;
            this._fle_strength = _fle_strength;
            this._she_strength = _she_strength;
            this._density = _density;
        }

      static public IEnumerable <Wood> GetWood()
        {
            yield return new Wood("C24", 24000, 4000, 4.2);
            yield return new Wood("C27", 27000, 4000, 4.5);
            yield return new Wood("C30", 30000, 4000, 4.6);
            yield return new Wood("C36", 36000, 4000, 4.8);
        } 
    }
}
