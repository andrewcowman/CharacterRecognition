using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognition.Distance {
    public abstract class AbstractDistance : ICalculateDistance {
        public double Calculate(double[] pos1, double[] pos2) {
            return Calculate(pos1, 0, pos2, 0, pos1.Length);
        }

        public abstract double Calculate(double[] pos1, int position1, double[] pos2, int position2, int length);
    }
}
