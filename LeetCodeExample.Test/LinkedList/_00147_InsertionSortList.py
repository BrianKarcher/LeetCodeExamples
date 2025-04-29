# Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.

# The steps of the insertion sort algorithm:

# Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
# At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
# It repeats until no input elements remain.
# The following is a graphical example of the insertion sort algorithm. The partially sorted list (black) initially contains only the first element in the list. One element (red) is removed from the input data and inserted in-place into the sorted list with each iteration.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def insertionSortList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or head.next == None:
            return head
        current = head
        while current is not None and current.next is not None:
            #print(f'current: {current.val}')
            if current.next.val < current.val:
                # Find new place for current Insert Sort
                item = current.next
                current.next = current.next.next
                if item.val <= head.val:
                    # new head
                    #print(f'Placing {item.val} at head')
                    item.next = head
                    head = item
                else:
                    iter = head
                    #print(f'Finding place for {item.val}')
                    while iter is not None and iter.next is not None and iter is not item:
                        #print(f'iter: {iter.val}, next {iter.next.val}')
                        if iter.val < item.val and iter.next.val >= item.val:
                            # place item between iter and iter.next
                            #print(f'Found, iter: {iter.val}')
                            item.next = iter.next
                            #print(f'item: {item.val}')
                            iter.next = item
                            break
                        iter = iter.next
                # We need to recalculate the new next value, so keep current the same
            else:
                current = current.next
        return head