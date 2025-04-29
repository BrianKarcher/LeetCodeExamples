from typing import List
from collections import deque
class Solution:
    def candy(self, ratings: List[int]) -> int:
        if len(ratings) == 1:
            return 1
        q = deque()
        ans = [1] * len(ratings)
        # lower ratings will serve as the initial base queue
        print('initial queue')
        if ratings[1] > ratings[0]:
            print('queueing first item')
            q.append(0)
        if ratings[-2] > ratings[-1]:
            print('queueing last item')
            q.append(len(ratings) - 1)
        for i in range(1, len(ratings) - 1):
            left = False
            right = False
            if ratings[i - 1] > ratings[i]:
                left = True
            if ratings[i + 1] > ratings[i]:
                right = True
            if left and not right:
                q.append(i)
            if right and not left:
                q.append(i)
        
        # Do a BFS. q will hold items that need to be recalculated.
        # We will add neighbors of the item being recalculated if they need adjusting.
        print('calc')
        while q:
            item = q.popleft()
            #print(f'popped {item}')
            right, left = 1,1
            # check left if possible
            if item > 0:
                if ratings[item] > ratings[item - 1]:
                    left = max(left, max(ans[item], ans[item - 1] + 1))
            if item < len(ratings) - 1:
                if ratings[item] > ratings[item + 1]:
                    right = max(right, max(ans[item], ans[item + 1] + 1))
            m = max(left, right)
            #print(f'{item} = {m}')
            ans[item] = m

            if item > 0:
                if ratings[item] < ratings[item - 1] and ans[item] >= ans[item - 1]:
                    q.append(item - 1)
            if item < len(ratings) - 1:
                if ratings[item] < ratings[item + 1] and ans[item] >= ans[item + 1]:
                    q.append(item + 1)
        
        rtn = 0
        for item in ans:
            #print(item)
            rtn += item
        
        return rtn