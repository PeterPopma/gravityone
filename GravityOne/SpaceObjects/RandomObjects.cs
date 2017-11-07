using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.SpaceObjects
{
    class RandomObjects
    {
        int numberOfObjects;
        long mass;
        Texture2D texture;
        ulong area;
        string areaUnits;
        int speed;
        int speedRandomness;

        public int NumberOfObjects
        {
            get
            {
                return numberOfObjects;
            }

            set
            {
                numberOfObjects = value;
            }
        }

        public long Mass
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

        public ulong Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public string AreaUnits
        {
            get
            {
                return areaUnits;
            }

            set
            {
                areaUnits = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public int SpeedRandomness
        {
            get
            {
                return speedRandomness;
            }

            set
            {
                speedRandomness = value;
            }
        }
    }
}
