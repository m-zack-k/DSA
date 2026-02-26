public class Solution
{
    public int NumSteps(string s)
    {
        int steps = 0;
        int carry = 0;

        // Iterate from the last bit down to the second bit (index 1)
        for (int i = s.Length - 1; i > 0; i--)
        {
            // Calculate current bit value including the carry
            int curr = (s[i] - '0') + carry;

            if (curr % 2 == 1)
            {
                // If odd (curr == 1): We add 1 (takes 1 step) and divide by 2 (takes 1 step)
                steps += 2;
                carry = 1;
            }
            else
            {
                // If even (curr == 0 or curr == 2): We just divide by 2 (takes 1 step)
                steps += 1;
                // Note: carry doesn't change. If it was 1 (curr == 2), it stays 1. 
                // If it was 0 (curr == 0), it stays 0.
            }
        }

        // Add the final carry for the most significant bit
        return steps + carry;
    }
}