using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognition.Distance {
    public class EuclideanDistance {
        public double Calculate(double[] pos1, double[] pos2) {
            return Calculate(pos1, 0, pos2, 0, pos1.Length);
        }
        public double Calculate(double[] pos1, int position1, double[] pos2, int position2, int length) {
            double sum = 0;
            for(int i = 0; i < length; i++) {
                double d = pos1[i + position1] - pos2[i + position1];
                sum += d * d;
            }
            return Math.Sqrt(sum);
        }
    }
}
