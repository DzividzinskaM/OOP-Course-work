using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class DoorUnit : InWallElement
    {
        public int id { get; }

        public string material { get;  }

        public string name { get; }
       // public int width { get; }
       // public int length { get; }
        public int height { get; }
        
        public string color { get; }

        public DoorUnit(int id, string name, string material, int width, int length, int height, string color) : base(width, length, "D")
        {
            this.id = id;
            this.name = name;
            this.material = material;
            this.width = width;
            this.length = length;
            this.height = height;
            this.color = color;
        }

        public DoorUnit(string name, string material, int width, int length, int height, string color) : base(width, length, "D")
        {
            this.name = name;
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
            space.doors.Add(this);
        }

        public void removeElement(Space space)
        {
            base.removeElement(space);
            space.doors.Remove(this);
        }
       
    }
}
