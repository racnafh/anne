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
        Fkt activFkt;
        List<Weight> connections;
        Ellipse elli;
        double input;
        double output;

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

        public Ellipse Elli
        {
            get
            {
                return elli;
            }
        }

        public OutputNeuron()
        {
            activFkt = new Fkt();
            connections = new List<Weight>();
            elli = new Ellipse();
            elli.Width = 50;
            elli.Height = 50;
            elli.Stroke = Brushes.Black;
            elli.Fill = Brushes.Blue;
        }

        public void setFkt(ushort Index) { activFkt.Fktindex = Index; }

        public ushort getFkt() { return activFkt.Fktindex; }

        public void addConnection(InputNeuron IntNeu, double IntVal) { connections.Add(new Weight(IntNeu, IntVal)); }

        void sumWeightedInput()
        {
            input = 0;
            foreach (Weight wgt in connections)
                input += wgt.getWeightedInput();
        }
    }
}
