using System;
using System.Collections.Generic;
using System.Text;

namespace Football_BuilderDP.Entities
{
    public class PlayGround
    {
        List<string> parts = new();
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Display()
        {
            Console.WriteLine("=================");
            Console.WriteLine("PlayGround Components:");
            foreach(string part in parts)
            {
                Console.WriteLine($"{part}");
            }
            Console.WriteLine("=================");
        }
    }
}
