using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace anne
{
    class OutputNeuron
    {
        private static int index;
        public static int Index
        {
            get { return index; }
        }
        private bool counterReduced = false;
        Fkt activFkt;
        List<Weight> connections;
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
        }

        public double Output
        {
            get
            {
                sumWeightedInput();
                return output = activFkt.calculateOutput(input);
            }
        }

        public OutputNeuron() { activFkt = new Fkt(); connections = new List<Weight>(); number = index++; }

        public void setFkt(ushort Index) { activFkt.Fktindex = Index; }

        public ushort getFkt() { return activFkt.Fktindex; }

        public void addConnection(InputNeuron IntNeu, double IntVal) { connections.Add(new Weight(IntNeu, IntVal)); }

        void sumWeightedInput()
        {
            input = 0;
            foreach (Weight wgt in connections)
                input += wgt.getWeightedInput();
        }

        // Destruktor 
        ~OutputNeuron()
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
