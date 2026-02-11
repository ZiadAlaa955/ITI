namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Case1
            //double hundredMillion = Math.Pow(10, 8);

            //int count = 0;
            //for (int i = 1; i < hundredMillion; i++)
            //{
            //    string s = i.ToString();
            //    for (int j = 0; j < s.Length; j++)
            //    {
            //        if (s[j] == '1') count++;
            //    }
            //}

            //Console.WriteLine($"Count of ones: {count}");
            #endregion

            #region Case2
            //double hundredMillion = Math.Pow(10, 8);

            //int count = 0;
            //for (int i = 1; i < hundredMillion; i++)
            //{
            //    int currentI = i;
            //    while(currentI > 0)
            //    {
            //        int digit = currentI % 10;
            //        currentI /= 10;
            //        if (digit == 1) count++;
            //    }
            //}

            //Console.WriteLine($"Count of ones: {count}");
            #endregion

            #region Case3
            //double count = 0;
            //for(int i = 0; i < 8; i++)
            //{
            //    count += Math.Pow(10, i) * (i + 1);
            //}


            //Console.WriteLine($"Count of ones: {Math.Pow(10, 7) * (8)}");
            #endregion
        }
    }
}
