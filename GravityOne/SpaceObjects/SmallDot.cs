using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.SpaceObjects
{
    class CustomShape
    {
        int pixelSize = 5;
        int type = 0;
        int alpha = 120;
        bool randomSize;
        bool randomColor;
        bool updateExisting;
        Color color;

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

        public Color Color { get => color; set => color = value; }
        public bool UpdateExisting { get => updateExisting; set => updateExisting = value; }

        public string ColorToText()
        {
            if (randomColor)
            {
                return "[Random]";
            }

            if (Color.Equals(Color.Red))
            {
                return "Red";
            }
            if (Color.Equals(Color.Green))
            {
                return "Green";
            }
            if (Color.Equals(Color.Blue))
            {
                return "Blue";
            }
            if (Color.Equals(Color.Yellow))
            {
                return "Yellow";
            }

            return "White";
        }

        public void TextToColor(string colorText)
        {
            if (colorText.Equals("[Random]"))
            {
                randomColor = true;
                return;
            }

            randomColor = false;
            if (colorText.Equals("Red"))
            {
                Color = Color.Red;
            }
            if (colorText.Equals("Green"))
            {
                Color = Color.Green;
            }
            if (colorText.Equals("Blue"))
            {
                Color = Color.Blue;
            }
            if (colorText.Equals("Yellow"))
            {
                Color = Color.Yellow;
            }
            if (colorText.Equals("White"))
            {
                Color = Color.White;
            }
        }

        public string SizeToText()
        {
            if (randomSize)
            {
                return "[Random]";
            }

            return pixelSize.ToString();
        }

        public void TextToSize(string sizeText)
        {
            if (sizeText.Equals("[Random]"))
            {
                randomSize = true;
                return;
            }

            randomSize = false;
            pixelSize = Convert.ToInt32(sizeText);
        }
    }
}
