using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Design a data structure that simulates an in-memory file system.

    //    Implement the FileSystem class:

    //    FileSystem() Initializes the object of the system.
    //    List<String> ls(String path)
    //If path is a file path, returns a list that only contains this file's name.
    //If path is a directory path, returns the list of file and directory names in this directory.
    //    The answer should in lexicographic order.
    //    void mkdir(String path) Makes a new directory according to the given path.The given directory path does not exist. If the middle directories in the path do not exist, you should create them as well.
    //    void addContentToFile(String filePath, String content)
    //    If filePath does not exist, creates that file containing given content.
    //If filePath already exists, appends the given content to original content.
    //    String readContentFromFile(String filePath) Returns the content in the file at filePath.
    /// </summary>
    public class _00588_InMemoryFileSystem_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public class FileSystem
        {

            // The file system will be a tree-based system
            Node root;

            public FileSystem()
            {
                root = new Node("/");
                root.IsDirectory = true;
            }

            public IList<string> Ls(string path)
            {
                var node = GetPath(path);
                if (node.IsDirectory)
                {
                    return node.Children.Select(i => i.Key).OrderBy(i => i).ToList();
                }
                else
                {
                    return new List<string> { node.Name };
                }
            }

            public void Mkdir(string path)
            {
                var parsedPath = path.Substring(1).Split('/');
                Node current = root;
                foreach (var thePath in parsedPath)
                {
                    if (!current.Children.ContainsKey(thePath))
                    {
                        Node newNode = new Node(thePath);
                        newNode.IsDirectory = true;
                        current.Children.Add(thePath, newNode);
                        current = newNode;
                    }
                    else
                    {
                        current = current.Children[thePath];
                    }
                }
            }

            public void AddContentToFile(string filePath, string content)
            {
                var parsedPath = filePath.Substring(1).Split('/');
                Node current = root;

                // Stop at the directory just below the file
                for (int i = 0; i < parsedPath.Length - 1; i++)
                {
                    current = current.Children[parsedPath[i]];
                }
                // Add the file if it does not exist yet
                if (!current.Children.ContainsKey(parsedPath.Last()))
                {
                    var newFile = new Node(parsedPath.Last());
                    current.Children.Add(parsedPath.Last(), newFile);
                    current = newFile;
                }
                else
                {
                    // Get the file if it already exists
                    current = current.Children[parsedPath.Last()];
                }

                current.Contents += content;
            }

            public string ReadContentFromFile(string filePath)
            {
                var node = GetPath(filePath);
                return node.Contents;
            }

            private Node GetPath(string path)
            {
                if (path == "/")
                    return root;
                var parsedPath = path.Substring(1).Split('/');
                Node current = root;
                foreach (var thePath in parsedPath)
                {
                    //Console.WriteLine($"Getting path child {thePath}");
                    current = current.Children[thePath];
                }
                return current;
            }
        }

        // Node is shared for both files and directories for simplicity
        public class Node
        {
            public bool IsDirectory = false;
            public string Name;
            public string Contents; // If a file
            public Dictionary<string, Node> Children = new Dictionary<string, Node>();

            public Node(string name)
            {
                Name = name;
            }
        }
    }
}