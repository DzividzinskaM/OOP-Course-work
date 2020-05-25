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
            Space tplSpace = new Space(space.width, space.length, space.height);

            removeElementFromSpace(tplSpace);

            int tplX = x;
            int tplY = y;

            while (tplX < x + length)
            {
                tplY = y;
                while (tplY - tplX <= y - x)
                {
                    if(tplSpace.matrixSpace[tplX, tplY] != space.emptyElemInSpace)
                    {

                        throw new Exception("not enough space for turning element");

                    }
                    else
                    {
                        tplSpace.matrixSpace[tplY, tplX] = "t";
                    }
                    tplY++;
                }
                tplX++;
            }

            space.matrixSpace = tplSpace.matrixSpace;
            int tpl = x;
            x = y;
            y = tpl;
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
