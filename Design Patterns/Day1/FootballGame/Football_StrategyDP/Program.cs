using Football_StrategyDP.Entites;

namespace Football_StrategyDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TeamStrategy Attacking = new AttackStrategy();

            Team Barcelona = new Team("Barcelona", Attacking);

            Barcelona.PlayGame();

            Console.WriteLine("--------------------------------");
            
            TeamStrategy Defending = new DefendStrategy();

            Team RealMadrid = new Team("RealMadrid", Defending);

            RealMadrid.PlayGame();

        }
    }
}
