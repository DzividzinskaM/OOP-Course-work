using System;
using CourseWorkLib;
using CourseWorkLib.FurnitureFactory;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using CourseWorkLib.Exception;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            Console.WriteLine("Menu");
            Console.WriteLine("Do you want to create space (Y/N)");
            string answer = Console.ReadLine();
            if(answer == "Y" ||  answer == "y")
            {
                int spaceLength = 0;
                int spaceWidth = 0;
                int spaceHeigh = 0;
                string spaceName;

                Console.Write("Please enter space name ");
                spaceName = Console.ReadLine();
                EnterParametrs("space length", ref spaceLength);

                EnterParametrs("space width", ref spaceWidth);

                EnterParametrs("space height", ref spaceHeigh);
                Space space = new Space(spaceLength, spaceWidth, spaceHeigh, spaceName);

                flag = false;
                while (!flag)
                {
                    Console.WriteLine("Please enter action");
                    Console.WriteLine("\t1. Get list of available element\n\t2.Save space to database \n\t3. Finish work");
                    answer = Console.ReadLine();
                    if (Int32.TryParse(answer, out int result) && result >= 1 && result <= 3)
                    {
                        switch (result)
                        {
                            case 1:
                                chooseElementLst(space);
                                break;
                            case 2:
                                saveAllToDb(space);
                                break;
                            case 3:
                                flag = true;
                                break;
                        }

                    }
                    else
                        showIncorrectAnswer();

                }
            }

        }

        private static void saveAllToDb(Space space)
        {
            try
            {
                space.saveSpace();
                space.saveElementToDB();
            }
            catch(Exception ex)
            {
                showException(ex);
            }
        }

        private static void chooseElementLst(Space space)
        {
            bool flag = false;
            Wall walls = new Wall();
            Door doors = new Door();
            Window windows = new Window();

            ChairCreator chairCreator = new ChairCreator();
            BedCreator bedCreator = new BedCreator();
            WardrobeCreator wardrobeCreator = new WardrobeCreator();

            while (!flag)
            {
                Console.WriteLine("Which list you want to show?");
                Console.WriteLine("\t1. Wall \n\t2.Door \n\t3.Window \n\t4. Chairs \n\t5.Beds \n\t6.Wardrobes \n\t7.Return");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int result) && result >= 1 && result <= 7)
                {
                    switch (result)
                    {
                        case 1:
                            WallWorking(walls, space);
                            break;
                        case 2:
                            DoorWorking(doors, space);
                            break;
                        case 3:
                            WindowWorking(windows, space);
                            break;
                        case 4:
                            ChairWorking(chairCreator, space);
                            break;
                        case 5:
                            BedWorking(bedCreator, space);
                            break;
                        case 6:
                            WardrobeWorking(wardrobeCreator, space);
                            break;
                        case 7:
                            flag = true;
                            break;

                    }
                }
            }

        }

        private static void WardrobeWorking(WardrobeCreator wardrobes, Space space)
        {
            showWardrobeLst(wardrobes.wardrobes);
            while (true)
            {
                Console.Write("Please enter one of list, what you want to add. If you want to return please enter '0' ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int result) && result >= 1)
                {
                    addFurniture(space, result, wardrobes);
                    break;
                }
                else
                    showIncorrectAnswer();
            }
        }

        private static void BedWorking(BedCreator beds, Space space)
        {
            showBedsLst(beds.beds);
            while (true)
            {
                Console.Write("Please enter one of list, what you want to add. If you want to return please enter '0' ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int result) && result >= 1)
                {
                    addFurniture(space, result, beds);
                    break;
                }
                else
                    showIncorrectAnswer();
            }
        }

        private static void ChairWorking(ChairCreator chairs, Space space)
        {
            showChairsLst(chairs.chairs);
            while (true)
            {
                Console.Write("Please enter one of list, what you want to add. If you want to return please enter '0' ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int result) && result >= 1)
                {
                    addFurniture(space, result, chairs);
                    break;
                }
                else
                    showIncorrectAnswer();
            }
        }

        private static void addFurniture(Space space, int result, FurnitureCreator creator)
        {
            try
            {
                Furniture furniture = creator.getElemByID(result);
                int x = 0;
                int y = 0;
                EnterParametrs("x", ref x);
                EnterParametrs("y", ref y);
                furniture.addElement(space, x, y);
                showCurrentSpace(space);
                Console.Write("Do you want to change position of element (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    ChangeFurniturePosition(furniture, space);
                }
            }
            catch (Exception ex)
            {
                showException(ex);
            }
        }

        private static void ChangeFurniturePosition(Furniture furniture, Space space)
        {
            int position = 0;
            string positionName = "position";
            int result = showChangeMenu();
            switch (result)
            {
                case 1:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        furniture.moveRight(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 2:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        furniture.moveLeft(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 3:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        furniture.moveUp(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 4:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        furniture.moveDown(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 5:
                    try
                    {
                        furniture.turnElement(space);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
            }
            showCurrentSpace(space);
            Console.Write("Do you want to change something else(Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
                ChangeFurniturePosition(furniture, space);
            else
                return;
        }

        private static void WindowWorking(Window windows, Space space)
        {
            showWindowLst(windows.windows);
            while (true)
            {
                Console.Write("Please enter one of list, what you want to add. If you want to return please enter '0' ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int result) && result >= 1)
                {
                    addWindow(space, result, windows);
                    break;
                }
                else
                    showIncorrectAnswer();
            }

        }

        private static void addWindow(Space space, int result, Window windows)
        {
            try
            {
                WindowUnit window = windows.getWindowById(result);
                int x = 0;
                int y = 0;
                int z = 0;
                EnterParametrs("x", ref x);
                EnterParametrs("y", ref y);
                EnterParametrs("the installation height", ref z);
                window.addElement(space, x, y, z);
                showCurrentSpace(space);
                Console.Write("Do you want to change position of element (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    ChangeWindowPosition(window, space);
                }
            }
            catch (Exception ex)
            {
                showException(ex);
            }
        }

        private static void ChangeWindowPosition(WindowUnit window, Space space)
        {
            int position = 0;
            string positionName = "position";
            int result = showChangeMenu();
            switch (result)
            {
                case 1:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        window.moveRight(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 2:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        window.moveLeft(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 3:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        window.moveUp(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 4:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        window.moveDown(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 5:
                    try
                    {
                        window.turnElement(space);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
            }
            showCurrentSpace(space);
            Console.Write("Do you want to change something else(Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
                ChangeWindowPosition(window, space);
            else
                return;
        }

        private static void DoorWorking(Door doors, Space space)
        {
            showDoorLst(doors.doors);
            while (true)
            {
                Console.Write("Please enter one of list, what you want to add. If you want to return please enter '0' ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int result) && result >= 1)
                {
                    addDoor(space, result, doors);
                    break;
                }
                else
                    showIncorrectAnswer();
            }
            

        }

        static void addDoor(Space space, int result, Door doors)
        {
            try
            {
                DoorUnit door = doors.getDoorById(result);
                int x = 0;
                int y = 0;
                EnterParametrs("x", ref x);
                EnterParametrs("y", ref y);
                door.addElement(space, x, y);
                showCurrentSpace(space);
                Console.Write("Do you want to change position of element (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    ChangeDoorPosition(door, space);
                }
            }
            catch(Exception ex)
            {
                showException(ex);
            }
        }

        private static void ChangeDoorPosition(DoorUnit door, Space space)
        {
            int position = 0;
            string positionName = "position";
            int result = showChangeMenu();
            switch (result)
            {
                case 1:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        door.moveRight(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 2:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        door.moveLeft(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 3:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        door.moveUp(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 4:
                    try
                    {
                        EnterParametrs(positionName, ref position);
                        door.moveDown(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 5:
                    try
                    {
                        door.turnElement(space);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
            }
            showCurrentSpace(space);
            Console.Write("Do you want to change something else(Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
                ChangeDoorPosition(door, space);
            else
                return;
        }

        static void WallWorking(Wall walls, Space space)
        {
            bool flag = false;
            string incorrectAnswer = "Your answer isn't correct. Please try again";
            showWallLst(walls.walls);
            while (!flag)
            {
                Console.WriteLine("Please enter one of list, what you want to add. If you want to return please enter '0'");
                string answer = Console.ReadLine();
                if(Int32.TryParse(answer, out int result) && result >=0 && result <= walls.walls.Count)
                {
                    if (result == 0)
                        return;
                    bool Inflag = false;
                    while (!Inflag)
                    {
                        Console.WriteLine("Please choose");
                        Console.WriteLine("1. Add border \n2. Add room \n3.Add simple wall \n4.return");
                        answer = Console.ReadLine();
                        if (Int32.TryParse(answer, out int r1) && r1 >= 1 && r1 <= 4)
                        {
                            if (r1 == 1)
                                walls.addOutsideWall(space, result);
                            else if (r1 == 2)
                                addRoom(result, space, walls);
                            else if (r1 == 3)
                                addSimpleWall(result, space, walls);
                            else if (r1 == 4)
                                return;
                            showCurrentSpace(space);
                            return;
                        }
                    }
                    flag = true;
                }
            }
            
           
           
           
        }

        private static void addSimpleWall(int wallId, Space space, Wall walls)
        {
            bool flag = false;
            string incorrectAnswer = "Your answer isn't correct. Please try again";
            int length = 0;
            int x = 0;
            int y = 0;
            string answer;

            while (!flag)
            {
                Console.Write("Enter length ");
                answer = Console.ReadLine();
                if(Int32.TryParse(answer, out int value) && value > 0)
                {
                    length = value;
                    break;
                }
                else
                {
                    Console.WriteLine(incorrectAnswer);
                }
                    
            }

            flag = false;
            while (!flag)
            {
                Console.Write("Enter x ");
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int value) && value > 0)
                {
                    x = value;
                    break;
                }
                else
                    Console.WriteLine(incorrectAnswer);
            }
            while (!flag)
            {
                Console.Write("Enter y ");
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int value) && value > 0)
                {
                    y = value;
                    break;
                }
                else
                    Console.WriteLine(incorrectAnswer);
            }

            try
            {
                WallUnit wall = walls.getElemByID(wallId);
                wall.addElement(space, x, y, length);
                showCurrentSpace(space);
                Console.Write("Do you want to change position of element (Y/N)");
                answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    changeWallPosition(wall, space);
                }
            }
            catch(Exception ex)
            {
                showException(ex);
            }

            

        }

        private static void changeWallPosition(WallUnit wall, Space space)
        {
            string incorrectAnswer = "Your answer isn't correct. Please try again";
            int position = 0;
            string positionStr = "position";
            int result = showChangeMenu();
            switch (result)
            {
                case 1:
                    try
                    {
                        EnterParametrs(positionStr, ref position);
                        wall.moveRight(space, position);
                    }
                    catch(Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 2:
                    try
                    {
                        EnterParametrs(positionStr, ref position);
                        wall.moveLeft(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 3:
                    try
                    {
                        EnterParametrs(positionStr, ref position);
                        wall.moveUp(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 4:
                    try
                    {
                        EnterParametrs(positionStr, ref position);
                        wall.moveDown(space, position);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
                case 5:
                    try
                    {
                        wall.turnElement(space);
                    }
                    catch (Exception ex)
                    {
                        showException(ex);
                    }
                    break;
            }
            showCurrentSpace(space);
            Console.Write("Do you want to change something else(Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
                changeWallPosition(wall, space);
            else
                return;
        }

        private static int showChangeMenu()
        {
            string incorrectAnswer = "Your answer isn't correct. Please try again";
            while (true)
            {
                Console.WriteLine("\t1. Move right \n\t2.Move left \n\t3.Move up \n\t4.Move down \n\t5.Turn element \n\t6.Return");
                string answer = Console.ReadLine();
                if(Int32.TryParse(answer, out int result) && result >=1 && result <= 6)
                {
                    return result;
                }
                else
                    Console.WriteLine(incorrectAnswer);
            }
        }

        static void addRoom(int wallId, Space space, Wall walls)
        {
            int length = 0;
            int width = 0;
            int x = 0;
            int y = 0;
            string answer;

            EnterParametrs("length", ref length);
            EnterParametrs("width", ref width);
            EnterParametrs("x", ref x);
            EnterParametrs("y", ref y);
            try
            {
                walls.addRoom(space, width, length, x, y, wallId);
            }
            catch(Exception ex)
            {
                showException(ex);
            }
            
        }

        static void EnterParametrs(string paramName, ref int value)
        {
            while (true)
            {
                Console.Write($"Enter {paramName} ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int result) && result >= 0)
                {
                    value = result;
                    return;
                }
                else
                    showIncorrectAnswer();
            }
        }
   



        static void showWallLst(List<WallUnit> walls)
        {
            foreach (var wall in walls)
            {
                Console.WriteLine($"\t{wall.id}. Name: {wall.name}");
                Console.WriteLine($"\tDensity: {wall.width}");
                Console.WriteLine($"\tMaterial: {wall.material}");
                Console.WriteLine($"\tColor: {wall.color}");
            }
        }

        private static void showWardrobeLst(List<Wardrobe> wardrobes)
        {
            foreach (var wardrobe in wardrobes)
            {
                Console.WriteLine($"\t{wardrobe.id}Name: {wardrobe.name}");
                Console.WriteLine($"\tWidth: {wardrobe.width}");
                Console.WriteLine($"\tLength: {wardrobe.length}");
                Console.WriteLine($"\tHeight {wardrobe.height}");
                Console.WriteLine($"\tMaterial: {wardrobe.material}");
                Console.WriteLine($"\tColor: {wardrobe.color}");
                Console.WriteLine($"\tNumber of shelf: {wardrobe.shelfNumber}");
                Console.WriteLine($"\tType: {wardrobe.type}");
                Console.WriteLine();
            }
        }

        static void showBedsLst(List<Bed> beds)
        {
            foreach (var bed in beds)
            {
                Console.WriteLine($"\t{bed.id}Name: {bed.name}");
                Console.WriteLine($"\tWidth: {bed.width}");
                Console.WriteLine($"\tLength: {bed.length}");
                Console.WriteLine($"\tHeight {bed.height}");
                Console.WriteLine($"\tMaterial: {bed.material}");
                Console.WriteLine($"\tColor: {bed.color}");
                Console.WriteLine($"\tType: {bed.type}");
                Console.WriteLine();
            }
        }

        static void showChairsLst(List<Chair> chairs)
        {
            foreach (var chair in chairs)
            {
                Console.WriteLine($"\t{chair.id}Name: {chair.name}");
                Console.WriteLine($"\tWidth: {chair.width}");
                Console.WriteLine($"\tLength: {chair.length}");
                Console.WriteLine($"\tHeight {chair.height}");
                Console.WriteLine($"\tMaterial: {chair.material}");
                Console.WriteLine($"\tColor: {chair.color}");
                Console.WriteLine();
            }
        }

        static void showWindowLst(List<WindowUnit> windows)
        {
            foreach (var window in windows)
            {
                Console.WriteLine($"\t\t{window.id}.Name: {window.name}");
                Console.WriteLine($"\t\tWidth: {window.width}");
                Console.WriteLine($"\t\tLength: {window.length}");
                Console.WriteLine($"\t\tHeight {window.height}");
                Console.WriteLine($"\t\tMaterial: {window.material}");
                Console.WriteLine($"\t\tColor: {window.color}");
                Console.WriteLine($"\t\tPattern: {window.pattern}");
                Console.WriteLine($"\t\tParts: {window.parts}");
                Console.WriteLine();
            }
        }

        static void showDoorLst(List<DoorUnit> doors)
        {
            foreach (var door in doors)
            {
                Console.WriteLine($"\t{door.id}.Name: {door.name}");
                Console.WriteLine($"\tWidth: {door.width}");
                Console.WriteLine($"\tLength: {door.length}");
                Console.WriteLine($"\tHeight {door.height}");
                Console.WriteLine($"\tMaterial: {door.material}");
                Console.WriteLine($"\tColor: {door.color}");
                Console.WriteLine();
            }
        }





        static void showCurrentSpace(Space space)
        {
            for(int i = 0; i<space.width; i++)
            {
                for(int j=0; j<space.length; j++)
                {
                    Console.Write($"{space.matrixSpace[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void showException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }


        private static void showIncorrectAnswer()
        {
            string incorrectAnswer = "Your answer isn't correct. Please try again";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(incorrectAnswer);
            Console.ResetColor();
        }

    }

}
