using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anne
{
    class Weight
    {
        double value;

        InputNeuron inNeu;

        public Weight(InputNeuron IntNeu, double IntVal) { value = IntVal; inNeu = IntNeu; }

        public double getWeightedInput() { return inNeu.Output * value; }
    }
}
