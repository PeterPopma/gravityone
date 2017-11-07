using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.SpaceObjects
{
    class Position
    {
        double x;
        double y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
