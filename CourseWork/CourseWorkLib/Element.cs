﻿using System;
using CourseWorkLib;

namespace CourseWorkLib
{
    public class Element
    {
        public int length { get; }
        public int width { get; }
        public int x { get; set; }
        public int y { get; set; }

        public Element(int width, int length)
        {
            this.length = length;
            this.width = width;
        }

        public bool checkAvailableSpace(Space space, int x, int y)
        {
            if(x+width>space.width && y+length>space.length)
            {
                throw new Exception("You go over space");
            }
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    if (space.matrixSpace[tplX, tplY] != space.emptyElemInSpace)
                        return false;
                    tplX++;
                }
                tplY++;
            }
            return true;

        }
        public void addElementToSpace(Space space, int xStart, int yStart)
        {
            --xStart;
            --yStart;
            if(checkAvailableSpace(space, xStart, yStart))
            {
                x = xStart;
                y = yStart;
                int tplX = x;
                int tplY = y;
                while (tplY < y + length)
                {
                    tplX = x;
                    while (tplX < (x + width))
                    {
                        space.matrixSpace[tplX, tplY] = "1";
                        tplX++;
                    }
                    tplY++;
                }
            }
            else
            {
                throw new Exception("There aren't available space for adding this element");
            }
           
        }


        public void removeElementFromSpace(Space space)
        {
            if(checkAvailableSpace(space, x, y))
                throw new Exception("Nothing for delete! Please add element firstly");
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    space.matrixSpace[tplX, tplY] = "0";
                    tplX++;
                }
                tplY++;
            }
        }
        
        public void moveUp(Space space, int position)
        {
            if(x-position < 0)
            {
                throw new Exception("You go over space");
            }
            removeElementFromSpace(space);
            if(checkAvailableSpace(space, x-position, y))
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
            if(x+position > space.width)
                throw new Exception("You go over space");

            removeElementFromSpace(space);
            if(checkAvailableSpace(space, x + position, y))
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
            if (y + position > space.length)
            {
                throw new Exception("You go over space");
            }
            removeElementFromSpace(space);
            if (checkAvailableSpace(space, x, y+position))
            {
                ++x;
                ++y;
                addElementToSpace(space, x, y+position);
            }
            else
            {
                addElementToSpace(space, x, y);
                throw new Exception("space for element is not available");
            }

        }

        public void moveLeft(Space space, int position)
        {
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
    }
}
