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

        private int xStartOut = 1;
        private int yStartOut = 1;

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


        public void addOutsideWall(Space space)
        {
            WallUnit rigthWall = this;
            rigthWall.addElement(space, xStartOut, yStartOut, space.length);
            rigthWall.turnElement(space);
            rigthWall.moveRight(space, space.length - density);


            base.width = density;
            WallUnit leftWall = this;
            leftWall.length = space.length - density;
            leftWall.addElement(space, xStartOut, yStartOut, length);
            leftWall.turnElement(space);


            int NewLength = space.length - (2 * density);
            base.width = density;
            WallUnit wallTop = this;
            wallTop.addElement(space, xStartOut, yStartOut + density, NewLength);
            WallUnit wallBottom = this;
            wallBottom.addElement(space, space.length - density + xStartOut, yStartOut, space.length - density);

        }

        public void addRoom(Space space, int width, int length, int x, int y)
        {


            addElement(space, x, y, length);
            addElement(space, x + length - density, y, length);

            int newLength = length - (2 * density);

            //  base.width = density;

            addElement(space, x + density, y, newLength);
            turnElement(space);
            //base.width = density;

            addElement(space, x + density, y + length - density, newLength);
            turnElement(space);

        }

        public void addElement(Space space, int xStart, int yStart, int length)
        {
            base.length = length;
            base.addElementToSpace(space, xStart, yStart);
           // space.walls.Add(this);
        }

        public void removeElement(Space space)
        {
            base.removeElementFromSpace(space);
            space.walls.Remove(this);
        }

    }

}