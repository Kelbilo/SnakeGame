using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    class ConsoleRenderer
    {
        private GameWorld world;
        /// <summary>
        /// Storläk på föstret som spelet visas på
        /// </summary>
        /// <param name="gameWorld">höjd och bredd för spelaplan (program fönster)</param>
        public ConsoleRenderer(GameWorld gameWorld)
        {
            Console.SetWindowSize(gameWorld.width, gameWorld.height);
            
            Console.SetBufferSize(gameWorld.width, gameWorld.height);

            world = gameWorld;
        }
        /// <summary>
        /// Metoden renderar(ritar upp) spelvärld och andra objekt som spelaren och maten
        /// </summary>
        public void Render()
        {

            foreach (GameObject walls in world.getGameObjects)
            {
                if (walls is Walls)
                {
                    Console.SetCursorPosition(walls.CurrentPosition.X, walls.CurrentPosition.Y);
                    Console.Write(walls.Renderer);
                }
            }

            foreach (GameObject gameObject in world.getGameObjects)
            {
                
                // Ritar upp spelvärlden(spelaren, maten, väggarna)
                if (gameObject is IRenderable)
                {
                    Console.SetCursorPosition(gameObject.CurrentPosition.X, gameObject.CurrentPosition.Y);
                    Console.Write(gameObject.Renderer);
                    Console.CursorVisible = false;
                    // Ritar upp svansen
                    /*if (gameObject is Player)
                    {
                        var player = gameObject as Player;
                        foreach (Tail tail in player.tailList)
                        {
                            Console.SetCursorPosition(tail.CurrentPosition.X, tail.CurrentPosition.Y);
                            Console.Write(tail.Renderer);
                        }
                    }*/
                }
            }
            // Poängräknare
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"POINTS: {world.score}");
            // Tid innan maten byter plats
            Console.SetCursorPosition(15, 0);
            Console.Write($"Tid innan mat regeneation: {world.time}");
        }
        /// <summary>
        /// Den är metoden tar bort den blinkande effekten för spelet(smooth gameplay)
        /// </summary>
        public void RenderBlank()
        {
            foreach (GameObject gameObject in world.getGameObjects)
            {

                if (gameObject is IRenderable)
                {
                    Console.SetCursorPosition(gameObject.CurrentPosition.X, gameObject.CurrentPosition.Y);
                    Console.Write(' ');
                    Console.CursorVisible = false;
                }
            }
        }
    }
}
