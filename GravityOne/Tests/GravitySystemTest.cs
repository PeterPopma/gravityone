using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GravityOne.CustomControls;
using GravityOne.Forms;
using GravityOne.SpaceObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;

namespace GravityOne.Gravity
{
    [TestClass]
    public class GravitySystemTest
    {
        [TestMethod]
        // Create a square of 4 objects, all 10,000,000 km apart. 
        // XAcceleration on each object is 0.70710678118654752440084436210485*(5/pow(14142135623,2)) + 5/pow(10000000000,2)
        // YAcceleration on each object is 0.70710678118654752440084436210485*(5/pow(14142135623,2)) + 5/pow(10000000000,2)
        // = 6.7677669531491064330205001821662e-20 * 667408000000
        // = 4.5168618066673388262493459855792e-8 m/s^2
        // EscapeVelocity = ((4.5168618066673388262493459855792e-8 ^2 * 2)^0.5 * radius_center_of_mass)^0.5
        // radius_center_of_mass = 7071067811.8654752440084436210485
        // EscapeVelocity = 21.252909934094528191231303953706 m/s
        public void StabilizeObjectsSpeedsTest()
        {
            GravitySystem gravitySystem = new GravitySystem(1290,1080);
            gravitySystem.GravityObjects.Add(new GravityObject("object1", 10000000000, 0, 5));
            gravitySystem.GravityObjects.Add(new GravityObject("object2", 0, 10000000000, 5));
            gravitySystem.GravityObjects.Add(new GravityObject("object3", 10000000000, 10000000000, 5));
            gravitySystem.GravityObjects.Add(new GravityObject("object4", 0, 0, 5));
            gravitySystem.StabilizeObjectsSpeeds(0, false);
            double escapeVelocity = 21.253;
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                Assert.IsTrue(Math.Abs(o.Speed - escapeVelocity)<0.1);
            }
        }

        public void CalculateFrameObjectTest()
        {

        }

        public void QuadTreeCalculateValuesTest()
        {

        }

