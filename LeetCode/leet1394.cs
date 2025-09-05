public class Solution1394 {
    
    public static int FindLucky(int[] arr)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in arr)
        {
            if (freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        }
        int largest = -1;
        foreach (int key in freq.Keys)
        {
            if (freq[key] == key && key > largest)
            {
                largest = key;
            }
        }
        return largest;
    }
}