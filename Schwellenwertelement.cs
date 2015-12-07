using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anne
{
    class Schwellenwertelement
    {
        double x1;

        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        double x2;

        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        double w1;

        public double W1
        {
            get { return w1; }
            set { w1 = value; }
        }

        double w2;

        public double W2
        {
            get { return w2; }
            set { w2 = value; }
        }

        double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        double t;

        public double T
        {
            get { return t; }
            set { t = value; }
        }

        public Schwellenwertelement()
        {
            x1=x2=w1=w2=y=t=0;
        }

        public void Init()
        {
            Random rnd = new Random();

            w1 = 1.0 - 2 * rnd.NextDouble();
            w2 = 1.0 - 2 * rnd.NextDouble();
            t = 1.0 - 2 * rnd.NextDouble();
        }
    }
}
