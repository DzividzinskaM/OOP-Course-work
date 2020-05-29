﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class WindowUnit : InWallElement
    {
        public int id { get; }

        public string color { get; }
        public string material { get; }

        public int width { get; }
        public int length { get; }

        public int height { get;  }
        public bool pattern { get; }

        public int parts { get; }


        public WindowUnit(int id, string color, string material, int width, 
            int length, int height, bool pattern, int parts) : base(width, length, "W")
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

        public WindowUnit(string color, string material, int width,
           int length, int height, bool pattern, int parts) : base(width, length, "W")
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
            base.addElementToSpace(space, x, y);
        }
    }
}
