using Football_DecoratorDP.Entities;

namespace Football_DecoratorDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player Garcia = new GoalKeeper("Garcia");
            Garcia.PassBall();

            Console.WriteLine("-----------------------");
            
            Player Messi = new FieldPlayer("Messi");
            Messi.PassBall();

            Console.WriteLine("-----------------------");

            Midfielder midfielderMessi = new Midfielder();
            midfielderMessi.AssignPlayer(Messi);
            midfielderMessi.Dribble();
            midfielderMessi.PassBall();

            Console.WriteLine("-----------------------");

            Forward forwardMessi = new Forward();
            forwardMessi.AssignPlayer(Messi);
            forwardMessi.ShootGoal();
            forwardMessi.PassBall();

        }
    }
}
