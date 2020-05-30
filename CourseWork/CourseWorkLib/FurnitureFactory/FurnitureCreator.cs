using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.FurnitureFactory
{
    public abstract class FurnitureCreator
    {
        //abstract public void create();

        public DB db;
        public string connectionString;

        public FurnitureCreator()
        {
            db = DB.GetDBInstance();
            connectionString = DB.GetConnectionString();
        }

        abstract public void getLstFromDB();


        abstract public Furniture getElemByID(int id);

        
       
    }
}
