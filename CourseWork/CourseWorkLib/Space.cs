using System;
using System.Collections.Generic;
using System.Text;
using CourseWorkLib.FurnitureFactory;

namespace CourseWorkLib
{
    public class Space
    {
        public int length { get; }
        public int width { get; }
        public int height { get;  }

        public string[,] matrixSpace;

        internal string emptyElemInSpace = "0";

        public List<WallUnit> walls { get; internal set; }
        public List<DoorUnit> doors;
        public List<WindowUnit> windows;
        public List<Bed> beds;
        public List<Chair> chairs;
        public List<Wardrobe> wardrobes;

        public Space(int width, int length, int height)
        {
            walls = new List<WallUnit>();
            doors = new List<DoorUnit>();
            windows = new List<WindowUnit>();
            beds = new List<Bed>();
            chairs = new List<Chair>();
            wardrobes = new List<Wardrobe>();
            if (length>0 && width>0 && height > 0)
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
