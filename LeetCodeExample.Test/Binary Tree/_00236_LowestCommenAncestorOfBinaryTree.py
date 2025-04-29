# Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

# According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution:
    def lowestCommonAncestor(self, root: 'TreeNode', p: 'TreeNode', q: 'TreeNode') -> 'TreeNode':
        def get_lca(node: Optional[TreeNode]) -> Optional[TreeNode]:
            if not node: return None
            if node in [p, q]: return node
            l, r = get_lca(node.left), get_lca(node.right)
            if l and r: return node
            return l or r

        return get_lca(root)
    
    

class Solution:

    def find(self, root: 'TreeNode', p: 'TreeNode', lst) -> bool:
        if root == None:
            return False
        #print(root.val)
        if root == p:
            return True
        #print(lst)
        if lst == None:
            #print('List is None')
            return False
        if root.left != None:
            lst.append(root.left)
            l = self.find(root.left, p, lst)
            if l == True:
                return True
            # Backtrack
            lst.pop()
        if root.right != None:
            lst.append(root.right)
            r = self.find(root.right, p, lst)
            if r == True:
                return True
            # Backtrack
            lst.pop()
        return False

    def lowestCommonAncestor(self, root: 'TreeNode', p: 'TreeNode', q: 'TreeNode') -> 'TreeNode':
        pList = [root]
        self.find(root, p, pList)
        qList = [root]
        self.find(root, q, qList)
        # Traverse both lists until they diverge to find LCA
        lca = None
        for i in range(len(pList)):
            if i >= len(qList) or pList[i].val != qList[i].val:
                break
            lca = pList[i]
        return lca