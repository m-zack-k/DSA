public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        // long m = mass;
        // Array.Sort(asteroids);
        // foreach(int a in asteroids){
        //     if (a > m){
        //         return false;
        //     } else{
        //         m += a;
        //     }
        // }
        // return true;

        // above is a previous version

        // the below is optimized, using counting sort

        int max = 0;
        foreach (int a in asteroids)
        {
            if (max < a)
            {
                max = a;
            }
        }
        int[] freq = new int[max + 1];
        foreach (int a in asteroids)
        {
            freq[a]++;
        }
        long m = mass;
        for (int i = 1; i <= max; ++i)
        {
            if (freq[i] > 0)
            {
                if (i > m)
                {
                    return false;
                }
                else
                {
                    m += (long)freq[i] * i;
                }
            }
        }
        return true;
    }
}