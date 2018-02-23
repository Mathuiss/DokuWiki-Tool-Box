using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace Utils.Selector.Web
{
    public class Selector
    {
        public void GetFiles(ref List<FileObject> files, string path)
        {
            string[] lines = File.ReadAllLines(path);
            files.Add(new FileObject(lines, path));
        }
    }
}
