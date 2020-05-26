using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class Wall {

        private bool outsideStandardWall = false;

        private int wallOtsideWidth = 2;

        private int wallInsideWidth = 1;

        private int xStart = 1;
        private int yStart = 1;
        public void addOutsideWall(Space space)
        {
            UnitWall sideUnit = new UnitWall(space.length, space.height, wallOtsideWidth);
            sideUnit.turnWall(space);
            sideUnit.addWall(space, xStart, space.length - yStart);


            int lengthMainWall = space.length - (2 * wallOtsideWidth);
            int yForMainWall = sideUnit.width + 1;
            int xForMainWall = space.width - wallOtsideWidth;
            UnitWall mainUnit = new UnitWall(lengthMainWall , space.height, wallOtsideWidth);
            mainUnit.addWall(space, xStart, yForMainWall);
            mainUnit.moveWallToDown(space, xForMainWall);
            mainUnit.addWall(space, xStart, yForMainWall);

            outsideStandardWall = true;

        }

        public void addRoom(Space space, int width, int length, int x, int y)
        {
            if (Math.Abs(x - wallInsideWidth) <= wallInsideWidth)
            {
                throw new Exception("too small size of room");
            }

            UnitWall mainUnits = new UnitWall(length, space.height, wallInsideWidth);
            mainUnits.addWall(space, x, y);
            mainUnits.addWall(space, x + length-wallInsideWidth, y);

            int newLength = length - (2 * wallInsideWidth);
            UnitWall sideUnits = new UnitWall(newLength, space.height, wallInsideWidth);
            sideUnits.addWall(space, x+wallInsideWidth, y);
            sideUnits.turnWall(space);
            sideUnits.addWall(space, x + wallInsideWidth, y + length-wallInsideWidth);

        }

    }
}
