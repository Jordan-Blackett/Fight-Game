using System;

namespace FightGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Fight Game Server";
            Console.WriteLine("Hello World!");

            GameServer.Start(50, 26950);

            Console.ReadKey();
        }
    }
}
