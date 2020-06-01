using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CourseWorkLib
{
    public class Wall 
    {

        public readonly List<WallUnit> walls = new List<WallUnit>();

        private DB db;
        private string connectionString;

        public Wall()
        {
            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();
        }


        public void addNewElemToDB(WallUnit wall)
        {
            string cmdStr = $"insert into {db.wallsTableName} ({db.nameAttrName}, {db.materialAttrName}, {db.colorAttrName}, {db.densityAttrName})" +
                $"values(@{db.nameAttrName}, @{db.materialAttrName}, @{db.colorAttrName}, @{db.densityAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                cmd.Parameters.AddWithValue($"@{db.nameAttrName}", wall.name);
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", wall.material);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", wall.color);
                cmd.Parameters.AddWithValue($"@{db.densityAttrName}", wall.density);

                int result = cmd.ExecuteNonQuery();
                if(result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }
            }
        }

        public void getLstFromDB()
        {
            string cmdStr = $"select * from {db.wallsTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    WallUnit wallUnit = new WallUnit((int)rd[db.wallIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.colorAttrName],
                                                    (string)rd[db.materialAttrName], (int)rd[db.densityAttrName]);
                    if (!walls.Contains(wallUnit))
                    {
                        walls.Add(wallUnit);
                    }
                }

            }
        }

        public WallUnit getElemByID(int id)
        {
            string cmdStr = $"select * from {db.wallsTableName} where {db.wallIdAttrName} = {id}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                WallUnit unit = null;
                while (rd.Read())
                {
                    unit =  new WallUnit((int)rd[db.wallIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.colorAttrName],
                                                    (string)rd[db.materialAttrName], (int)rd[db.densityAttrName]);
                     
                }
                if(unit == null)
                {
                    throw new Exception("Element with this id isn't find in database");
                }
                return unit;

            }
        }


        public void addOutsideWall(Space space, int id)
        {
            int xStartOut = 1;
            int yStartOut = 1;
            
            WallUnit right = getElemByID(id);
            right.addElement(space, xStartOut, yStartOut, space.length);
            right.turnElement(space);
            right.moveRight(space, space.length - right.density);


            WallUnit left = getElemByID(id);

            left.width = left.density;

            left.length = space.length - left.density;
            left.addElement(space, xStartOut, yStartOut, left.length);
            left.turnElement(space);

            


            WallUnit top = getElemByID(id);
            int NewLength = space.length - (2 * top.density);
            top.width = top.density;
         
            top.length = NewLength;
            top.addElement(space, xStartOut, yStartOut + top.density, top.length);



            WallUnit bottom = getElemByID(id);
            bottom.length = space.length - bottom.density;
            bottom.addElement(space, space.length - top.density + xStartOut, yStartOut, top.length);

           


        }


       
    }
}
