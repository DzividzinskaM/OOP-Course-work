using System;
using CourseWorkLib;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Space space = new Space(20, 20, 20);
            showCurrentSpace(space, 20, 20);
            RectangleElement element = new RectangleElement(5, 7);
            element.addElementToSpace(space, 15, 5);
            Console.WriteLine("after adding");
            showCurrentSpace(space, 20, 20);
            Console.WriteLine();

            Console.WriteLine("turn element");
            element.turnElement(space);
            showCurrentSpace(space, 20, 20);
            Console.WriteLine();


            Console.WriteLine("after move up");
             element.moveUp(space, 3);
            //element.moveDown(space, 2);
            showCurrentSpace(space, 20, 20);
            Console.WriteLine();

            

           /* Console.WriteLine("after move down");
            element.moveDown(space, 15);
            showCurrentSpace(space, 20, 20);
            Console.WriteLine();

            Console.WriteLine("after move right");
            element.moveRight(space, 14);
            showCurrentSpace(space, 20, 20);

            Console.WriteLine("after move left");
            element.moveLeft(space, 18);
            showCurrentSpace(space, 20, 20);

            element.removeElementFromSpace(space);
            Console.WriteLine("after remove");
            showCurrentSpace(space, 20, 20);
*/

        }

        static void showCurrentSpace(Space space, int width, int length)
        {
            for(int i = 0; i<width; i++)
            {
                for(int j=0; j<length; j++)
                {
                    Console.Write($"{space.matrixSpace[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }

}
