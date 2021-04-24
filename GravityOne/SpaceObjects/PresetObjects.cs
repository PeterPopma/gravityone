using GravityOne.CustomControls;
using GravityOne.Gravity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.SpaceObjects
{
    class PresetObjects
    {
        Galaxy galaxy = new Galaxy();
        RandomObjects randomObjects = new RandomObjects();
        Grid grid = new Grid();
        Circle circle = new Circle();
        Random rnd = new Random();
        Display displayXNA;
        GravitySystem gravitySystem;
        private bool _hasDeviate;
        private double _storedDeviate;
        Random random = new Random();

        internal Galaxy Galaxy { get => galaxy; set => galaxy = value; }
        internal RandomObjects RandomObjects { get => randomObjects; set => randomObjects = value; }
        internal Grid Grid { get => grid; set => grid = value; }
        internal Circle Circle { get => circle; set => circle = value; }
        

        public PresetObjects(Display displayXNA_)
        {
            displayXNA = displayXNA_;
            gravitySystem = displayXNA.GravitySystem;
        }

        public void PresetToLargeStableGalaxy()
        {
            Galaxy.TotalMass = 1200000000;       // 0.8–1.5×10^12 for Milky Way
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.CrossSection = 1700000000;
            Galaxy.HasBlackHole = true;
            Galaxy.HasSpiral = true;
            Galaxy.HasEllipse = true;
            Galaxy.NumberOfObjects = 10000;
            Galaxy.RotateCCW = true;
            Galaxy.RotationPeriod = 10000000;
            Galaxy.VelocityIncreaseFactor = 0.1;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.1;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 50;
            Galaxy.SpiralBlurriness = 50;
            Galaxy.MassVariation = 40;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }

        public void PresetToMilkyWay()
        {
            Galaxy.TotalMass = 1200000000000;       // 0.8–1.5×10^12 solar masses. NOTE: totalmass is specified in Solar masses
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.CrossSection = 1700000000;
            Galaxy.HasBlackHole = true;
            Galaxy.HasSpiral = true;
            Galaxy.HasEllipse = true;
            Galaxy.NumberOfObjects = 10000;
            Galaxy.RotateCCW = true;
            Galaxy.RotationPeriod = 360000000;
            Galaxy.VelocityIncreaseFactor = 0.2;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.1;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 50;
            Galaxy.SpiralBlurriness = 50;
            Galaxy.MassVariation = 40;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }

        public void PresetToSmallGalaxy()
        {
            Galaxy.NumberOfObjects = 5000;        // 1 star actually represents 40000000 stars
            Galaxy.TotalMass = 30;                // 1200000000/40000000
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.CrossSection = 42;             // 1700000000/40000000
            Galaxy.HasBlackHole = false;
            Galaxy.HasSpiral = true;
            Galaxy.HasEllipse = false;
            Galaxy.RotateCCW = true;
            Galaxy.RotationPeriod = 3600;
            Galaxy.VelocityIncreaseFactor = 0;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.1;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 50;
            Galaxy.SpiralBlurriness = 30;
            Galaxy.MassVariation = 20;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }

        public void PresetToEllipse()
        {
            Galaxy.CrossSection = 42000;
            Galaxy.NumberOfObjects = 10000;
            Galaxy.TotalMass = 6000000;
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.RotationPeriod = 100000;
            Galaxy.HasBlackHole = false;
            Galaxy.HasSpiral = false;
            Galaxy.HasEllipse = true;
            Galaxy.RotateCCW = true;
            Galaxy.VelocityIncreaseFactor = 0.2;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.1;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 50;
            Galaxy.SpiralBlurriness = 30;
            Galaxy.MassVariation = 20;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }
        public void PresetToSpiral()
        {
            Galaxy.CrossSection = 3000000;
            Galaxy.NumberOfObjects = 10000;
            Galaxy.TotalMass = 1500000000;
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.RotationPeriod = 400000;
            Galaxy.HasBlackHole = true;
            Galaxy.HasSpiral = true;
            Galaxy.HasEllipse = true;
            Galaxy.RotateCCW = true;
            Galaxy.VelocityIncreaseFactor = 0.0;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.4;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 50;
            Galaxy.SpiralBlurriness = 30;
            Galaxy.MassVariation = 20;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }
        public void PresetToSmallEllipse()
        {
            Galaxy.CrossSection = 500000;
            Galaxy.NumberOfObjects = 1500;
            Galaxy.TotalMass = 80000000;
            Galaxy.BlackHoleMass = 4100000;
            Galaxy.RotationPeriod = 200000;
            Galaxy.HasBlackHole = false;
            Galaxy.HasSpiral = false;
            Galaxy.HasEllipse = true;
            Galaxy.RotateCCW = true;
            Galaxy.VelocityIncreaseFactor = 0.0;
            Galaxy.EllipseRatio = 0.5;
            Galaxy.EllipseSizePercentage = 50;
            Galaxy.EllipseObjectsPercentage = 30;
            Galaxy.NumberOfArms = 2;
            Galaxy.ArmLength = 1.1;
            Galaxy.HasBar = true;
            Galaxy.BarPercentage = 20;
            Galaxy.EllipseBlurriness = 30;
            Galaxy.SpiralBlurriness = 30;
            Galaxy.MassVariation = 20;
            Galaxy.AddSolarSystem = false;
            Galaxy.CalculateStableSpeed = false;
            Galaxy.XSpeed = 0;
            Galaxy.YSpeed = 0;
        }

        // Calculate the position and speed of a solar system object
        //
        // @param x  relative position to sun (no unit)
        // @param y  relative position to sun (no unit)
        // @param orbitalVelocity  orbital velocity around sun (m/s)
        // @param radius  radius circle around sun the object makes (m)
        private PositionSpeed CalculatePositionSpeed(double x, double y, double orbitalVelocity, double radius)
        {
            PositionSpeed posSpeed = new PositionSpeed();
            double angle = Math.Atan2(y, x);

            // ----- adjustment for position compared to 1/1/2017
            long diffSeconds = displayXNA.SimulationTime - new DateTime(2017, 1, 1).Ticks/10000000;
            // Calculate how many radians/s the planet is moving. orbitalVelocity in m/s, radius in m
            double radiansPerSecond = orbitalVelocity / radius;
            angle += diffSeconds * radiansPerSecond;
            // --------------------------------------------------

            posSpeed.X = Math.Cos(angle) * radius;
            posSpeed.Y = Math.Sin(angle) * radius;
            angle += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            posSpeed.XSpeed = Math.Cos(angle) * orbitalVelocity;
            posSpeed.YSpeed = Math.Sin(angle) * orbitalVelocity;

            return posSpeed;
        }

        public void CreateSlingShot(double x, double y)
        {
            Random rnd = new Random();

            gravitySystem.AddObject("Planet", 25000000.0f, x, y, 10000, 0, displayXNA.GetTextureByName("Planet"), false, false);

            for (int k = 0; k < 8; k++)
            {
                gravitySystem.AddObject("Object " + (k * 2 + 1).ToString(), 1.0f, x - 800 - k * 120, y - 10 - Math.Pow(k, 2) * 3, 25000, 0, displayXNA.GetTextureByName("Metal Ball"), true, true);
                gravitySystem.AddObject("Object " + (k * 2 + 2).ToString(), 1.0f, x - 800 - k * 120, y + 10 + Math.Pow(k, 2) * 3, 25000, 0, displayXNA.GetTextureByName("Metal Ball"), true, true);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = 0;     // center on first object

//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateGrid(double xCenter, double yCenter)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double gridSpacingMeters = Grid.Spacing * 1000000000;    // default million km.
            if (Grid.SpacingUnits.Equals("pixels"))
            {
                gridSpacingMeters = gravitySystem.PixelsToMeters(Grid.Spacing);
            }
            int count = 0;
            for (double y = yCenter - (gridSpacingMeters * Grid.YAmount) * 0.5; y < yCenter + (gridSpacingMeters * Grid.YAmount) * 0.5; y += gridSpacingMeters)
            {
                for (double x = xCenter - (gridSpacingMeters * Grid.XAmount) * 0.5; x < xCenter + (gridSpacingMeters * Grid.XAmount) * 0.5; x += gridSpacingMeters)
                {
                    count++;
                    if (Grid.Rotations == 0)
                    {
                        gravitySystem.AddObject("Grid object " + count, Grid.Mass, x, y, 0, 0, Grid.Texture, false, false);
                    }
                    else
                    {
                        double angleWithCenter = Math.Atan2(y - yCenter, x - xCenter);
                        angleWithCenter += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                        double distanceFromCenter = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
                        double distancePerYear = distanceFromCenter * Math.PI * 2.0 * Grid.Rotations;
                        double orbitalVelocity = distancePerYear / (24 * 60 * 60 * 365);
                        double XSpeed = Math.Cos(angleWithCenter) * orbitalVelocity;
                        double YSpeed = Math.Sin(angleWithCenter) * orbitalVelocity;
                        gravitySystem.AddObject("Grid object " + count, Grid.Mass, x, y, XSpeed, YSpeed, Grid.Texture, false, false);
                    }
                }
            }

            if (Grid.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += Grid.XSpeed;
                }
            }
            if (Grid.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += Grid.YSpeed;
                }
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object
        }

        public void CreateCircle(double xCenter, double yCenter)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double circleSpacingMeters = Circle.Spacing * 1000000000;    // default million km.
            if (Circle.SpacingUnits.Equals("pixels"))
            {
                circleSpacingMeters = gravitySystem.PixelsToMeters(Circle.Spacing);
            }
            int count = 0;
            double maxDistance = circleSpacingMeters * Circle.NumObjectsRadius;
            for (double y = yCenter - (circleSpacingMeters * Circle.NumObjectsRadius); y <= yCenter + (circleSpacingMeters * Circle.NumObjectsRadius); y += circleSpacingMeters)
            {
                for (double x = xCenter - (circleSpacingMeters * Circle.NumObjectsRadius); x <= xCenter + (circleSpacingMeters * Circle.NumObjectsRadius); x += circleSpacingMeters)
                {
                    double distanceFromCenter = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
                    count++;
                    if (distanceFromCenter < maxDistance)
                    {
                        if (Circle.Rotations == 0)
                        {
                            gravitySystem.AddObject("Circle object " + count, Circle.Mass, x, y, 0, 0, Circle.Texture, false, false);
                        }
                        else
                        {
                            double angleWithCenter = Math.Atan2(y - yCenter, x - xCenter);
                            angleWithCenter += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                            double distancePerYear = distanceFromCenter * Math.PI * 2.0 * Circle.Rotations;
                            double orbitalVelocity = distancePerYear / (24 * 60 * 60 * 365);
                            double XSpeed = Math.Cos(angleWithCenter) * orbitalVelocity;
                            double YSpeed = Math.Sin(angleWithCenter) * orbitalVelocity;
                            gravitySystem.AddObject("Circle object " + count, Circle.Mass, x, y, XSpeed, YSpeed, Circle.Texture, false, false);
                        }
                    }
                }
            }

            if (Circle.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += Circle.XSpeed;
                }
            }
            if (Circle.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += Circle.YSpeed;
                }
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object
        }


        public void CreateRandom(double x, double y)
        {
            Random rnd = new Random();
            double areaMeters = Convert.ToDouble(RandomObjects.Area * 1000000000);    // default million km.
            if (RandomObjects.AreaUnits.Equals("pixels"))
            {
                areaMeters = gravitySystem.PixelsToMeters(RandomObjects.Area);
            }

            for (int k = 0; k < RandomObjects.NumberOfObjects; k++)
            {
                double x_adjustPercentage = (rnd.Next(0, 2000) - 1000) / 2000.0;
                double y_adjustPercentage = (rnd.Next(0, 2000) - 1000) / 2000.0;
                double x_speed = 0;
                double y_speed = 0;
                if (RandomObjects.Speed > 0)
                {
                    double direction = (rnd.Next(0, 10000) * 2 * Math.PI) / 10000.0;
                    x_speed = RandomObjects.Speed * Math.Cos(direction);
                    y_speed = RandomObjects.Speed * Math.Sin(direction);
                    if (RandomObjects.SpeedRandomness > 0)
                    {
                        double adjustSpeedPercentage = 100 - RandomObjects.SpeedRandomness + (2 * RandomObjects.SpeedRandomness * rnd.Next(0, 10000) / 10000.0);
                        x_speed *= (adjustSpeedPercentage / 100);
                        adjustSpeedPercentage = 100 - RandomObjects.SpeedRandomness + (2 * RandomObjects.SpeedRandomness * rnd.Next(0, 10000) / 10000.0);
                        y_speed *= (adjustSpeedPercentage / 100);
                    }
                }
                gravitySystem.AddObject("Random object " + k.ToString(), RandomObjects.Mass, x + (x_adjustPercentage * areaMeters), y + (y_adjustPercentage * areaMeters), x_speed, y_speed, RandomObjects.Texture, false, false);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object

//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }


        /// <summary>
        /// Obtains normally (Gaussian) distributed random numbers, using the Box-Muller
        /// transformation.  This transformation takes two uniformly distributed deviates
        /// within the unit circle, and transforms them into two independently
        /// distributed normal deviates.
        /// </summary>
        /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
        /// <param name="mu">The mean of the distribution.  Default is zero.</param>
        /// <returns></returns>
        public double CalculateDeviation(double sigma = 1, double mu = 0)
        {
            if (sigma <= 0)
                return mu;

            if (_hasDeviate)
            {
                _hasDeviate = false;
                return _storedDeviate * sigma + mu;
            }

            double v1, v2, rSquared;
            do
            {
                // two random values between -1.0 and 1.0
                v1 = 2 * rnd.NextDouble() - 1;
                v2 = 2 * rnd.NextDouble() - 1;
                rSquared = v1 * v1 + v2 * v2;
                // ensure within the unit circle
            } while (rSquared >= 1 || rSquared == 0);

            // calculate polar tranformation for each deviate
            var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
            // store first deviate
            _storedDeviate = v2 * polar;
            _hasDeviate = true;
            // return second deviate
            return v1 * polar * sigma + mu;
        }

        public void CreateGalaxy(double x_real, double y_real, int startPosition)
        {
            int minMass = (int)(1000 - 1000 * Galaxy.MassVariation / 100.0);
            int maxMass = (int)(1000 + 1000 * Galaxy.MassVariation / 100.0);
            double averageMass = (Galaxy.TotalMass / (double)Galaxy.NumberOfObjects) * 1000;
            if (Galaxy.HasBlackHole)
            {
                gravitySystem.AddObject("Black Hole", (long)Galaxy.BlackHoleMass * 198910000, x_real, y_real, 0, 0, displayXNA.GetTextureByName("Point"), Color.White, false, false, true, 0, false);
            }

            //            double max_radius = gravitySystem.MetersToPixels((galaxy.CrossSection / 2) * 1000000000000.0);
            double max_radius = (Galaxy.CrossSection / 2.0) * 1000000000000.0;
            double outer_speed = 2 * Math.PI * (Galaxy.CrossSection / 2.0) * 100000.0 / (Galaxy.RotationPeriod * 3.1558150);  // in m/s (removed 7 zeroes from years and bln. km.)
            // speed of solar system should be about 2.2 X 10^5 meters per second
            // accelleration of solar system should be about  1.9 X 10^-10 meter per squared second
            int objectNumber = 0;

            if (Galaxy.HasEllipse)
            {
                int numberOfObjects = Galaxy.NumberOfObjects;
                if (Galaxy.HasSpiral)        // percentage of objects is lost to spiral
                {
                    numberOfObjects = (int)(numberOfObjects * ((Galaxy.EllipseObjectsPercentage) / 100.0));
                }
                for (int k = 0; k < numberOfObjects; k++)
                {
                    double angle = rnd.Next(0, 36000) / 100.0;
                    double mass = (double)(rnd.Next(minMass, maxMass)) * 198910000;
                    mass *= averageMass;
                    int random = rnd.Next(0, 1000);
                    random = (int)Math.Pow(random, 2);        // 0.. 1000000
                    double normal_deviation = CalculateDeviation(1);
                    double fuzzy_deviation = rnd.Next(-1000, 1000) / 1000.0;
                    double deviation = ((normal_deviation * (100 - Galaxy.EllipseBlurriness)) + (fuzzy_deviation * Galaxy.EllipseBlurriness)) / 100.0;
                    double actual_radius = Math.Abs(deviation * max_radius * (Galaxy.EllipseSizePercentage / 100.0));      // Math.Pow(minus,..) gives a NaN..
                    // for linear increase: speed = outer_speed * (actual_radius/max_radius)
                    // for ^2 increase: speed = (max_radius/actual_radius)^2 * outer_speed * (actual_radius/max_radius)
                    // -> increase: speed = (max_radius/actual_radius)^galaxy.VelocityIncreaseFactor * outer_speed * (actual_radius/max_radius)
                    double velocity = 0;
                    if (actual_radius > 0)
                    {
                        velocity = Math.Pow((max_radius / actual_radius), Galaxy.VelocityIncreaseFactor) * outer_speed * (actual_radius / max_radius);
                    }

                    // randomize velocity +/- 10%
                    velocity *= 0.9 + rnd.Next(0, 200) / 1000.0;

                    double direction_angle = angle - (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                    Vector speed = new Vector();
                    speed.X = Math.Cos(direction_angle) * velocity;
                    speed.Y = Math.Sin(direction_angle) * velocity;

                    if (!Galaxy.RotateCCW)
                    {
                        speed.X = -speed.X;
                        speed.Y = -speed.Y;
                    }
                    objectNumber++;
                    gravitySystem.AddObject("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(angle), y_real + actual_radius * Galaxy.EllipseRatio * Math.Sin(angle), speed.X, speed.Y, displayXNA.TextureCustomShape, Galaxy.Color, false, false, false, 0, false);
                }
            }

            if (Galaxy.HasSpiral)
            {
                int numberOfObjects = Galaxy.NumberOfObjects;
                if (Galaxy.HasEllipse)        // percentage of objects is lost to ellipse
                {
                    numberOfObjects = (int)(numberOfObjects * ((100 - Galaxy.EllipseObjectsPercentage) / 100.0));
                }
                numberOfObjects /= Galaxy.NumberOfArms;
                double init_angle = 0;
                double angle_increase = 2 * Math.PI / Galaxy.NumberOfArms;
                bool SolarSystemAdded = false;
                for (int spiral = 0; spiral < Galaxy.NumberOfArms; spiral++)
                {
                    double current_angle = init_angle;
                    for (double radius = 0; radius < max_radius; radius += max_radius / numberOfObjects)
                    {
                        double mass = (double)(rnd.Next(minMass, maxMass)) * 198910000;
                        mass *= averageMass;
                        bool isBar = Galaxy.HasBar && Galaxy.NumberOfArms == 2 && ((radius / max_radius) * 100 < Galaxy.BarPercentage);
                        if (!isBar)
                        {
                            if (Galaxy.RotateCCW)
                            {
                                current_angle += (Galaxy.ArmLength * 2 * Math.PI) / numberOfObjects;    // make ArmLength full circles
                            }
                            else
                            {
                                current_angle -= (Galaxy.ArmLength * 2 * Math.PI) / numberOfObjects;    // make ArmLength full circles
                            }
                        }
                        double deviation = 1 + (CalculateDeviation(Galaxy.SpiralBlurriness * (1 - ((radius / max_radius) / 1.2))) / 200.0); // more deviation at center
                                                                                                                                            //                        double deviation = CalculateDeviation(galaxy.EllipseBlurriness) / (2 * galaxy.EllipseBlurriness);
                        double actual_radius = Math.Abs(deviation * radius);      // Math.Pow(minus,..) gives a NaN..

                        double adjust_x = Math.Cos(current_angle) * actual_radius;
                        double adjust_y = Math.Sin(current_angle) * actual_radius;

                        // for linear increase: speed = outer_speed * (actual_radius/max_radius)
                        // for ^2 increase: speed = (max_radius/actual_radius)^2 * outer_speed * (actual_radius/max_radius)
                        // -> increase: speed = (max_radius/actual_radius)^galaxy.VelocityIncreaseFactor * outer_speed * (actual_radius/max_radius)
                        double velocity = 0;
                        if (actual_radius > 0)
                        {
                            velocity = Math.Pow((max_radius / actual_radius), Galaxy.VelocityIncreaseFactor) * outer_speed * (actual_radius / max_radius);
                        }
                        double direction_angle = current_angle - (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                        Vector speed = new Vector();
                        speed.X = Math.Cos(direction_angle) * velocity;
                        speed.Y = Math.Sin(direction_angle) * velocity;

                        if (!Galaxy.RotateCCW)
                        {
                            speed.X = -speed.X;
                            speed.Y = -speed.Y;
                        }

                        objectNumber++;
                        if (objectNumber <= Galaxy.NumberOfObjects)       // neccessary because of rounding issues
                        {
                            if (!isBar)
                            {
                                if (Galaxy.AddSolarSystem && !SolarSystemAdded && spiral == Galaxy.NumberOfArms - 1 && ((radius / max_radius) > 0.75))     // add solar system in last spiral at 75%
                                {
                                    SolarSystemAdded = true;
                                    GravityObject solarSystem = CreateSolarSystem(x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle));
                                    gravitySystem.ObjectIndex = gravitySystem.GravityObjects.FindIndex(a => a.Name == "Earth");
                                    gravitySystem.VisibleObjectsIndex = gravitySystem.GetVisibleObjectIndex();
                                    gravitySystem.MinimumTextureSize = 1;
                                    solarSystem.XSpeed = speed.X;
                                    solarSystem.YSpeed = speed.Y;

                                    // Proxima centauri = 40,208,000,000,000 km = 40208000000000000
                                    gravitySystem.AddObject("Alpha Centauri", mass, x_real + (actual_radius+40208000000000000) * Math.Cos(current_angle), y_real + (actual_radius + 40208000000000000) * Math.Sin(current_angle), speed.X, speed.Y, displayXNA.TextureCustomShape, Galaxy.Color, false, false, false, 0, false);
                                }
                                else
                                {
                                    gravitySystem.AddObject("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y, displayXNA.TextureCustomShape, Galaxy.Color, false, false, false, 0, false);
                                }
                            }
                            else
                            {
                                deviation = CalculateDeviation(Galaxy.SpiralBlurriness * (1 - ((radius / max_radius) / 1.2))) / 1500.0;  // more deviation at center
                                gravitySystem.AddObject("Star " + objectNumber, mass, x_real + actual_radius * 0.85 /*prevent too long bar */ * Math.Cos(current_angle), y_real + (deviation * max_radius), speed.X, speed.Y, displayXNA.TextureCustomShape, Galaxy.Color, false, false, false, 0, false);
                            }
                        }
                    }

                    init_angle += angle_increase;
                }
            }

            if (Galaxy.CalculateStableSpeed)
            {
                displayXNA.Refresh();
                gravitySystem.StabilizeObjectsSpeeds(startPosition, Galaxy.RotateCCW);
            }
            if (Galaxy.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += Galaxy.XSpeed;
                }
            }
            if (Galaxy.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += Galaxy.YSpeed;
                }
            }
        }


        public void CreateSunPlanetMoon(double x, double y)
        {
            gravitySystem.AddObject("Sun", 198900000.0, x, y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            PositionSpeed posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObject("Planet", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.AddObject("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, displayXNA.GetTextureByName("Moon"), true, false, true);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;       // sun
                gravitySystem.CenterIndex = 0;
            }
//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateMoonMoon(double x, double y)
        {
            gravitySystem.AddObject("Sun", 1000000000000.0, x, y, -50, -100, displayXNA.GetTextureByName("Sun"), false, false);
            gravitySystem.AddObject("Planet", 20000000000.0, x + 1500000000000, y, 0, 1220000, displayXNA.GetTextureByName("Earth"), true, false);
            gravitySystem.AddObject("Moon", 5000000000.0, x + 1500000000000 + 20000000000, y, 0, 2080000, displayXNA.GetTextureByName("Moon"), true, false);
            gravitySystem.AddObject("Moon of a moon", 1.0, x + 1500000000000 + 20000000000 + 384000000, y, 0, 4080000, displayXNA.GetTextureByName("Asteroid"), true, false); 
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;          // sun
                gravitySystem.CenterIndex = 1;          // planet
            }
//            displayXNA.ParentForm.macTrackBarScale.Value = 327;

//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }


        public void CreateSunPlanet(double x, double y)
        {
            gravitySystem.AddObject("Sun", 100000000.0, x, y, 0, -5, displayXNA.GetTextureByName("Sun"), false, false);
            gravitySystem.AddObject("Planet", 500.0, x + 150000000000, y, 0, 25000, displayXNA.GetTextureByName("Planet"), true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on sun
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = 0;       // sun
            }
//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreatePlanetMoon(double x, double y)
        {
            gravitySystem.AddObject("Planet", 1000.0, x, y, 0, -5, displayXNA.GetTextureByName("Earth"), true, false);
            gravitySystem.AddObject("Moon", 5.0, x + 384000000, y, 0, 1100, displayXNA.GetTextureByName("Moon"), true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on planet
            {
                gravitySystem.ObjectIndex = 0;       // planet
                gravitySystem.CenterIndex = 0;
            }
//            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateBinaryTwoPlanets(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 4000000000.0, x - 150000000000, y, 0, 44000, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Sun 2", 4000000000.0, x + 150000000000, y, 0, -44000, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, x - 150000000000 - 15000000000, y, 0, -500000, displayXNA.GetTextureByName("Planet"), true, false);
            gravitySystem.AddObject("Planet 2", 1000.0, x + 150000000000 + 15000000000, y, 0, 500000, displayXNA.GetTextureByName("Planet"), true, false);
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
//                displayXNA.ParentForm.macTrackBarScale.Value = 292;
//                displayXNA.ParentForm.SetSpeed(60 * 60 * 2);

            }
//            gravitySystem.ScaleObjects();
        }

        public void CreateBinaryOnePlanetStable(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 198900000.0, x - 150000000000, y, 0, 20000, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Sun 2", 198900000.0, x + 150000000000, y, 0, -20000, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Planet", 597.2, x + 150000000000 + 15000000000, y, 0, 40000, displayXNA.GetTextureByName("Planet"), true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 2;       // planet
                gravitySystem.CenterIndex = -1;
//                displayXNA.ParentForm.macTrackBarScale.Value = 297;
//                displayXNA.ParentForm.SetSpeed(60 * 60 * 24);
            }
//            gravitySystem.ScaleObjects();
        }

        public void CreateBinaryOnePlanetHopping(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 2000000000.0, x - 150000000000, y, 0, 24900, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Sun 2", 2000000000.0, x + 150000000000, y, 0, -24900, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Planet", 100.0, x, y, 0, -190000, displayXNA.GetTextureByName("Planet"), true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
//                displayXNA.ParentForm.macTrackBarScale.Value = 294;
//                displayXNA.ParentForm.SetSpeed(60 * 60 * 8);
            }
//            gravitySystem.ScaleObjects();
        }

        public void CreateTripleStar(double x, double y)
        {
            double radius = 150000000000;
            double speed = 64000;
            double mass = 2400000000.0f;
            double angle = 0.0f;
            double speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            double XSpeed = Math.Cos(speed_angle) * speed;
            double YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 1", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, Math.Cos(angle) * radius + x + 30, Math.Sin(angle) * radius + y, XSpeed, YSpeed + 330000, displayXNA.GetTextureByName("Planet"), true, false);
            angle = Math.PI / 1.5;       // 120 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 2", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.GetTextureByName("Sun"), true, false);
            angle = Math.PI / 0.75;       // 240 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 3", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.GetTextureByName("Sun"), true, false);
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup
            {
                gravitySystem.ObjectIndex = 0;       // sun 1
                gravitySystem.CenterIndex = -1;
//                displayXNA.ParentForm.macTrackBarScale.Value = 294;
//                displayXNA.ParentForm.SetSpeed(60 * 60 * 8);
            }
//            gravitySystem.ScaleObjects();
        }

        private Object2D randomPointWithRadius(double x, double y, double lightYears)
        {
            double angle = random.NextDouble() * Math.PI * 2;
            Object2D value = new Object2D();
            value.X = x + gravitySystem.LightYearsToMeters(lightYears * Math.Cos(angle));
            value.Y = y + gravitySystem.LightYearsToMeters(lightYears * Math.Sin(angle));

            return value;
        }

        public void CreateNeighbourhood(double x, double y)
        {
            GravityObject lastObject = CreateSolarSystem(x, y);
            lastObject.Name = "Our Solar System";
            Object2D position = randomPointWithRadius(x, y, 4.37);
            gravitySystem.AddObject("Alpha Centauri A", gravitySystem.SolarMassToKg(1.1), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Alpha Centauri B", gravitySystem.SolarMassToKg(0.9), position.X + gravitySystem.AUToMeters(20), position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Alpha Centauri C", gravitySystem.SolarMassToKg(0.123), position.X + gravitySystem.LightYearsToMeters(0.21), position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false));
            lastObject = gravitySystem.AddObject("Proxima Centauri b", gravitySystem.EarthMassToKg(1.27), position.X + gravitySystem.LightYearsToMeters(0.21) + gravitySystem.AUToMeters(0.0485), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Alpha Centauri";

            position = randomPointWithRadius(x, y, 5.9577);
            lastObject = gravitySystem.AddObject("Barnard's Star", gravitySystem.SolarMassToKg(0.144), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 6.5029);
            gravitySystem.AddObject("Luhman 16A", gravitySystem.JupiterMassToKg(33.5), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            lastObject = gravitySystem.AddObject("Luhman 16B", gravitySystem.JupiterMassToKg(28.6), position.X, position.Y + gravitySystem.AUToMeters(3.5), 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            if (lastObject.SolarSystem == null)
            {
                lastObject = gravitySystem.AddObject("Luhman 16B", gravitySystem.JupiterMassToKg(28.6), position.X, position.Y + gravitySystem.AUToMeters(3.5), 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            }
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Luhman";

            position = randomPointWithRadius(x, y, 7.28);
            lastObject = gravitySystem.AddObject("WISE 0855 0714", gravitySystem.JupiterMassToKg(5), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 7.89);
            lastObject = gravitySystem.AddObject("Wolf 359", gravitySystem.SolarMassToKg(0.09), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 8.31);
            lastObject = gravitySystem.AddObject("Lalande 21185", gravitySystem.SolarMassToKg(0.46), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 8.6);
            gravitySystem.AddObject("Sirius A", gravitySystem.SolarMassToKg(2.063), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            lastObject = gravitySystem.AddObject("Sirius B", gravitySystem.SolarMassToKg(1.018), position.X + gravitySystem.AUToMeters(20), position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Sirius";

            position = randomPointWithRadius(x, y, 8.73);
            gravitySystem.AddObject("Luyten 726 8 A", gravitySystem.SolarMassToKg(0.102), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            lastObject = gravitySystem.AddObject("Luyten 726 8 B", gravitySystem.SolarMassToKg(0.100), position.X + gravitySystem.AUToMeters(5), position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Luyten 726";

            position = randomPointWithRadius(x, y, 9.7035);
            lastObject = gravitySystem.AddObject("Ross 154", gravitySystem.SolarMassToKg(0.17), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 10.29);
            lastObject = gravitySystem.AddObject("Ross 248", gravitySystem.SolarMassToKg(0.136), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 10.446);
            gravitySystem.AddObject("Epsilon Eridani", gravitySystem.SolarMassToKg(0.82), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            lastObject = gravitySystem.AddObject("Epsilon Eridani b", gravitySystem.JupiterMassToKg(1.55), position.X + gravitySystem.AUToMeters(3.50), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Epsilon Eridani";

            position = randomPointWithRadius(x, y, 10.7211);
            gravitySystem.AddObject("Lacaille 9352", gravitySystem.SolarMassToKg(0.503), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 11.0074);
            gravitySystem.AddObject("Ross 128", gravitySystem.SolarMassToKg(0.168), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            lastObject = gravitySystem.AddObject("Ross 128 b", gravitySystem.EarthMassToKg(1.35), position.X + gravitySystem.AUToMeters(0.0493), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Ross 128";

            position = randomPointWithRadius(x, y, 11.46);
            gravitySystem.AddObject("Procyon A", gravitySystem.SolarMassToKg(1.499), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.AddObject("Procyon B", gravitySystem.SolarMassToKg(0.602), position.X + gravitySystem.AUToMeters(15), position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 11.905);
            gravitySystem.AddObject("Tau Ceti", gravitySystem.SolarMassToKg(0.783), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Tau Ceti b", gravitySystem.EarthMassToKg(2.00), position.X + gravitySystem.AUToMeters(0.105), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Tau Ceti c", gravitySystem.EarthMassToKg(3.1), position.X + gravitySystem.AUToMeters(0.195), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Tau Ceti d", gravitySystem.EarthMassToKg(3.60), position.X + gravitySystem.AUToMeters(0.374), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Tau Ceti e", gravitySystem.EarthMassToKg(4.30), position.X + gravitySystem.AUToMeters(0.552), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            lastObject = gravitySystem.AddObject("Tau Ceti f", gravitySystem.EarthMassToKg(6.6), position.X + gravitySystem.AUToMeters(1.35), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Tau Ceti";

            position = randomPointWithRadius(x, y, 15.250);
            gravitySystem.AddObject("Gliese 876", gravitySystem.SolarMassToKg(0.37), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Gliese 876 d", gravitySystem.EarthMassToKg(6.83), position.X, position.Y + gravitySystem.AUToMeters(0.02080665), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Gliese 876 c", gravitySystem.JupiterMassToKg(0.7142), position.X, position.Y + gravitySystem.AUToMeters(0.129590), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Gliese 876 b", gravitySystem.JupiterMassToKg(2.2756), position.X, position.Y + gravitySystem.AUToMeters(0.208317), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            lastObject = gravitySystem.AddObject("Gliese 876 e", gravitySystem.EarthMassToKg(14.6), position.X, position.Y + gravitySystem.AUToMeters(0.3343), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Gliese 876";

            position = randomPointWithRadius(x, y, 20.545);
            gravitySystem.AddObject("Gliese 581", gravitySystem.SolarMassToKg(0.31), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Gliese 581 e", gravitySystem.EarthMassToKg(0.02815), position.X + gravitySystem.AUToMeters(0.02815), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("Gliese 581 b", gravitySystem.EarthMassToKg(0.04061), position.X + gravitySystem.AUToMeters(0.04061), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            lastObject = gravitySystem.AddObject("Gliese 581 c", gravitySystem.EarthMassToKg(0.0721), position.X + gravitySystem.AUToMeters(0.0721), position.Y, 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Gliese 581";

            position = randomPointWithRadius(x, y, 25.04);
            lastObject = gravitySystem.AddObject("Vega", gravitySystem.SolarMassToKg(2.135), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 33.78);
            lastObject = gravitySystem.AddObject("Pollux", gravitySystem.SolarMassToKg(1.91), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 36.7);
            lastObject = gravitySystem.AddObject("Arcturus", gravitySystem.SolarMassToKg(1.08), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 39.6);
            gravitySystem.AddObject("Trappist 1", gravitySystem.SolarMassToKg(0.089), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1b", gravitySystem.EarthMassToKg(1.017), position.X, position.Y + gravitySystem.AUToMeters(0.01154775), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1c", gravitySystem.EarthMassToKg(1.156), position.X, position.Y + gravitySystem.AUToMeters(0.01581512), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1d", gravitySystem.EarthMassToKg(0.297), position.X, position.Y + gravitySystem.AUToMeters(0.02228038), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1e", gravitySystem.EarthMassToKg(0.772), position.X, position.Y + gravitySystem.AUToMeters(0.02928285), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1f", gravitySystem.EarthMassToKg(0.934), position.X, position.Y + gravitySystem.AUToMeters(0.03853361), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            gravitySystem.SetSpeedByHost(gravitySystem.AddObject("trappist 1g", gravitySystem.EarthMassToKg(1.148), position.X, position.Y + gravitySystem.AUToMeters(0.04687692), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true));
            lastObject = gravitySystem.AddObject("trappist 1h", gravitySystem.EarthMassToKg(0.331), position.X, position.Y + gravitySystem.AUToMeters(0.06193488), 0, 0, displayXNA.GetTextureByName("Planet"), true, false, true);
            gravitySystem.SetSpeedByHost(lastObject);
            lastObject.SolarSystem.Name = "Trappist 1";

            position = randomPointWithRadius(x, y, 43.44);
            lastObject = gravitySystem.AddObject("Capella", gravitySystem.SolarMassToKg(2.5687), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 65.3);
            lastObject = gravitySystem.AddObject("Aldebaran", gravitySystem.SolarMassToKg(1.16), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 139);
            lastObject = gravitySystem.AddObject("Alcemar", gravitySystem.SolarMassToKg(6.7), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 310);
            lastObject = gravitySystem.AddObject("Canopus", gravitySystem.SolarMassToKg(8), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 432.57);
            lastObject = gravitySystem.AddObject("Polaris", gravitySystem.SolarMassToKg(6), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 550);
            lastObject = gravitySystem.AddObject("Antares A", gravitySystem.SolarMassToKg(12), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            lastObject = gravitySystem.AddObject("Antares B", gravitySystem.SolarMassToKg(7.2), position.X + gravitySystem.AUToMeters(220), position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 723.18);
            lastObject = gravitySystem.AddObject("Betelgeuse", gravitySystem.SolarMassToKg(20), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);
            lastObject = gravitySystem.AddObject("Rigel", gravitySystem.SolarMassToKg(17), position.X + gravitySystem.LightYearsToMeters(862.85-723.18), position.Y, 0, 0, displayXNA.GetTextureByName("Brown Dwarf"), true, false);

            position = randomPointWithRadius(x, y, 2615);
            lastObject = gravitySystem.AddObject("Deneb", gravitySystem.SolarMassToKg(19), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 2764.1);
            lastObject = gravitySystem.AddObject("V762 Cas", gravitySystem.SolarMassToKg(20), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            position = randomPointWithRadius(x, y, 3400);
            lastObject = gravitySystem.AddObject("Rho Cassiopeiae (farthest visible star)", gravitySystem.SolarMassToKg(40), position.X, position.Y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            gravitySystem.AddObject("Milky Way Center", gravitySystem.SolarMassToKg(0.783), x + gravitySystem.LightYearsToMeters(26490), y, 0, 0, displayXNA.GetTextureByName("Metal Ball"), true, false);

            // Disable all galaxy objects, so they stay in their place
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                if (o.SolarSystem == null)
                    o.IsActive = false;
            }
        }


        public GravityObject CreateSolarSystem(double x, double y)
        {
            gravitySystem.AddObject("Sun", 198900000.0, x, y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObject("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Mercury"), true, false, true);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObject("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Venus"), true, false, true);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObject("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Earth"), true, false, true);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObject("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, displayXNA.GetTextureByName("Moon"), true, false, true);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObject("Mars", 63.9, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Mars"), true, false, true);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObject("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Jupiter"), true, false, true);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObject("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Saturn"), true, false, true); 

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObject("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Uranus"), true, false, true);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObject("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Neptune"), true, false, true);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            GravityObject solarSystem = gravitySystem.AddObject("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Pluto"), true, false, true).SolarSystem;

            if (gravitySystem.GravityObjects.Count == 12)      // no objects before this setup; select earth, center on sun
            {
                gravitySystem.ObjectIndex = 4;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

            return solarSystem;
        }

        public void CreateSolarSystemMoons(double x, double y)
        {
            gravitySystem.AddObject("Sun", 198900000.0, x, y, 0, 0, displayXNA.GetTextureByName("Sun"), true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObject("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Mercury"), true, false, true);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObject("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Venus"), true, false, true);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObject("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Earth"), true, false, true);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObject("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, displayXNA.GetTextureByName("Moon"), true, false, true);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObject("Mars", 63.90000000, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Mars"), true, false, true);

            gravitySystem.AddObject("Phobos", 0.0000010659, posSpeed.X + x + 9377000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 2138, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Deimos", 0.0000001471, posSpeed.X + x - 23436000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 1351, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(0, 1, -17905, 419000000000);
            gravitySystem.AddObject("Ceres", 0.09393, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObject("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Jupiter"), true, false, true);

            gravitySystem.AddObject("Io", 8.9319, posSpeed.X + x + 421700000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 17334, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Europa", 4.8, posSpeed.X + x - 671034000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 13740, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Ganymede", 14.819, posSpeed.X + x + 1070412000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10880, displayXNA.GetTextureByName("Asteroid"), true, false, true); 
            gravitySystem.AddObject("Callisto", 10.759, posSpeed.X + x - 1882709000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 8204, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObject("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Saturn"), true, false, true);

            gravitySystem.AddObject("Dione", 0.11, posSpeed.X + x + 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10030, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Rhea", 0.23, posSpeed.X + x + 527108000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 8480, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Titan", 13.5, posSpeed.X + x - 1221870000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5570, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Iapetus", 0.18, posSpeed.X + x - 3560820000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3260, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObject("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Uranus"), true, false, true);

            gravitySystem.AddObject("Miranda", 0.00659, posSpeed.X + x - 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 6660, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Ariel", 0.1353, posSpeed.X + x - 191020000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5510, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Umbriel", 0.1172, posSpeed.X + x - 266300000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4670, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Titania", 0.3527, posSpeed.X + x - 435910000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3640, displayXNA.GetTextureByName("Asteroid"), true, false, true);
            gravitySystem.AddObject("Oberon", 0.3014, posSpeed.X + x - 583520000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3150, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObject("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Neptune"), true, false, true);

            gravitySystem.AddObject("Triton", 2.1408, posSpeed.X + x - 354759000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4390, displayXNA.GetTextureByName("Asteroid"), true, false, true);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObject("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.GetTextureByName("Pluto"), true, false, true);

            if (gravitySystem.GravityObjects.Count == 29)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 4;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

        }
    }
}

