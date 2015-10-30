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
            Ellipse elli = new Ellipse();
            elli.Width = 50;
            elli.Height = 50;
            elli.Stroke = Brushes.Black;
            elli.Fill = Brushes.Red;
            //-----------
            Label lbl = new Label();
            //lbl.Content = "bla";
            //------------------
            can.Children.Add(elli);
            
            can.Children.Add(lbl);
        }
    }
}
