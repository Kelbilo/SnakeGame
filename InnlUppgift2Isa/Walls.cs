using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public class Walls : GameObject, IRenderable
    {

        public override char Renderer { get => '#'; }

        public Walls(int posX, int posY)
        {
            CurrentPosition.X = posX;
            CurrentPosition.Y = posY;
        }

        public override void Update()
        {

        }
    }
}
