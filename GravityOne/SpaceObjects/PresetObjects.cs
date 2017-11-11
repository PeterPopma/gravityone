using GravityOne.CustomControls;
using GravityOne.Gravity;
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

        internal Galaxy Galaxy { get => galaxy; set => galaxy = value; }
        internal RandomObjects RandomObjects { get => randomObjects; set => randomObjects = value; }
        internal Grid Grid { get => grid; set => grid = value; }
        internal Circle Circle { get => circle; set => circle = value; }

        public PresetObjects(Display displayXNA_)
        {
            displayXNA = displayXNA_;
            gravitySystem = displayXNA.GravitySystem;
        }

        private PositionSpeed CalculatePositionSpeed(double x, double y, double orbitalVelocity, double radius)
        {
            PositionSpeed posSpeed = new PositionSpeed();
            double angle = Math.Atan2(y, x);

            // ----- adjustment for position compared to 1/1/2017
            TimeSpan diff = displayXNA.SimulationTime.Subtract(new DateTime(2017, 1, 1));
            // Calculate how many radians/s the planet is moving. orbitalVelocity in m/s, radius in m
            double radiansPerSecond = orbitalVelocity / radius;
            angle += diff.TotalSeconds * radiansPerSecond;
            // --------------------------------------------------

            posSpeed.X = Math.Cos(angle) * radius;
            posSpeed.Y = Math.Sin(angle) * radius;
            angle += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            posSpeed.XSpeed = Math.Cos(angle) * orbitalVelocity;
            posSpeed.YSpeed = Math.Sin(angle) * orbitalVelocity;

            return posSpeed;
        }

        public void CreateSlingShot(int x, int y)
        {
            Random rnd = new Random();

            gravitySystem.AddObject("Planet", 25000000.0f, x, y, 10000, 0, displayXNA.TexturePlanet, false, false);

            for (int k = 0; k < 8; k++)
            {
                gravitySystem.AddObject("Object " + (k * 2 + 1).ToString(), 1.0f, x - 800 - k * 120, y - 10 - Math.Pow(k, 2) * 3, 25000, 0, displayXNA.TextureMetalBall, true, true);
                gravitySystem.AddObject("Object " + (k * 2 + 2).ToString(), 1.0f, x - 800 - k * 120, y + 10 + Math.Pow(k, 2) * 3, 25000, 0, displayXNA.TextureMetalBall, true, true);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = 0;     // center on first object

            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateGrid(int x_, int y_)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double gridSpacingMeters = Grid.Spacing * 1000000000;    // default million km.
            if (Grid.SpacingUnits.Equals("pixels"))
            {
                gridSpacingMeters = gravitySystem.PixelsToMeters(Grid.Spacing);
            }
            double xCenter = gravitySystem.ScreenToRealCoordinateX(x_);
            double yCenter = gravitySystem.ScreenToRealCoordinateY(y_);
            int count = 0;
            for (double y = yCenter - (gridSpacingMeters * Grid.YAmount) * 0.5; y < yCenter + (gridSpacingMeters * Grid.YAmount) * 0.5; y += gridSpacingMeters)
            {
                for (double x = xCenter - (gridSpacingMeters * Grid.XAmount) * 0.5; x < xCenter + (gridSpacingMeters * Grid.XAmount) * 0.5; x += gridSpacingMeters)
                {
                    count++;
                    if (Grid.Rotations == 0)
                    {
                        gravitySystem.AddObjectRealPosition("Grid object " + count, Grid.Mass, x, y, 0, 0, Grid.Texture, false, false);
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
                        gravitySystem.AddObjectRealPosition("Grid object " + count, Grid.Mass, x, y, XSpeed, YSpeed, Grid.Texture, false, false);
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

        public void CreateCircle(int x_, int y_)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double circleSpacingMeters = Circle.Spacing * 1000000000;    // default million km.
            if (Circle.SpacingUnits.Equals("pixels"))
            {
                circleSpacingMeters = gravitySystem.PixelsToMeters(Circle.Spacing);
            }
            double xCenter = gravitySystem.ScreenToRealCoordinateX(x_);
            double yCenter = gravitySystem.ScreenToRealCoordinateY(y_);
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
                            gravitySystem.AddObjectRealPosition("Circle object " + count, Circle.Mass, x, y, 0, 0, Circle.Texture, false, false);
                        }
                        else
                        {
                            double angleWithCenter = Math.Atan2(y - yCenter, x - xCenter);
                            angleWithCenter += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                            double distancePerYear = distanceFromCenter * Math.PI * 2.0 * Circle.Rotations;
                            double orbitalVelocity = distancePerYear / (24 * 60 * 60 * 365);
                            double XSpeed = Math.Cos(angleWithCenter) * orbitalVelocity;
                            double YSpeed = Math.Sin(angleWithCenter) * orbitalVelocity;
                            gravitySystem.AddObjectRealPosition("Circle object " + count, Circle.Mass, x, y, XSpeed, YSpeed, Circle.Texture, false, false);
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


        public void CreateRandom(int x, int y)
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
                gravitySystem.AddObjectRealPosition("Random object " + k.ToString(), RandomObjects.Mass, x + (x_adjustPercentage * areaMeters), y + (y_adjustPercentage * areaMeters), x_speed, y_speed, RandomObjects.Texture, false, false);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object

            gravitySystem.ScaleObjects();       // scale has changed by this setup
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
                throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");

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

        public void CreateGalaxy(int x_screen, int y_screen)
        {
            double x_real = gravitySystem.ScreenToRealCoordinateX(x_screen);
            double y_real = gravitySystem.ScreenToRealCoordinateY(y_screen);
            int startPosition = gravitySystem.GravityObjects.Count;
            int minMass = (int)(1000 - 1000 * Galaxy.MassVariation / 100.0);
            int maxMass = (int)(1000 + 1000 * Galaxy.MassVariation / 100.0);
            double averageMass = (Galaxy.TotalMass / (double)Galaxy.NumberOfObjects) * 1000;
            if (Galaxy.HasBlackHole)
            {
                gravitySystem.AddObjectRealPosition("Black Hole", (long)Galaxy.BlackHoleMass * 198910000, x_real, y_real, 0, 0, displayXNA.TextureLargeDot, false, false);
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
                    gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(angle), y_real + actual_radius * Galaxy.EllipseRatio * Math.Sin(angle), speed.X, speed.Y, displayXNA.TextureSmallDot, Galaxy.Color, false, false, false);
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
                                    CreateSolarSystemInGalaxy(x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y);
                                    gravitySystem.AddObjectRealPosition("Alpha Centauri", mass, x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y, displayXNA.TextureSmallDot, Galaxy.Color, false, false, false);      // 40 trillion m away
                                }
                                else
                                {
                                    gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y, displayXNA.TextureSmallDot, Galaxy.Color, false, false, false);
                                }
                            }
                            else
                            {
                                deviation = CalculateDeviation(Galaxy.SpiralBlurriness * (1 - ((radius / max_radius) / 1.2))) / 1500.0;  // more deviation at center
                                gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * 0.85 /*prevent too long bar */ * Math.Cos(current_angle), y_real + (deviation * max_radius), speed.X, speed.Y, displayXNA.TextureSmallDot, Galaxy.Color, false, false, false);
                            }
                        }
                    }

                    init_angle += angle_increase;
                }
            }

            if (!Galaxy.AddSolarSystem)
            {
                gravitySystem.ObjectIndex = -1;     // no object selected
                displayXNA.ParentForm.gradientPanelObjectProperties.Visible = false;
            }

            gravitySystem.CenterIndex = -1;     // no center object
            gravitySystem.ScaleObjects();       // scale has changed by this setup
            displayXNA.updateSmallDots(startPosition);      // We need to set the color of each star on "random color" mode seperately

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


        public void CreateSunPlanetMoon(int x, int y)
        {
            gravitySystem.AddObject("Sun", 100000000.0, x, y, -10, -80, displayXNA.TextureSun, false, false);
            gravitySystem.AddObject("Planet", 1000000.0, x + 350, y, 0, 25000, displayXNA.TextureEarth, true, false);
            gravitySystem.AddObject("Moon", 10.0, x + 370, y, 0, 32950, displayXNA.TextureMoon, true, false);     // +4100
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;       // sun
                gravitySystem.CenterIndex = 0;
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateMoonMoon(int x, int y)
        {
            gravitySystem.AddObject("Sun", 1000000000000.0, x, y, -50, -100, displayXNA.TextureSun, false, false);
            gravitySystem.AddObject("Planet", 20000000000.0, x + 500, y, 0, 1220000, displayXNA.TextureEarth, true, false);
            gravitySystem.AddObject("Moon", 5000000000.0, x + 525, y, 0, 2080000, displayXNA.TextureMoon, true, false);     // +4100
            gravitySystem.AddObject("Moon of a moon", 1.0, x + 526, y, 0, 4080000, displayXNA.TextureAsteroid, true, false);     // +4100
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;          // sun
                gravitySystem.CenterIndex = 1;          // planet
            }
            displayXNA.ParentForm.macTrackBarScale.Value = 327;

            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }


        public void CreateSunPlanet(int x, int y)
        {
            gravitySystem.AddObject("Sun", 100000000.0, x, y, 0, -5, displayXNA.TextureSun, false, false);
            gravitySystem.AddObject("Planet", 500.0, x + 350, y, 0, 25000, displayXNA.TexturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on sun
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = 0;       // sun
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreatePlanetMoon(int x, int y)
        {
            gravitySystem.AddObject("Planet", 1000.0, x, y, 0, -5, displayXNA.TextureEarth, true, false);
            gravitySystem.AddObject("Moon", 5.0, x + 300, y, 0, 1100, displayXNA.TextureMoon, true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on planet
            {
                gravitySystem.ObjectIndex = 0;       // planet
                gravitySystem.CenterIndex = 0;
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateDualStar(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 4000000000.0, x - 390, y - 10, 0, 44000, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Sun 2", 4000000000.0, x + 390, y + 10, 0, -44000, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, x + 415, y + 10, 0, -500000, displayXNA.TexturePlanet, true, false);
            gravitySystem.AddObject("Planet 2", 1000.0, x - 415, y - 10, 0, 500000, displayXNA.TexturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateDualStar2(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 198900000.0, x - 150, y - 10, 0, 20000, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Sun 2", 198900000.0, x + 150, y + 10, 0, -20000, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Planet", 597.2, x + 400, y - 50, 0, 40000, displayXNA.TexturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 2;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateDualStar3(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 2000000000.0, x - 390, y, 0, 24900, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Sun 2", 2000000000.0, x + 390, y, 0, -24900, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Planet", 100.0, x + 450, y + 10, 0, -190000, displayXNA.TexturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateTripleStar(double x, double y)
        {
            double radius = 390;
            double speed = 64000;
            double mass = 2400000000.0f;
            double angle = 0.0f;
            double speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            double XSpeed = Math.Cos(speed_angle) * speed;
            double YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 1", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.TextureSun, true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, Math.Cos(angle) * radius + x + 30, Math.Sin(angle) * radius + y, XSpeed, YSpeed + 330000, displayXNA.TexturePlanet, true, false);
            angle = Math.PI / 1.5;       // 120 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 2", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.TextureSun, true, false);
            angle = Math.PI / 0.75;       // 240 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 3", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, displayXNA.TextureSun, true, false);
            //            if (gravitySystem.GetGravityObjects().Count == 4)      // no objects before this setup
            {
                gravitySystem.ObjectIndex = 0;       // sun 1
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateSolarSystemInGalaxy(double x, double y, double GalaxySpeedX, double GalaxySpeedY)
        {
            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureMercury, false, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureVenus, false, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureEarth, false, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed + 1022, displayXNA.TextureMoon, false, false);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.9, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureMars, false, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureJupiter, false, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureSaturn, false, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureUranus, false, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TextureNeptune, false, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, displayXNA.TexturePluto, false, false);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, GalaxySpeedX, GalaxySpeedY, displayXNA.TextureSun, false, false);

            gravitySystem.ObjectIndex = gravitySystem.GravityObjects.FindIndex(a => a.Name == "Earth");

            gravitySystem.MinimumTextureSize = 1;
        }

        public void CreateSolarSystem(double x, double y, bool AddJWST = false)
        {
            x = gravitySystem.ScreenToRealCoordinateX(x);
            y = gravitySystem.ScreenToRealCoordinateY(y);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, 0, 0, displayXNA.TextureSun, true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureMercury, true, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureVenus, true, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureEarth, true, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, displayXNA.TextureMoon, true, false);

            /* at the moment not accurate enough
            if (AddJWST)    // add James Webb Space Telescope at L2 point
            {
                posSpeed = CalculatePositionSpeed(42, -228, 1.00 * (2 * Math.PI * (149600000000 + 1500000000)) / 31556926.0, 149600000000 + 1500000000);
                GravitySystem.AddObjectRealPosition("James Webb Telescope",
                    0.00000000065,
                    posSpeed.X + x, posSpeed.Y + y,
                    posSpeed.XSpeed, posSpeed.YSpeed,   
                    displayXNA.TextureLargeDot, true, false);        
            }
            */

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.9, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureMars, true, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureJupiter, true, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureSaturn, true, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureUranus, true, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureNeptune, true, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TexturePluto, true, false);

            if (gravitySystem.GravityObjects.Count == 11)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 3;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

            gravitySystem.ScaleObjects();
        }

        public void CreateSolarSystemMoons(double x, double y)
        {
            x = gravitySystem.ScreenToRealCoordinateX(x);
            y = gravitySystem.ScreenToRealCoordinateY(y);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, 0, 0, displayXNA.TextureSun, true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureMercury, true, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureVenus, true, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureEarth, true, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, displayXNA.TextureMoon, true, false);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.90000000, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureMars, true, false);

            gravitySystem.AddObjectRealPosition("Phobos", 0.0000010659, posSpeed.X + x + 9377000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 2138, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Deimos", 0.0000001471, posSpeed.X + x - 23436000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 1351, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(0, 1, -17905, 419000000000);
            gravitySystem.AddObjectRealPosition("Ceres", 0.09393, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureJupiter, true, false);

            gravitySystem.AddObjectRealPosition("Io", 8.9319, posSpeed.X + x + 421700000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 17334, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Europa", 4.8, posSpeed.X + x - 671034000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 13740, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Ganymede", 14.819, posSpeed.X + x + 1070412000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10880, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Callisto", 10.759, posSpeed.X + x - 1882709000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 8204, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureSaturn, true, false);

            gravitySystem.AddObjectRealPosition("Dione", 0.11, posSpeed.X + x + 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10030, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Rhea", 0.23, posSpeed.X + x + 527108000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 8480, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Titan", 13.5, posSpeed.X + x - 1221870000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5570, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Iapetus", 0.18, posSpeed.X + x - 3560820000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3260, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureUranus, true, false);

            gravitySystem.AddObjectRealPosition("Miranda", 0.00659, posSpeed.X + x - 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 6660, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Ariel", 0.1353, posSpeed.X + x - 191020000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5510, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Umbriel", 0.1172, posSpeed.X + x - 266300000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4670, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Titania", 0.3527, posSpeed.X + x - 435910000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3640, displayXNA.TextureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Oberon", 0.3014, posSpeed.X + x - 583520000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3150, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TextureNeptune, true, false);

            gravitySystem.AddObjectRealPosition("Triton", 2.1408, posSpeed.X + x - 354759000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4390, displayXNA.TextureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, displayXNA.TexturePluto, true, false);

            //            if (gravitySystem.GetGravityObjects().Count == 11)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 3;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

            gravitySystem.ScaleObjects();
        }
    }
}
