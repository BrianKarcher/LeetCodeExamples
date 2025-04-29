using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a reference of a node in a connected undirected graph.
    //Return a deep copy (clone) of the graph.
    //Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.
    /// </summary>
    public class _00133_CloneGraph_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Node one = new Node();
            one.val = 1;
            Node two = new Node();
            two.val = 2;
            Node three = new Node();
            three.val = 3;
            Node four = new Node();
            four.val = 4;

            one.neighbors.Add(two);
            one.neighbors.Add(four);
            two.neighbors.Add(one);
            two.neighbors.Add(three);
            three.neighbors.Add(two);
            three.neighbors.Add(four);
            four.neighbors.Add(one);
            four.neighbors.Add(three);

            var answer = CloneGraph(one);
            Assert.AreEqual(0, answer);
        }

        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;
            return Recurse(node);
        }

        Dictionary<int, Node> map = new Dictionary<int, Node>();

        public Node Recurse(Node node)
        {
            if (map.ContainsKey(node.val))
            {
                return map[node.val];
            }

            Node newNode = new Node();
            newNode.val = node.val;
            map.Add(newNode.val, newNode);

            for (int i = 0; i < node.neighbors.Count; i++)
            {
                newNode.neighbors.Add(Recurse(node.neighbors[i]));
            }

            return newNode;
        }


        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

    }
}