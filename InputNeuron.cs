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
        Fkt activFkt;
        Ellipse elli;
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

        public Ellipse Elli
        {
            get
            {
                return elli;
            }
        }

        public InputNeuron()
        {
            activFkt = new Fkt();
            Input = 0;
            elli = new Ellipse();
            elli.Width = 50;
            elli.Height = 50;
            elli.Stroke = Brushes.Black;
            elli.Fill = Brushes.Red;
        }

        public void setFkt(ushort index) { activFkt.Fktindex = index; output = activFkt.calculateOutput(input); }

        public ushort getFkt() { return activFkt.Fktindex; }
    }
}
