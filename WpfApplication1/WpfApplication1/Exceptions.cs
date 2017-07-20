using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class BeamLenghtException : Exception
    {
        public BeamLenghtException(double minlenght, double maxlenght) : base($"Wprowadź długość elementu od {minlenght} do {maxlenght}") { }
    }

    class XException : Exception
    {
        public XException(double lenght) : base($"Punkt przyłożenia siły poza elementem, wprowadź wartość mniejszą niż: {lenght}") { }
    }

    class TooLargeArea : Exception
    {
        public TooLargeArea(double maxarea) : base($"Za duże wymiary przekroju, powierzchnia przekroju nie powinna przekraczać {maxarea} m2") { }
    }

    class WrongDimensions : Exception
    {
        public WrongDimensions() : base($"Podano niewłaściwe wymiary przekroju.") { }
    }
}

