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

        public DB db;
        public string connectionString;

        public Wall()
        {
            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();
        }


        public void addNewElemToDB(WallUnit wall)
        {
            string cmdStr = $"insert into {db.wallsTableName} ({db.materialAttrName}, {db.colorAttrName}, {db.densityAttrName})" +
                $"values(@{db.materialAttrName}, @{db.colorAttrName}, @{db.densityAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
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
                    WallUnit wallUnit = new WallUnit((int)rd[db.wallIdAttrName], (string)rd[db.colorAttrName],
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
            return walls.Where(wall => wall.id == id).First();
        }
    }
}
