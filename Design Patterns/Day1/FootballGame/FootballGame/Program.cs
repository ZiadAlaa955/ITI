using FootballGame.Entities;

namespace FootballGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Publisher
            Football gameBall = new Football();

            //Subscribers
            Player messi = new Player("Messi", gameBall);
            Player ronaldo = new Player("Ronaldo", gameBall);
            Referee collina = new Referee("Mark", gameBall);

            Console.WriteLine("\n--- Game Start! ---");

            gameBall.SetBallPosition(new Position(10, 20, 0));
            Console.WriteLine("-----------------------------");
            gameBall.SetBallPosition(new Position(80, 50, 15));

        }
    }
}
