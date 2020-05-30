using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public class Bed : Furniture
    {
        public string type;

        public Bed(int id, string name, string material, string color, int width, int length, int height, string type)
              : base(id, name, width, length, height, color, material)
        {
            base.codeElement = "B";
            this.type = type;
        }

    }
}
