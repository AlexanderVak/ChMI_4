using System;
using System.Collections.Generic;
using System.Text;

namespace CHMI_4
{
    class Lagrange
    {
        public double X { get; set; }
        public double[] XValues { get; set; }
        public double[] YValues { get; set; }
        
        public Lagrange(double x, double[] xVal, double[] yVal)
        {
            X = x;
            XValues = xVal;
            YValues = yVal;
        }

        public void PrintAnswers()
        {
            double h = (XValues[XValues.Length - 1] - XValues[0]) / 99;
            int counter = 0;
            for (double i = XValues[0]; i <= XValues[XValues.Length - 1] + h; i += h)
            {
                counter++;
                Console.WriteLine(counter + "       "
                    + InterpolateLagrange(i));
            }
        }

        double InterpolateLagrange(double x)
        {
            double lagrPol = 0;
            for (int i = 0; i < XValues.Length; i++)
            {
                double basicPol = 1;
                for (int j = 0; j < XValues.Length; j++)
                {
                    if (j != i)
                        basicPol *= (x - XValues[j]) / (XValues[i] - XValues[j]);
                }
                lagrPol += basicPol * YValues[i];
            }
            return lagrPol;
        }
    }
}
