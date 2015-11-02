using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Threading;

namespace anne
{
    class SLP
    {
        List<InputNeuron> inputLayer;
        List<OutputNeuron> outputLayer;

        public SLP()
        {
            inputLayer = new List<InputNeuron>();
            inputLayer.Add(new InputNeuron());
            inputLayer.Add(new InputNeuron());

            outputLayer = new List<OutputNeuron>();
            outputLayer.Add(new OutputNeuron());

            Random rndObj = new Random();
            outputLayer[0].addConnection(inputLayer[0], rndObj.NextDouble());
        }

        public void drawNet(Canvas can)
        {
            foreach (InputNeuron inNeu in inputLayer)
                can.Children.Add(inNeu.Elli);

            foreach (OutputNeuron ouNeu in outputLayer)
                can.Children.Add(ouNeu.Elli);
        }

        public void formatNet(Canvas can)
        {
            double width = can.ActualWidth;
            double height = can.ActualHeight;
            double size;
            double inputXLine, inputYLine, outputXLine, outputYLine;
            if (height<width)
            {
                if (inputLayer.Count >= outputLayer.Count)
                {
                    size = height / ((inputLayer.Count * 2) + 1);
                    inputYLine = size;
                    outputYLine = size + (inputLayer.Count - outputLayer.Count) * size;
                }
                else
                {
                    size = height / ((outputLayer.Count * 2) + 1);
                    inputYLine = size + (outputLayer.Count - inputLayer.Count) * size;
                    outputYLine = size;
                }

                foreach (InputNeuron inNeu in inputLayer)
                {
                    inNeu.Elli.Width = inNeu.Elli.Height = size;
                }

                foreach (OutputNeuron ouNeu in outputLayer)
                {
                    ouNeu.Elli.Width = ouNeu.Elli.Height = size;
                }

                inputXLine = size;
                outputXLine = 3*size;


                int inputCounter = 0;

                foreach (Ellipse elli in can.Children)
                {
                    if (elli.Fill == Brushes.Red)
                    {
                        elli.SetValue(Canvas.LeftProperty, inputXLine);
                        elli.SetValue(Canvas.TopProperty, inputYLine);
                        inputYLine += 2 * size;
                    }
                    else
                    {
                        elli.SetValue(Canvas.LeftProperty, outputXLine);
                        elli.SetValue(Canvas.TopProperty, outputYLine);
                        inputYLine += 2 * size;
                    }
                }
            }
            else
            {
                if (inputLayer.Count >= outputLayer.Count)
                {
                    size = width / ((inputLayer.Count * 2) + 1);
                    inputYLine = size;
                    outputYLine = size + (inputLayer.Count - outputLayer.Count) * size;
                }
                else
                {
                    size = width / ((outputLayer.Count * 2) + 1);
                    inputYLine = size + (outputLayer.Count - inputLayer.Count) * size;
                    outputYLine = size;
                }

                foreach (InputNeuron inNeu in inputLayer)
                {
                    inNeu.Elli.Width = inNeu.Elli.Height = size;
                }

                foreach (OutputNeuron ouNeu in outputLayer)
                {
                    ouNeu.Elli.Width = ouNeu.Elli.Height = size;
                }

                inputXLine = size;
                outputXLine = 3 * size;


                int inputCounter = 0;

                foreach (Ellipse elli in can.Children)
                {
                    if (elli.Fill == Brushes.Red)
                    {
                        elli.SetValue(Canvas.LeftProperty, inputXLine);
                        elli.SetValue(Canvas.TopProperty, inputYLine);
                        inputYLine += 2 * size;
                    }
                    else
                    {
                        elli.SetValue(Canvas.LeftProperty, outputXLine);
                        elli.SetValue(Canvas.TopProperty, outputYLine);
                        inputYLine += 2 * size;
                    }
                }
            }
       
        }
    }
}
