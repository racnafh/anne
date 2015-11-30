using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace anne
{
    class InputNeuron
    {
        private static int index;
        public static int Index
        {
            get { return index; }
        }
        private bool counterReduced = false;
        Fkt activFkt;
        double input;
        double output;
        int number;

        public int Number
        {
            get { return number; }
        }

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

        public InputNeuron() { activFkt = new Fkt(); Input = 0; number=index++; }

        public void setFkt(ushort index) { activFkt.Fktindex = index; output = activFkt.calculateOutput(input); }

        public ushort getFkt() { return activFkt.Fktindex; }

        // Destruktor 
        ~InputNeuron()
        { 
            if(! counterReduced) 
                index--; 
        } 
        // Dispose aus der IDisposable-Schnittstelle 
        public void Dispose()
        {
            if (!counterReduced)
            {
                index--;
                counterReduced = true;
            }
        } 
    }
}
