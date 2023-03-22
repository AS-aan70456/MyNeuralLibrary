using kiILibrary.ActFun;
using kiILibrary.interfaces;
using System;

namespace kiILibrary.Perceptron{
    class Matrix{
        Random f;
        ActivationFun activation;
        public double[,] weight { get; private set; }

        public Matrix(int input, int output){
            this.activation = new SigmoidFun();
            f = new Random((int)DateTime.Now.Ticks);
            _init(input, output);
        }

        public Matrix(int input, int output, ActivationFun activation) {
            this.activation = activation;
            f = new Random((int)DateTime.Now.Ticks);
            _init(input, output);
            
        }

        public void _init(int input, int output) {
            weight = new double[input, output];
            
            for (int i = 0; i < input; i++) {
                for (int j = 0; j < output; j++){
                    weight[i, j] = f.NextDouble();
                }
            }
        }

        public double[] Screening(double[] input) {
            double[] output = new double[GetOutputNeurons()];

            for (int row = 0; row < GetOutputNeurons(); row++){
                for (int col = 0; col < GetInputNeurons(); col++){
                    output[row] += weight[col, row] * input[col];
                }
            }

            for (int i = 0; i < output.Length; i++)
                output[i] = activation.ActFunction(output[i]);
            return output;
        }

        public int GetInputNeurons() {
            return weight.GetLength(0);
        }
        public int GetOutputNeurons(){
            return weight.GetLength(1);
        }

    }
}
