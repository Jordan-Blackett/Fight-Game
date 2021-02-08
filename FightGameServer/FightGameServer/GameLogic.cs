using System;
using System.Collections.Generic;
using System.Text;

namespace FightGameServer
{
    class GameLogic
    {
        public static void Update()
        {
            foreach (Client client in GameServer.clients.Values)
            {
                if (client.player != null)
                {
                    client.player.Update();
                }
            }

            ThreadManager.UpdateMain();
        }
    }
}
