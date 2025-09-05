// // public class Solution704 {
// //     public int Search(int[] nums, int target)
// //     {
// //         int n = nums.Length;
// //         int mid = n / 2;
// //         int left = 0;
// //         int right = n - 1;
// //         while (left < right)
// //         {
// //             int curr = nums[mid];
// //             if (curr == target)
// //             {
// //                 return mid;
// //             }
// //             else if (curr < target)
// //             {
// //                 left = mid + 1;
// //                 mid = (left + right) / 2;
// //             }
// //             else
// //             {
// //                 right = mid - 1;
// //                 mid = (left + right) / 2;
// //             }
// //         }
// //         return -1;
// //     }
// // }

// static void Main()
// {
//     int n = int.Parse(Console.ReadLine());
//     string line2 = Console.ReadLine();
//     string[] strings = line2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//     int target = int.Parse(Console.ReadLine());
//     int[] nums = new int[n];
//     int i = 0;
//     foreach (string num in strings)
//     {
//         nums[i] = int.Parse(num);
//     }

//     int mid;
//     int left = 0;
//     int right = n - 1;
//     while (left <= right)
//     {
//         mid = (left + right) / 2;
//         int curr = nums[mid];
//         if (curr == target)
//         {
//             Console.WriteLine("Yes");
//             return;
//         }
//         else if (curr < target)
//         {
//             left = mid + 1;
//         }
//         else
//         {
//             right = mid - 1;
//         }
//     }
//     Console.WriteLine("No");
//     return;
    
// }

using System;

class Program2
{
    static void Main()
    {
        string line1 = Console.ReadLine();
        string[] info = line1.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(info[0]);
        int numQ = int.Parse(info[1]);
        string line2 = Console.ReadLine();
        char[] target = new char[n];
        int i  = 0;
        foreach (char c in line2)
        {
            target[i] = c;
            i++;
        }
        for (int j = 0; j < numQ; ++j)
        {
            string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (line[0] == "1")
            {
                target[j - 1] = char.Parse(line[2]);
            }
            else
            {
                int l = int.Parse(line[1]) - 1;
                int r = int.Parse(line[2]) - 1;
                string d = "";
                for (int k = l; k <= r; ++k)
                {
                    d += target[k];
                }
                Console.WriteLine(f(d));
            }

        }

    }
    static int f(string a)
    {
        int n = a.Length;
        char prevChar = a[0];
        int max = 1;
        int len = 1;
        for (int i = 1; i < n; ++i)
        {
            if (a[i] == prevChar)
            {
                len++;
                if (len > max) max = len;
            }
            else
            {
                prevChar = a[i];
                len = 1;
            }
        }
        return max;
    }
}