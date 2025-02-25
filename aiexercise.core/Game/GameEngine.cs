using System;
using System.Collections.Generic;
using System.Threading;

namespace aiexercise.core.Game
{
    public class GameEngine
    {
        private Player player;
        private List<Obstacle> obstacles;
        private int groundLevel;
        private Random random;
        private int score;

        public Player GetPlayer()
        {
            return player;
        }

        public GameEngine()
        {
            groundLevel = 20;
            int startX = Console.WindowWidth / 2;
            player = new Player(groundLevel, startX);
            obstacles = new List<Obstacle>();
            random = new Random();
            score = 0;
        }

        public void Start()
        {
            while (true)
            {
                Update();
                Draw();
                Thread.Sleep(50); // Decrease sleep time to make the game faster
            }
        }

        private void Update()
        {
            player.Update();

            foreach (var obstacle in obstacles)
            {
                obstacle.Update();
            }

            if (random.Next(0, 100) < 10) // Randomly generate obstacles
            {
                obstacles.Add(new Obstacle(Console.WindowWidth - 1, groundLevel));
            }

            // Check for collisions
            foreach (var obstacle in obstacles)
            {
                if (IsCollision(player, obstacle))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"Score: {score}");
                    Environment.Exit(0);
                }
            }

            // Check for successful jumps
            foreach (var obstacle in obstacles)
            {
                if (player.X > obstacle.X + 2 && !obstacle.IsScored)
                {
                    score++;
                    obstacle.IsScored = true;
                }
            }

            // Remove off-screen obstacles
            obstacles.RemoveAll(o => o.X < 0);
        }

        private bool IsCollision(Player player, Obstacle obstacle)
        {
            // Check for overlapping areas between the player and the obstacle
            for (int i = 0; i < 4; i++) // Check across the height of the player and obstacle
            {
                for (int j = 0; j < 4; j++) // Check across the width of the player and obstacle
                {
                    if (player.X + j == obstacle.X && player.Y + i == obstacle.Y + i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Draw()
        {
            Console.Clear();
            player.Draw();
            foreach (var obstacle in obstacles)
            {
                obstacle.Draw();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {score}");
        }
    }
}


