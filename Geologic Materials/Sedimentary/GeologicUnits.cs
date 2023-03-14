using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Element_GroundWater_Flow.Geologic_Materials.Sedimentary
{
    public class GeologicUnits
    {
        private static GeologicUnits instance;
        public static GeologicUnits Instance => instance ?? (instance = new GeologicUnits());

        public static List<Characteristics> Units()
        {


            List<Characteristics> units = new List<Characteristics>();
            units.Add(new Characteristics
            {
                SizeTerms = "Clay",
                SizeTermsClass = " ",
                SizeRange = new double[] { 0.001,0.002},
                PorosityRange = new double[] {0.30,0.60 },
                HydraulicConductivityRange = new double[] {0.00000000001, 0.0000000000001 }
                
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Silt",
                SizeTermsClass = "Very Fine",
                SizeRange = new double[] { 0.004, 0.008},
                PorosityRange = new double[] { 0.40, 0.50},
                HydraulicConductivityRange = new double[] { 0.0000000001, 0.00000000001 }

            });
            units.Add(new Characteristics
            {
                SizeTerms = "Silt",
                SizeTermsClass = "Fine",
                SizeRange = new double[] {0.008, 0.016},
                PorosityRange = new double[] { 0.30, 0.40 },
                HydraulicConductivityRange = new double[] { 0.0000000001, 0.00000000001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Silt",
                SizeTermsClass = "Medium",
                SizeRange = new double[] { 0.016, 0.031},
                PorosityRange = new double[] { 0.30, 0.40 },
                HydraulicConductivityRange = new double[] { 0.000000001, 0.0000000001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Silt",
                SizeTermsClass = "Coarse",
                SizeRange = new double[] { 0.031, 0.062},
                PorosityRange = new double[] { 0.30, 0.35 },
                HydraulicConductivityRange = new double[] { 0.000001, 0.00001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Sand",
                SizeTermsClass = "Very Fine",
                SizeRange = new double[] { 0.062, 0.125},
                PorosityRange = new double[] { 0.40, 0.50},
                HydraulicConductivityRange = new double[] { 0.000001, 0.00001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Sand",
                SizeTermsClass = "Fine",
                SizeRange = new double[] { 0.125, 0.250},
                PorosityRange = new double[] { 0.30, 0.40 },
                HydraulicConductivityRange = new double[] { 0.000001, 0.0001}
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Sand",
                SizeTermsClass = "Medium",
                SizeRange = new double[] {0.250, 0.500},
                PorosityRange = new double[] { 0.30, 0.35 },
                HydraulicConductivityRange = new double[] { 0.000001, 0.00001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Sand",
                SizeTermsClass = "Coarse",
                SizeRange = new double[] { 0.500 , 1 },
                PorosityRange = new double[] { 0.30, 0.35 },
                HydraulicConductivityRange = new double[] { 0.00001, 0.0001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Sand",
                SizeTermsClass = "Very Coarse",
                SizeRange = new double[] {1,2},
                PorosityRange = new double[] { 0.25, 0.30 },
                HydraulicConductivityRange = new double[] { 0.00001, 0.0001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Gravel",
                SizeTermsClass = "Very Fine",
                SizeRange = new double[] { 2,4 },
                PorosityRange = new double[] { 0.30, 0.35 },
                HydraulicConductivityRange = new double[] { 0.0001, 0.001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Gravel",
                SizeTermsClass = "Fine",
                SizeRange = new double[] { 4,8 },
                PorosityRange = new double[] { 0.30, 0.35 },
                HydraulicConductivityRange = new double[] { 0.0001, 0.001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Gravel",
                SizeTermsClass = "Medium",
                SizeRange = new double[] {8,16 },
                PorosityRange = new double[] { 0.25, 0.30},
                HydraulicConductivityRange = new double[] { 0.005, 0.001 }
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Gravel",
                SizeTermsClass = "Coarse",
                SizeRange = new double[] { 16,32 },
                PorosityRange = new double[] { 0.20, 0.25},
                HydraulicConductivityRange = new double[] { 0.05, 0.01}
            });
            units.Add(new Characteristics
            {
                SizeTerms = "Gravel",
                SizeTermsClass = "Coarse",
                SizeRange = new double[] { 32, 64},
                PorosityRange = new double[] { 0.20, 0.25 },
                HydraulicConductivityRange = new double[] { 0.05, 0.01 }
            });




            return null;
        }
    }
}
