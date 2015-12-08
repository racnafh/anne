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
            set { x1 = Math.Round(value,2); }
        }

        double x2;

        public double X2
        {
            get { return x2; }
            set { x2 = Math.Round(value, 2); }
        }

        double w1;

        public double W1
        {
            get { return w1; }
            set { w1 = Math.Round(value, 2); }
        }

        double w2;

        public double W2
        {
            get { return w2; }
            set { w2 = Math.Round(value, 2); }
        }

        double y;

        public double Y
        {
            get { return y; }
            set { y = Math.Round(value, 2); }
        }

        double t;

        public double T
        {
            get { return t; }
            set { t = Math.Round(value, 2); }
        }

        double error;

        public double Error
        {
            get { return error; }
            set { error = Math.Round(value, 2); }
        }

        public Schwellenwertelement()
        {
            x1=x2=w1=w2=y=t=error=0;
        }

        public void Init()
        {
            Random rnd = new Random();

            x1 = x2 = y = error = 0;

            W1 = 1.0 - 2 * rnd.NextDouble();
            W2 = 1.0 - 2 * rnd.NextDouble();
            T = 1.0 - 2 * rnd.NextDouble();
        }
    }

    class SchwellenwertelementInput
    {
        double x1, x2, y;

        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public SchwellenwertelementInput(double x1, double x2, double y)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
        }
    }
}
