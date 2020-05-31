using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public class Chair : Furniture
    {  
        public Chair (int id, string name, string color, string material, int width, int length, int height) 
            : base(id, name, width, length, height, color, material)
        {
            base.codeElement = CodeElementHelper.chairElement;
           
        }

        public override void addElement(Space space, int x, int y)
        {
            base.addElementToSpace(space, x, y);
            space.chairs.Add(this);
        }

        public override void removeElement(Space space)
        {
            base.removeElementFromSpace(space);
            space.chairs.Remove(this);
        }
    }
}
