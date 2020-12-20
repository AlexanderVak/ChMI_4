using System;
using System.Collections.Generic;
using System.Text;

namespace CHMI_4
{
    class CubicSpline
    {
        double X { get; set; }
        double[] XValues { get; set; }
        double[] YValues { get; set; }
        int N { get; set; }

        public CubicSpline( double[] xValues, double[] yValues, int n)
        {
            XValues = xValues;
            YValues = yValues;
            N = n;
            Interpolations();
        }

        void Interpolations()
        {
            for (int i = 0; i < N - 1; i++)
            {
                X = XValues[i];
                Interpolate();                
            }
        }
        void Interpolate()
        {
            double A = 2 * (XValues[2] - XValues[0]);
            double B = (XValues[2] - XValues[1]);
            double C = 6 / (XValues[2] - XValues[1]) * (YValues[2] - YValues[1]) + 6 / (XValues[1] - XValues[0]) * (YValues[0] - YValues[1]);

            double D = XValues[2] - XValues[1];
            double E = 2 * (XValues[3] - XValues[1]);
            double F = 6 / (XValues[3] - XValues[2]) * (YValues[3] - YValues[2]) + 6 / (XValues[2] - XValues[1]) * (YValues[1] - YValues[2]);

            var fdd = new double[4];
            fdd[0] = 0;
            fdd[1] = (B * F - C * E) / (B * D - A * E);
            fdd[2] = (C - A * fdd[1]) / B;
            fdd[3] = 0;
            int i;

            if (X >= XValues[2] && X <= XValues[3])
            {
                i = 3;
            }
            else if (X >= XValues[1] && X <= XValues[2])
            {
                i = 2;
            }
            else if (X >= XValues[0] && X <= XValues[1])
            {
                i = 1;
            }
            else
            {
                throw new ArgumentException("xi is not inside any interval");
            }

            var var1 = fdd[i - 1] / (6 * (XValues[i] - XValues[i - 1]));
            var var2 = fdd[i] / (6 * (XValues[i] - XValues[i - 1]));
            var var3 = ((YValues[i - 1] / (XValues[i] - XValues[i - 1]) - fdd[i - 1] * (XValues[i] - XValues[i - 1]) / 6));
            var var4 = ((YValues[i] / (XValues[i] - XValues[i - 1]) - fdd[i] * (XValues[i] - XValues[i - 1]) / 6));

            var res = var1 * Math.Pow(XValues[i] - X, 3)
                    + var2 * Math.Pow(X - XValues[i - 1], 3)
                    + (var3 * (XValues[i] - X))
                    + (var4 * (X - XValues[i - 1]));

            Console.Write("\ny = {0}({1} - x)^3 ", var1, XValues[i]);
            Console.Write("{0} {1}(x {2} {3})^3 ", var2 < 0 ? '-' : '+',
                Math.Abs(var2), XValues[i - 1] > 0 ? '-' : '+', Math.Abs(XValues[i - 1]));
            Console.Write("{0} {1}({2} - x)", var3 < 0 ? '-' : '+', Math.Abs(var3), XValues[i]);
            Console.WriteLine("{0} {1}(x {2} {3})", var4 < 0 ? '-' : '+',
                Math.Abs(var4), XValues[i - 1] > 0 ? '-' : '+', Math.Abs(XValues[i - 1]));
        }
    }
}
