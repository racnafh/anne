using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace anne
{
    class ViewModelSLP : ViewModelBase 
    {
        private Canvas Can;
        private SLP Model;

        List<InputNeuron> inputLayer;

        List<InputNeuron> InputLayer
        {
            get { return inputLayer; }
            set
            {
                if (InputLayer != value)
                {
                    inputLayer = value;
                    OnPropertyChanged("InputLayer");
                }
            }
        }

        List<OutputNeuron> outputLayer;

        List<OutputNeuron> OutputLayer
        {
            get { return outputLayer; }
            set
            {
                if (OutputLayer != value)
                {
                    outputLayer = value;
                    OnPropertyChanged("OutputLayer");
                }
            }
        }

        
        public ViewModelSLP(SLP model, Canvas can)
        {
            Model = model;
            InputLayer = Model.InputLayer;
            OutputLayer = Model.OutputLayer;
            Can = can;

            foreach (InputNeuron inNeu in inputLayer)
            {
                Button elli = new Button();
                elli.Style = Application.Current.FindResource("InputNeuron") as Style;
                elli.DataContext = inNeu;
                elli.Width = 50;
                elli.Height = 50;
                elli.Tag = inNeu;
                Can.Children.Add(elli);
            }
                

            foreach (OutputNeuron ouNeu in outputLayer)
            {
                Button elli = new Button();
                elli.Style = Application.Current.FindResource("OutputNeuron") as Style;
                elli.DataContext = ouNeu;
                elli.Width = 50;
                elli.Height = 50;
                elli.Tag = ouNeu;
                Can.Children.Add(elli);
            }
        }

        public void formatNet()
        {
            double width = Can.ActualWidth;
            double height = Can.ActualHeight;
            double size, indiff, outdiff;
            double inputXLine, outputXLine;
            outdiff = 0;
            indiff = outputLayer.Count - inputLayer.Count;
            if (indiff < 0)
            {
                outdiff = Math.Abs(indiff);
                indiff = 0;
            }

            double heightdivisor = (outputLayer.Count * 2) +1;
            if (inputLayer.Count > outputLayer.Count)
                heightdivisor = (inputLayer.Count * 2) + 1;
            
            if ((height / heightdivisor) < (width / 7.0)) size = height / heightdivisor;
            else size = width / 7.0;

            inputXLine = size;
            outputXLine = 5.0 * size;

            foreach (Button elli in Can.Children)
            {
                elli.Width = elli.Height = size;
                object dummy = elli.Tag;

                if(dummy is InputNeuron)
                {
                    elli.SetValue(Canvas.LeftProperty, inputXLine);
                    elli.SetValue(Canvas.TopProperty, size * (((InputNeuron)dummy).Number * 2 + 1 + indiff) );
                }
                else
                {
                    elli.SetValue(Canvas.LeftProperty, outputXLine);
                    elli.SetValue(Canvas.TopProperty, size * (((OutputNeuron)dummy).Number * 2 + 1 + outdiff) );
                }
            }
        }
    }
}
