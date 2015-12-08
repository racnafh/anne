using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace anne
{
    class SchwellenwertelementVM : ViewModelBase
    {
        private Schwellenwertelement swe;

        public double X1
        {
            get { return swe.X1; }
            set
            {
                if (swe.X1 != value)
                {
                    swe.X1 = value;
                    OnPropertyChanged("X1");
                }
            }
        }

        public double X2
        {
            get { return swe.X2; }
            set
            {
                if (swe.X2 != value)
                {
                    swe.X2 = value;
                    OnPropertyChanged("X2");
                }
            }
        }

        public double W1
        {
            get { return swe.W1; }
            set
            {
                if (swe.W1 != value)
                {
                    swe.W1 = value;
                    OnPropertyChanged("W1");
                }
            }
        }

        public double W2
        {
            get { return swe.W2; }
            set
            {
                if (swe.W2 != value)
                {
                    swe.W2 = value;
                    OnPropertyChanged("W2");
                }
            }
        }

        public double Y
        {
            get { return swe.Y; }
            set
            {
                if (swe.Y != value)
                {
                    swe.Y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public double T
        {
            get { return swe.T; }
            set
            {
                if (swe.T != value)
                {
                    swe.T = value;
                    OnPropertyChanged("T");
                }
            }
        }

        public double Error
        {
            get { return swe.Error; }
            set
            {
                if (swe.Error != value)
                {
                    swe.Error = value;
                    OnPropertyChanged("Error");
                }
            }
        }

        public SchwellenwertelementVM(Schwellenwertelement swe)
        {
            this.swe = swe;
        }

        public void Clear()
        {
            Random rnd = new Random();

            X1 = X2 = Y = Error = 0;

            W1 = 1.0 - 2 * rnd.NextDouble();
            W2 = 1.0 - 2 * rnd.NextDouble();
            T = 1.0 - 2 * rnd.NextDouble();
        }

        public void Online_Training(List<SchwellenwertelementInput> Daten)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoOnlineTraining;
            worker.RunWorkerAsync(Daten);
        }

        void worker_DoOnlineTraining(object sender, DoWorkEventArgs e)
        {
            double terror = 0.25;
            int round = 0;
            List<SchwellenwertelementInput> daten = (List<SchwellenwertelementInput>)e.Argument;
            do
            {
                Error = 0.0;
                foreach (SchwellenwertelementInput swei in daten)
                {
                    X1 = swei.X1;
                    X2 = swei.X2;
                    if ((X1 * W1 + X2 * W2) >= T) Y = 1.0;
                    else Y = 0.0;

                    Thread.Sleep(500);

                    if (Y != swei.Y)
                    {
                        T -= 0.1 * (swei.Y - Y);
                        W1 += 0.1 * (swei.Y - Y) * X1;
                        W2 += 0.1 * (swei.Y - Y) * X2;
                        Error += Math.Abs(swei.Y - Y);
                    }

                    Thread.Sleep(500);
                }
            } while ((Error > terror) && (++round <= 5)); 
        }

    }
}
