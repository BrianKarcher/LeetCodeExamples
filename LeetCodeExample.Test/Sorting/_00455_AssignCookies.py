# Assume you are an awesome parent and want to give your children some cookies. But, you should give each child at most one cookie.

# Each child i has a greed factor g[i], which is the minimum size of a cookie that the child will be content with; and each cookie j has a size s[j]. If s[j] >= g[i], we can assign the cookie j to the child i, and the child i will be content. Your goal is to maximize the number of your content children and output the maximum number.
    
class Solution:
    def findContentChildren(self, g: List[int], s: List[int]) -> int:
        if len(s) == 0 or len(g) == 0:
            return 0
        g.sort(reverse=True)
        s.sort(reverse=True)
        si = 0
        ans = 0
        for gi in range(len(g)):
            if s[si] >= g[gi]:
                si += 1
                ans += 1
                if si >= len(s):
                    break
        return ans