# Given an array of characters chars, compress it using the following algorithm:

# Begin with an empty string s. For each group of consecutive repeating characters in chars:

# If the group's length is 1, append the character to s.
# Otherwise, append the character followed by the group's length.
# The compressed string s should not be returned separately, but instead, be stored in the input character array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.

# After you are done modifying the input array, return the new length of the array.

# You must write an algorithm that uses only constant extra space.

from typing import List
class Solution:
    def compress(self, chars: List[str]) -> int:
        l, r = 0, 0
        while r < len(chars):
            # Count repeating characters
            count = 0
            c = chars[r]
            while r < len(chars) and c == chars[r]:
                r += 1
                count += 1
            chars[l] = c
            l += 1
            if count == 1:
                continue
            str_count = str(count)
            for char in str_count:
                chars[l] = char
                l += 1
        return l