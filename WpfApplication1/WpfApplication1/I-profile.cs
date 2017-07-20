using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class I_Profile : IProfile
    {

        private double _height; //m
        private double _widht; //m
        private double _height2;//m
        private double _width2;//m
        private double _area; //m2
        private double _max_area = 10; //m2
        private double _momentOFInertia;
        private double _weight;
        private double _fle_tension;
        private double _she_tension;
        private double _fle_effort;
        private double _she_effort;
        private double _strenght;
        private double hw;
        private double bw;

        public I_Profile(double H, double B, double h, double t, IMaterial material, IBeam beam, ILoad load)
        {
            _height = H;
            _widht = B;
            _height2 = h;
            _width2 = t;
            hw = H - (2 * h);
            bw = (B - t) / 2;

            if (bw < 0 || hw < 0) { throw new WrongDimensions(); }
            _area = (2 * B * h) + (t * (H - (2 * h)));
            if (_area == 0) { throw new WrongDimensions(); }
            if ( _area > _max_area) { _area = 0; throw new TooLargeArea(_max_area); }
            _momentOFInertia = ((B * Math.Pow(H, 3)) / 12) - (2*((bw * Math.Pow(hw,3))/12));
            _weight = _area * material.Density;
            _fle_tension = (beam.maxMoment(load) + ((_weight * (Math.Pow(beam.Lenght, 2))) / 8)) / (_momentOFInertia / (h / 2));
            _she_tension = (beam.maxForce(load) + beam.Lenght * _weight) * (1.5 * hw);
            _fle_effort = _fle_tension / material.FlexuralStrenght;
            _strenght = material.FlexuralStrenght;
            _she_effort = _she_tension / material.ShearStrenght;

        }



        public double Area
        {
            get
            {
                return _area;
            }
        }

        public double FlexuralEffort
        {
            get
            {
                return _fle_effort;
            }
        }

        public double FlexuralTension
        {
            get
            {
                return _fle_tension;
            }
        }

        public double MomentOFInertia
        {
            get
            {
                return _momentOFInertia;
            }
        }

        public double ShearEffort
        {
            get
            {
                return _she_effort;
            }
        }

        public double ShearTension
        {
            get
            {
                return _she_tension;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
        }

        public IEnumerable<string> GetResults()
        {
            yield return $"Powierzchnia przekroju: {(Area * 10000)} cm2";
            yield return $"Waga przekroju: {Weight} kN/m";
            yield return $"Moment bezwładności przekroju: {MomentOFInertia} m4";
            yield return $"Naprężenia styczne w przekroju: {ShearTension} kPa";
            yield return $"Naprężenia normalne w przekroju: {FlexuralTension} kPa";
            yield return $"Wytrzymałość drewna na zginanie: {_strenght} kPa";
            yield return $"Wytężenie przekroju: {(FlexuralEffort * 100)} %";
            if ((FlexuralEffort) >= 1)
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
