using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CourseWorkLib.FurnitureFactory;

namespace CourseWorkLib
{
    public class Space
    {
        private int id;
        public string name { get; }
        public int length { get; }
        public int width { get; }
        public int height { get;  }

        public string[,] matrixSpace;

        public List<WallUnit> walls { get; internal set; }
        public List<DoorUnit> doors;
        public List<WindowUnit> windows;
        public List<Bed> beds;
        public List<Chair> chairs;
        public List<Wardrobe> wardrobes;

        private DB db;
        private string connectionString;

        public Space(int width, int length, int height, string name)
        {
            this.name = name;
            if (length>0 && width>0 && height > 0)
            {
                this.length = length;
                this.height = height;
                this.width = width;
            }
            else
            {
                throw new Exception("data isn't correct");
            }

            matrixSpace = new string[width, length];

            for(int i=0; i < width; i++)
            {
                for(int j=0; j<length; j++)
                {
                    matrixSpace[i, j] = CodeElementHelper.emptyElement;
                }
            }

            walls = new List<WallUnit>();
            doors = new List<DoorUnit>();
            windows = new List<WindowUnit>();
            beds = new List<Bed>();
            chairs = new List<Chair>();
            wardrobes = new List<Wardrobe>();

            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();

        }

        public void saveAllToDb()
        {
            saveSpace();
            foreach(var wall in walls)
            {
                saveSpaceWall(wall);
                
            }
            foreach(var door in doors)
            {
                saveSpaceDoor(door);
            }
            foreach(var window in windows)
            {
                saveSpaceWindow(window);
            }
            foreach(var chair in chairs)
            {
                saveSpaceChair(chair);
            }
            foreach(var bed in beds)
            {
                saveSpaceBed(bed);
            }
            foreach(var wardrobe in wardrobes)
            {
                saveSpaceWardrobe(wardrobe);
            }
        }


        public void saveSpace()
        {
            string cmdStr = $"insert into {db.spacesTableName} ({db.spaceLengthAttrName}, {db.spaceWidthAttrName}," +
                $"{db.spaceHeightAttrName}, {db.spaceNameAttrName}) values(@{db.spaceLengthAttrName}, @{db.spaceWidthAttrName}," +
                $"@{db.spaceHeightAttrName}, @{db.spaceNameAttrName})";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);

                cmd.Parameters.AddWithValue($"@{db.spaceLengthAttrName}", length);
                cmd.Parameters.AddWithValue($"@{db.spaceWidthAttrName}", width);
                cmd.Parameters.AddWithValue($"@{db.spaceHeightAttrName}", height);
                cmd.Parameters.AddWithValue($"@{db.spaceNameAttrName}", name);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }
                
            }
            getID();
        }

        private void getID()
        {
            string cmdStr = $"select top(1) {db.spaceIDAttrName} from {db.spacesTableName} where {db.spaceNameAttrName} = '{name}' and " +
                $"{db.spaceLengthAttrName} = {length} and {db.spaceWidthAttrName} = {width} and {db.spaceHeightAttrName} = {height} " +
                $"order by {db.spaceIDAttrName} desc";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                Console.WriteLine(cmd.CommandText);

                id = (int)cmd.ExecuteScalar();
            }
        }

        public void saveSpaceWall(WallUnit wall)
        {

            string cmdStr = $"insert into {db.SpaceWallsTableName} ({db.spaceIDAttrName}, {db.wallIdAttrName}, " +
                $"{db.wallLengthAttrName}, {db.xAttrName}, {db.yAttrName}) values(@{db.spaceIDAttrName}, @{db.wallIdAttrName}, " +
                $"@{db.wallLengthAttrName}, @{db.xAttrName}, @{db.yAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                Console.WriteLine(wall.length);
                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.wallIdAttrName}", wall.id);
                cmd.Parameters.AddWithValue($"@{db.wallLengthAttrName}", wall.length);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", wall.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", wall.y);
                Console.WriteLine(cmd.CommandText);
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }

            }


        }

        public void saveSpaceDoor(DoorUnit door)
        {
            string cmdStr = $"insert into {db.SpaceDoorTableName} ({db.spaceIDAttrName}, {db.doorIdAttrName}, " +
                $"{db.xAttrName}, {db.yAttrName}) values (@{db.spaceIDAttrName}, @{db.doorIdAttrName}, " +
                $"@{db.xAttrName}, @{db.yAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);


                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.doorIdAttrName}", door.id);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", door.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", door.y);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }


            }
        }


        public void saveSpaceWindow(WindowUnit window)
        {
            string cmdStr = $"insert into {db.SpaceWindowsTableName} ({db.spaceIDAttrName}, {db.windowIdAttrName}, " +
                $"{db.xAttrName}, {db.yAttrName}, {db.installationHeightAttrName}) values (@{db.spaceIDAttrName}, @{db.windowIdAttrName}, " +
                $"@{db.xAttrName}, @{db.yAttrName}, @{db.installationHeightAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);


                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.windowIdAttrName}", window.id);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", window.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", window.y);
                cmd.Parameters.AddWithValue($"@{db.installationHeightAttrName}", window.installationHeight);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }


            }
        }

        public void saveSpaceChair(Chair chair)
        {
            string cmdStr = $"insert into {db.SpaceChairsTableName} ({db.spaceIDAttrName}, {db.chairIdAttrName}, " +
                $"{db.xAttrName}, {db.yAttrName}) values (@{db.spaceIDAttrName}, @{db.chairIdAttrName}, " +
                $"@{db.xAttrName}, @{db.yAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);


                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.chairIdAttrName}", chair.id);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", chair.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", chair.y);
               
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }

            }
        }

        public void saveSpaceBed(Bed bed)
        {
            string cmdStr = $"insert into {db.SpaceBedsTableName} ({db.spaceIDAttrName}, {db.bedIdAttrName}, " +
              $"{db.xAttrName}, {db.yAttrName}) values (@{db.spaceIDAttrName}, @{db.bedIdAttrName}, " +
              $"@{db.xAttrName}, @{db.yAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);


                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.bedIdAttrName}", bed.id);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", bed.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", bed.y);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }

            }
        }

        public void saveSpaceWardrobe(Wardrobe wardrobe)
        {
            string cmdStr = $"insert into {db.SpaceWardrobesTableName} ({db.spaceIDAttrName}, {db.WardrobeIDAttrName}, " +
              $"{db.xAttrName}, {db.yAttrName}) values (@{db.spaceIDAttrName}, @{db.chairIdAttrName}, " +
              $"@{db.xAttrName}, @{db.yAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);


                cmd.Parameters.AddWithValue($"@{db.spaceIDAttrName}", id);
                cmd.Parameters.AddWithValue($"@{db.chairIdAttrName}", wardrobe.id);
                cmd.Parameters.AddWithValue($"@{db.xAttrName}", wardrobe.x);
                cmd.Parameters.AddWithValue($"@{db.yAttrName}", wardrobe.y);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }

            }
        }


    }
}
