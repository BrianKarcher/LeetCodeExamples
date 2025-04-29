using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Write a function, printTree(), which prints a given tree to stdout. Details:
    // The argument of printTree is a stream of Relations: pairs of "parent -> child" relationships.
    // Each string found anywhere in the input represents a unique node.
    // Each parent can have many children
    // The input list may contain Relations in any order, although:
    // The order in which the pairs appear in the input list determines the nodes' order with respect to its siblings.
    /// </summary>
    public class G_ParentChildListToDFSPrint
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            List<Relation> input = new List<Relation>();
            input.Add(new Relation("animal", "mammal"));
            input.Add(new Relation("animal", "bird"));
            input.Add(new Relation("lifeform", "animal"));
            input.Add(new Relation("cat", "lion"));
            input.Add(new Relation("mammal", "cat"));
            input.Add(new Relation("animal", "fish"));
            var ans = printTree2(input);
            Assert.AreEqual("", ans);
        }

        public class Relation
        {
            public string _parent;
            public string _child;
            public Relation(string parent, string child)
            {
                _parent = parent;
                _child = child;
            }
        }

        public string printTree(List<Relation> rel)
        {
            Dictionary<string, Node> dict = new Dictionary<string, Node>();
            for (int i = 0; i < rel.Count; i++)
            {
                // Find and add each node
                if (!dict.TryGetValue(rel[i]._parent, out var parentNode))
                {
                    parentNode = new Node(rel[i]._parent);
                    dict.Add(rel[i]._parent, parentNode);
                }

                if (!dict.TryGetValue(rel[i]._child, out var childNode))
                {
                    childNode = new Node(rel[i]._child);
                    dict.Add(rel[i]._child, childNode);
                }

                parentNode.children.Add(childNode);
                childNode.parent = parentNode;
            }

            // Find the root
            // Start at any node
            var root = dict[rel[0]._parent];

            // Then traverse up the tree, stopping when no more parents
            while (root.parent != null)
                root = root.parent;

            return printTree(root, string.Empty);
        }

        // BFS
        //public string printTree(Node root)
        //{
        //    string rtn = string.Empty;

        //    Queue<Node> queue = new Queue<Node>();
        //    queue.Enqueue(root);
        //    while (queue.Any())
        //    {
        //        var node = queue.Dequeue();
        //        rtn += node.name;
        //        //Console.WriteLine(node.name);

        //        if (node.children == null)
        //            continue;
        //        for (int i = 0; i < node.children.Count; i++)
        //            queue.Enqueue(node.children[i]);
        //    }
        //    return rtn;
        //}

        // DFS since need to print the output in a certain order (value first, then first child, then its child, etc.).
        public string printTree(Node node, string prefix)
        {
            string rtn = string.Empty;

            rtn += prefix + node.name + Environment.NewLine;

            if (node.children != null)
            {
                for (int i = 0; i < node.children.Count; i++)
                    rtn += printTree(node.children[i], prefix + "  ");
            }
            return rtn;
        }

        public class Node
        {
            public List<Node> children;
            // For traversing up a tree to find the root
            public Node parent;
            public string name;
            public Node(string name)
            {
                this.name = name;
                children = new List<Node>();
            }
        }


        /// <summary>
        /// ///////////////
        /// </summary>
        /// 

        Dictionary<string, List<string>> lst = new Dictionary<string, List<string>>();
        public string printTree2(List<Relation> rs)
        {
            /* Adjacency List
             * lifeform -> [animal]
             * animal -> [mammal, bird, fish]
             * mammal -> [cat]
             * 
             * 1. Loop through relations and put all parents as keys pointing to their children
             *      Put each child in a set
             *      
             * 2. Loop through the keys of our map.
             *      When we find a key that's not in children set, we know that that's our root
             * 
             * 3. Perform DFS starting at root
             *      Keep track of depth to know how many tabs we need to write
             */


            HashSet<string> children = new HashSet<string>();

            for (int i = 0; i < rs.Count; i++)
            {
                if (!lst.ContainsKey(rs[i]._parent))
                    lst.Add(rs[i]._parent, new List<string>());
                lst[rs[i]._parent].Add(rs[i]._child);
                children.Add(rs[i]._child);
            }

            string root = null;
            foreach (var parents in lst)
            {
                if (!children.Contains(parents.Key))
                {
                    root = parents.Key;
                    break;
                }
            }

            return printTree2(root, string.Empty);
        }

        public string printTree2(string node, string prefix)
        {
            string rtn = string.Empty;

            rtn += prefix + node + Environment.NewLine;

            if (!lst.ContainsKey(node))
                return rtn;

            var children = lst[node];

            for (int i = 0; i < children.Count; i++)
                rtn += printTree2(children[i], prefix + "  ");

            return rtn;
        }
    }
}