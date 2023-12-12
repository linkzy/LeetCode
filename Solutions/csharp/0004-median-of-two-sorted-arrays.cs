using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class _0004_median_of_two_sorted_arrays
    {
        [Fact]
        public void Can_Find_The_Median()
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };

            Object.Equals(FindMedianSortedArrays(nums1, nums2), 2.5);

        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                // Ensure nums1 is the smaller array
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int x = nums1.Length;
            int y = nums2.Length;

            int low = 0;
            int high = x;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];

                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

                if (maxX <= minY && maxY <= minX)
                {
                    // Correct partition found
                    if ((x + y) % 2 == 0)
                    {
                        // Total number of elements is even
                        return (double)(Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2;
                    }
                    else
                    {
                        // Total number of elements is odd
                        return Math.Max(maxX, maxY);
                    }
                }
                else if (maxX > minY)
                {
                    // Adjust the partition to the left in nums1
                    high = partitionX - 1;
                }
                else
                {
                    // Adjust the partition to the right in nums1
                    low = partitionX + 1;
                }
            }

            // If we reach here, the input arrays are not sorted
            throw new ArgumentException("Input arrays are not sorted.");
        }



        //Worng solution because its O(m + n)
        public double FindMedianSortedArraysTwo(int[] nums1, int[] nums2)
        {
            SortedDictionary<int, bool> mergedArray = new SortedDictionary<int, bool>();
            for (int i = 0; i < nums1.Length; i++) { mergedArray[nums1[i]] = true; }
            for (int i = 0;i < nums2.Length; i++) { mergedArray[nums2[i]] = true;}

            if (mergedArray.Count() % 2 == 0)
            {
                int m1 = (mergedArray.Count() / 2) - 1;
                int m2 = (mergedArray.Count() / 2);
                return ((double)(mergedArray.ElementAt(m1).Key + mergedArray.ElementAt(m2).Key) / (double)2);
            }
            else
            {
                int midPoint = (int)Math.Floor((double)(mergedArray.Count() / 2));
                return mergedArray.ElementAt(midPoint).Key;
            }
        }
    }
}
