using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;

namespace DokuWikiToolBox
{
    class RenameEngine
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
                catch (IndexOutOfRangeException iore) { MessageBox.Show("Error: The number of lines in the file was " +
                    "propably smaller than the header you entered \n \n" + iore); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex); }
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }
    }
}
