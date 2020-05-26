using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class UnitWall : RectangleElement
    {
        public string color { get; }

        public string code = "w";

        protected int maxWidth = 3;
        public int width { get; }
        public int length { get; }

        public int height { get; }

        public UnitWall(int length, int height, int width=1) : base(width, length)
        {
            this.height = height;
            base.codeElement = code;
            if(width <= maxWidth)
            {
                this.width = width;
               
            }
            else
            {
                throw new Exception("Wall must be in diapason from 1 to 2");
            }
        }

        public void addWall(Space space, int xStart, int yStart)
        {
            if(space.height < this.height)
            {
                throw new Exception("Wall's height is more than space's height");
            }
            base.addElementToSpace(space, xStart, yStart);
        }

        public void removeWall(Space space)
        {
            base.removeElementFromSpace(space);
        }

        public void moveWallRigth(Space space, int position)
        {
            base.moveRight(space, position);
        }

        public void moveWallLeft(Space space, int position)
        {
            base.moveLeft(space, position);
        }

        public void moveWallToUp(Space space, int position)
        {
            base.moveUp(space, position);
        }

        public void moveWallToDown(Space space, int position)
        {
            base.moveDown(space, position);
        }

        public void turnWall(Space space)
        {
            base.turnElement(space);
        }
    }
}
