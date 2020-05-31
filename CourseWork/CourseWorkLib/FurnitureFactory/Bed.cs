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
            base.codeElement = CodeElementHelper.BedElement;
            this.type = type;
        }

        public override void addElement(Space space, int x, int y)
        {
            base.addElementToSpace(space, x, y);
            space.beds.Add(this);
        }

        public override void removeElement(Space space)
        {
            base.removeElementFromSpace(space);
            space.beds.Remove(this);
        }
    }
}
