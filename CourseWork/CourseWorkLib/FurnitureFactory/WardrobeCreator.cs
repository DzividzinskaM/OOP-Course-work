using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public class WardrobeCreator : FurnitureCreator
    {
        public readonly List<Wardrobe> wardrobes = new List<Wardrobe>();
        public override void getLstFromDB()
        {
            string cmdStr = $"select * from {db.WardrobesTableName}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {

                    Wardrobe wardrobe = new Wardrobe((int)rd[db.WardrobeIDAttrName], (string)rd[db.nameAttrName], (string)rd[db.materialAttrName],
                        (string)rd[db.colorAttrName], (int)rd[db.WardrobeWidthAttrName], (int)rd[db.WardrobeLengthAttrName],
                        (int)rd[db.WardrobeHeightAttrName], (string)rd[db.WardrobeTypeAttrName], (int)rd[db.shelfNumberAttrName]);

                    if (!wardrobes.Contains(wardrobe))
                        wardrobes.Add(wardrobe);

                }
            }
        }
        public override Furniture getElemByID(int id)
        {
            string cmdStr = $"select * from {db.WardrobesTableName} where {db.WardrobeIDAttrName} = {id}";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                Wardrobe wardrobe = null;
                while (rd.Read())
                {

                    wardrobe = new Wardrobe((int)rd[db.WardrobeIDAttrName], (string)rd[db.nameAttrName], (string)rd[db.materialAttrName],
                        (string)rd[db.colorAttrName], (int)rd[db.WardrobeWidthAttrName], (int)rd[db.WardrobeLengthAttrName],
                        (int)rd[db.WardrobeHeightAttrName], (string)rd[db.WardrobeTypeAttrName], (int)rd[db.shelfNumberAttrName]);

                }

                if (wardrobe == null)
                {
                    throw new Exception("Element with this id isn't find in database");
                }
                return wardrobe;
            }
        }

        public void addNewElemToDB(Wardrobe wardrobe)
        {
            string cmdStr = $"insert into {db.WardrobesTableName} ({db.nameAttrName}, {db.colorAttrName}, {db.materialAttrName}, {db.WardrobeWidthAttrName}," +
                $"{db.WardrobeHeightAttrName}, {db.WardrobeLengthAttrName}, {db.WardrobeTypeAttrName}, {db.shelfNumberAttrName})" +
                $" values(@{db.nameAttrName}, @{db.colorAttrName}, @{db.materialAttrName}, @{db.WardrobeWidthAttrName}," +
                $" @{db.WardrobeHeightAttrName}, @{db.WardrobeLengthAttrName}, @{db.WardrobeTypeAttrName}, @{db.shelfNumberAttrName})";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, cn);

                cmd.Parameters.AddWithValue($"@{db.nameAttrName}", wardrobe.name);
                cmd.Parameters.AddWithValue($"@{db.colorAttrName}", wardrobe.color);
                cmd.Parameters.AddWithValue($"@{db.materialAttrName}", wardrobe.material);
                cmd.Parameters.AddWithValue($"@{db.WardrobeLengthAttrName}", wardrobe.length);
                cmd.Parameters.AddWithValue($"@{db.WardrobeWidthAttrName}", wardrobe.width);
                cmd.Parameters.AddWithValue($"@{db.WardrobeHeightAttrName}", wardrobe.height);
                cmd.Parameters.AddWithValue($"@{db.WardrobeTypeAttrName}", wardrobe.type);
                cmd.Parameters.AddWithValue($"@{db.shelfNumberAttrName}", wardrobe.shelfNumber);

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("there are some problems with adding wall to database");
                }
            }
        }


    }
}
