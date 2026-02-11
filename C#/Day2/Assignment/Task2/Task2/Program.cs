namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] words = s.Split(' ');
            Array.Reverse(words);

            string result = "";
            foreach(string x in words)
            {
                result += x + " ";
            }

            Console.WriteLine(result);
        }
    }
}
