using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Statistics.Distributions
{
    public class UniformDistribution : IDistribution
    {
        public static UniformDistribution StandardUniformDistribution = new UniformDistribution(0, 1);

        private double A;
        private double B;

        public UniformDistribution(double a, double b)
        {
            A = a;
            B = b;
        }

        public double PDF(double x)
        {
            if (x > B || x < A)
                return 0;

            return 1 / (B - A);
        }

        public double CDF(double x)
        {
            if (x < A)
                return 0;

            if (x > B)
                return 1;

            return (x - A) / (B - A);
        }

        public double GetRandomValue(Random rand)
        {
            return rand.NextDouble() * (B - A) + A;
        }
    }
}
