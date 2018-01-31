using System;
using System.Collections.Generic;
using System.IO;

namespace DokuWikiToolBox
{
    class LabelEngine
    {
        public void Run(List<FileObject> fileObjects)
        {
            string tagName;
            string anchorName;
            string anchorTag;

            foreach (FileObject fileObject in fileObjects)
            {
                for (int i = 0; i < fileObject.Lines.Length; i++)
                {
                    if (Checker.IsParagraph(fileObject.Lines[i]))
                    {
                        tagName = Checker.GetChapterName(fileObject.Lines[i]);
                        anchorName = Checker.GetChapterName(fileObject.Lines[i]);
                        anchorTag = "{{tag>" + tagName + "}} {{anchor:" + anchorName + "}}";
                        if (!fileObject.Lines[i].Contains(anchorTag))
                        {
                            fileObject.Lines[i] = fileObject.Lines[i].Replace(fileObject.Lines[i], fileObject.Lines[i] + " " + anchorTag);
                        }
                    }
                }

                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }
    }
}
