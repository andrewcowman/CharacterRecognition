using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognition.Distance {
    public interface ICalculateDistance {
        double Calculate(double[] pos1, double[] pos2);

        double Calculate(double[] pos1, int position1, double[] pos2, int position2, int length);
    }
}
