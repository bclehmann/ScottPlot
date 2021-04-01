using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Statistics.Distributions
{
    public class NormalDistribution : IContinuousDistribution
    {
        public static NormalDistribution StandardNormalDistribution = new NormalDistribution(0, 1);

        private const double SQRT_PI = 1.7724538509055159; // sqrt(pi)
        private const double LN_2 = 0.6931471805599453; // ln(2)
        private const double SQRT_TWO = 1.4142135623730951; // sqrt(2)
        private const double SQRT_TWO_PI = 2.5066282746310002; // sqrt(2 * pi)

        private double Mean;
        private double StandardDeviation;

        public NormalDistribution(double mean, double standardDeviation)
        {
            this.Mean = mean;
            this.StandardDeviation = standardDeviation;
        }

        public double PDF(double x)
        {
            double z_score = (x - Mean) / StandardDeviation;

            return (1 / (StandardDeviation * SQRT_TWO_PI)) * Math.Exp(-0.5 * (z_score) * z_score);
        }

        public double CDF(double x)
        {
            return 0.5 * (1 + Erf((x - Mean) / (StandardDeviation * SQRT_TWO)));
        }

        private static double Erf(double x) // Approximates the error function
        {
            // This post explains why this is a good simple approximation https://math.stackexchange.com/questions/321569/approximating-the-error-function-erf-by-analytical-functions
            return Math.Tanh(SQRT_PI * LN_2 * x);
        }

        public static double InvErf(double x) // Applys Newtons method to approximate the inverse of Erf
        {
            const double EPSILON = 1E-5;
            if (x > 1 - EPSILON)
            {
                return InvErf(1 - EPSILON);
            }

            if (x < EPSILON - 1)
            {
                return InvErf(EPSILON - 1);
            }

            double ErfDerivative(double x)
            {
                return (2 / SQRT_PI) * Math.Exp(-x * x);
            }

            double[] ys = DataGen.Random(new Random(0), 10);
            HashSet<int> toSkip = new HashSet<int>();

            const int MAX_RUNS = 10;

            double min_distance = 10;
            double best_y = 0;
            int runs = 0;
            while (Math.Abs(min_distance) > EPSILON && runs < MAX_RUNS)
            {
                for (int i = 0; i < ys.Length; i++)
                {
                    if (toSkip.Contains(i))
                    {
                        continue;
                    }

                    double offset = (Erf(ys[i]) - x) / ErfDerivative(ys[i]);
                    if (!double.IsInfinity(ys[i]))
                    {
                        ys[i] -= offset;

                        double distance = Math.Abs(Erf(ys[i]) - x);
                        if (distance < min_distance)
                        {
                            min_distance = distance;
                            best_y = ys[i];
                        }
                    }
                    else
                    {
                        toSkip.Add(i);
                        continue;
                    }
                }

                runs++;
            }

            return best_y;
        }

        public double InvCDF(double x) // AKA Quantile function
        {
            return Mean + StandardDeviation * InvErf(2 * x - 1);
        }

        public double GetRandomValue(Random rand)
        {
            return InvCDF(rand.NextDouble()); // See https://en.wikipedia.org/wiki/Inverse_transform_sampling if this is confusing
        }

    }
}
