using System.Collections.Generic;
using System.IO;

namespace DokuWikiToolBox
{
    class ReplaceEngine
    {
        /// <summary>
        /// StringInjector takes the list of FileObjects, a target and a replacement.
        /// For each FileObject in the list fileObjects it searches in the Lines[i] for a target.
        /// If a fileObject.lines[i] contains a target, the target is replaced in memory with the replacement.
        /// It then goes through a foreach loop of all FileObject in fileObjects and WriteAllLines to the Path and the Lines array.
        /// </summary>
        /// <param name="fileObjects"></param>
        /// <param name="target"></param>
        /// <param name="replacement"></param>
        public void Run(List<FileObject> fileObjects, string target, string replacement)
        {
            foreach (FileObject fileObject in fileObjects)
            {
                //For each line in a Lines array in FileObject
                for (int i = 0; i < fileObject.Lines.Length; i++)
                {
                    //Find your target
                    if (fileObject.Lines[i].Contains(target))
                    {
                        //Replace with set string
                        fileObject.Lines[i] = fileObject.Lines[i].Replace(target, replacement);
                    }
                }
            }
            //Write all changes to disk
            foreach (FileObject fileObject in fileObjects)
            {
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }
    }
}