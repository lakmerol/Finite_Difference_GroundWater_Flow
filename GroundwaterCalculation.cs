using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Element_GroundWater_Flow
{
    public class GroundwaterCalculation
    {
        private static GroundwaterCalculation instance;
        public static GroundwaterCalculation Instance => instance ?? (instance = new GroundwaterCalculation());


        public double OneDimension(double K, double distance, double HeadDifference)
        {
              double q = K * (HeadDifference / distance);
            double MassTransfer = q*(1/86400)*(4*distance*distance);
            return MassTransfer;
        }

        public string TwoDimension(double Kx, double Ky, double lx, double ly, double hx, double hy)
        {
            double qx = Kx * (hx / lx);
            double qy = Ky * (hy / ly);
            string answer = $"qx = {qx} m/d -- qy={qy} m/d";
           
            return answer;
        }

    }
}
