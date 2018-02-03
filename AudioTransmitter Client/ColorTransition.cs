using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTransmitter_Client
{
    class ColorTransition
    {
        public ColorTransition()
        {
        }

        // TODO
        public static Color getColorScale(int passentage, Color startColor, Color endColor)
        {
            passentage = 1 + (1 * passentage / 100);

            int r1 = startColor.R;
            int g1 = startColor.G;
            int b1 = startColor.B;

            int r2 = endColor.R;
            int g2 = endColor.G;
            int b2 = endColor.B;

            int mixR = (r1 + r2) != 0 && (r1 + r2) < 255 ? (r1 + r2) / passentage : 0;
            int mixG = (g1 + g2) != 0 && (g1 + g2) < 255 ? (g1 + g2) / passentage : 0;
            int mixB = (b1 + b2) != 0 && (b1 + b2) < 255 ? (b1 + b2) / passentage : 0;

            Color mixed = Color.FromArgb(mixR, mixG,mixB);
            return mixed;
        }

        private float interpolate(float a, float b, float proportion)
        {
            return (a + ((b - a) * proportion));
        }
    }
}
