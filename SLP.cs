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

        public List<InputNeuron> InputLayer
        {
            get { return inputLayer; }
            set { inputLayer = value; }
        }

        List<OutputNeuron> outputLayer;

        public List<OutputNeuron> OutputLayer
        {
            get { return outputLayer; }
            set { outputLayer = value; }
        }

        public SLP()
        {
            inputLayer = new List<InputNeuron>();

            outputLayer = new List<OutputNeuron>();   
        }

        public void Add(InputNeuron inNeu) { inputLayer.Add(inNeu); }

        public void Add(OutputNeuron ouNeu) { outputLayer.Add(ouNeu); } 

        public void FullConnect()
        {
            Random rndObj = new Random();
            foreach(OutputNeuron ouNeu in outputLayer)
            {
                for( int i=0; i<inputLayer.Count; i++ )
                    ouNeu.addConnection(inputLayer[i], rndObj.NextDouble());
            }

        }
    }
}
