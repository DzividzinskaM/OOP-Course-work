using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CourseWorkLib
{
    public class Door
    {
        public readonly List<DoorUnit> doors = new List<DoorUnit>();
        public DB db;
        public string connectionString;

        public Door()
        {
            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();
        }

        public void getDoorLstFromDB()
        {
            string cmdStr = $"select * from {db.doorsTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    DoorUnit door = new DoorUnit((int)rd[db.doorIdAttrName], (string)rd[db.materialAttrName], (int)rd[db.doorWidthAttrName],
                        (int)rd[db.doorLengthAttrName], (int)rd[db.doorHeightAttrName], (string)rd[db.colorAttrName]);

                    if (!doors.Contains(door))
                        doors.Add(door);
                }
            }
        }


        public DoorUnit getDoorById(int id)
        {
            return doors.Where(door => door.id == id).First();
        }

        public void addNewDoorToDB(DoorUnit door)
        {
            string cmdStr = $"insert into {db.doorsTableName} ({db.materialAttrName}, {db.doorWidthAttrName}," +
                $"{db.doorLengthAttrName}, {db.doorHeightAttrName}, {db.colorAttrName}) values(@{db.materialAttrName}, " +
                $"@{db.doorWidthAttrName}, @{db.doorLengthAttrName}, @{db.doorHeightAttrName}, @{db.colorAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", door.material);
                cmd.Parameters.AddWithValue($"@{db.doorWidthAttrName}", door.width);
                cmd.Parameters.AddWithValue($"@{db.doorLengthAttrName}", door.length);
                cmd.Parameters.AddWithValue($"@{db.doorHeightAttrName}", door.height);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", door.color);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }

            }
        }
    }
}
