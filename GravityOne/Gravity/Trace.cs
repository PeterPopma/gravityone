using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.Gravity
{
    class Trace
    {
        Color color;
        double x;
        double y;
        int lifetime;

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

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

        public Trace(double x_, double y_)
        {
            x = x_;
            y = y_;
            lifetime = 1000;
            color = new Color(255.0f, 255.0f, 255.0f);
        }

        public void UpdateFrame()
        {
            lifetime--;
            int r = Convert.ToInt32((lifetime / 1000.0f) * 255.0f);
            color = new Color(r, r, 0);
        }

        public bool isAlive()
        {
            return lifetime > 0;
        }
    }
}
