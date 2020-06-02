using System;
using System.Collections.Generic;
using System.Text;
using CourseWorkLib.Exception;

namespace CourseWorkLib
{
    public class InWallElement : RectangleElement
    {

        public  int x { get; private set; }
        
        public  int y { get; private set; }


        public InWallElement(int width, int length, string code) : base(width, length)
        {
            base.removingElement = CodeElementHelper.wallElement;
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
                throw new DesignSpaceException("You can add this element only instead of wall");
            this.x = x;
            this.y = y;
            base.x = x;
            base.y = y;
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    space.matrixSpace[tplX, tplY] = codeElement;
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
                    if (space.matrixSpace[tplX, tplY] != CodeElementHelper.wallElement)
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
    }
}
