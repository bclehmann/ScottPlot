using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot
{
    public static class Generate
    {
        /// <summary>
        /// Generates a range of values.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="stop">The end of the range.</param>
        /// <param name="step">The space between values. Default 1.</param>
        /// <param name="includeStop">Indicates whether to include the stop point in the range. Default false.</param>
        /// <returns>A range of values.</returns>
        public static double[] Range(double start, double stop, double step = 1, bool includeStop = false)
        {
            return DataGen.Range(start, stop, step, includeStop);
        }

        /// <summary>
        /// Generates an array of zeros
        /// </summary>
        /// <param name="pointCount">The number of zeroes to generate</param>
        /// <returns>An array of zeros</returns>
        public static double[] Zeros(int pointCount)
        {
            return DataGen.Zeros(pointCount);
        }

        /// <summary>
        /// Generates an array of ones
        /// </summary>
        /// <param name="pointCount">The number of ones to generate</param>
        /// <returns>An array of ones</returns>
        public static double[] Ones(int pointCount)
        {
            return DataGen.Ones(pointCount);
        }

        /// <summary>
        /// Generates an array of sine values.
        /// </summary>
        /// <param name="pointCount">The number of values to generate.</param>
        /// <param name="oscillations">The number of periods. Default 1.</param>
        /// <param name="offset">The number to increment the output by. Default 0.</param>
        /// <param name="mult">The number to multiply the output by. Default 1.</param>
        /// <param name="phase">The fraction of a period to offset by. Default 0.</param>
        /// <returns>An array of sine values</returns>
        public static double[] Sin(int pointCount, double oscillations = 1, double offset = 0, double mult = 1, double phase = 0)
        {
            double sinScale = 2 * Math.PI * oscillations / (pointCount - 1);
            double[] ys = new double[pointCount];
            for (int i = 0; i < ys.Length; i++)
                ys[i] = Math.Sin(i * sinScale + phase * Math.PI * 2) * mult + offset;
            return ys;
        }

        /// <summary>
        /// Generates an array of cosine values.
        /// </summary>
        /// <param name="pointCount">The number of values to generate.</param>
        /// <param name="oscillations">The number of periods. Default 1.</param>
        /// <param name="offset">The number to increment the output by. Default 0.</param>
        /// <param name="mult">The number to multiply the output by. Default 1.</param>
        /// <param name="phase">The fraction of a period to offset by. Default 0.</param>
        /// <returns>An array of cosine values</returns>
        public static double[] Cos(int pointCount, double oscillations = 1, double offset = 0, double mult = 1, double phase = 0)
        {
            double sinScale = 2 * Math.PI * oscillations / (pointCount - 1);
            double[] ys = new double[pointCount];
            for (int i = 0; i < ys.Length; i++)
                ys[i] = Math.Cos(i * sinScale + phase * Math.PI * 2) * mult + offset;
            return ys;
        }
    }
}
