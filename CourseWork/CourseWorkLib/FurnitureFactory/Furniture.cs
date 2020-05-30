using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    abstract public class Furniture : RectangleElement
    {
        public int id { get; }

        public string name { get; }

       // public int width { get; }

      //  public int length { get; }

        public int height { get; }

        public string color { get; }

        public string material { get; }

        protected string code;
        public Furniture(int id, string name, int width, int length, int height, string color, string material) : base(width, length)
        {
            base.codeElement = code;
            this.id = id;
            this.name = name;
            this.width = width;
            this.length = length;
            this.height = height;
            this.color = color;
            this.material = material;
        }

        public abstract void addElement(Space space, int x, int y);

        public abstract void removeElement(Space space);


    }
}
