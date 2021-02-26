using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public class Player : GameObject, IMovable, IRenderable
    {
        // IRenderable interface implementation
        public override char Renderer { get => '☺'; }

        // IMovable interface implementation
        public Direction GetDirection { get; set; }

        //public List<Tail> tailList = new List<Tail>();

        public Player()
        {
            CurrentPosition = new Position(15, 10);
        }

        /// <summary>
        /// Player Update för vilken direction som player ska färdas på
        /// </summary>
        public override void Update()
        {
            //tailList.Add(new Tail(CurrentPosition.X, CurrentPosition.Y));
            //tailList.RemoveAt(0);

            switch (GetDirection)
            {
                case Direction.Up:
                    CurrentPosition.Y -= 1;
                    break;
                case Direction.Down:
                    CurrentPosition.Y += 1;
                    break;
                case Direction.Left:
                    CurrentPosition.X -= 1;
                    break;
                case Direction.Right:
                    CurrentPosition.X += 1;
                    break;
                case Direction.None:
                    CurrentPosition.X += 0;
                    CurrentPosition.Y -= 0;
                    break;
                default:
                    break;
            }


        }
    }
}
