using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CourseWorkLib.Exception;

namespace CourseWorkLib.FurnitureFactory
{
    public class ChairCreator : FurnitureCreator
    {
        public readonly List<Chair> chairs = new List<Chair>();
       
        public ChairCreator()
        {
            getLstFromDB();
        }
        public override void getLstFromDB()
        {
            string cmdStr = $"select * from {db.chairTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    
                    Chair chair = new Chair((int)rd[db.chairIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.colorAttrName],
                        (string)rd[db.materialAttrName], (int)rd[db.chairWidthAttrName], (int)rd[db.chairLengthAttrName], (int)rd[db.chairHeightAttrName]);
                    if (!chairs.Contains(chair))
                        chairs.Add(chair);
                }
            }
        }

        public override Furniture getElemByID(int id)
        {
            string cmdStr = $"select * from {db.chairTableName} where {db.chairIdAttrName} = {id}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                Chair chair = null;
                while (rd.Read())
                {
                    chair = new Chair((int)rd[db.chairIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.colorAttrName],
                        (string)rd[db.materialAttrName], (int)rd[db.chairWidthAttrName], (int)rd[db.chairLengthAttrName], (int)rd[db.chairHeightAttrName]);
                    
                }
                if (chair == null)
                {
                    throw new DesignSpaceException("Element with this id isn't find in database");
                }
                return chair;
            }
        }


        public void addNewElemToDB(Chair chair)
        {
            string cmdStr = $"insert into {db.chairTableName} ({db.nameAttrName}, {db.colorAttrName}, {db.materialAttrName}, {db.chairWidthAttrName}," +
                $"{db.chairHeightAttrName}, {db.chairLengthAttrName}) values(@{db.nameAttrName}, @{db.colorAttrName}, @{db.materialAttrName}, " +
                $"@{db.chairWidthAttrName}, @{db.chairHeightAttrName}, @{db.chairLengthAttrName})";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);

                cmd.Parameters.AddWithValue($"@{db.nameAttrName}", chair.name);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", chair.color);
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", chair.material);
                cmd.Parameters.AddWithValue($"@{db.chairLengthAttrName}", chair.length);
                cmd.Parameters.AddWithValue($"@{db.chairWidthAttrName}", chair.width);
                cmd.Parameters.AddWithValue($"@{db.chairHeightAttrName}", chair.height);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new DesignSpaceException("there are some problems with adding wall to database");
                }
            }

            getLstFromDB();
        }
    }
}
