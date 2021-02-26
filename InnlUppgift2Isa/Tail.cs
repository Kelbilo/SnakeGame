using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public class Tail : IRenderable
    {
        public char Renderer { get => 'X'; }

        public Position CurrentPosition;

        public Tail(int posX, int posY)
        {
            CurrentPosition.X = posX;
            CurrentPosition.Y = posY;
        }
    }
}
