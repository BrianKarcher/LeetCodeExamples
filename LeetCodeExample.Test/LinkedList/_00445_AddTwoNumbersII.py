# You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

# You may assume the two numbers do not contain any leading zero, except the number 0 itself.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        def reverse(head: Optional[ListNode]) -> Optional[ListNode]:
            prev: Optional[ListNode] = None
            current = head
            while current != None:
                next = current.next
                current.next = prev
                prev = current
                current = next
            return prev
        
        l1 = reverse(l1)
        l2 = reverse(l2)

        rtn = None
        carry = False
        while l1 != None or l2 != None:
            val1, val2 = 0, 0
            if l1 != None:
                val1 = l1.val
                l1 = l1.next
            if l2 != None:
                val2 = l2.val
                l2 = l2.next
            val3 = val1 + val2 + (1 if carry else 0)
            if val3 >= 10:
                carry = True
                val3 = val3 % 10
            else:
                carry = False
            node = ListNode(val3)
            if rtn == None:
                rtn = node
            else:
                node.next = rtn
                rtn = node
        
        if carry == True:
            node = ListNode(1)
            node.next = rtn
            rtn = node
        
        return rtn