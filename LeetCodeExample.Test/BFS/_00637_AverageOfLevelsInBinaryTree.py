# Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. Answers within 10-5 of the actual answer will be accepted.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def averageOfLevels(self, root: Optional[TreeNode]) -> List[float]:
        queue = deque()
        avg = []
        queue.append(root)
        while len(queue) > 0:
            total = 0
            count = len(queue)
            for i in range(count):
                node = queue.popleft()
                #print(f"adding {node.val}")
                total += node.val
                if node.left != None:
                    queue.append(node.left)
                if node.right != None:
                    queue.append(node.right)
            #print(f"{total}/{count}")
            avg.append(float(total) / float(count))
        return avg