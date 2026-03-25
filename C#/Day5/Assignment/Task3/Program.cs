namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NIC nic = NIC.SingleTon;

            Console.WriteLine($"Manufacture: {nic.manufacture}");
            Console.WriteLine($"Manufacture: {nic.MAC}");
            Console.WriteLine($"Manufacture: {nic.NIC_Type}");

        }
    }
}
