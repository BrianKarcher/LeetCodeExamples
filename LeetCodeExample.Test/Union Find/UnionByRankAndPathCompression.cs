using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.UnionFind2
{
    // https://www.geeksforgeeks.org/union-find-algorithm-set-2-union-by-rank/?ref=lbp

    // A union by rank and path compression
    // based program to detect cycle in a graph
    using System;

    class Graph
    {
        public int V, E;
        public Edge[] edge;

        public Graph(int nV, int nE)
        {
            V = nV;
            E = nE;
            edge = new Edge[E];
            for (int i = 0; i < E; i++)
            {
                edge[i] = new Edge();
            }
        }

        // class to represent edge
        public class Edge
        {
            public int src, dest;
        }

        // class to represent Subset
        class subset
        {
            public int parent;
            public int rank;
        }

        // A utility function to find
        // set of an element i (uses
        // path compression technique)
        int find(subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
                subsets[i].parent
                    = find(subsets, subsets[i].parent);
            return subsets[i].parent;
        }

        // A function that does union
        // of two sets of x and y
        // (uses union by rank)
        void Union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[yroot].rank < subsets[xroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[xroot].parent = yroot;
                subsets[yroot].rank++;
            }
        }

        // The main function to check whether
        // a given graph contains cycle or not
        int isCycle(Graph graph)
        {
            int V = graph.V;
            int E = graph.E;

            subset[] subsets = new subset[V];
            for (int v = 0; v < V; v++)
            {
                subsets[v] = new subset();
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            for (int e = 0; e < E; e++)
            {
                int x = find(subsets, graph.edge[e].src);
                int y = find(subsets, graph.edge[e].dest);
                if (x == y)
                    return 1;
                Union(subsets, x, y);
            }
            return 0;
        }

        // Driver Code
        static public void Main3(String[] args)
        {
            /* Let us create the following graph
                0
                | \
                | \
                1-----2 */

            int V = 3, E = 3;
            Graph graph = new Graph(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;

            // add edge 1-2
            graph.edge[1].src = 1;
            graph.edge[1].dest = 2;

            // add edge 0-2
            graph.edge[2].src = 0;
            graph.edge[2].dest = 2;

            if (graph.isCycle(graph) == 1)
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine(
                    "Graph doesn't contain cycle");
        }
    }

    // This code is contributed
    // by Arnab Kundu
}