public class Fancy
{
    private const int MOD = 1000000007;

    private List<int> storedValues;
    private int multiplier;
    private int increment;

    public Fancy()
    {
        storedValues = new List<int>();
        multiplier = 1;
        increment = 0;
    }

    private int ModPow(int baseValue, int exponent)
    {
        long result = 1;
        long current = baseValue;

        while (exponent > 0)
        {
            if ((exponent & 1) != 0)
            {
                result = result * current % MOD;
            }

            current = current * current % MOD;
            exponent >>= 1;
        }

        return (int)result;
    }

    private int ModularInverse(int value)
    {
        return ModPow(value, MOD - 2);
    }

    public void Append(int value)
    {
        long normalized =
            ((long)(value - increment + MOD) % MOD) *
            ModularInverse(multiplier) % MOD;

        storedValues.Add((int)normalized);
    }

    public void AddAll(int addValue)
    {
        increment = (increment + addValue) % MOD;
    }

    public void MultAll(int multiplyValue)
    {
        multiplier = (int)((long)multiplier * multiplyValue % MOD);
        increment = (int)((long)increment * multiplyValue % MOD);
    }

    public int GetIndex(int index)
    {
        if (index >= storedValues.Count)
        {
            return -1;
        }

        return (int)(((long)multiplier * storedValues[index] + increment) % MOD);
    }
}