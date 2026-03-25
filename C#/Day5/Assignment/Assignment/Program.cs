namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point3D p = new Point3D(10, 10, 10);

            Console.WriteLine(p);

            string pString = (string)p;
            Console.WriteLine(pString);
            Console.WriteLine("--------------------------");

            Point3D clonePoint = (Point3D)p.Clone();
            clonePoint.X = 999;
            Console.WriteLine($"Original after clone change: {p}");
            Console.WriteLine($"Clone after clone change: {clonePoint}");
            Console.WriteLine("--------------------------");

            Console.WriteLine("--- Sorting ---");
            Point3D[] pointsArray = new Point3D[]
            {
                new Point3D(5, 10, 2),
                new Point3D(1, 20, 3),
                new Point3D(5, 2, 1),
                new Point3D(3, 8, 4)
            };

            Array.Sort(pointsArray);

            foreach (var pt in pointsArray)
            {
                Console.WriteLine(pt);
            }
            Console.WriteLine("--------------------------");

            /////////////////////////////////////////////
            Console.WriteLine("--------------------------");
            Console.WriteLine("Enter X and Y Coordinates of a point:");
            int x, y;
            while(!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Enter numbers only!!!");
            }   
            while(!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Enter numbers only!!!");
            }
            Point3D p2 = new Point3D(x, y);

        }
    }
}
