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
        public readonly string doorsTableName = "Doors";
        public readonly string windowsTableName = "Windows";
        public readonly string chairTableName = "Chairs";
        public readonly string bedsTableName = "Beds";
        public readonly string WardrobesTableName = "Wardrobes";

        public readonly string wallIdAttrName = "WallID";
        public readonly string materialAttrName = "material";
        public readonly string colorAttrName = "color";
        public readonly string densityAttrName = "density";
        public readonly string nameAttrName = "name";
        public readonly string doorIdAttrName = "DoorID";
        public readonly string doorWidthAttrName = "doorWidth";
        public readonly string doorLengthAttrName = "doorLength";
        public readonly string doorHeightAttrName = "doorHeight";
        public readonly string windowIdAttrName = "WindowID";
        public readonly string windowWidthAttrName = "windowWidth";
        public readonly string windowLengthAttrName = "windowLength";
        public readonly string windowHeightAttrName = "windowHeight";
        public readonly string patternAttrName = "pattern";
        public readonly string partsAttrName = "parts";
        public readonly string chairIdAttrName = "ChairID";
        public readonly string chairLengthAttrName = "chairLength";
        public readonly string chairWidthAttrName = "chairWidth";
        public readonly string chairHeightAttrName = "chairHeight";
        public readonly string bedIdAttrName = "BedID";
        public readonly string bedLengthAttrName = "bedLength";
        public readonly string bedWidthAttrName = "bedWidth";
        public readonly string bedHeightAttrName = "bedHeight";
        public readonly string bedTypeAttrName = "bedType";
        public readonly string WardrobeIDAttrName = "WardrobeID";
        public readonly string WardrobeWidthAttrName = "WardrobeWidth";
        public readonly string WardrobeLengthAttrName = "WardrobeLength";
        public readonly string WardrobeHeightAttrName = "WardrobeHeight";
        public readonly string WardrobeTypeAttrName = "WardrobeType";
        public readonly string shelfNumberAttrName = "shelfNumber";


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
