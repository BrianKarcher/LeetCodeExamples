# You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

# Merge nums1 and nums2 into a single array sorted in non-decreasing order.

# The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

class Solution:
    def merge(self, nums1: List[int], m: int, nums2: List[int], n: int) -> None:
        """
        Do not return anything, modify nums1 in-place instead.
        """
        # Do it backwards
        i = len(nums1) - 1
        mi = m - 1
        ni = len(nums2) - 1
        while mi >= 0 and ni >= 0:
            if nums1[mi] >= nums2[ni]:
                # pick nums1
                nums1[i] = nums1[mi]
                i -= 1
                mi -= 1
            else:
                # pick nums2
                nums1[i] = nums2[ni]
                i -= 1
                ni -= 1
        
        # Do any remaining
        while mi >= 0:
            nums1[i] = nums1[mi]
            i -= 1
            mi -= 1

        while ni >= 0:
            nums1[i] = nums2[ni]
            i -= 1
            ni -= 1