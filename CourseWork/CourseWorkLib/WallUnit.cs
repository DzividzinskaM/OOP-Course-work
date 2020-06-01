using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CourseWorkLib
{
    public class WallUnit : RectangleElement
    {

        public int id { get; }

        public string name { get; }
        public string color { get; }

        public string material { get; }

        public int density { get; }

        private string code = CodeElementHelper.wallElement;

        public WallUnit(int id, string name, string color, string material, int density) : base(density, 0)
        {
         
            this.id = id;
            this.name = name;
            this.color = color;
            this.material = material;
            this.density = density;
            base.codeElement = code;

        }

        public WallUnit(string name, string color, string material, int density) : base(density, 0)
        {
            this.name = name;
            this.color = color;
            this.material = material;
            this.density = density;
            base.codeElement = code;

        }

     

        public void addElement(Space space, int xStart, int yStart, int length)
        {
            base.length = length;
            base.addElementToSpace(space, xStart, yStart);
            space.walls.Add(this);

        }

        public void removeElement(Space space)
        {
            base.removeElementFromSpace(space);
            space.walls.Remove(this);
        }

    }

}