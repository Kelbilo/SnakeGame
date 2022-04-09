using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public abstract class GameObject
    {
        public Position CurrentPosition;
        
        public abstract char Renderer { get; }

        public abstract void Update();
        // Test
    }
}
