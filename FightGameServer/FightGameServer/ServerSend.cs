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
        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            GameServer.clients[_toClient].udp.SendData(_packet);
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

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= GameServer.MaxPlayers; i++)
            {
                GameServer.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= GameServer.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    GameServer.clients[i].udp.SendData(_packet);
                }
            }
        }

        #region Packets
        public static void Welcome(int toClient, string msg)
        {
            using (Packet packet = new Packet((int)ServerPackets.welcome))
            {
                packet.Write(msg);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }

        public static void UDPTest(int _toClient)
        {
            using (Packet _packet = new Packet((int)ServerPackets.udpTest))
            {
                _packet.Write("A test packet for UDP.");

                SendUDPData(_toClient, _packet);
            }
        }
        #endregion
    }
}
