using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CourseWorkLib
{
    public class WallUnit : RectangleElement
    {

        public int id { get; }
        public string color { get; }

        public string material { get; }

        public int density { get; }

        private int xStartOut = 1;
        private int yStartOut = 1;

        private string code = "w";


        public WallUnit(int id, string color, string material, int density) : base(density, 0)
        {
            this.id = id;
            this.color = color;
            this.material = material;
            this.density = density;
            base.codeElement = code;

        }

        public WallUnit(string color, string material, int density) : base(density, 0)
        {

            this.color = color;
            this.material = material;
            this.density = density;
            base.codeElement = code;

        }


        public void addOutsideWall(Space space)
        {
            base.length = space.length;
            addWall(space, xStartOut, yStartOut);
            turnWall(space);
            moveRight(space, space.length - density);

            base.length = space.length - density;
            base.width = density;
            addWall(space, xStartOut, yStartOut);
            turnWall(space);

            base.length = space.length - (2 * density);
            base.width = density;
            addWall(space, xStartOut, yStartOut + density);
            base.length = space.length - density;
            addWall(space, space.length - density + xStartOut, yStartOut);

        }

        public void addRoom(Space space, int width, int length, int x, int y)
        {
            base.length = length;
            addWall(space, x, y);
            addWall(space, x + length - density, y);

            int newLength = length - (2 * density);

            base.width = density;
            base.length = newLength;
            addWall(space, x + density, y);
            turnWall(space);
            base.width = density;
            base.length = newLength;
            addWall(space, x + density, y + length - density);
            turnWall(space);

        }

        public void addWall(Space space, int xStart, int yStart)
        {
            Console.WriteLine(length);
            base.addElementToSpace(space, xStart, yStart);
        }

        public void removeWall(Space space)
        {
            base.removeElementFromSpace(space);
        }

        public void moveWallRigth(Space space, int position)
        {
            base.moveRight(space, position);
        }

        public void moveWallLeft(Space space, int position)
        {
            base.moveLeft(space, position);
        }

        public void moveWallToUp(Space space, int position)
        {
            base.moveUp(space, position);
        }

        public void moveWallToDown(Space space, int position)
        {
            base.moveDown(space, position);
        }

        public void turnWall(Space space)
        {
            base.turnElement(space);
        }


    }

}