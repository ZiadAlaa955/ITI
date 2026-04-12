using Football_BuilderDP.Entities;

namespace Football_BuilderDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            IBuilder multiBuilder = new BuilderMulti();

            director.ConstructGround(multiBuilder);

            PlayGround wembley = multiBuilder.GetGround();
            wembley.Display();


            IBuilder singleBuilder = new BuilderSingle();
            director.ConstructGround(singleBuilder);

            PlayGround localPitch = singleBuilder.GetGround();
            localPitch.Display();

        }
    }
}
