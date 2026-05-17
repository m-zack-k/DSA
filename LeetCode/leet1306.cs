public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            if (arr[curr] == 0)
            {
                return true;
            }
            else
            {
                visited[curr] = true;
                if (curr + arr[curr] < n && !visited[curr + arr[curr]])
                {
                    queue.Enqueue(curr + arr[curr]);
                }
                if (curr - arr[curr] >= 0 && !visited[curr - arr[curr]])
                {
                    queue.Enqueue(curr - arr[curr]);
                }
            }
        }

        return false;
    }
}