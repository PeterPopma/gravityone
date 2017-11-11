using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.Gravity
{
    class GravityUtils
    {
        GravitySystem gravitySystem;

        public GravityUtils(GravitySystem gravitySystem_)
        {
            gravitySystem = gravitySystem_;
        }

        public int FindClosestObject(double x, double y)
        {
            int closestObjectIndex = -1;
            double closestDistance = double.MaxValue;
            for (int k = 0; k < gravitySystem.GravityObjects.Count; k++)
            {
                GravityObject o = gravitySystem.GravityObjects[k];
                double distance = Math.Sqrt(Math.Pow((o.X - x), 2) + Math.Pow((o.Y - y), 2));
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObjectIndex = k;
                }
            }

            return closestObjectIndex;
        }

    }
}
