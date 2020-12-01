using System;
using System.Collections.Generic;
using System.Text;

namespace FightGameServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClient, Packet packet)
        {
            packet.WriteLength();
            GameServer.clients[toClient].tcp.SendData(packet);
        }

        private static void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();
            for (int i = 1; 1 <= GameServer.MaxPlayers; i++)
            {
                GameServer.clients[i].tcp.SendData(packet);
            }
        }

        private static void SendTCPDataToAll(int exceptClient, Packet packet)
        {
            packet.WriteLength();
            for (int i = 1; 1 <= GameServer.MaxPlayers; i++)
            {
                if (i != exceptClient)
                { 
                    GameServer.clients[i].tcp.SendData(packet);
                }                    
            }
        }

        public static void Welcome(int toClient, string msg)
        {
            using (Packet packet = new Packet((int)ServerPackets.welcome))
            {
                packet.Write(msg);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }
    }
}
