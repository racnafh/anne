using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private double round;

        private double roundmax;

        private double ds;

        private double dsmax;

        private double errormax;

        private double lp;

        private double deltat;

        private double deltaw1;

        private double deltaw2;

        private BackgroundWorker worker;

        public event EventHandler ClearEvent;
        public event EventHandler FirstLineEvent;
        public event EventHandler SecondLineEvent;
        public event EventHandler ThirdLineEventTrue;
        public event EventHandler ThirdLineEventFalse;
        public event EventHandler FourthLineEvent;
        public event EventHandler FourthLineBatchEvent;
        public event EventHandler BatchEvent;
        public event EventHandler ResetEvent;

        protected virtual void OnClearEvent(EventArgs e)
        {
            EventHandler clearLine = ClearEvent;
            if (clearLine != null)
            {
                clearLine(this, e);
            }
        }

        protected virtual void OnFirstLineEvent (EventArgs e)
        {
            EventHandler firstLine = FirstLineEvent;
            if(firstLine != null)
            {
                firstLine(this, e);
            }
        }

        protected virtual void OnSecondLineEvent(EventArgs e)
        {
            EventHandler secondLine = SecondLineEvent;
            if (secondLine != null)
            {
                secondLine(this, e);
            }
        }

        protected virtual void OnThirdLineEventFalse(EventArgs e)
        {
            EventHandler thirdLineFalse = ThirdLineEventFalse;
            if (thirdLineFalse != null)
            {
                thirdLineFalse(this, e);
            }
        }

        protected virtual void OnThirdLineEventTrue(EventArgs e)
        {
            EventHandler thirdLineTrue = ThirdLineEventTrue;
            if (thirdLineTrue != null)
            {
                thirdLineTrue(this, e);
            }
        }

        protected virtual void OnFourthLineEvent(EventArgs e)
        {
            EventHandler fourthLine = FourthLineEvent;
            if (fourthLine != null)
            {
                fourthLine(this, e);
            }
        }

        protected virtual void OnFourthLineBatchEvent(EventArgs e)
        {
            EventHandler fourthLineBatch = FourthLineBatchEvent;
            if (fourthLineBatch != null)
            {
                fourthLineBatch(this, e);
            }
        }

        protected virtual void OnBatchEvent(EventArgs e)
        {
            EventHandler Batch = BatchEvent;
            if (Batch != null)
            {
                Batch(this, e);
            }
        }

        protected virtual void OnResetEvent(EventArgs e)
        {
            EventHandler resetBatch = ResetEvent;
            if (resetBatch != null)
            {
                resetBatch(this, e);
            }
        }

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

        public double DeltaW1
        {
            get { return deltaw1; }
            set
            {
                if (deltaw1 != value)
                {
                    deltaw1 = value;
                    OnPropertyChanged("DeltaW1");
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

        public double DeltaW2
        {
            get { return deltaw2; }
            set
            {
                if (deltaw2 != value)
                {
                    deltaw2 = value;
                    OnPropertyChanged("DeltaW2");
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

        public double DeltaT
        {
            get { return deltat; }
            set
            {
                if (deltat != value)
                {
                    deltat = value;
                    OnPropertyChanged("DeltaT");
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

        public double ErrorMax
        {
            get { return errormax; }
            set
            {
                if (errormax != value)
                {
                    errormax = value;
                    OnPropertyChanged("ErrorMax");
                }
            }
        }

        public double LP
        {
            get { return lp; }
            set
            {
                if (lp != value)
                {
                    lp = value;
                    OnPropertyChanged("LP");
                }
            }
        }

        public double Round
        {
            get { return round; }
            set
            {
                if (round != value)
                {
                    round = value;
                    OnPropertyChanged("Round");
                }
            }
        }

        public double RoundMax
        {
            get { return roundmax; }
            set
            {
                if (roundmax != value)
                {
                    roundmax = value;
                    OnPropertyChanged("RoundMax");
                }
            }
        }

        public double DS
        {
            get { return ds; }
            set
            {
                if (ds != value)
                {
                    ds = value;
                    OnPropertyChanged("DS");
                }
            }
        }

        public double DSMAX
        {
            get { return dsmax; }
            set
            {
                if (dsmax != value)
                {
                    dsmax = value;
                    OnPropertyChanged("DSMAX");
                }
            }
        }

        public SchwellenwertelementVM(Schwellenwertelement swe)
        {
            this.swe = swe;
            round = ds = dsmax = 0;
            roundmax = 5;
            errormax = 0.0;
            lp = 0.15;
            deltat = deltaw1 = deltaw2 = 0.0;
        }

        public void Clear()
        {
            Random rnd = new Random();

            X1 = X2 = Y = Error = Round = DeltaT = DeltaW1 = DeltaW2 = DS = 0;

            W1 = 1.0 - 2 * rnd.NextDouble();
            W2 = 1.0 - 2 * rnd.NextDouble();
            T = 1.0 - 2 * rnd.NextDouble();
        }

        public void Online_Training(ObservableCollection<SchwellenwertelementInput> Daten)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoOnlineTraining;
            worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync(Daten);
        }

        void worker_DoOnlineTraining(object sender, DoWorkEventArgs e)
        {
            Round = 0;
            int p;// set your progress if appropriate

            ObservableCollection<SchwellenwertelementInput> daten = (ObservableCollection<SchwellenwertelementInput>)e.Argument;
            DSMAX = daten.Count;
            do
            {
                Error = DS = 0.0;
                Round++;
                foreach (SchwellenwertelementInput swei in daten)
                {
                    p = 0;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    DS++;
                    X1 = swei.X1;
                    X2 = swei.X2;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    if ((X1 * W1 + X2 * W2) >= T) Y = 1.0;
                    else Y = 0.0;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    if (Y != swei.Y)
                    {
                        Error += Math.Abs(swei.Y - Y);
                        worker.ReportProgress(p++, false);
                        Thread.Sleep(500);

                        T -= LP * (swei.Y - Y);
                        W1 += LP * (swei.Y - Y) * X1;
                        W2 += LP * (swei.Y - Y) * X2;

                        worker.ReportProgress(p);
                        Thread.Sleep(500);
                    }
                    else
                    {
                        worker.ReportProgress(p, true);
                        Thread.Sleep(500);
                    }
                }
            } while ((Error > ErrorMax) && (Round < RoundMax));

            worker.ReportProgress(7);
        }

        public void Batch_Training(ObservableCollection<SchwellenwertelementInput> Daten)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoBatchTraining;
            worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync(Daten);
        }

        void worker_DoBatchTraining(object sender, DoWorkEventArgs e)
        {
            Round = 0;
            int p;// set your progress if appropriate
            double deltaT,deltaW1,deltaW2;

            ObservableCollection<SchwellenwertelementInput> daten = (ObservableCollection<SchwellenwertelementInput>)e.Argument;
            DSMAX = daten.Count;
            do
            {
                deltaT = deltaW1 = deltaW2 = Error = DS = 0.0;
                Round++;
                foreach (SchwellenwertelementInput swei in daten)
                {
                    p = 0;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    DS++;
                    X1 = swei.X1;
                    X2 = swei.X2;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    if ((X1 * W1 + X2 * W2) >= T) Y = 1.0;
                    else Y = 0.0;

                    worker.ReportProgress(p++);
                    Thread.Sleep(500);

                    if (Y != swei.Y)
                    {
                        Error += Math.Abs(swei.Y - Y);
                        worker.ReportProgress(p++, false);
                        Thread.Sleep(500);

                        deltaT -= LP * (swei.Y - Y);
                        deltaW1 += LP * (swei.Y - Y) * X1;
                        deltaW2 += LP * (swei.Y - Y) * X2;

                        worker.ReportProgress(++p);
                        Thread.Sleep(500);
                    }
                    else
                    {
                        worker.ReportProgress(p, true);
                        Thread.Sleep(500);
                    }
                }

                if(deltaT!=0)
                {
                    T += deltaT;
                    W1 += deltaW1;
                    W2 += deltaW2;

                    worker.ReportProgress(6);
                    Thread.Sleep(1000);
                }
            } while ((Error > ErrorMax) && (Round < RoundMax));
            
            worker.ReportProgress(7);

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case 0: OnClearEvent(EventArgs.Empty);
                    break;
                case 1: OnFirstLineEvent(EventArgs.Empty);
                    break;
                case 2: OnSecondLineEvent(EventArgs.Empty);
                    break;
                case 3: if((bool)e.UserState) OnThirdLineEventTrue(EventArgs.Empty);
                    else OnThirdLineEventFalse(EventArgs.Empty);
                    break;
                case 4: OnFourthLineEvent(EventArgs.Empty);
                    break;
                case 5: OnFourthLineBatchEvent(EventArgs.Empty);
                    break;
                case 6: OnBatchEvent(EventArgs.Empty);
                    break;
                case 7: OnResetEvent(EventArgs.Empty);
                    break;
            }
        }

    }
}
