using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class DoorUnit : InWallElement
    {
        public int id { get; }

        public string material { get;  }
        public int width { get; }
        public int length { get; }
        public int height { get; }
        
        public string color { get; }

        public DoorUnit(int id, string material, int width, int length, int height, string color) : base(width, length, "D")
        {
            this.id = id;
            this.material = material;
            this.width = width;
            this.length = length;
            this.height = height;
            this.color = color;
        }

        public DoorUnit(string material, int width, int length, int height, string color) : base(width, length, "D")
        {

            this.material = material;
            this.width = width;
            this.length = length;
            this.height = height;
            this.color = color;
        }

        public void addElement(Space space, int x, int y)
        {
            if(space.height < height)
            {
                throw new Exception("this door is higher then space");
            }
            base.addElementToSpace(space, x, y);
        }
       
    }
}
