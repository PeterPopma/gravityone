using GravityOne.Gravity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.BarnesHut
{
    class Node
    {
        List<Node> childNodes = new List<Node>();
        Calculation calculation;
        double centerMassX;
        double centerMassY;
        double x;
        double y;
        double width;
        double height;
        double totalMass;
        int numExternalChildNodes = 1;     

        public Node(double X_, double Y_, double Width_, double Height_, double centerMassX_, double centerMassY_, double totalMass_)
        {
            x = X_;
            y = Y_;
            width = Width_;
            height = Height_;
            centerMassX = centerMassX_;
            centerMassY = centerMassY_;
            TotalMass = totalMass_;

        }

        public bool IsInternal()
        {
            return childNodes.Count>0;
        }

        public Node CreateQuadrantNode(Calculation calculation, double mass)
        {
            double newX = x;     // left quadrant
            if (calculation.X - newX > width * .5)
            {
                // right quadrant
                newX += width * .5;
            }

            double newY = y;     // top quadrant
            if (calculation.Y - newY > height * .5)
            {
                // lower quadrant
                newY += height * .5;
            }

            Node SubNode = new Node(newX, newY, width * .5, height * .5, calculation.X, calculation.Y, mass);
            childNodes.Add(SubNode);

            return SubNode;
        }


        public Node FindOrCreateQuadrantNode(Calculation calculation, double mass)
        {
            NumExternalChildNodes++;

            // Update center of mass: this node will always become an internal node
            CenterMassX = (CenterMassX * TotalMass + calculation.X * mass) / (mass + TotalMass);
            CenterMassY = (CenterMassY * TotalMass + calculation.Y * mass) / (mass + TotalMass);
            TotalMass += mass;            

            // find existing quadrant node
            foreach (Node node in childNodes)
            {
                if (calculation.X > node.X && calculation.X < (node.X + node.Width) && 
                    calculation.Y > node.Y && calculation.Y < (node.Y + node.Height) )
                {
                    return node;
                }
            }

            // No node for this quadrant yet; create it
            double newX = x;     // left quadrant
            if (calculation.X - newX > width * .5)
            {
                // right quadrant
                newX += width *.5;
            }

            double newY = y;     // top quadrant
            if (calculation.Y - newY > height * .5)
            {
                // lower quadrant
                newY += height * .5;
            }

            Node SubNode = new Node(newX, newY, width * .5, height * .5, calculation.X, calculation.Y, mass);
            childNodes.Add(SubNode);

            return SubNode;
        }

        public double CenterMassX
        {
            get
            {
                return centerMassX;
            }

            set
            {
                centerMassX = value;
            }
        }

        public double CenterMassY
        {
            get
            {
                return centerMassY;
            }

            set
            {
                centerMassY = value;
            }
        }

        internal List<Node> ChildNodes
        {
            get
            {
                return childNodes;
            }

            set
            {
                childNodes = value;
            }
        }

        internal Calculation Calculation
        {
            get
            {
                return calculation;
            }

            set
            {
                calculation = value;
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

        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public double TotalMass
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

        public int NumExternalChildNodes
        {
            get
            {
                return numExternalChildNodes;
            }

            set
            {
                numExternalChildNodes = value;
            }
        }
    }
}
