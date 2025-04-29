# You are given two positive integer arrays spells and potions, of length n and m respectively, where spells[i] represents the strength of the ith spell and potions[j] represents the strength of the jth potion.
# You are also given an integer success. A spell and potion pair is considered successful if the product of their strengths is at least success.
# Return an integer array pairs of length n where pairs[i] is the number of potions that will form a successful pair with the ith spell.

# Official answer

class Solution:
    def successfulPairs(self, spells: List[int], potions: List[int], success: int) -> List[int]:
        sortedSpells = [(spell, index) for index, spell in enumerate(spells)]

        # Sort the 'spells with index' and 'potions' array in increasing order.
        sortedSpells.sort()
        potions.sort()

        answer = [0] * len(spells)
        m = len(potions)
        potionIndex = m - 1
        
        # For each 'spell' find the respective 'minPotion' index.
        for spell, index in sortedSpells:
            while potionIndex >= 0 and (spell * potions[potionIndex]) >= success:
                potionIndex -= 1
            answer[index] = m - (potionIndex + 1)
        
        return answer

# My answer 2 - it shrinks the potions window per each spell search.
from typing import List
class Solution:
    def successfulPairs(self, spells: List[int], potions: List[int], success: int) -> List[int]:
        # Sort potions, then we can just do a binary search to find the number of potions
        # per spell
        potions.sort()
        sorted_spells = sorted([(value, index) for index, value in enumerate(spells)])
        print(sorted_spells)
        def search(spell_power: int, r) -> tuple[int, int]:
            l = 0
            # left_most = r
            while l <= r:
                mid = (l + r) // 2
                # print(f'{spell_power} {l} {r} mid {mid}')
                potion_power = potions[mid]
                total_power = spell_power * potion_power
                if total_power == success:
                    # left_most = mid
                    r = mid - 1
                elif total_power > success:
                    r = mid - 1
                else:
                    l = mid + 1
            # print(f'ans for {spell_power}, {l} {r}')
            return len(potions) - l, r
        
        ans = [0] * len(spells)
        # The right pointer can only get smaller because math. (because of the sorts)
        right = len(potions) - 1
        for i in range(len(sorted_spells)):
            print(f'new spell, right: {right}')
            ans[sorted_spells[i][1]], right = search(sorted_spells[i][0], right)
        return ans

# My answer 1
from typing import List
class Solution:
    def successfulPairs(self, spells: List[int], potions: List[int], success: int) -> List[int]:
        # Sort potions, then we can just do a binary search to find the number of potions
        # per spell
        potions.sort()
        def search(spell_power: int) -> int:
            l = 0
            r = len(potions) - 1
            # left_most = r
            while l <= r:
                mid = (l + r) // 2
                # print(f'{spell_power} {l} {r} mid {mid}')
                potion_power = potions[mid]
                total_power = spell_power * potion_power
                if total_power == success:
                    # left_most = mid
                    r = mid - 1
                elif total_power > success:
                    r = mid - 1
                else:
                    l = mid + 1
            # print(f'ans for {spell_power}, {l} {r}')
            return len(potions) - l
        
        ans = [0] * len(spells)
        for i in range(len(spells)):
            ans[i] = search(spells[i])
        return ans