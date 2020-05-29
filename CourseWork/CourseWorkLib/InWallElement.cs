using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class InWallElement 
    {
        private string codeElement;

        public InWallElement(string code)
        {
            codeElement = code;
        }
       
        public void addElement(Space space, int length, int width, int x, int y) 
        {
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
    }
}
