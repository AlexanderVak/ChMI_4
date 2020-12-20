using System;

namespace CHMI_4
{
    class Program
    {
        static void Main(string[] args)
        {
            void Test()
            {
                double[] x = { 0, 4, 7, 10, 12 };
                double[] y = { 1, 3, 7, 5, 6 };

                Console.WriteLine("Lagrange interpolation");
                Lagrange lagrange = new Lagrange(x[0], x, y);
                lagrange.PrintAnswers();
                Console.WriteLine("\nCubic Spline interpolation");
                new CubicSpline(x, y, x.Length);
            }

            Test();

            Console.WriteLine("Enter quantity of coordinats");

            int size = Convert.ToInt32(Console.ReadLine());
            double[] x = new double[size];
            double[] y = new double[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter x : ");
                x[i] = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter y : ");
                y[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Lagrange interpolation");
            Lagrange lagrange = new Lagrange(x[0], x, y);
            lagrange.PrintAnswers();
            Console.WriteLine("Cubic Spline interpolation");
            new CubicSpline(x, y, size);
        }
    }
}
