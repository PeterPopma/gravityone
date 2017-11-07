using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravityOne.SpaceObjects
{
    class Galaxy
    {
        bool rotateCCW = true;
        bool hasSpiral = true;
        bool hasEllipse = true;
        bool hasBlackHole = true;
        bool addSolarSystem = false;
        long crossSection = 1700000000;
        int numberOfObjects = 6000;
        long totalMass = 12000;
        long blackHoleMass = 4100000;
        double velocityIncreaseFactor = 0.2;
        long rotationPeriod = 360000000;
        int numberOfArms = 2;
        double armLength = 1.4;
        bool hasBar = true;
        int barPercentage = 20;
        int spiralBlurriness = 50;
        double ellipseRatio = 0.5;
        int ellipseObjectsPercentage = 30;
        int ellipseSizePercentage = 50;
        int ellipseBlurriness = 50;
        double massVariation = 50;
        bool calculateStableSpeed = true;
        double xSpeed = 0;
        double ySpeed = 0;
        Microsoft.Xna.Framework.Color color = Color.White;

        public bool RotateCCW
        {
            get
            {
                return rotateCCW;
            }

            set
            {
                rotateCCW = value;
            }
        }

        public bool HasSpiral
        {
            get
            {
                return hasSpiral;
            }

            set
            {
                hasSpiral = value;
            }
        }

        public bool HasBlackHole
        {
            get
            {
                return hasBlackHole;
            }

            set
            {
                hasBlackHole = value;
            }
        }

        public long CrossSection
        {
            get
            {
                return crossSection;
            }

            set
            {
                crossSection = value;
            }
        }

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

        public long TotalMass
        {
            get
            {
                return totalMass;
            }

            set
            {
                totalMass = value;
            }
        }

        public long BlackHoleMass
        {
            get
            {
                return blackHoleMass;
            }

            set
            {
                blackHoleMass = value;
            }
        }

        public double VelocityIncreaseFactor
        {
            get
            {
                return velocityIncreaseFactor;
            }

            set
            {
                velocityIncreaseFactor = value;
            }
        }

        public long RotationPeriod
        {
            get
            {
                return rotationPeriod;
            }

            set
            {
                rotationPeriod = value;
            }
        }

        public double ArmLength
        {
            get
            {
                return armLength;
            }

            set
            {
                armLength = value;
            }
        }

        public int NumberOfArms
        {
            get
            {
                return numberOfArms;
            }

            set
            {
                numberOfArms = value;
            }
        }

        public bool HasBar
        {
            get
            {
                return hasBar;
            }

            set
            {
                hasBar = value;
            }
        }

        public double EllipseRatio
        {
            get
            {
                return ellipseRatio;
            }

            set
            {
                ellipseRatio = value;
            }
        }

        public int EllipseSizePercentage
        {
            get
            {
                return ellipseSizePercentage;
            }

            set
            {
                ellipseSizePercentage = value;
            }
        }

        public int BarPercentage
        {
            get
            {
                return barPercentage;
            }

            set
            {
                barPercentage = value;
            }
        }

        public bool HasEllipse
        {
            get
            {
                return hasEllipse;
            }

            set
            {
                hasEllipse = value;
            }
        }

        public int EllipseObjectsPercentage
        {
            get
            {
                return ellipseObjectsPercentage;
            }

            set
            {
                ellipseObjectsPercentage = value;
            }
        }

        public int SpiralBlurriness
        {
            get
            {
                return spiralBlurriness;
            }

            set
            {
                spiralBlurriness = value;
            }
        }

        public int EllipseBlurriness
        {
            get
            {
                return ellipseBlurriness;
            }

            set
            {
                ellipseBlurriness = value;
            }
        }

        public double MassVariation
        {
            get
            {
                return massVariation;
            }

            set
            {
                massVariation = value;
            }
        }

        public bool AddSolarSystem
        {
            get
            {
                return addSolarSystem;
            }

            set
            {
                addSolarSystem = value;
            }
        }

        public bool CalculateStableSpeed
        {
            get
            {
                return calculateStableSpeed;
            }

            set
            {
                calculateStableSpeed = value;
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

        public Galaxy()
        {

        }

        public Galaxy(bool rotateCCW_, bool hasSpiral_, int CrossSection_, int NumberOfObjects_, long AverageMass_, bool hasBlackHole_, long blackHoleMass_, double velocityIncreaseFactor_, long rotationPeriod_)
        {
            rotateCCW = rotateCCW_;
            hasSpiral = hasSpiral_;
            crossSection = CrossSection_;
            numberOfObjects = NumberOfObjects_;
            totalMass = AverageMass_;
            hasBlackHole = hasBlackHole_;
            blackHoleMass = blackHoleMass_;
            velocityIncreaseFactor = velocityIncreaseFactor_;
            rotationPeriod = rotationPeriod_;
        }

    }
}
