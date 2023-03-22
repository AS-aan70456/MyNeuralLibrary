using kiILibrary.interfaces;
using System;

namespace kiILibrary.ActFun{
    public class SigmoidFun : ActivationFun{
        public double ActFunction(double res){
            return 1 / (1 + Math.Pow(Math.E, -res));
        }
    }
}