        [TestMethod]
        public void CalculateStepSimpleGalaxyTest()
        {
            GravitySystem gravitySystem = new GravitySystem(1290, 1080);

            // Create a black hole with 4 stars orbiting it
            double radius = 900000000000000000000.0;
            double mass = 500000000000000000000.0;
            double acceleration = 667408000000 * mass / Math.Pow(radius, 2);
            gravitySystem.AddObject("black hole", mass, 0, 0, 0, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            double EscapeVelocity = Math.Sqrt(/*centripetal_force*/Math.Sqrt(Math.Pow(acceleration, 2)) * radius);
            gravitySystem.AddObject("star1", 198900000.0, 0, -radius, -EscapeVelocity, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.AddObject("star2", 198900000.0, 0, radius, EscapeVelocity, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.AddObject("star3", 198900000.0, radius, 0, 0, -EscapeVelocity, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.AddObject("star4", 198900000.0, -radius, 0, 0, EscapeVelocity, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.CalculationsPerStepActual = 1;

            for (int k = 0; k < 200; k++)
            {
                // Take one step; note that this value will be multipied by TIME_GALAXY_INCREASE_FACTOR
                gravitySystem.CalculateStep(100000, true);
                if (gravitySystem.Message.Text != null && gravitySystem.Message.Text.Equals("Acceleration of object has been limited, because it is too close to another object."))
                {
                    Assert.Fail("Limit not expected");
                }
                foreach (GravityObject o in gravitySystem.GravityObjects)
                {
                    if (o.Name.Equals("black hole"))
                    {
                        continue;
                    }
                    double angleCenter = Math.Atan2(o.Y, o.X);
                    double angleMovementAndCenter = Math.Abs((angleCenter - o.SpeedAngle) % Math.PI);

                    // angle of movement should be perpendicular to center
                    Assert.IsTrue(angleMovementAndCenter > (Math.PI / 2 - 0.1) && angleMovementAndCenter < (Math.PI / 2 + 0.1));
                }
            }
        }

        [TestMethod]
        public void CalculateStepSimpleSolarSystemTest()
        {
            GravitySystem gravitySystem = new GravitySystem(1290, 1080);
            // Create a "simple" solar system with 1 sun and 2 mars-like planets
            // radius is about 227900000000 meters (mars-sun)
            // speed = 24000 m/s
            gravitySystem.AddObject("sun", 198900000.0, 0, 0, 0, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.AddObject("planet1", 50000, 0, 227900000000, -24000, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.AddObject("planet2", 50000, 0, -227900000000, 24000, 0, null, Microsoft.Xna.Framework.Color.White, false, false);
            gravitySystem.CalculationsPerStepActual = 200;

            for (int k = 0; k < 200; k++)
            {
                // Take one step of a day 
                gravitySystem.CalculateStep(86400, true);
                if (gravitySystem.Message.Text != null && gravitySystem.Message.Text.Equals("Acceleration of object has been limited, because it is too close to another object."))
                {
                    Assert.Fail("Limit not expected");
                }
                foreach (GravityObject o in gravitySystem.GravityObjects)
                {
                    if (o.Name.Equals("sun") || o.SolarSystem == null)
                    {
                        continue;
                    }
                    double angleCenter = Math.Atan2(o.Y, o.X);
                    double angleMovementAndCenter = Math.Abs((angleCenter - o.SpeedAngle) % Math.PI);

                    // angle of movement should be perpendicular to center
                    Assert.IsTrue(angleMovementAndCenter > (Math.PI / 2 - 0.1) && angleMovementAndCenter < (Math.PI / 2 + 0.1));
                }
            }
        }

        [TestMethod]
        public void CalculateStepCircleTest()
        {
            GravitySystem gravitySystem = new GravitySystem(1290, 1080);
            Display displayXNA = new Display();
            displayXNA.GravitySystem = gravitySystem;
            PresetObjects presetObjects = new PresetObjects(displayXNA);
            presetObjects.Circle.Mass = 10000000000000000000000000.0;
            presetObjects.Circle.NumObjectsRadius = 10;
            presetObjects.Circle.Rotations = 0.0000030000;
            presetObjects.Circle.SpacingUnits = "km";
            presetObjects.Circle.Spacing = 100000000000;
            presetObjects.CreateCircle(0, 0);
            displayXNA.GravitySystem.CalculationsPerStepActual = 1;
            gravitySystem.CalculateStep(300000, true);
            gravitySystem.CalculateStep(300000, true);

            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                double angleCenter = Math.Atan2(o.Y, o.X);
                double angleMovementAndCenter = Math.Abs((angleCenter - o.SpeedAngle) % Math.PI);
                double distance = DistanceToCenter(o);

                if (distance > 10000)
                {
                    // angle of movement should be perpendicular to center
                    Assert.IsTrue(angleMovementAndCenter > (Math.PI / 2 - 0.1) && angleMovementAndCenter < (Math.PI / 2 + 0.1));
                }
            }
        }

        [TestMethod]
        public void ForceOnGalaxyScaleIsStillTheSameTest()
        {
            GravitySystem gravitySystem = new GravitySystem(1290, 1080);
            Display displayXNA = new Display();
            displayXNA.GravitySystem = gravitySystem;
            PresetObjects presetObjects = new PresetObjects(displayXNA);

            presetObjects.PresetToMilkyWay();
            presetObjects.Galaxy.TotalMass = 12000000000;
            presetObjects.Galaxy.NumberOfObjects = 100;        // limit the number of objects for speed reasons
            presetObjects.Galaxy.CalculateStableSpeed = true;
            presetObjects.Galaxy.HasBlackHole = false;
            presetObjects.Galaxy.MassVariation = 0;
            presetObjects.Galaxy.SpiralBlurriness = 0;
            presetObjects.Galaxy.EllipseBlurriness = 0;
            presetObjects.Galaxy.HasEllipse = false;
            presetObjects.Galaxy.HasBar = false;
            presetObjects.Galaxy.HasSpiral = true;
            presetObjects.CreateGalaxy(0, 0, 0);
            displayXNA.GravitySystem.CalculationsPerStepActual = 10;
            double totalDistanceToCenterBefore = 0, totalDistanceToCenterAfter = 0;
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                totalDistanceToCenterBefore += DistanceToCenter(o);
            }

            for (int k = 0; k < 400; k++)
                displayXNA.GravitySystem.CalculateStep(300000, true);

            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                totalDistanceToCenterAfter += DistanceToCenter(o);
            }

            double distanceRatio = totalDistanceToCenterAfter / totalDistanceToCenterBefore;

            // Distance has increased a bit, but not too much.
            Assert.IsTrue(distanceRatio > 1.2 && distanceRatio < 1.8);
        }

        static double DistanceToCenter(GravityObject o)
        {
            return Math.Sqrt(Math.Pow(o.X, 2) + Math.Pow(o.Y, 2));
        }
    }
}
