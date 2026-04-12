using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class PlayerRole : Player
    {
        Player player;

        public void AssignPlayer(Player p)
        {
            player = p;
            this.Name = p.Name;
        }

        public override void PassBall()
        {
            player.PassBall();
        }
    }
}
