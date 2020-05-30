using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public class Wardrobe : Furniture
    {
        public string type { get; }
        public int shelfNumber { get; }
        public Wardrobe(int id, string name, string material, string color, int width, 
            int length, int height, string type, int shelfNumber)
             : base(id, name, width, length, height, color, material)
        {
            base.codeElement = "W";
            this.type = type;
            this.shelfNumber = shelfNumber;
        }
    }
}
