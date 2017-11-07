using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.Gravity
{
    class GravityObject
    {
        const int MINIMUM_TEXTURE_SIZE = 10;

        private string name;
        protected double mass;
        protected double x;
        protected double y;
        protected double xSpeed;
        protected double ySpeed;
        protected double xAcceleration;
        protected double yAcceleration;
        protected Texture2D texture;
        protected bool trace;
        protected bool vector;
        private bool scaleTexture;
        private int scaledTextureWidth;
        private int scaledTextureHeight;
        private Color color;
        List<Trace> traces = new List<Trace>();

        public GravityObject(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, Color color_, bool trace_, long scale_, bool vector_, bool scaleTexture_=true)
        {
            name = name_;
            mass = mass_;
            x = x_;
            y = y_;
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
            xAcceleration = 0;
            yAcceleration = 0;
            texture = texture_;
            color = color_;
            trace = trace_;
            scaledTextureWidth = texture_.Width;
            scaledTextureHeight = texture_.Height;
            ScaleTexture = scaleTexture_;
            if (ScaleTexture)
            {
                Scale(scale_);
            }
            vector = vector_;
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
    }


}
