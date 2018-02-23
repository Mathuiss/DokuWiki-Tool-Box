using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using Model;

namespace Engine
{
    public class HyperLinkEngine
    {
        public void Run(List<FileObject> fileObjects)
        {
            //Regex indicating hyper link presence
            string pattern = @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            string noRun1 = "[[";
            string noRun2 = "]]";

            foreach (FileObject fileObject in fileObjects)
            {
                for (int i = 0; i < fileObject.Lines.Length; i++)
                {
                    //If a hyper link is found, replace line with [[ + line + ]]
                    if (Regex.IsMatch(fileObject.Lines[i], pattern) || fileObject.Lines[i].Contains("http"))
                    {
                        //If a hyper link already contains [[ and ]]
                        if (fileObject.Lines[i].Contains(noRun1) && fileObject.Lines[i].Contains(noRun2))
                        {
                            //Removes faulty links
                            if (fileObject.Lines[i].Contains("[[//") || fileObject.Lines[i].Contains("//]]"))
                            {
                                fileObject.Lines[i] = fileObject.Lines[i].Replace("[[//", "[[");
                                fileObject.Lines[i] = fileObject.Lines[i].Replace("//]]", "]]");
                            }
                            //Do nothing
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            fileObject.Lines[i] = fileObject.Lines[i].Replace(fileObject.Lines[i], "[[" + fileObject.Lines[i] + "]]");
                        }
                    }
                }
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }

        public void Remove(List<FileObject> fileObjects)
        {
            string run1 = "[[";
            string run2 = "]]";

            foreach (FileObject fileObject in fileObjects)
            {
                for (int i = 0; i < fileObject.Lines.Length; i++)
                {
                    //If a hyper link already contains [[ and ]]
                    if (fileObject.Lines[i].Contains(run1) && fileObject.Lines[i].Contains(run2))
                    {
                        fileObject.Lines[i] = fileObject.Lines[i].Replace(run1, "");
                        fileObject.Lines[i] = fileObject.Lines[i].Replace(run2, "");
                    }
                }
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }

        //##################### Advanced HyperLink Proto ##################################

        ////For unequal "//" and http://
        //if (fileObject.Lines[i].Contains("//"))
        //{
        //    if (fileObject.Lines[i].Contains("http"))
        //    {
        //        if (!fileObject.Lines[i].Contains("[[") && !fileObject.Lines[i].Contains("]]"))
        //        {
        //            char[] letters = fileObject.Lines[i].ToCharArray();
        //            int counter = 0;
        //            int firstPos = 0;
        //            int position = 0;

        //            for (int j = 0; j < letters.Length - 1; j++)
        //            {
        //                if (letters[j + 1] == '/' && letters[j] == '/')
        //                {
        //                    counter++;
        //                    position = j;
        //                    if (firstPos == 0)
        //                        firstPos = j;
        //                }
        //            }

        //            if (counter % 2 != 0)
        //            {
        //                position += 2;
        //                fileObject.Lines[i] = fileObject.Lines[i].Insert(position, "]]");
        //                firstPos -= 1;
        //                if (counter > 1)
        //                    fileObject.Lines[i] = fileObject.Lines[i].Insert(firstPos, "[[" + fileObject.Lines[i]);
        //                else
        //                    fileObject.Lines[i] = fileObject.Lines[i].Replace(fileObject.Lines[i], "[[" + fileObject.Lines[i]);
        //            }
        //        }
        //    }
        //}
    }
}
