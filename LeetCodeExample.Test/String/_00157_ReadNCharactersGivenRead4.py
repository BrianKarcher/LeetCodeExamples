# Given a file and assume that you can only read the file using a given method read4, implement a method to read n characters.

# Method read4:

# The API read4 reads four consecutive characters from file, then writes those characters into the buffer array buf4.

# The return value is the number of actual characters read.

# Note that read4() has its own file pointer, much like FILE *fp in C.

class Solution:
    def read(self, buf, n):
        """
        :type buf: Destination buffer (List[str])
        :type n: Number of characters to read (int)
        :rtype: The number of actual characters read (int)
        """
        buf4 = [''] * 4
        read = 0
        while read < n:
            count = read4(buf4)
            if not count: break
            count = min(count, n - read)
            #for i in range(actual):
            buf[read:] = buf4[:count]
            read += count
        return read