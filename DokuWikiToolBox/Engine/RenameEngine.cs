using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Model;

namespace Engine
{
    public class RenameEngine
    {
        private const string StartsOrEndsWith = "**";
        private const string PropperHeader = "===";

        public void Run(List<FileObject> fileObjects, int linesInHeader)
        {
            foreach (FileObject fileObject in fileObjects)
            {
                File.Move(fileObject.Path, fileObject.Path.ToLower());
                if (fileObject.Path.Contains(" "))
                {
                    File.Move(fileObject.Path, fileObject.Path.Replace(" ", "-"));
                }
                try
                {
                    for (int i = 0; i < linesInHeader; i++)
                    {
                        if (fileObject.Lines[i].StartsWith(StartsOrEndsWith) ||
                            fileObject.Lines[i].EndsWith(StartsOrEndsWith))
                        {
                            fileObject.Lines[i] = fileObject.Lines[i].Replace(StartsOrEndsWith, PropperHeader);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { fileObject.Lines[linesInHeader + 1] = "HEADER CANNOT BE READ, No closing ** Detected"; }
                catch (Exception) { fileObject.Lines[linesInHeader + 1] = "An Error Occured Here"; }
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }
    }
}
