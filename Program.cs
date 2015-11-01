using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_Three
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the original array
            int[] theArray = new int[] { 7, 10, 4, 3, 8, 9 };

            // print the unsorted array out to the screen
            Console.WriteLine("Unsorted Array...");
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.WriteLine(theArray[i]);
            }
            Console.WriteLine("");

            // call MergeSort for the first time. Note that we pass an empty
            // array for the second parameter. This will be filled as we are
            // sorting. we don't create it as a variable first because we do
            // not need it after we've Merge Sorted
            MergeSort(theArray, new int[theArray.Length], theArray.Length);

            // print the sorted array out to the screen
            Console.WriteLine("Sorted Array...");
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.WriteLine(theArray[i]);
            }

            // stop the window from shutting when using debug mode
            Console.Read();
        }

        /*
         * MergeSort - kicks off the first SplitMerge call
         * 
         * int[] theArray - the Array that we are sorting
         * int[] theTempArray - the Array that we are using to work on
         * int n - the length of the array that we want to sort
         */
        static void MergeSort(int[] theArray, int[] theTempArray, int n)
        {
            // kick off the first SplitMerge on the whole array
            SplitMerge(theArray, 0, n, theTempArray);
        }

        /*
         * CopyArray - copies the recently sorted indexes from the
         *             temporary array to the original array
         *             
         * int[] theTempArray - the temporary array
         * int theStart - the first index to copy
         * int theEnd - the last index to copy
         * int[] theArray - the array to copy the indexes to
         */
        static void CopyArray(int[] theTempArray, int theStart, int theEnd, int[] theArray)
        {
            // loop through the recently sorted indexes and copy them
            // from the temporary array to the main one
            for (int k = theStart; k < theEnd; k++)
            {
                theArray[k] = theTempArray[k];
            }
        }

        /*
         * SplitMerge - a recursive function, it repeatedly
         *              splits the input array in half until
         *              it has two single indexes to compare.
         *              it then compares them, sorts them into
         *              a temporary array and then copies them.
         *             
         * int[] theArray - the array
         * int theStart - the first index to split
         * int theEnd - the last index to split
         * int[] theTempArray - the temporary array to copy the indexes to
         */
        static void SplitMerge(int[] theArray, int theStart, int theEnd, int[] theTempArray)
        {
            // if there aren't two indexes to compare, stop splitting
            if (theEnd - theStart < 2)
            {
                return;
            }

            // get the midpoint between the start and end
            int theMid = (theEnd + theStart) / 2;

            // split the left side
            SplitMerge(theArray, theStart, theMid, theTempArray);

            // split the right side
            SplitMerge(theArray, theMid, theEnd, theTempArray);

            // merge the left and right side
            Merge(theArray, theStart, theMid, theEnd, theTempArray);

            // copy the newly sorted indexes from the temporary array
            // to the permanent one
            CopyArray(theTempArray, theStart, theEnd, theArray);
        }

        /*
         * Merge - this is the bit that actually does the sort.
         *         we constantly want to compare the left half 
         *         with the right half. and copy the lower of
         *         the two into the current index of the array
         *         once we have copied a number the left side,
         *         for example, we compare the next one with the
         *         same right side from before and vice versa
         *             
         * int[] theArray - the array
         * int theStart - the first index
         * int theMid - the midpoint
         * int theEnd - the last index 
         * int[] theTempArray - the temporary array to copy the indexes to
         */
        static void Merge(int[] theArray, int theStart, int theMid, int theEnd, int[] theTempArray)
        {
            // the left and right indexes to start from
            int theLeftIndex = theStart;
            int theRightIndex = theMid;

            // loop through the all indexes between the left start 
            // and the right end.
            for (int j = theStart; j < theEnd; j++)
            {
                /*
                 * update from the left side if BOTH a) and b) are TRUE
                 *      a) we haven't used all of the left side already (i.e the 
                 *         left index is smaller than the midpoint)
                 *      b) we have used all of the right side (i.e the right index
                 *         is larger than or equal to the end 
                 *         OR
                 *         the left side is smaller than or equal to the right side
                 *
                 * otherwise use the right side
                */
                if (theLeftIndex < theMid && (theRightIndex >= theEnd || theArray[theLeftIndex] <= theArray[theRightIndex]))
                {
                    // use the left side, and update the left index
                    theTempArray[j] = theArray[theLeftIndex];
                    theLeftIndex++;
                }
                else
                {
                    // use the right side and update the right index
                    theTempArray[j] = theArray[theRightIndex];
                    theRightIndex++;
                }

            }
        }

    }


}


