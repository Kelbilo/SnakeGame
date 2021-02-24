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
            //Rita upp väggar
            /*foreach (GameObject walls in world.getGameObjects)
            {
                if (walls is Walls)
                {
                    int wallWidth = 47;
                    int wallHeight = 19;
                    // ritar upp väggen på toppen
                    for (int i = 1; i <= wallWidth; i++)
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.Write(walls.Renderer);
                    }
                    // ritar upp väggen på vänster sida
                    for (int i = 1; i <= wallHeight; i++)
                    {
                        Console.SetCursorPosition(1, i);
                        Console.Write(walls.Renderer);
                    }
                    // ritar upp väggen på botten
                    for (int i = 1; i < wallWidth; i++)
                    {
                        Console.SetCursorPosition(i, wallHeight);
                        Console.Write(walls.Renderer);
                    }
                    // ritar upp väggen på höger sida
                    for (int i = 1; i < wallHeight; i++)
                    {
                        Console.SetCursorPosition(wallWidth, i);
                        Console.Write(walls.Renderer);
                    }
                }
            }*/

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
