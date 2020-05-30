using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class InWallElement : RectangleElement
    {
//        private string codeElement;

       // private int width;
      //  private int length;

        public InWallElement(int width, int length, string code) : base(width, length)
        {
            base.removingElement = "w";
            this.width = width;
            this.length = length;
            codeElement = code;
            base.codeElement = codeElement;
        }

        protected override void addElementToSpace(Space space, int x, int y) 
        {
            --x;
            --y;
            if (!checkAvailableSpace(space, x, y))
                throw new Exception("You can add this element only instead of wall");
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    space.matrixSpace[tplX, tplY] = "D";
                    tplX++;

                }
                tplY++;
            }
        }

        protected override bool checkAvailableSpace(Space space, int x, int y)
        {
            
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    if (space.matrixSpace[tplX, tplY] != "w")
                        return false;
                    tplX++;

                }
                tplY++;
            }
            return true;
        }

        public void removeElement(Space space)
        {
            base.width = width;
            base.length = length;


            base.removeElementFromSpace(space);

        }

       /* public void moveRight(Space space, int position)
        {
            base.moveRight(space, position);
        }

        public void moveLeft(Space space, int position)
        {
            base.moveLeft(space, position);
        }

        public void moveUp(Space space, int position)
        {
            base.moveUp(space, position);
        }

        public void moveDown(Space space, int position)
        {
            base.moveDown(space, position);
        }*/
    }
}
