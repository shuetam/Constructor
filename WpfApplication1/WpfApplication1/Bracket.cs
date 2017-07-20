using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Bracket : IBeam
    {

        private double _lenght;
        public double Reaction1 { get { return _reaction1; } }
        private double _minlenght = 0.01;
        private double _maxlenght = 50;
        private double _reaction1;


        public Bracket(double lenght)
        {
            if (lenght > _maxlenght || lenght< _minlenght) { _lenght = 100; throw new BeamLenghtException(_minlenght,_maxlenght); }
            else _lenght = lenght;
        }


        public double Lenght
        {
            get
            {
                { return _lenght; }
            }
        }

        public double maxForce(ILoad load)
        {
            if (load.CenterOfGravity == _lenght) return 0;
            else
                return load.Value;
        }

        public double maxMoment(ILoad load)
        {
           return (load.Value * (_lenght - load.CenterOfGravity));
        }

        public void Reactions(ILoad load)
        {
            _reaction1 = (load.Value * (_lenght - load.CenterOfGravity));
        }

        public IEnumerable<string> GetResults(ILoad load)
        {
            yield return $"Maksymalna siła ścinająca wspornik: {load.Value} kN";
            yield return $"Moment podporowy: {_reaction1} kNm";
          
        }
    }
}
