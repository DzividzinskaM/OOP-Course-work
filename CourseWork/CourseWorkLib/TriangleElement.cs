using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class TriangleElement
    {
        int x { get; set; }
        int y { get; set; }
        int length { get; set; }

        public TriangleElement(int length)
        {
            this.length = length;
        }

        public void addElement(Space space, int xStart, int yStart)
        {
            --xStart;
            --yStart;
            x = xStart;
            y = yStart;

            int tplX = x;
            int tplY = y;

            while(tplX < x + length)
            {
                tplY = y;
                while(tplY-tplX <= y - x)
                {
                    Console.WriteLine("coords");
                    Console.WriteLine(tplX);
                    Console.WriteLine(tplY);
                    tplY++;
                }
                tplX++;
            }
        }

    }
}
