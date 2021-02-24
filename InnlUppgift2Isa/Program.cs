using System;
using System.Threading;

namespace InnlUppgift2Isa
{
    public class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it as uppercase, otherwise returns '\0'.
        /// </summary>
        static char ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key.ToString().ToUpper()[0] : '\0';
        /// <summary>
        /// The Game Loop
        /// </summary>
        public static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld(50, 20);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            Player player = new Player();
            world.getGameObjects.Add(player);

            Food food = new Food();
            world.getGameObjects.Add(food);


            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                char key = ReadKeyIfExists();
                switch (key)
                {
                    case 'W':
                        player.GetDirection = Direction.Up;
                        break;
                    case 'S':
                        player.GetDirection = Direction.Down;
                        break;
                    case 'A':
                        player.GetDirection = Direction.Left;
                        break;
                    case 'D':
                        player.GetDirection = Direction.Right;
                        break;
                    default:
                        // Jag valde att ta bort när spelaren står still så att spelaren rör på sig det hållet konstant
                        //player.GetDirection = Direction.None;
                        // TODO if- satser för spelare utanför spelplan.
                        break;
                }

                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();
                

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
        }
    }
}

