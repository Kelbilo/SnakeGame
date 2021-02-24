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
            Walls walls = new Walls();
            world.getGameObjects.Add(walls);
            foreach (GameObject gameObject in world.getGameObjects)
            {
                if (gameObject is Walls)
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
                }
            }
            // Poängräknare
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"POINTS: {world.score}");
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
