using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public class Food : GameObject, IRenderable
    {
        public override char Renderer { get => '¤'; }

        public Food()
        {
            // Slumpmässiga koordinater for food objektet
            Random random = new Random();

            int posX = random.Next(2, 48);
            int posY = random.Next(3, 18);

            CurrentPosition = new Position(posX, posY);
        }
        
        public override void Update()
        {

        }
    }
}
