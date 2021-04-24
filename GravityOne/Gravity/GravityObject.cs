using GravityOne.SpaceObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.Gravity
{
    enum RotationMode_ { None, Circle, Square, Triangle, Bar, BiasedBar };

    class GravityObject
    {
        const int MINIMUM_TEXTURE_SIZE = 10;
        

        private string name;
        protected double mass;      // 10^22 kg
        protected double x;         // m (this is the x-coordinate of the center of mass for solar system objects)
        protected double y;         // m (this is the y-coordinate of the center of mass for solar system objects)
        protected double xSpeed;    // m/s
        protected double ySpeed;    // m/s
        protected double xAcceleration;     // m/s^2
        protected double yAcceleration;     // m/s^2        // TODO : make of type object2D
        protected Texture2D texture;
        protected bool trace;
        protected bool vector;
        private int numObjects;     // Used for solar systems
        private GravityObject solarSystem;
        private bool scaleTexture;
        private bool isActive = true;
        private int scaledTextureWidth;
        private int scaledTextureHeight;
        private Color color;
        List<Trace> traces = new List<Trace>();
        internal GravityObject SolarSystem { get => solarSystem; set => solarSystem = value; }

        public GravityObject(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, Color color_, bool trace_, long scale_, bool vector_, bool scaleTexture_ = true, double rotationSpeed_ = 0)
        {
            name = name_;
            mass = mass_;   // 10^22 kg
            x = x_;     // m
            y = y_;     // m
            xSpeed = xSpeed_;   // m/s
            ySpeed = ySpeed_;   // m/s
            xAcceleration = 0;  // m/s^2
            yAcceleration = 0;  // m/s^2
            texture = texture_;
            color = color_;
            trace = trace_;
            ScaleTexture = scaleTexture_;
            if (texture != null)
            {
                scaledTextureWidth = texture_.Width;
                scaledTextureHeight = texture_.Height;
                if (ScaleTexture)
                {
                    Scale(scale_);
                }
            }
            vector = vector_;
        }

        public GravityObject(string name, double x, double y, double mass, double xSpeed_, double ySpeed_)
        {
            this.name = name;
            this.mass = mass;
            this.x = x;
            this.y = y;
            xSpeed = xSpeed_;   // m/s
            ySpeed = ySpeed_;   // m/s
            trace = false;
            vector = false;
            numObjects = 1;     // this constructor is only used for solar systems
        }

        public GravityObject(string name, double x, double y, double mass)
        {
            this.name = name;
            this.mass = mass;
            this.x = x;
            this.y = y;
            trace = false;
            vector = false;
            numObjects = 1;     // this constructor is only used for solar systems
        }

        private void Scale(long Scale)
        {
            float scale_ = 1 + (Scale / 100.0f);
            if (texture.Width < MINIMUM_TEXTURE_SIZE)
            {
                return;       // scaling not possible
            }
            if (texture.Width / scale_ < MINIMUM_TEXTURE_SIZE)
            {
                scale_ = texture.Width / MINIMUM_TEXTURE_SIZE;
            }
            if (texture.Height / scale_ < MINIMUM_TEXTURE_SIZE)
            {
                scale_ = texture.Height / MINIMUM_TEXTURE_SIZE;
            }
            ScaledTextureWidth = (int)(texture.Width / scale_);
            ScaledTextureHeight = (int)(texture.Height / scale_);
        }

        public void SetSpeed(Vector vector)
        {
            XSpeed = vector.X;
            YSpeed = vector.Y;
        }

        public void AddTrace(double x_, double y_)
        {
            traces.Add(new Trace(x_, y_));
        }

        public List<Trace> GetTraces()
        {
            return traces;
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

        public double XAcceleration
        {
            get
            {
                return xAcceleration;
            }

            set
            {
                xAcceleration = value;
            }
        }

        public double YAcceleration
        {
            get
            {
                return yAcceleration;
            }

            set
            {
                yAcceleration = value;
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

        public bool Trace
        {
            get
            {
                return trace;
            }

            set
            {
                trace = value;
            }
        }

        public bool Vector
        {
            get
            {
                return vector;
            }

            set
            {
                vector = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Speed
        {
            get
            {
                return Math.Sqrt(Math.Pow(xSpeed, 2) + Math.Pow(ySpeed, 2));
            }

        }

        public double Acceleration
        {
            get
            {
                return Math.Sqrt(Math.Pow(xAcceleration, 2) + Math.Pow(yAcceleration, 2));
            }
        }

        public int ScaledTextureWidth
        {
            get
            {
                return scaledTextureWidth;
            }

            set
            {
                scaledTextureWidth = value;
            }
        }

        public int ScaledTextureHeight
        {
            get
            {
                return scaledTextureHeight;
            }

            set
            {
                scaledTextureHeight = value;
            }
        }

        public double AccelerationAngle
        {
            get
            {
                return Math.Atan2(yAcceleration, xAcceleration);
            }
        }

        public double SpeedAngle
        {
            get
            {
                return Math.Atan2(ySpeed, xSpeed);
            }
        }

        public bool ScaleTexture
        {
            get
            {
                return scaleTexture;
            }

            set
            {
                scaleTexture = value;
            }
        }

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

        public int NumObjects { get => numObjects; set => numObjects = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public double SolarSystemPositionX()
        {
            if(solarSystem==null)
            {
                return 0;
            }
            else
            {
                return solarSystem.X;
            }
        }

        public double SolarSystemPositionY()
        {
            if (solarSystem == null)
            {
                return 0;
            }
            else
            {
                return solarSystem.Y;
            }
        }

        public double AbsolutePositionX()
        {
            if (solarSystem == null)
            {
                return x;
            }
            else
            {
                return x + solarSystem.X;
            }
        }

        public double AbsolutePositionY()
        {
            if (solarSystem == null)
            {
                return y;
            }
            else
            {
                return y + solarSystem.Y;
            }
        }

        public void AddObject(GravityObject addingObject)
        {
            addingObject.SolarSystem = this;
            Mass += addingObject.Mass;
            NumObjects++;
        }

        // Returns true if the Solar system objects itself must be deleted
        public bool RemoveObject(GravityObject deletingObject)
        {
            Mass -= deletingObject.Mass;
            NumObjects--;
            if (NumObjects < 2)
                return true;
            else
                return false;
        }
    }

}
