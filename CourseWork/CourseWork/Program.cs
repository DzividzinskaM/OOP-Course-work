using System;
using CourseWorkLib;
using CourseWorkLib.FurnitureFactory;
using System.Configuration;
using System.Data.SqlClient;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Space space = new Space(20, 20, 20);

            WallCreator walls = new WallCreator();
            walls.getWallLstFromDb();

            Wall wall = walls.getWallById(2);
            wall.addOutsideWall(space);
            wall = walls.getWallById(1);
            wall.addRoom(space, 7, 7, 3, 3);

            showCurrentSpace(space, 20, 20);


            WardrobeCreator creator = new WardrobeCreator();
            creator.getLstFromDB();

            foreach(var value in creator.wardrobes)
            {
                Console.WriteLine(value.id);
                Console.WriteLine(value.name);
                Console.WriteLine(value.color);
                Console.WriteLine(value.type);
                Console.WriteLine(value.shelfNumber);
                Console.WriteLine();
            }

            Furniture w1 = creator.getElemByID(1);
            w1.addElement(space, 5, 11);
            showCurrentSpace(space, 20, 20);*/
/*
            Furniture bed = bedCreator.getElemByID(1);
            bed.addElement(space, 5,11);
            Console.WriteLine();
            showCurrentSpace(space, 20, 20);*/

            
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
