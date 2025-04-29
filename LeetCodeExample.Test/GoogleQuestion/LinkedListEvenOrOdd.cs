using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.GeeksForGeeks
{
    public class G_LinkedListEvenOrOdd
    {
		/* isLengthEvenorOdd method should return 1 if the length of LL is even 
   otherwise return 0.*/
		int isLengthEvenorOdd(Node head1)
		{
			//Add your code here.
			int count = 0;
			Node current = head1;
			while (current != null)
			{
				current = current.next;
				count++;
			}
			return count % 2;
		}
		class Node
		{
			public int data;
			public Node next;
			Node(int d) { data = d; next = null; }
		}
	}

	


}
