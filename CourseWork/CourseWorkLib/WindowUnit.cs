using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class WindowUnit : InWallElement
    {
        public int id { get; }

        public string name { get; }
        public string color { get; }
        public string material { get; }

    //    public int width { get; }
     //   public int length { get; }

        public int height { get;  }
        public bool pattern { get; }

        public int parts { get; }

        public int installationHeight { get; private set; }


        public WindowUnit(int id, string name, string color, string material, int width, 
            int length, int height, bool pattern, int parts) : base(width, length, CodeElementHelper.windowElement)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.material = material;
            this.width = width;
            this.length = length;
            this.height = height;
            this.pattern = pattern;
            this.parts = parts;
        }

        public WindowUnit(string name, string color, string material, int width,
           int length, int height, bool pattern, int parts) : base(width, length, CodeElementHelper.windowElement)
        {
            this.id = id;
            this.color = color;
            this.material = material;
            this.width = width;
            this.length = length;
            this.height = height;
            this.pattern = pattern;
            this.parts = parts;
        }


        public void addElement(Space space, int x, int y, int installationHeight) 
        {
            
            if (installationHeight + height > space.height)
                throw new Exception("Yon can not put this element on this height");
            this.installationHeight = installationHeight;
            base.addElementToSpace(space, x, y);
            space.windows.Add(this);
        }

        public void removeElement(Space space)
        {
            base.removeElement(space);
            space.windows.Remove(this);
        }
    }
}
