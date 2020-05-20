using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class Space
    {
        public int length { get; }
        public int width { get; }

        public int height { get;  }

        public string[,] matrixSpace;

        internal string emptyElemInSpace = "0";

        public Space(int width, int length, int height)
        {
            if(length>0 && width>0 && height > 0)
            {
                this.length = length;
                this.height = height;
                this.width = width;
            }
            else
            {
                throw new Exception("data isn't correct");
            }

            matrixSpace = new string[width, length];

            for(int i=0; i < width; i++)
            {
                for(int j=0; j<length; j++)
                {
                    matrixSpace[i, j] = emptyElemInSpace;
                }
            }
        }

    }
}
