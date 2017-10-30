﻿using System.Collections.Generic;
using System.Diagnostics;

namespace Advanced.Algorithms.DynamicProgramming
{
    /// <summary>
    /// Problem statement in detail below
    /// http://www.geeksforgeeks.org/iterative-tower-of-hanoi/
    /// </summary>
    public class TowerOfHanoi
    {
        public static int Tower(int numOfDisks)
        {
            return Tower(numOfDisks, "a", "b", "c", new Dictionary<int, int>());
        }

        /// <summary>
        /// DP top down 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="source"></param>
        /// <param name="aux"></param>
        /// <param name="dest"></param>
        /// <param name="moveCount"></param>
        private static int Tower(int n, string source, string aux, string dest, Dictionary<int, int> cache)
        {
            Debug.WriteLine("Moving disc {0} from pole {1} to {2}", n, source, dest);

            if (n == 1)
            {
                return 1;
            }

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            ////assume without last disc on top we would be moving a disc from source to dest
            //Tower(n - 1, source, aux, dest, ref moveCount);

            ////The last disc we just moved above to destination was in source
            ////that disc was definitely moved from aux to source (if it was in destination we would be not here)
            //Tower(n - 1, aux, dest, source, ref moveCount);

            //or alternatively
            //assume without last disc on top we would be moving a disc from aux to dest
            var result = Tower(n - 1, aux, source, dest, cache)

            //The last disc we just moved above to destination was in aux
            //that disc was definitely moved from source to aux (if it was in destination we would be done by now)
            + Tower(n - 1, source, dest, aux, cache) + 1;

            cache.Add(n, result);

            return result;

        }

    }
}