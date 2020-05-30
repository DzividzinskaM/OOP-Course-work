using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class TriangleElement : IElement
    {
        int x { get; set; }
        int y { get; set; }
        int length { get; set; }

        public TriangleElement(int length)
        {
            this.length = length;
        }

      

        public bool checkAvailableSpace(Space space, int x, int y)
        {
            int tplX = x;
            int tplY = y;
            while (tplX < x + length)
            {
                tplY = y;
                while (tplY - tplX <= y - x)
                {
                    if (space.matrixSpace[tplX, tplY] != space.emptyElemInSpace)
                    {
                        return false;
                    }
                    tplY++;
                }
                tplX++;
            }
            return true;
        }

        public void addElementToSpace(Space space, int xStart, int yStart)
        {

            x = --xStart;
            y = --yStart;
            if (checkAvailableSpace(space, x, y))
            {
                int tplX = x;
                int tplY = y;
                while (tplX < x + length)
                {
                    tplY = y;
                    while (tplY - tplX <= y - x)
                    {
                        space.matrixSpace[tplX, tplY] = "t";
                        tplY++;
                    }
                    tplX++;
                }
            }
        }

        public void removeElementFromSpace(Space space)
        {
            int tplX = x;
            int tplY = y;

            while (tplX < x + length)
            {
                tplY = y;
                while (tplY - tplX <= y - x)
                {
                    space.matrixSpace[tplX, tplY] = space.emptyElemInSpace;
                    tplY++;
                }
                tplX++;
            }
        }

        public void moveUp(Space space, int position)
        {
            if (x - position < 0)
            {
                throw new Exception("You go over space");
            }
            removeElementFromSpace(space);
            if (checkAvailableSpace(space, x - position, y))
            {
                ++x;
                ++y;
                addElementToSpace(space, x - position, y);
            }
            else
            {
                addElementToSpace(space, x, y);
                throw new Exception("space for element is not available");
            }
        }

        public void moveDown(Space space, int position)
        {
            if (x + position > space.width)
                throw new Exception("You go over space");

            removeElementFromSpace(space);
            if (checkAvailableSpace(space, x + position, y))
            {
                ++x;
                ++y;
                addElementToSpace(space, x + position, y);
            }
            else
            {
                addElementToSpace(space, x, y);
                throw new Exception("space for element is not available");
            }
        }

        public void moveRight(Space space, int position)
        {
            --position;
            if (y + position > space.length)
            {
                throw new Exception("You go over space");
            }
            removeElementFromSpace(space);
            if (checkAvailableSpace(space, x, y + position))
            {
                ++x;
                ++y;
                addElementToSpace(space, x, y + position);
            }
            else
            {
                addElementToSpace(space, x, y);
                throw new Exception("space for element is not available");
            }
        }

        public void moveLeft(Space space, int position)
        {
            --position;
            if (y - position < 0)
            {
                throw new Exception("You go over space");
            }
            removeElementFromSpace(space);
            if (checkAvailableSpace(space, x, y - position))
            {
                ++x;
                ++y;
                addElementToSpace(space, x, y - position);
            }
            else
            {
                addElementToSpace(space, x, y);
                throw new Exception("space for element is not available");
            }
        }

        public void turnElement(Space space)
        {

            removeElementFromSpace(space);
            addElementToSpace(space, ++y, ++x);

           /* Space tplSpace = space;

            removeElementFromSpace(space);

            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX - tplY <= x-y)
                {
                    if(space.matrixSpace[tplX, tplY] != space.emptyElemInSpace)
                    {
                        space = tplSpace;
                        throw new Exception("element can not to be turn in this space");
                    }
                    space.matrixSpace[tplX, tplY] = "t";
                    tplX++;
                }
                tplY++;
            }*/
        }
    }
}
