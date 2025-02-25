using System;
using System.Threading;
using aiexercise.core.Game;

namespace aiexercise.core
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            ConsoleKeyInfo keyInfo;

            Thread gameThread = new Thread(new ThreadStart(game.Start));
            gameThread.Start();

            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    game.GetPlayer().Jump();
                }
            }
        }
    }
}
