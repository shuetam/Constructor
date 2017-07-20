using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class RecProfile : IProfile
    {
        private double _height; //m
        private double _widht; //m
        private double _area; //m2
        private double _max_area = 5; //m2
        private double _momentOFInertia;
        private double _weight;
        private double _fle_tension;
        private double _she_tension;
        private double _fle_effort;
        private double _she_effort;

        public double Area { get { return _area; } }
        public double MomentOFInertia { get { return _momentOFInertia; } }
        public double Weight { get { return _weight; } }
        public double FlexuralTension { get { return _fle_tension; } }
        public double ShearTension { get { return _she_tension; } }
        public double FlexuralEffort { get { return _fle_effort; } }
        public double ShearEffort { get { return _she_effort; } }

        private double _strenght;
       

      public  RecProfile (double h, double b, IMaterial material, IBeam beam, ILoad load)
        {
            _height = h;
            _widht = b;

            if (h * b > _max_area) { _area = 0; throw new TooLargeArea(_max_area); }
            else
            {
                _area = h * b;
                if (_area == 0) { throw new WrongDimensions(); }
            }
            _momentOFInertia = (b * Math.Pow(h, 3)) / 12;
             _weight = _area * material.Density;
            _fle_tension = ( beam.maxMoment(load) + ((_weight*(Math.Pow(beam.Lenght,2)))/8))  / (_momentOFInertia / (h / 2));
            _she_tension = (beam.maxForce(load) + beam.Lenght*_weight) * (1.5 * _height);
            _fle_effort = _fle_tension / material.FlexuralStrenght;
            _strenght = material.FlexuralStrenght;
            _she_effort = _she_tension / material.ShearStrenght;

    }

      public IEnumerable <string>  GetResults()
        {
            yield return $"Powierzchnia przekroju: {(Area*10000)} cm2";
            yield return $"Waga przekroju: {Weight} kN/m";
            yield return $"Moment bezwładności przekroju: {MomentOFInertia} m4";
            yield return $"Naprężenia styczne w przekroju: {ShearTension} kPa";
            yield return $"Naprężenia normalne w przekroju: {FlexuralTension} kPa";
            yield return $"Wytrzymałość drewna na zginanie: {_strenght} kPa";
            yield return $"Wytężenie przekroju: {(FlexuralEffort*100)} %";
            if ((FlexuralEffort)>=1)
            {
                yield return $"UWAGA! STAN GRANICZNY NOŚNOŚCI PRZEKROCZONY! {Environment.NewLine} PROFIL NIEPOPRAWNY!";
               
            }

            else
            {
                yield return "PROFIL POPRAWNY";
            }
        }

        
    }
}
