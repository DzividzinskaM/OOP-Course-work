using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CourseWorkLib
{
    public class DB
    {
        private static DB instance;

        private static string name = "SqlProvider";

        public readonly string wallsTableName = "Walls";
        public readonly string wallIdAttrName = "WallID";
        public readonly string materialAttrName = "material";
        public readonly string colorAttrName = "color";
        public readonly string densityAttrName = "density";

        private DB() { }

        public static DB GetDBInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }

        public static string GetConnectionString()
        {

            string returnValue = null;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
