using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an undirected weighted graph of n nodes(0-indexed), represented by an edge list where edges[i] = [a, b] is an undirected edge connecting the nodes a and b with a probability of success of traversing that edge succProb[i].
    // Given two nodes start and end, find the path with the maximum probability of success to go from start to end and return its success probability.
    // If there is no path from start to end, return 0. Your answer will be accepted if it differs from the correct answer by at most 1e-5.
    /// </summary>
    public class _01514_PathWithMaximumProbability
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            // Create an Adjacency Matrix since we are dealing with weights
            List<(int i, double p)>[] adj = new List<(int, double)>[n];
            for (int i = 0; i < n; i++)
                adj[i] = new List<(int i, double p)>();

            for (int i = 0; i < edges.Length; i++)
            {
                adj[edges[i][0]].Add((edges[i][1], succProb[i]));
                // Undirected graph, so also do the other direction
                adj[edges[i][1]].Add((edges[i][0], succProb[i]));
            }

            // Never revisit a node
            double[] visited = new double[n];
            // We will always follow the highest probabilty chain since probabilities will never go up (they are only 0 to 1)
            PriorityQueue<(int node, double probability)> pq = new PriorityQueue<(int node, double probability)>((i1, i2) => i1.probability > i2.probability ? -1 : 1);

            pq.Enqueue((start, 1));
            visited[start] = 1;

            while (pq.Count() != 0)
            {
                var node = pq.Dequeue();
                //Console.WriteLine($"Node {node.node}, prob: {node.probability}");
                if (node.node == end)
                    return node.probability;

                // Add the adjacent nodes and their new probabilites to the pq
                foreach (var otherNode in adj[node.node])
                {
                    var newProb = otherNode.p * node.probability;
                    if (newProb <= visited[otherNode.i])
                        continue;
                    visited[otherNode.i] = newProb;
                    //Console.WriteLine($"Queueing {i}, prob {newProb}");
                    pq.Enqueue((otherNode.i, newProb));
                }
            }

            return 0;
        }
    }
}