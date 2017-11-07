using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.SpaceObjects
{
    class PositionSpeed
    {
        double x;
        double y;
        double xSpeed;
        double ySpeed;

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

        public double XSpeed
        {
            get
            {
                return xSpeed;
            }

            set
            {
                xSpeed = value;
            }
        }

        public double YSpeed
        {
            get
            {
                return ySpeed;
            }

            set
            {
                ySpeed = value;
            }
        }
    }
}
