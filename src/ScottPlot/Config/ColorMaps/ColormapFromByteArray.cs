using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScottPlot.Config.ColorMaps
{
    abstract class ColormapFromByteArray : Colormap
    {
        public override byte[,] IntenstitiesToRGB(double[] intensities)
        {
            byte[,] output = new byte[intensities.Length, 3];
            for (int i = 0; i < intensities.Length; i++)
            {
                if (intensities[i] < 0)
                {
                    output[i, 0] = (byte)0;
                    output[i, 1] = (byte)0;
                    output[i, 2] = (byte)0;
                    continue;
                }
                for (int j = 0; j < 3; j++)
                {
                    output[i, j] = intensities[i] >= 0 ? cmap[(int)(intensities[i] * 255), j] : (byte)0;
                }
            }
            return output;
        }

        public override int[] IntensitiesToARGB(double[] intensities)
        {
            return intensities.AsParallel().AsOrdered().Select(i => i >= 0 ? RGBToARGB(new byte[] { cmap[(int)(i * 255), 0], cmap[(int)(i * 255), 1], cmap[(int)(i * 255), 2] }) : unchecked((int)0xFF000000)).ToArray();
        }

        protected abstract byte[,] cmap { get; }
    }
}
