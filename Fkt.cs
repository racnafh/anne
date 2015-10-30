using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anne
{
    class Fkt
    {
        ushort fktindex;
        double threshold;

        public ushort Fktindex
        {
            get
            {
                return fktindex;
            }

            set
            {
                fktindex = value;
            }
        }

        public double Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
            }
        }

        public Fkt() { fktindex = 0; threshold = 0; }

        public double calculateOutput(double Input)
        {
            switch(fktindex)
            {
                case 0: if (Input > threshold) return 1;
                        else return 0;
                case 1: return Input;
                default: return 0;
            }
        }
    }
}
