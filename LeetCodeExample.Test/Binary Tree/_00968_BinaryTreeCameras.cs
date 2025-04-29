using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given the root of a binary tree.We install cameras on the tree nodes where each camera at a node can monitor its parent, itself, and its immediate children.
//Return the minimum number of cameras needed to monitor all nodes of the tree.
/// </summary>
public class _00968_BinaryTreeCameras
{

    int camera = 0;
    public enum Camera { HAS_CAMERA, COVERED, PLEASE_COVER };

    public int minCameraCover(TreeNode root)
    {
        // If root is not covered then we need to place a camera at root node
        return cover(root) == Camera.PLEASE_COVER ? ++camera : camera;
    }

    public Camera cover(TreeNode root)
    {

        // Base case - if there is no node then it's already covered
        if (root == null)
            return Camera.COVERED;

        // Try to cover left and right children's subtree
        Camera l = cover(root.left);
        Camera r = cover(root.right);

        // If Any one of the children is not covered then we must place a camera at current node
        if (l == Camera.PLEASE_COVER || r == Camera.PLEASE_COVER)
        {
            camera++;
            return Camera.HAS_CAMERA;
        }

        // If any one of left or right node has Camera then the current node is also covered
        if (l == Camera.HAS_CAMERA || r == Camera.HAS_CAMERA)
            return Camera.COVERED;

        // If None of the children is covering the current node then ask it's parent to cover
        return Camera.PLEASE_COVER;
    }




    /// <summary>
    /// ///////////
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int MinCameraCover(TreeNode root)
    {
        count = 0;
        covered = new HashSet<TreeNode>();
        covered.Add(null);
        dfs(root, null);
        return count;
    }

    int count;
    HashSet<TreeNode> covered;

    void dfs(TreeNode node, TreeNode par)
    {
        if (node == null)
        {
            return;
        }
        dfs(node.left, node);
        dfs(node.right, node);

        if (par == null && !covered.Contains(node)
            || !covered.Contains(node.left)
            || !covered.Contains(node.right))
        {
            count++;
            covered.Add(node);
            covered.Add(par);
            covered.Add(node.left);
            covered.Add(node.right);
        }
    }


    ////////////////////
    ///


}