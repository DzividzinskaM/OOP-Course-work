using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CourseWorkLib
{
    public class Window
    {
        public readonly List<WindowUnit> windows = new List<WindowUnit>();
        public DB db;
        public string connectionString;

        public Window()
        {
            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();
        }

        public void getWindowLstFromDB()
        {
            string cmdStr = $"select * from {db.windowsTableName}";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    bool pattern = false;
                    if ((bool)rd[db.patternAttrName])
                        pattern = true;
                    WindowUnit window = new WindowUnit((int)rd[db.windowIdAttrName], (string)rd[db.colorAttrName],
                        (string)rd[db.materialAttrName], (int)rd[db.windowWidthAttrName], (int)rd[db.windowLengthAttrName],
                        (int)rd[db.windowHeightAttrName], pattern, (int)rd[db.partsAttrName]);

                    if (!windows.Contains(window))
                        windows.Add(window);
                }
            }
        }

        public WindowUnit getWindowById(int id)
        {
            return windows.Where(window => window.id == id).First();
        }

        public void addNewWindowToDB(WindowUnit window)
        {
            string cmdStr = $"insert into {db.windowsTableName} ({db.materialAttrName}, {db.colorAttrName}," +
                $"{db.windowWidthAttrName}, {db.windowLengthAttrName}, {db.windowHeightAttrName}, {db.patternAttrName}," +
                $"{db.partsAttrName}) values( @{db.materialAttrName}, @{db.colorAttrName}," +
                $"@{db.windowWidthAttrName}, @{db.windowLengthAttrName}, @{db.windowHeightAttrName}, @{db.patternAttrName}," +
                $"@{db.partsAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", window.material);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", window.color);
                cmd.Parameters.AddWithValue($"@{db.windowWidthAttrName}", window.width);
                cmd.Parameters.AddWithValue($"@{db.windowLengthAttrName}", window.length);
                cmd.Parameters.AddWithValue($"@{db.windowHeightAttrName}", window.height);
                if (window.pattern)
                    cmd.Parameters.AddWithValue($"@{db.patternAttrName}", 1);
                else
                    cmd.Parameters.AddWithValue($"@{db.patternAttrName}", 0);
                cmd.Parameters.AddWithValue($"@{db.partsAttrName}", window.parts);
               
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }
            }
        }

    }
}
