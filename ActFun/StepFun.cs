using kiILibrary.interfaces;
using System;

namespace kiILibrary.ActFun{
    public class StepFun : ActivationFun{
        public double ActFunction(double res){
            if (res > 0.5) return 0;
            else           return 1;
        }
    }
}
