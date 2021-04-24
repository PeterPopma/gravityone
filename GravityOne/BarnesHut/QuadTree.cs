using GravityOne.Gravity;
using GravityOne.SpaceObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.BarnesHut
{
    class QuadTree
    {
        public const uint TIME_GALAXY_INCREASE_FACTOR = 125000000;      // moon circles in 28 days, milky way in 73000 million days

        double minX;            // minimum X value of bounding box
        double maxX;            // maximum X value of bounding box
        double minY;            // minimum Y value of bounding box
        double maxY;            // maximum X value of bounding box
        double rangeX;          // maxX-minX of bounding box
        double rangeY;          // maxY-minY of bounding box
        Node rootNode;
        double treshold = 0.5;
        double gravitationalConstant;
        int numNodesInternal;
        int numNodesExternal;
        BackgroundWorker backgroundWorkerPreCalculate;
        DoWorkEventArgs e;
        double secondsInCalculation;

        long scale;
        long offsetX;
        long offsetY;

        double totalMass;
        double totalMassExpected;

        public double Treshold
        {
            get
            {
                return treshold;
            }

            set
            {
                treshold = value;
            }
        }

        public double GravitationalConstant
        {
            get
            {
                return gravitationalConstant;
            }

            set
            {
                gravitationalConstant = value;
            }
        }

        public double SecondsInCalculation { get => secondsInCalculation; set => secondsInCalculation = value; }

        public void DetermineBoundingBox(List<GravityObject> objects)
        {
            // Determine Bounding Box
            minX = double.MaxValue;
            maxX = double.MinValue;
            minY = double.MaxValue;
            maxY = double.MinValue;

            foreach (GravityObject o in objects)
            {
                if (maxX < o.X)
                {
                    maxX = o.X;
                }
                if (maxY < o.Y)
                {
                    maxY = o.Y;
                }
                if (minX > o.X)
                {
                    minX = o.X;
                }
                if (minY > o.Y)
                {
                    minY = o.Y;
                }
            }

            rangeX = maxX - minX;
            rangeY = maxY - minY;

            // add 100% on all sides
            minX -= (rangeX * 1);
            maxX += (rangeX * 1);
            minY -= (rangeY * 1);
            maxY += (rangeY * 1);

            rangeX *= 3;
            rangeY *= 3;

        }

        private int toScreenX(double realX)
        {
            return (int)(realX / (GravitySystem.METERS_PER_PIXEL * scale) - offsetX);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenY(double realY)
        {
            return (int)(realY / (GravitySystem.METERS_PER_PIXEL * scale) - offsetY);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenWidth(double realWidth)
        {
            return (int)(realWidth / (GravitySystem.METERS_PER_PIXEL * scale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenHeight(double realHeight)
        {
            return (int)(realHeight / (GravitySystem.METERS_PER_PIXEL * scale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        // show used internal nodes (for debugging)
        public void DrawUsedInternalNodes(SpriteBatch spriteBatch, Texture2D textureTrace, GravityObject gravityObject, long scale_, long offsetX_, long offsetY_, SpriteFont fontNormal)
        {
            scale = scale_;
            offsetX = offsetX_;
            offsetY = offsetY_;
            if (rootNode != null)
            {
                DrawUsedInternalNode(rootNode, spriteBatch, textureTrace, gravityObject, fontNormal);
            }
        }

        public void DrawUsedInternalNode(Node node, SpriteBatch spriteBatch, Texture2D textureTrace, GravityObject gravityObject, SpriteFont fontNormal)
        {
            double x_difference = node.CenterMassX - gravityObject.X;
            double y_difference = node.CenterMassY - gravityObject.Y;
            double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
            if (node.IsInternal())
                {
                if (((node.Width / Math.Sqrt(square_radius)) < treshold))
                {
                    spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), toScreenWidth(node.Width), 4), Color.OrangeRed);
                    spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.OrangeRed);
                    spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X + node.Width), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.OrangeRed);
                    spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y + node.Height), toScreenWidth(node.Width), 4), Color.OrangeRed);

                    spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.CenterMassX), toScreenY(node.CenterMassY), 12, 12), Color.Orange);
                    spriteBatch.DrawString(fontNormal, node.TotalMass.ToString(), new Vector2(toScreenX(node.CenterMassX), toScreenY(node.CenterMassY)), Color.White);
                }
                else
                {
                    foreach (Node subNode in node.ChildNodes.ToList())
                    {
                        DrawUsedInternalNode(subNode, spriteBatch, textureTrace, gravityObject, fontNormal);
                    }
                }
            }
        }

        // show quadrants (for debugging)
        public void DrawQuadrants(SpriteBatch spriteBatch, Texture2D textureTrace, long scale_, long offsetX_, long offsetY_, SpriteFont fontNormal)
        {
            scale = scale_;
            offsetX = offsetX_;
            offsetY = offsetY_;
            spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(minX), toScreenY(minY), toScreenWidth(rangeX), 16), Color.Blue);
            spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(minX), toScreenY(minY), 16, toScreenHeight(rangeY)), Color.Blue);
            spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(minX + rangeX), toScreenY(minY), 16, toScreenHeight(rangeY)), Color.Blue);
            spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(minX), toScreenY(minY + rangeY), toScreenWidth(rangeX) + 16, 16), Color.Blue);
            if (rootNode != null)
            {
                DrawExternalNode(rootNode, spriteBatch, textureTrace, fontNormal);
                DrawInternalNode(rootNode, spriteBatch, textureTrace, fontNormal);
            }

        }

        public void DrawExternalNode(Node node, SpriteBatch spriteBatch, Texture2D textureTrace, SpriteFont fontNormal)
        {
            if (!node.IsInternal())
            {
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), toScreenWidth(node.Width), 4), Color.GreenYellow);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.GreenYellow);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X + node.Width), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.GreenYellow);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y + node.Height), toScreenWidth(node.Width), 4), Color.GreenYellow);
            }
            lock (node.ChildNodes)
            foreach (Node subNode in node.ChildNodes.ToList())
            {
                DrawExternalNode(subNode, spriteBatch, textureTrace, fontNormal);
            }
        }

        public void DrawInternalNode(Node node, SpriteBatch spriteBatch, Texture2D textureTrace, SpriteFont fontNormal)
        {
            if (node.IsInternal())
            {
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), toScreenWidth(node.Width), 4), Color.Gray);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.Gray);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X + node.Width), toScreenY(node.Y), 4, toScreenHeight(node.Height)), Color.Gray);
                spriteBatch.Draw(textureTrace, new Rectangle(toScreenX(node.X), toScreenY(node.Y + node.Height), toScreenWidth(node.Width), 4), Color.Gray);
                spriteBatch.DrawString(fontNormal, node.NumExternalChildNodes.ToString(), new Vector2(toScreenX(node.X+node.Width) - 24, toScreenY(node.Y+node.Height) - 24), Color.White);
            }
            lock (node.ChildNodes)
            foreach (Node subNode in node.ChildNodes.ToList())
            {
                DrawInternalNode(subNode, spriteBatch, textureTrace, fontNormal);
            }
        }

        public void Create(Object2D[][] calculations, List<GravityObject> objects, int frameNumber, BackgroundWorker backgroundWorkerPreCalculate_, DoWorkEventArgs e_, Message message)
        {
            backgroundWorkerPreCalculate = backgroundWorkerPreCalculate_;
            e = e_;
            numNodesInternal = 0;
            numNodesExternal = 0;
            rootNode = new Node(minX, minY, rangeX, rangeY, 0, 0, 0);
            totalMassExpected = 0;

            for (int currentObjectNumber = 0; currentObjectNumber < calculations[0].Length; currentObjectNumber++)
            {
                if (objects.Count <= currentObjectNumber)
                {
                    message.Text = "Tried to calculate non-existing object!";
                    return;
                }
                if (objects[currentObjectNumber].SolarSystem == null)       // skip Solar System objects for Barnes Hut
                {
                    totalMassExpected += objects[currentObjectNumber].Mass;
                    Object2D calculation = calculations[frameNumber][currentObjectNumber];
                    if (calculation.X < minX || calculation.Y < minY || calculation.X > minX + rangeX || calculation.Y > minY + rangeY)
                    {
                        message.Text = "Resized bounding box for Barnes-Hut approximation.";
                        DetermineBoundingBox(objects);
                    }
                    InsertCalculation(rootNode, calculation, objects[currentObjectNumber].Mass);
                }
            }

//            Debug.Write("Tree created. Internal nodes: "+numNodesInternal + " external nodes: "+ numNodesExternal + "\r\n");
        }

        private void InsertCalculation(Node currentNode, Object2D calculation, double mass)
        {
            if (backgroundWorkerPreCalculate.CancellationPending)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was cancelled.
                e.Cancel = true;
                return;
            }

            if (currentNode.IsInternal())
            {
                Node appropriateQuadrant = currentNode.FindOrCreateQuadrantNode(calculation, mass);

                // Insert node in appropriate quadrant
                InsertCalculation(appropriateQuadrant, calculation, mass);
            }
            else
            {
                if (currentNode.Calculation == null/*currentNode.Calculation.X == 0 && currentNode.Calculation.Y==0*/)     // default value ("currentNode.Calculation==null")
                {
                    numNodesExternal++;
                    currentNode.Calculation = calculation;
                    currentNode.CenterMassX = calculation.X;
                    currentNode.CenterMassY = calculation.Y;
                    currentNode.TotalMass = mass;
                }
                else
                {
                    // Node already contains an item; move current item to sub-node
                    Node appropriateQuadrant = currentNode.CreateQuadrantNode(currentNode.Calculation, currentNode.TotalMass);
                    appropriateQuadrant.Calculation = currentNode.Calculation;
                    // disabled when Calculation is struct:
                    currentNode.Calculation = null;     // not really neccessary, but an internal node is not supposed to contain an object (they were moved to child nodes)
                    numNodesInternal++;

                    // Now insert our new object in appropriate quadrant
                    appropriateQuadrant = currentNode.FindOrCreateQuadrantNode(calculation, mass);
                    InsertCalculation(appropriateQuadrant, calculation, mass);
                }
            }
        }

        public void CalculateValues(Object2D[][] calculations, Vector[] calculationCurrentAccelerations,  int frameNumber, BackgroundWorker backgroundWorkerPreCalculate_, DoWorkEventArgs e_, double accelerationLimit, Message message)
        {
            backgroundWorkerPreCalculate = backgroundWorkerPreCalculate_;
            e = e_;
            for (int object_number = 0; object_number < calculations[0].Length; object_number++)
            {
                Object2D calculation = calculations[frameNumber][object_number];   // Start with old value
                Vector acceleration = calculationCurrentAccelerations[object_number];
                acceleration.X = 0;
                acceleration.Y = 0;
                totalMass = 0;
                CalculateNode(rootNode, calculation, acceleration, accelerationLimit, message);       // calculates the new acceleration for this object
//                Debug.Write("Quadtree calculated. Total mass: " + totalMass + " Expected:" + totalMassExpected + "\r\n");
                calculationCurrentAccelerations[object_number].X = acceleration.X * GravitationalConstant;
                calculationCurrentAccelerations[object_number].Y = acceleration.Y * GravitationalConstant;
            }
        }

        private void CalculateNode(Node node, Object2D calculation, Vector acceleration, double accelerationLimit, Message message)
        {
            double x_difference = node.CenterMassX - calculation.X;
            double y_difference = node.CenterMassY - calculation.Y;
            double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);

            if (backgroundWorkerPreCalculate.CancellationPending)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was cancelled.
                e.Cancel = true;
                return;
            }

            if (!node.IsInternal() || ((node.Width / Math.Sqrt(square_radius)) < treshold))      // External node or lower than treshold: calculate its force
            {
                totalMass += node.TotalMass;
                if (square_radius == 0)
                {
                    // objects exactly on top of each other (or the object itself!); bail out to prevent division by zero
                    return;
                }
                if (node.Equals(rootNode))
                {
                    // not a real gravity object 
                    return;
                }

                double accel = node.TotalMass / square_radius;

                // limit the acceleration to prevent objects very close to each other to get insane accelerations.
                if (accel > accelerationLimit / SecondsInCalculation)
                {
                    message.Text = "Acceleration of object has been limited, because it is too close to another object.";
                    accel = (accelerationLimit / SecondsInCalculation);
                }

                // divide acceleration in X and Y component
                double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                acceleration.X += Math.Cos(angle) * accel;
                acceleration.Y += Math.Sin(angle) * accel;
            }
            else
            {
                foreach (Node subNode in node.ChildNodes.ToList())
                {
                    CalculateNode(subNode, calculation, acceleration, accelerationLimit, message);
                    if (e.Cancel == true)
                    {
                        break;
                    }
                }
            }
        }

    }
}
