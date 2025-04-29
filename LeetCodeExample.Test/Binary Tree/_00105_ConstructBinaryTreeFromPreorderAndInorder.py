# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right


class Solution:
    def buildTree(self, preorder: List[int], inorder: List[int]) -> Optional[TreeNode]:
        inorderMap = {}
        for i in range(len(inorder)):
            inorderMap[inorder[i]] = i
        def helper(l, r) -> Optional[TreeNode]:
            if l > r:
                return None
            node = TreeNode(preorder.pop(0))
            mid = inorderMap[node.val]
            node.left = helper(l, mid - 1)
            node.right = helper(mid + 1, r)
            return node
        return helper(0, len(inorder) - 1)



####################


class Solution:
    def __init__(self):
        self.used = set()
        self.order = {}

    def buildTree(self, preorder: List[int], inorder: List[int]) -> Optional[TreeNode]:
        self.preorder = preorder
        for i in range(len(inorder)):
            self.order[inorder[i]] = i
        
        return self.build(0, 0)

    def build(self, preorderIndex: int, parentIndex: int) -> Optional[TreeNode]:
        val = self.preorder[preorderIndex]
        order = self.order[self.preorder[preorderIndex]]
        node = TreeNode(val)
        self.used.add(val)
        # this node can never contain nodes that exceed the boundaries of the parent node's order
        leftIndex = preorderIndex + 1
        if leftIndex >= len(self.preorder):
            return node
        # is the next node in preorder to the left?
        print(leftIndex)
        print(parentIndex)
        print(self.preorder[leftIndex])
        if (self.order[self.preorder[leftIndex]] < order):
            print("going left")
            node.left = self.build(leftIndex, preorderIndex)
        # there could be multiple items that were added down the left side 
        # of the tree, find out where we traverse the right side
        rightIndex = leftIndex
        while self.preorder[rightIndex] in self.used:
            rightIndex += 1
            # boundary check to see if a right node is possible
            if rightIndex >= len(self.preorder) or self.order[self.preorder[rightIndex]] >= self.order[self.preorder[parentIndex]]:
                return node
        print("going right")
        print(rightIndex)
        node.right = self.build(rightIndex, preorderIndex)
        return node