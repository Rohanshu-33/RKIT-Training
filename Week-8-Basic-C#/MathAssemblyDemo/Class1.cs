namespace MathAssemblyDemo
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public float Add(float a, float b)
        {
            return a + b;
        }

        public int Multiply(params int[] nums)
        {
            int ans = 1;
            foreach (int num in nums)
            {
                ans *= num;
            }
            return ans;
        }
    }
}
