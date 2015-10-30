using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anne
{
    class InputNeuron
    {
        Fkt activFkt;

        double input;
        double output;

        public double Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
                output = activFkt.calculateOutput(input);
            }
        }

        public double Output
        {
            get
            {
                return output;
            }
        }

        public InputNeuron() { activFkt = new Fkt(); Input = 0; }

        public void setFkt(ushort index) { activFkt.Fktindex = index; output = activFkt.calculateOutput(input); }

        public ushort getFkt() { return activFkt.Fktindex; }
    }
}
