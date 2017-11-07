using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.SpaceObjects
{
    class SmallDot
    {
        int pixelSize = 5;
        int type = 0;
        int alpha = 120;
        int colorCoding = 0;
        bool randomSize;
        bool randomColor;

        public int PixelSize
        {
            get
            {
                return pixelSize;
            }

            set
            {
                pixelSize = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Alpha
        {
            get
            {
                return alpha;
            }

            set
            {
                alpha = value;
            }
        }

        public int ColorCoding
        {
            get
            {
                return colorCoding;
            }

            set
            {
                colorCoding = value;
            }
        }

        public bool RandomSize
        {
            get
            {
                return randomSize;
            }

            set
            {
                randomSize = value;
            }
        }

        public bool RandomColor
        {
            get
            {
                return randomColor;
            }

            set
            {
                randomColor = value;
            }
        }
    }
}
