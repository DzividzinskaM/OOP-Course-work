﻿using System;
using CourseWorkLib;

namespace CourseWorkLib
{
    public class RectangleElement 
    {
        public int length { get; set; }
        public int width { get; set; }

        public int x { get; set; }
        public int y { get; set; }


        protected string codeElement;
        protected string removingElement = CodeElementHelper.emptyElement;

        protected RectangleElement(int width, int length)
        {
            this.length = length;
            this.width = width;
        }

        protected virtual bool checkAvailableSpace(Space space, int x, int y)
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
                    Console.WriteLine(space.matrixSpace[tplX, tplY]);
                    if (space.matrixSpace[tplX, tplY] != CodeElementHelper.emptyElement)
                        return false;
                    tplX++;
                }
                tplY++;
            }
            return true;

        }
        protected virtual void addElementToSpace(Space space, int xStart, int yStart)
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
                        space.matrixSpace[tplX, tplY] = codeElement;
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


        protected void removeElementFromSpace(Space space)
        {
            int tplX = x;
            int tplY = y;
            while (tplY < y + length)
            {
                tplX = x;
                while (tplX < (x + width))
                {
                    space.matrixSpace[tplX, tplY] = removingElement;
                    tplX++;
                }
                tplY++;
            }
        }

        protected void moveUp(Space space, int position)
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
        protected void moveDown(Space space, int position)
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

        protected void moveRight(Space space, int position)
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

        protected void moveLeft(Space space, int position)
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

        protected void turnElement(Space space)
        {
            int tplWidth = width;
            int tplLength = length;

            removeElementFromSpace(space);

            length = tplWidth;
            width = tplLength;

            if(checkAvailableSpace(space, x, y))
            {
                x++;
                y++;
                addElementToSpace(space, x, y);
            }
            else
            {
                length = tplLength;
                width = tplWidth;

                addElementToSpace(space, x, y);

                throw new Exception("there aren't enough space for turning element");
            }
        }
    }
}
