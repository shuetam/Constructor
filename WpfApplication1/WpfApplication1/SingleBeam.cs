using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class SingleBeam : IBeam
    {
        private double _lenght;
        public double Reaction1 { get { return _reaction1; } }
        public double Reaction2 { get { return _reaction2; } }
        private double _minlenght = 0.01;
        private double _maxlenght = 100;
        private double _reaction1, _reaction2;


        public SingleBeam(double lenght)
        {
            if (lenght > _maxlenght || lenght < _minlenght) { _lenght = 100; throw new BeamLenghtException(_minlenght, _maxlenght); }
            else _lenght = lenght;
        }


        public double Lenght
        {
            get
            { return _lenght; }

        }

        public void Reactions(ILoad load)
        {
            _reaction2 = (load.Value * load.CenterOfGravity) / _lenght;
            _reaction1 = (load.Value * (_lenght - load.CenterOfGravity)) / _lenght;
        }

        public double maxMoment(ILoad load)
        {
            if (load.GetType() == typeof(ContinuousLoad))
            {
                return (load.Value * this._lenght) / 8;
            }

            if (load.GetType() == typeof(FocusForce))
            { return (((load.Value * (_lenght - load.CenterOfGravity)) / _lenght)) * load.CenterOfGravity; }
            else return 0;
        }

        public double maxForce(ILoad load)
        {
            if (load.CenterOfGravity == 0 || load.CenterOfGravity == _lenght) return 0;
            else
          return  Math.Max(_reaction1, _reaction2);
        }
        

       public IEnumerable<string> GetResults(ILoad load)
        {
            yield return $"Maksymlany moment zginajacy belkę: {maxMoment(load)} kNm";
            yield return $"Reakcja R1: {Reaction1} kN";
            yield return $"Reakcja R2: {Reaction2} kN";
        }

    }
}
