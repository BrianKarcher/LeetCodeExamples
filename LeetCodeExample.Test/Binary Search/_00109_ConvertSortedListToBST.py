# Given the head of a singly linked list where elements are sorted in ascending order, convert it to a 
# height-balanced
#  binary search tree.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution {
public:
    TreeNode* sortedListToBST(ListNode* head) {
    if (!head) return NULL; // Base case

    ListNode* slow = head;
    ListNode* fast = head;
    ListNode* prev = NULL;

    // Use two pointers to split the linked list into halves
    while (fast && fast->next) {
        prev = slow;
        slow = slow->next;
        fast = fast->next->next;
    }

    // Create a new node for the middle element and make it the root of the BST
    TreeNode* root = new TreeNode(slow->val);

    // If the linked list has only one element, return the root
    if (slow == head) return root;

    // Recursively construct the left and right subtrees of the root
    prev->next = NULL; // Split the linked list into two halves
    root->left = sortedListToBST(head);
    root->right = sortedListToBST(slow->next);

    return root;
    }
};


class Solution:
    def sortedListToBST(self, head: Optional[ListNode]) -> Optional[TreeNode]:
        if not head:
            return None
        arr = []
        current = head
        while current:
            arr.append(current.val)
            current = current.next
        #print(f"size: {len(arr)}")
        def build(l, r) -> Optional[TreeNode]:
            if r < l:
                return None
            mid = int((l + r) / 2)
            #print(f"l: {l}, r: {r}, mid: {mid}")
            return TreeNode(arr[mid], build(l, mid - 1), build(mid + 1, r))

        return build(0, len(arr) - 1)