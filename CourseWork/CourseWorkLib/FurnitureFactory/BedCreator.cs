using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public class BedCreator : FurnitureCreator
    {
        public readonly List<Bed> beds = new List<Bed>();

        public override void getLstFromDB()
        {
            string cmdStr = $"select * from {db.bedsTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                   
                    Bed bed = new Bed((int)rd[db.bedIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.materialAttrName],
                        (string)rd[db.colorAttrName], (int)rd[db.bedWidthAttrName], (int)rd[db.bedLengthAttrName],
                        (int)rd[db.bedHeightAttrName], (string)rd[db.bedTypeAttrName]);
                
                    if (!beds.Contains(bed))
                        beds.Add(bed);

                }
            }
        }
        public override Furniture getElemByID(int id)
        {
            string cmdStr = $"select * from {db.bedsTableName} where {db.bedIdAttrName} = {id}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                Bed bed = null;
                while (rd.Read())
                {
                    bed = new Bed((int)rd[db.bedIdAttrName], (string)rd[db.nameAttrName], (string)rd[db.materialAttrName],
                        (string)rd[db.colorAttrName], (int)rd[db.bedWidthAttrName], (int)rd[db.bedLengthAttrName],
                        (int)rd[db.bedHeightAttrName], (string)rd[db.bedTypeAttrName]);

                }
                if (bed == null)
                {
                    throw new Exception("Element with this id isn't find in database");
                }
                return bed;
            }
        }


        public void addNewElemToDB(Bed bed)
        {
            string cmdStr = $"insert into {db.bedsTableName} ({db.nameAttrName}, {db.colorAttrName}, {db.materialAttrName}, {db.bedWidthAttrName}," +
                $"{db.bedHeightAttrName}, {db.bedLengthAttrName}, {db.bedTypeAttrName}) values(@{db.nameAttrName}, @{db.colorAttrName}," +
                $" @{db.materialAttrName}, @{db.bedWidthAttrName}, @{db.bedHeightAttrName}, @{db.bedLengthAttrName}, @{db.bedTypeAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);

                cmd.Parameters.AddWithValue($"@{db.nameAttrName}", bed.name);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", bed.color);
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", bed.material);
                cmd.Parameters.AddWithValue($"@{db.bedLengthAttrName}", bed.length);
                cmd.Parameters.AddWithValue($"@{db.bedWidthAttrName}", bed.width);
                cmd.Parameters.AddWithValue($"@{db.bedHeightAttrName}", bed.height);
                cmd.Parameters.AddWithValue($"@{db.bedTypeAttrName}", bed.type);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }
            }
        }


    }
}
