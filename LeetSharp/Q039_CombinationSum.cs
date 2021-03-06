﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a set of candidate numbers (C) and a target number (T), 
// find all unique combinations in C where the candidate numbers sums to T.

// The same repeated number may be chosen from C unlimited number of times.

// Note:

// All numbers (including target) will be positive integers.
// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
// The solution set must not contain duplicate combinations.
// For example, given candidate set 2,3,6,7 and target 7, 
// A solution set is: 
// [7] 
// [2, 2, 3] 

namespace LeetSharp
{
    [TestClass]
    public class Q039_CombinationSum
    {
        public int[][] CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);

            List<int> data = new List<int>();
            List<int[]> results = new List<int[]>();
            CombinationSum(candidates, target, data, results, 0);
            return results.ToArray();
        }

        private void CombinationSum(int[] candidates, int target, List<int> data, List<int[]> results, int startIndex)
        {
            if (target < 0)
            {
                return;
            }

            if (target == 0)
            {
                results.Add(data.ToArray());
                return;
            }

            for (int i = startIndex; i < candidates.Length; i++)
            {
                data.Add(candidates[i]);
                CombinationSum(candidates, target - candidates[i], data, results, i);
                data.Remove(candidates[i]);
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(CombinationSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q039_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q039_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
