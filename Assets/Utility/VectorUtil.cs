using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Utility
{
    public static class VectorUtil
    {
        private static System.Random random = new System.Random();

        public static Vector3 CreateRandomUnitVector()
        {
            return new Vector3(NextUnitFloat(), NextUnitFloat(), NextUnitFloat());
        }

        public static Vector3 CreateRandomUnitVectorXZPlane()
        {
            return new Vector3(NextUnitFloat(), 0, NextUnitFloat());
        }

        /// <summary>
        /// Random double
        /// </summary>
        /// <returns>Between -1 and 1</returns>
        private static float NextUnitFloat()
        {
            return (float)random.NextDouble() * 2 - 1;
        }
    }
}
