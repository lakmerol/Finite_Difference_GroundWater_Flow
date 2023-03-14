using Finite_Element_GroundWater_Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Difference_GroundWater_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region sample 1D-2D
            //string result;
            //Console.WriteLine("Is Aquifer has Aniztropy ? True / False");
            //string anizotropy = Console.ReadLine();
            //if (anizotropy == "True")
            //{
            //    Console.WriteLine("Kx");
            //    double kx = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Ky");
            //    double ky = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("lx");
            //    double lx = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("ly");
            //    double ly = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("hx");
            //    double hx = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("hy");
            //    double hy = Convert.ToDouble(Console.ReadLine());
            //    result =  GroundwaterCalculation.Instance.TwoDimension(kx, ky, lx, ly, hx, hy);
            //}
            //else
            //{
            //    Console.WriteLine("K");
            //    double k = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("H");
            //    double h = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("l");
            //    double l = Convert.ToDouble(Console.ReadLine());
            //    result = GroundwaterCalculation.Instance.OneDimension(k, h, l);
            //}



            //Console.WriteLine(result);
            //Console.ReadLine();
            #endregion

            Console.WriteLine("Please Enter Cubic Box One Side(m)");
            double BoxSize = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Distance X (m)");
            double Dx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Distance Y (m)");
            double Dy = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Modelling Time (Day)");
            int Time = Convert.ToInt32(Console.ReadLine());

            int boxcount = Convert.ToInt32(Math.Round(((Dx * Dy) / BoxSize), 0));

            Console.WriteLine("Your Area Diveded By This Count, Please Enter for Continue");
            Console.WriteLine(boxcount);
            Console.ReadLine();
            int dxbox = Convert.ToInt32(Math.Round((Dx / BoxSize), 0));
            int dybox = Convert.ToInt32(Math.Round((Dy / BoxSize), 0));
            double[,,] KArray = new double[dxbox, dybox, 2];
            double[,,] HArray = new double[dxbox, dybox, 2];
            for (int x = 0; x < dxbox; x++)
            {
                for (int y = 0; y < dybox; y++)
                {
                    Console.WriteLine($"{x}-{y}. Please Insert Kx");
                    KArray[x, y, 0] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"{x}-{y}. Please Insert Ky");
                    KArray[x, y, 1] = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                }

            }
            for (int x = 0; x < dxbox; x++)
            {
                for (int y = 0; y < dybox; y++)
                {
                    Console.WriteLine($"{x}-{y}. Please Insert Hx");
                    HArray[x, y, 0] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"{x}-{y}. Please Insert Hy");
                    HArray[x, y, 1] = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                }

            }
            Console.WriteLine("Modelling...");
            int dt = Time * 86400;
            for (int i = 0; i < dt; i++)
            {
                for (int x = 0; x < dxbox; x++)
                {
                    for (int y = 0; y < dybox; y++)
                    {
                        double hx = HArray[x, y, 0];
                        double hy = HArray[x, y, 1];
                        double kx = KArray[x, y, 0];
                        double ky = KArray[x, y, 1];
                        double distance = BoxSize / 2;
                        if (y == dybox - 1 || y == 0)
                        {

                            if (x == dxbox - 1 || x == 0)
                            {
                                double dif = GroundwaterCalculation.Instance.OneDimension(ky, distance, -hy);
                                double difx1 = GroundwaterCalculation.Instance.OneDimension(kx, distance, -hx);
                                HArray[x, y, 0] = HArray[x, y, 0] - dif;
                                HArray[x, y, 1] = HArray[x, y, 0] - difx1;
                                continue;
                            }
                            double hx2 = HArray[x + 1, y, 0];
                            double diffhx = hx - hx2;
                            double difx = GroundwaterCalculation.Instance.OneDimension(kx, distance, -hy);
                            double dif2 = GroundwaterCalculation.Instance.OneDimension(ky, distance, -diffhx);
                            HArray[x, y, 0] = HArray[x, y, 0] - dif2;
                            HArray[x, y, 1] = HArray[x, y, 1] - dif2;
                            continue;
                        }
                        if (x == dxbox - 1 || x == 0)
                        {
                            double hy2 = HArray[x, y + 1, 0];
                            double diffhy = hy - hy2;
                            double dif2 = GroundwaterCalculation.Instance.OneDimension(ky, distance, -diffhy);
                            double difx = GroundwaterCalculation.Instance.OneDimension(ky, distance, -hx);
                            HArray[x, y, 0] = HArray[x, y, 0] - dif2;
                            HArray[x, y, 1] = HArray[x, y, 1] - difx;
                            continue;

                        }
                        #region + + 
                        double hxpp = HArray[x + 1, y + 1, 0];
                        double hypp = HArray[x + 1, y + 1, 0];
                        double diffhxpp = hx - hxpp;
                        double diffhypp = hy - hypp;
                        double hxppCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxpp);
                        double hxypCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhypp);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxppCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hxypCal;
                        #endregion
                        #region + 0
                        double hxp0 = HArray[x + 1, y, 0];
                        double hyp0 = HArray[x + 1, y, 0];
                        double diffhxp0 = hx - hxp0;
                        double diffhyp0 = hy - hyp0;
                        double hxp0Cal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxpp);
                        double hyp0Cal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhypp);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxp0Cal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hyp0Cal;
                        #endregion
                        #region +-
                        double hxpn = HArray[x + 1, y, 0];
                        double hypn = HArray[x - 1, y, 1];
                        double diffhxpn = hx - hxpn;
                        double diffhypn = hy - hypn;
                        double hxpnCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxpn);
                        double hypnCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhypn);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxpnCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hypnCal;
                        #endregion
                        #region 0+
                        double hx0p = HArray[x, y + 1, 0];
                        double hy0p = HArray[x, y + 1, 1];
                        double diffhx0p = hx - hx0p;
                        double diffhy0p = hy - hy0p;
                        double hx0pCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhx0p);
                        double hy0pCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhy0p);
                        HArray[x, y, 0] = HArray[x, y, 0] - hx0pCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hy0pCal;
                        #endregion
                        #region 0-
                        double hx0n = HArray[x, y - 1, 0];
                        double hy0n = HArray[x, y - 1, 1];
                        double diffhx0n = hx - hx0n;
                        double diffhy0n = hy - hy0n;
                        double hx0nCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhx0n);
                        double hy0nCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhy0n);
                        HArray[x, y, 0] = HArray[x, y, 0] - hx0nCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hy0nCal;
                        #endregion
                        #region -+
                        double hxnp = HArray[x - 1, y + 1, 0];
                        double hynp = HArray[x - 1, y + 1, 1];
                        double diffhxnp = hx - hxnp;
                        double diffhynp = hy - hynp;
                        double hxnpCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxnp);
                        double hynpCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhynp);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxnpCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hynpCal;
                        #endregion
                        #region -0
                        double hxn0 = HArray[x - 1, y, 0];
                        double hyn0 = HArray[x - 1, y, 1];
                        double diffhxn0 = hx - hxn0;
                        double diffhyn0 = hy - hyn0;
                        double hxn0Cal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxn0);
                        double hyn0Cal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhyn0);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxn0Cal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hyn0Cal;
                        #endregion
                        #region --
                        double hxnn = HArray[x - 1, y - 1, 0];
                        double hynn = HArray[x - 1, y - 1, 1];
                        double diffhxnn = hx - hxnn;
                        double diffhynn = hy - hynn;
                        double hxnnCal = GroundwaterCalculation.Instance.OneDimension(kx, distance, diffhxnn);
                        double hynnCal = GroundwaterCalculation.Instance.OneDimension(ky, distance, diffhynn);
                        HArray[x, y, 0] = HArray[x, y, 0] - hxnnCal;
                        HArray[x, y, 1] = HArray[x, y, 1] - hynnCal;
                        #endregion
                    }

                }
            }
            for (int x = 0; x < dxbox; x++)
            {
                for (int y = 0; y < dybox; y++)
                {
                    Console.WriteLine($"{x}{y} hx = {HArray[x, y, 0]} m");
                    Console.WriteLine($"{x}{y} hy = {HArray[x, y, 1]} m");
                   
                }

            }
            Console.ReadLine();
            Console.ReadLine();


        }
    }
}
