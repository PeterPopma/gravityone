﻿using GravityOne.Gravity;
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
        double minX;
        double maxX;
        double minY;
        double maxY;
        double rangeX;
        double rangeY;
        Node rootNode;
        double treshold = 0.5;
        double secondsPerStep;
        double gravitationalConstant;
        int numNodesInternal;
        int numNodesExternal;
        BackgroundWorker backgroundWorkerPreCalculate;
        DoWorkEventArgs e;

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

        public double SecondsPerStep
        {
            get
            {
                return secondsPerStep;
            }

            set
            {
                secondsPerStep = value;
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
            return (int)(realX / (1000000.0 * scale) - offsetX);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenY(double realY)
        {
            return (int)(realY / (1000000.0 * scale) - offsetY);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenWidth(double realWidth)
        {
            return (int)(realWidth / (1000000.0 * scale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        private int toScreenHeight(double realHeight)
        {
            return (int)(realHeight / (1000000.0 * scale));              // scale -> adjust offset (is not to scale) -> screen coords
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

        public void Create(Calculation[][] calculations, List<GravityObject> objects, int frameNumber, BackgroundWorker backgroundWorkerPreCalculate_, DoWorkEventArgs e_, Message message)
        {
            backgroundWorkerPreCalculate = backgroundWorkerPreCalculate_;
            e = e_;
            numNodesInternal = 0;
            numNodesExternal = 0;
            rootNode = new Node(minX, minY, rangeX, rangeY, 0, 0, 0);
            totalMassExpected = 0;

            for (int k = 0; k < calculations[0].Length; k++)
            {
                if (objects.Count > k)
                {
                    totalMassExpected += objects[k].Mass;
                    Calculation calculation = calculations[frameNumber][k];
                    if (calculation.X < minX || calculation.Y < minY || calculation.X > minX+rangeX || calculation.Y > minY + rangeY)
                    {
                        message.Text = "Resized bounding box for Barnes-Hut approximation.";
                        DetermineBoundingBox(objects);
                    }
                    InsertCalculation(rootNode, calculation, objects[k].Mass);
                }
            }

//            Debug.Write("Tree created. Internal nodes: "+numNodesInternal + " external nodes: "+ numNodesExternal + "\r\n");
        }

        private void InsertCalculation(Node currentNode, Calculation calculation, double mass)
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

        public void CalculateValues(Calculation[][] calculations, Vector[] calculationCurrentAccelerations,  int frameNumber, BackgroundWorker backgroundWorkerPreCalculate_, DoWorkEventArgs e_, double accelerationLimit, Message message)
        {
            backgroundWorkerPreCalculate = backgroundWorkerPreCalculate_;
            e = e_;
            for (int k = 0; k < calculations[0].Length; k++)
            {
                Calculation calculation = calculations[frameNumber][k];   // Start with old value
                Vector acceleration = calculationCurrentAccelerations[k];
                acceleration.X = 0;
                acceleration.Y = 0;
                totalMass = 0;
                CalculateNode(rootNode, calculation, acceleration, accelerationLimit, message);       // calculates the new acceleration for this object
//                Debug.Write("Quadtree calculated. Total mass: " + totalMass + " Expected:" + totalMassExpected + "\r\n");
                calculationCurrentAccelerations[k].X = acceleration.X * GravitationalConstant;
                calculationCurrentAccelerations[k].Y = acceleration.Y * GravitationalConstant;
            }
        }

        private void CalculateNode(Node node, Calculation calculation, Vector acceleration, double accelerationLimit, Message message)
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
                double accel = node.TotalMass / square_radius;

                // cap on acceleration
                double limit = node.NumExternalChildNodes * accelerationLimit / SecondsPerStep;

                if (accel > limit)
                {
                    message.Text = "Acceleration of object has been limited, because it is to close to another object.";
                    accel = limit;
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