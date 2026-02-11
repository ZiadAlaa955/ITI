namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int size = int.Parse(Console.ReadLine());
            arr = new int[size];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] =int.Parse(Console.ReadLine()) ;
            }


            int maxNum = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        int currMax = j - i - 1;
                        if (currMax > maxNum)
                            maxNum = currMax;
                    }
                }
            }

            Console.WriteLine($"Max distance: {maxNum}");
        }
    }
}
