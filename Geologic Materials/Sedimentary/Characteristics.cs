using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Element_GroundWater_Flow.Geologic_Materials.Sedimentary
{
    public class Characteristics
    {
        public  string SizeTerms {get; set;}
        public  string SizeTermsClass {get; set;}
        public double[] SizeRange { get; set; }                     // mm
        public double[] PorosityRange { get; set; }                 // %
        public double[] HydraulicConductivityRange { get; set; }         // m/s
        


    }
}
