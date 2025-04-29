# Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

# Basically, the deletion can be divided into two stages:

# Search for a node to remove.
# If the node is found, delete the node.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

# Solution that moves nodes
from typing import Optional
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        def find_min(node: Optional[TreeNode]):
            while node and node.left:
                node = node.left
            return node
        
        def find(node: Optional[TreeNode]) -> Optional[TreeNode]:
            if not node:
                return None
            
            if key < node.val:
                node.left = find(node.left)
            elif key > node.val:
                node.right = find(node.right)
            else:
                # Found it!
                # Leaf
                if not node.left and not node.right:
                    return None
                # Left OR right
                elif node.left and not node.right:
                    return node.left
                elif node.right and not node.left:
                    return node.right
                else:
                    # Both left and right have a value, we need to shift nodes around
                    # Fun
                    bottom = find_min(node.right)
                    bottom.left = node.left
                    return node.right
            return node
        return find(root)


# Solution that copies values
from typing import Optional
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        def findInOrderSuccessor(node: TreeNode) -> TreeNode:
            while (node.left):
                node = node.left
            return node

        def find(node: Optional[TreeNode], key: int) -> Optional[TreeNode]:
            if not node:
                return None
            if key < node.val:
                node.left = find(node.left, key)
            elif key > node.val:
                node.right = find(node.right, key)
            else:
                # case 1: Leaf node
                if not node.left and not node.right:
                    return None
                # case 2: One child
                if not node.left:
                    return node.right
                if not node.right:
                    return node.left
                # case 3: Two children

                # Found! Delete!
                #right = node.right
                IS = findInOrderSuccessor(node.right)
                node.val = IS.val
                node.right = find(node.right, IS.val)
                #if not node:
                #    return right
                #node.right = right
            return node
        return find(root, key)
    


########################################################
# My stupid answer

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import Optional, Tuple
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        def go_right(node: TreeNode) -> TreeNode:
            if not node or not node.right:
                return node
            return go_right(node.right)

        def search(node: Optional[TreeNode]) -> Optional[TreeNode]:
            if not node:
                return None
            if node.val == key:
                return node
            if key < node.val:
                # We need to return the parent of the found item
                if node.left and node.left.val == key:
                    return node
                return search(node.left)
            else:
                if node.right and node.right.val == key:
                    return node
                return search(node.right)

        if not root:
            return None
        if root.val == key:
            if not root.left:
                return root.right
            if not root.right:
                return root.left
            # We're deleting the root
            right_most = go_right(root.left)
            # print(f'right_most: {right_most}')
            # # The right most node is replacing the deleted node
            # # This will keep the BST structure intact
            if right_most:
                right_most.right = root.right
            return root.left

        parent_node = search(root)
        if not parent_node:
            return root

        if parent_node.left and parent_node.left.val == key:
            is_left = True
            node_to_delete = parent_node.left
        else:
            is_left = False
            node_to_delete = parent_node.right

        # print(f'parent: {parent_node}')
        # print(f'to_delete: {node_to_delete}')
        # print(f'is_left: {is_left}')

        # Is node_to_delete a leaf?
        if not node_to_delete.left and not node_to_delete.right:
            if is_left:
                parent_node.left = None
            else:
                parent_node.right = None
        # One child
        elif not node_to_delete.left:
            if is_left:
                parent_node.left = node_to_delete.right
            else:
                parent_node.right = node_to_delete.right
        else:
            #pass
            right_most = go_right(node_to_delete.left)
            # print(f'right_most: {right_most}')
            if is_left:
                parent_node.left = node_to_delete.left
            else:
                parent_node.right = node_to_delete.left
            # # The right most node is replacing the deleted node
            # # This will keep the BST structure intact
            if right_most:
                right_most.right = node_to_delete.right

        return root