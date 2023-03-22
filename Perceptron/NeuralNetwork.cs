using kiILibrary.ActFun;
using kiILibrary.interfaces;
using System;


namespace kiILibrary.Perceptron{

    public class NeuralNetwork{

        private Matrix[] neuralLayers;
        private double[][] neuronVaule;

        public NeuralNetwork(int input, int output, int[] leyers, ActivationFun ActFun) => _Init(input, output, leyers, ActFun);
        public NeuralNetwork(int input, int output, int[] leyers) => _Init(input, output, leyers, new SigmoidFun());
        public NeuralNetwork(int input, int output)                                     => _Init(input, output, new int[] { }, new SigmoidFun());

        private void _Init(int input, int output, int[] leyers, ActivationFun ActFun) {
            int[] neuronLayers = new int[leyers.Length + 2];
            for (int i = 0; i < leyers.Length; i++)
                neuronLayers[i + 1] = leyers[i];

            neuronLayers[0] = input;
            neuronLayers[leyers.Length + 1] = output;

            neuralLayers = new Matrix[neuronLayers.Length - 1];
            for (int i = 0; i < neuronLayers.Length - 1; i++)
                neuralLayers[i] = new Matrix(neuronLayers[i], neuronLayers[i + 1], ActFun);

            neuronVaule = new double[neuralLayers.Length + 1][];
        }

        public double[] Ansver(double[] input){
            neuronVaule[0] = input;
            for (int i = 0; i < neuralLayers.Length; i++){
                input = neuralLayers[i].Screening(input);
                neuronVaule[i + 1] = input;
            }
            return input;
        }

        public void Study(double[] input, double[] expendet){
            double[] resall = Ansver(input);

            for (int i = 0; i < neuronVaule[neuronVaule.Length - 1].Length; i++){
                double res = resall[i];
                double error = res - expendet[i];
                double weight_delta = error * (1 - (res * (1 - res)));
                Console.WriteLine(error);
                Studys(weight_delta, i, neuralLayers.Length - 1);
            }
        }

        public void Study(double[] expendet){
            for (int i = 0; i < neuronVaule[neuronVaule.Length - 1].Length; i++){
                double res = neuronVaule[neuronVaule.Length - 1][i];
                double error = res - expendet[i];
                double weight_delta = error * (1 - (res * (1 - res)));
                Studys(weight_delta, i, neuronVaule[neuronVaule.Length - 1].Length - 1);
                
            }
        }

        private void Studys(double weight_delta, int x, int y) {
            for (int i = 0; i < neuronVaule[y - 1].Length; i++)
                neuralLayers[y - 1].weight[i, x] -= ((neuronVaule[y - 1][i] * weight_delta) * 0.1);
            for (int i = 0; i < neuronVaule[y].Length; i++)
                Studys(weight_delta * neuralLayers[y - 1].weight[i, x], i, y - 1);
        }
    }
}
