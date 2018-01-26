using System;
using System.Collections.Generic;
using System.IO;

namespace DokuWikiToolBox
{
    class PurgeEngine
    {
        public void Run(List<FileObject> fileObjects, string target, string replacement)
        {
            foreach (FileObject fileObject in fileObjects)
            {
                var lines = new List<string>();

                for (int i = 0; i < fileObject.Lines.Length; i++)
                {
                    if (fileObject.Lines[i].Contains(target))
                    {
                        lines.Add(fileObject.Lines[i]);
                    }
                }
                File.WriteAllLines(fileObject.Path, lines.ToArray());
            }
        }
    }
}