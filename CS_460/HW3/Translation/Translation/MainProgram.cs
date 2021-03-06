﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Translation
{/// <summary>
/// A class that contains the driving program and the generation program for the binary representation of numbers.
/// </summary>
    public class MainProgram
    {
        /// <summary>
        /// Print the binary representation of all numbers from 1 up to n. This is accomplished by using a FIFO queue to perform a level order(i.e.BFS) traversal of a virtual binary tree and then storing each "value" in a list as it is "visited".
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            //Create an empty queue of strings with which to perform the traversal.
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            //A list for returning the binary values
            LinkedList<string> output = new LinkedList<string>();

            if(n < 1)
            {
                //binary representation of negative values is not suppported return an empty list
                return output;
            }

            //Enqueue the first binary number. Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            //BFS
            while(n-- > 0)
            {
                //print the font of queue. possibly put try catch here.
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                //make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left child
                sb.Append("0");
                q.Push(sb);
                //Right child
                sbc.Append("1");
                q.Push(sbc);
            }
            return output;
        }

        //Driver program to test above function
        /// <summary>
        /// Driver function for GenerateBinaryRepresentationList function.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 10;
            if(args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\t Translate 12");
                return;
            }
            try
            {
                n = Int32.Parse(args[0]);
            }
            catch(FormatException)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }
            LinkedList<string> output = GenerateBinaryRepresentationList(n);
            //Print it right justified. Longest string is the last one.
            //Print enough spaces to move it over the correct distance.
            int maxLength = output.Count();
            foreach (string s in output)
            {
                for(int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
