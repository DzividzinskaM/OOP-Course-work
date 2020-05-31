using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib
{
    public class CodeElementHelper
    {
        private static CodeElementHelper instance;

        public static string wallElement = "|";
        public static string doorEelement = "D";
        public static string emptyElement = " ";
        public static string windowElement = "W";
        public static string chairElement = "c";
        public static string BedElement = "b";
        public static string WarbdrobeElement = "w";

        private CodeElementHelper() { }

        public static CodeElementHelper GetInstance()
        {
            if (instance == null)
                instance = new CodeElementHelper();
            return instance;
        }
    }
}
