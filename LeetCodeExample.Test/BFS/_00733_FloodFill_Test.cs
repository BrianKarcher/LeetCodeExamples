using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.
   // You are also given three integers sr, sc, and newColor. You should perform a flood fill on the image starting from the pixel image[sr][sc].
   // To perform a flood fill, consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color), and so on.Replace the color of all of the aforementioned pixels with newColor.
   //Return the modified image after performing the flood fill.
    /// </summary>
    public class _00733_FloodFill_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FloodFill(new int[][] {new int[]{ 0, 0, 0 },new int[]{ 0, 0, 0 } }, 0, 0, 2);
            Assert.AreEqual(new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } }, answer);

            answer = FloodFill(new int[][] { new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 } }, 1, 0, 2);
            Assert.AreEqual(new int[][] { new int[] { 2, 2, 0 }, new int[] { 2, 2, 0 } }, answer);
        }

        // Do a BFS
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            HashSet<(int c, int r)> visited = new HashSet<(int c, int r)>();
            Queue<(int c, int r)> queue = new Queue<(int c, int r)>();
            queue.Enqueue((sc, sr));
            int originalColor = image[sr][sc];
            while (queue.Count != 0)
            {
                var pixel = queue.Dequeue();
                // Bounds check
                if (pixel.c < 0 || pixel.c >= image[0].Length || pixel.r < 0 || pixel.r >= image.Length)
                    continue;
                // Color check
                if (image[pixel.r][pixel.c] != originalColor)
                    continue;

                if (visited.Contains((pixel.c, pixel.r)))
                    continue;

                visited.Add((pixel.c, pixel.r));
                image[pixel.r][pixel.c] = newColor;

                // Check four directions
                queue.Enqueue((pixel.c - 1, pixel.r));
                queue.Enqueue((pixel.c + 1, pixel.r));
                queue.Enqueue((pixel.c, pixel.r - 1));
                queue.Enqueue((pixel.c, pixel.r + 1));
            }
            return image;
        }

        //public bool ShouldAddChild()
        //{

        //}
    }
}