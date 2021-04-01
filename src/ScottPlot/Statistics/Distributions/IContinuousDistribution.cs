using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Statistics.Distributions
{
    public interface IContinuousDistribution
    {
        double PDF(double x);
        double CDF(double x);
        double GetRandomValue(Random rand);
    }
}
