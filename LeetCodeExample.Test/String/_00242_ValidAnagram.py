class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False
        arr = [0] * 26
        ordA = ord('a')
        # count up the letters
        for char in s:
            arr[ord(char) - ordA] += 1
        for char in t:
            arr[ord(char) - ordA] -= 1
            if arr[ord(char) - ordA] < 0:
                return False
        
        for i in range(26):
            if arr[i] != 0:
                return False
        return True