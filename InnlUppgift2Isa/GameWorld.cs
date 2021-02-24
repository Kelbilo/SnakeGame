using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InnlUppgift2Isa
{
    public class GameWorld : Program
    {
        public int height;
        public int width;
        public int score;
        

        public List<GameObject> getGameObjects = new List<GameObject>();
        List<Tail> tail = new List<Tail>();
        Tail tails = new Tail();

        public GameWorld(int w, int h)
        {
            height = h;
            width = w;
        }
        /// <summary>
        /// GenerateFood metoden skapar ett food objekt och lägger till det i gameObject listan
        /// </summary>
        public void GenerateFood()
        {
            Food food = new Food();
            getGameObjects.Add(food);
        }
        

        public void Update()
        {
            foreach (GameObject gameObject in getGameObjects)
            {
                gameObject.Update();
            }


            foreach (GameObject player in getGameObjects)
            {
                if (player is Player)
                {
                    foreach (GameObject food in getGameObjects)
                    {
                        if (food is Food)
                        {
                            if (player.CurrentPosition == food.CurrentPosition)
                            {
                                getGameObjects.Remove(food);
                                score++;
                                GenerateFood();
                                tail.Add(tails);
                                break;
                            }
                        }
                    }
                }
                break;
            }

            int msSleep = 3000;
            foreach (GameObject player in getGameObjects)
            {
                if (player is Player)
                {
                    foreach (GameObject walls in getGameObjects)
                    {
                        if (walls is Walls)
                        {
                            if (player.CurrentPosition == walls.CurrentPosition)
                            {
                                GameOverScreen(msSleep);
                            }
                        }
                    }
                    // Kollar om spelaren korckar i väggen isåfall Starta om spelet spelet
                    if (player.CurrentPosition.X < 0)
                    {
                        GameOverScreen(msSleep);
                    }
                    else if (player.CurrentPosition.X >= width)
                    {
                        GameOverScreen(msSleep);
                    }
                    else if (player.CurrentPosition.Y < 1)
                    {
                        GameOverScreen(msSleep);
                    }
                    else if (player.CurrentPosition.Y >= height)
                    {
                        GameOverScreen(msSleep);
                    }
                }
            }
        }
        /// <summary>
        /// metdoen visas körs efter spelaren krockat och visar poäng 3 sekunder innan spelet startar om
        /// </summary>
        /// <param name="msSleep">Antal sekunder innan omstart (1000 ms = 1 sekund)</param>
        private void GameOverScreen(int msSleep)
        {
            Console.Clear();
            Console.SetCursorPosition(18, 6);
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(18, 8);
            Console.WriteLine("Game restart in 3 seconds");
            Console.SetCursorPosition(18, 9);
            Console.WriteLine("BE READY!!");
            Console.SetCursorPosition(18, 7);
            Console.WriteLine($"Your Score: {score}");
            // Läste lite om Thread.Sleep, såg att du använde den också så jag använde den här så inte spelet startar om direkt
            Thread.Sleep(msSleep);
            Console.Clear();
            // Anropar Loop efter 3 sekunder så spelet börjar om
            Program.Loop();
        }
    }
}
