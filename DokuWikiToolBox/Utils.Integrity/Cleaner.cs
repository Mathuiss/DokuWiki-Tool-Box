using System;
using System.IO;

namespace Utils.Integrity
{
    public class Cleaner
    {
        public void CleanFiles()
        {
            if (File.Exists("~/Output/file.txt"))
            {
                File.Delete("~/Output/file.txt");
            }
        }
    }
}
