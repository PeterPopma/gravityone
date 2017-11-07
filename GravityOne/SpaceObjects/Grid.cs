using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.SpaceObjects
{
    class Grid
    {
        double xAmount;
        double yAmount;
        double mass;
        double spacing;
        string spacingUnits;
        double rotations;
        Texture2D texture;
        double xSpeed = 0;
        double ySpeed = 0;

        public double XAmount
        {
            get
            {
                return xAmount;
            }

            set
            {
                xAmount = value;
            }
        }

        public double YAmount
        {
            get
            {
                return yAmount;
            }

            set
            {
                yAmount = value;
            }
        }

        public double Mass
        {
            get
            {
                return mass;
            }

            set
            {
                mass = value;
            }
        }

        public double Spacing
        {
            get
            {
                return spacing;
            }

            set
            {
                spacing = value;
            }
        }

        public double Rotations
        {
            get
            {
                return rotations;
            }

            set
            {
                rotations = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
            }
        }

        public string SpacingUnits
        {
            get
            {
                return spacingUnits;
            }

            set
            {
                spacingUnits = value;
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
