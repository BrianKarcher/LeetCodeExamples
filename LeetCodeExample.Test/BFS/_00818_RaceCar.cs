using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Your car starts at position 0 and speed +1 on an infinite number line.Your car can go into negative positions.Your car drives automatically according to a sequence of instructions 'A' (accelerate) and 'R' (reverse):

    //When you get an instruction 'A', your car does the following:
    //position += speed
    //speed *= 2
    //When you get an instruction 'R', your car does the following:
    //If your speed is positive then speed = -1
    //otherwise speed = 1
    //Your position stays the same.
    //For example, after commands "AAR", your car goes to positions 0 --> 1 --> 3 --> 3, and your speed goes to 1 --> 2 --> 4 --> -1.

    //Given a target position target, return the length of the shortest sequence of instructions to get there.
    /// </summary>
    public class _00818_RaceCar
    {
        public int Racecar(int target)
        {
            // This has possible memory implications
            // Max possible speed is Target * 2 = 20,000.
            // We use bit shifting to get the speed, so the max possible speed values are 
            // 30. 2^15 = 32,768. But we can also go negative so need to double 15 to 30.
            //bool[,] visited = new bool[target, 32];
            HashSet<(int pos, int speed)> visited = new HashSet<(int pos, int speed)>();
            // Using BFS. There are too many combinations of position and speed possible to do DP.
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((0, 1));
            //visited[0, 1 + 15] = true;
            visited.Add((0, 1));
            int size = 0;
            while (q.Count != 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    (int pos, int speed) = q.Dequeue();
                    Console.WriteLine($"{size}, {pos}, {speed}");
                    if (pos == target)
                    {
                        //Console.WriteLine($"Found target {size}");
                        return size;
                    }
                    // Two options, Accelerate or reverse
                    // Try Accelerate
                    //int isSpeedNegative = speed < 0 ? -1 : 1;
                    //int accelerateSpeedBits = speed += isSpeedNegative;
                    //int accelerateSpeed = (1 << (accelerateSpeedBits - 1)) * isSpeedNegative;
                    //int newPos = pos += 1 << (speed - 1);
                    int newPos = pos + speed;
                    int newSpeed = speed * 2;
                    // Pruning
                    //if (visited[newPos, accelerateSpeedBits + 15] == false && accelerateSpeed > -target * 2 && accelerateSpeed < target * 2) {
                    if (!visited.Contains((newPos, newSpeed)) && newSpeed > -20_000 && newSpeed < 20_000 && newPos > -target * 2 && newPos < target * 2)
                    {
                        visited.Add((newPos, newSpeed));
                        //visited[newPos, newSpeed] = true;
                        q.Enqueue((newPos, newSpeed));
                    }

                    // Try reverse
                    //int reverseSpeedBits = isSpeedNegative * -1;
                    int reverseSpeed = speed > 0 ? -1 : 1;
                    //if (visited[newPos, reverseSpeedBits + 15] == false) {
                    if (!visited.Contains((pos, reverseSpeed)) && pos > -20_000 && pos < 20_000)
                    {
                        visited.Add((pos, reverseSpeed));
                        //visited[newPos, reverseSpeedBits + 15] = true;
                        q.Enqueue((pos, reverseSpeed));
                    }
                }
                size++;
            }
            return -1;
        }
    }
}