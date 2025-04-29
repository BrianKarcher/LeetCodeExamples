using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given a tree with n nodes numbered from 0 to n - 1 in the form of a parent array parent where parent[i] is the parent of the ith node.The root of the tree is node 0, so parent[0] = -1 since it has no parent.You want to design a data structure that allows users to lock, unlock, and upgrade nodes in the tree.

//The data structure should support the following functions:

//Lock: Locks the given node for the given user and prevents other users from locking the same node. You may only lock a node using this function if the node is unlocked.
//Unlock: Unlocks the given node for the given user.You may only unlock a node using this function if it is currently locked by the same user.
//Upgrade: Locks the given node for the given user and unlocks all of its descendants regardless of who locked it. You may only upgrade a node if all 3 conditions are true:
//The node is unlocked,
//It has at least one locked descendant (by any user), and
//It does not have any locked ancestors.
//Implement the LockingTree class:

//LockingTree(int[] parent) initializes the data structure with the parent array.
//lock(int num, int user) returns true if it is possible for the user with id user to lock the node num, or false otherwise.If it is possible, the node num will become locked by the user with id user.
//unlock(int num, int user) returns true if it is possible for the user with id user to unlock the node num, or false otherwise.If it is possible, the node num will become unlocked.
//upgrade(int num, int user) returns true if it is possible for the user with id user to upgrade the node num, or false otherwise.If it is possible, the node num will be upgraded.
/// </summary>
public class _01993_OperationsOnTree
{
    public class LockingTree
    {
        // Need to create an ordinary adjacency list so we can traverse down a tree.
        Dictionary<int, List<int>> adjList = new();
        // The user who locked a node at inex i.
        int[] locks;
        int[] parent;

        public LockingTree(int[] parent)
        {
            this.parent = parent;
            locks = new int[parent.Length];
            Array.Fill(locks, -1);
            for (int i = 0; i < parent.Length; i++)
            {
                adjList.Add(i, new List<int>());
            }
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] != -1)
                    adjList[parent[i]].Add(i);
            }
        }

        public bool Lock(int num, int user)
        {
            if (locks[num] != -1)
            {
                return false;
            }
            locks[num] = user;
            return true;
        }

        public bool Unlock(int num, int user)
        {
            if (locks[num] != user)
            {
                return false;
            }
            locks[num] = -1;
            return true;
        }

        public bool Upgrade(int num, int user)
        {
            if (locks[num] != -1)
            {
                return false;
            }
            if (!HasLockedDescendent(num))
            {
                return false;
            }
            if (HasLockedAncenstor(num))
            {
                return false;
            }
            UnlockDescendents(num);
            locks[num] = user;
            return true;
        }

        bool HasLockedDescendent(int num)
        {
            if (locks[num] != -1)
            {
                return true;
            }

            foreach (int node in adjList[num])
            {
                // If any descendent is locked return true.
                if (HasLockedDescendent(node))
                {
                    return true;
                }
            }
            return false;
        }

        void UnlockDescendents(int num)
        {
            locks[num] = -1;
            foreach (int node in adjList[num])
            {
                UnlockDescendents(node);
            }
        }

        bool HasLockedAncenstor(int num)
        {
            if (num == -1)
            {
                return false;
            }
            if (locks[num] != -1)
            {
                return true;
            }
            return HasLockedAncenstor(parent[num]);
        }
    }
}