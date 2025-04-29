using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the root of a binary tree, the value of a target node target, and an integer k, return an array of the values of all nodes that have a distance k from the target node.
    // You can return the answer in any order.
    /// </summary>
    public class _00863_AllNodesDistanceKInBinaryTree
    {
        // Convert the tree into a graph, then perform BFS
        // Graph represented by Adj List
        Dictionary<TreeNode, List<TreeNode>> adjList = new Dictionary<TreeNode, List<TreeNode>>();

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            dfs(root, null);

            int dist = -1;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            queue.Enqueue(target);
            visited.Add(target);
            List<int> rtn = new List<int>();
            while (queue.Count != 0 && dist <= k)
            {
                dist++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var item = queue.Dequeue();
                    if (dist == k)
                    {
                        rtn.Add(item.val);
                        continue;
                    }
                    foreach (var adj in adjList[item])
                    {
                        if (visited.Contains(adj))
                            continue;
                        visited.Add(adj);
                        queue.Enqueue(adj);
                    }
                }
            }
            return rtn;
        }

        public void dfs(TreeNode node, TreeNode parent)
        {
            if (node == null)
                return;
            if (!adjList.ContainsKey(node))
                adjList.Add(node, new List<TreeNode>());
            if (parent != null)
                adjList[node].Add(parent);
            if (node.left != null)
                adjList[node].Add(node.left);
            if (node.right != null)
                adjList[node].Add(node.right);

            dfs(node.left, node);
            dfs(node.right, node);
        }

        //public IList<int> DistanceK2(TreeNode root, TreeNode target, int k)
        //{
        //    dfs(root, target, -1, k);
        //    return lst;
        //}

        //List<int> lst = new List<int>();

        //// dist: distance from target, k = get nodes from dist
        //public int dfs(TreeNode node, TreeNode target, int dist, int k)
        //{
        //    if (node == null)
        //        return -1;
        //    Console.WriteLine($"{node.val} {target.val} {dist} {k}");

        //    int rtn = -1;

        //    if (node == target)
        //    {
        //        dist = 0;
        //        rtn = 0;
        //    }

        //    // The target can be above or below this node.
        //    // Need to account for both.
        //    if (dist == k)
        //    {
        //        lst.Add(node.val);
        //        // Going down will not yield any results, return
        //        return -1;
        //    }
        //    if (dist > k)
        //        return -1;

        //    int downDist = dist == -1 ? -1 : dist + 1;
        //    // Check left
        //    int upDist = dfs(node.left, target, downDist, k);
        //    if (upDist != -1)
        //    {
        //        // Found the target
        //        upDist++;
        //        rtn = downDist;
        //        if (upDist == k)
        //        {
        //            lst.Add(node.val);
        //            // Going up or down will not yield any more results, return -1
        //            return -1;
        //        }
        //        downDist = upDist + 1;
        //    }

        //    // Check right
        //    upDist = dfs(node.right, target, downDist, k);
        //    if (upDist != -1)
        //    {
        //        // Found the target
        //        upDist++;
        //        if (upDist == k)
        //        {
        //            lst.Add(node.val);
        //            // Going up or down will not yield any more results, return -1
        //            return -1;
        //        }
        //        downDist = upDist;
        //        rtn = downDist;
        //        // Recheck the left path
        //        dfs(node.left, target, downDist + 1, k);
        //    }
        //    return rtn;
        //}
    }
}