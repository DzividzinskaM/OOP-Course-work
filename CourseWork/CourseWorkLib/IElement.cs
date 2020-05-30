using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    interface IElement
    {
        public bool checkAvailableSpace(Space space, int x, int y);
        public void addElementToSpace(Space space, int xStart, int yStart);

        public void removeElementFromSpace(Space space);

        public void moveUp(Space space, int position);

        public void moveDown(Space space, int position);

        public void moveRight(Space space, int position);

        public void moveLeft(Space space, int position);

        public void turnElement(Space space);

    }
}
