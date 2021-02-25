using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    class Tail : GameObject, IRenderable
    {
        public override char Renderer { get => '&'; }


        public Tail(int posX, int posY)
        {
            CurrentPosition.X = posX;
            CurrentPosition.Y = posY;
        }

        public override void Update()
        {

        }
    }
}
