using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace Engine
{
    public class EncodingCleanEngine
    {
        public void Run(List<FileObject> fileObjects)
        {
            //Attributes that indicate non UTF-8 encoding.
            //Also attributes to replace the non UTF-8 encoded ones with.
            string diaeresis = "Ã«";
            string diaresisRep = "ë";
            string doubleO = "Ã³Ã³";
            string doubleORep = "óó";
            string oDiaresis = "Ã¶";
            string oDiaresisRep = "ö";
            string iDiaresis = "Ã¯";
            string iDiaresisRep = "ï";
            string accoladeOpen = "â€˜";
            string accoladeOpenRep = "'";
            string accoladeClose = "â€™";
            string accoladeCloseRep = "'";
            string aAccent = "Ã¡";
            string aAccentRep = "á";

            foreach (FileObject fo in fileObjects)
            {
                for (int i = 0; i < fo.Lines.Length; i++)
                {
                    //Manipulates string in memory.
                    if (fo.Lines[i].Contains(diaeresis))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(diaeresis, diaresisRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(doubleO))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(doubleO, doubleORep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(oDiaresis))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(oDiaresis, oDiaresisRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(iDiaresis))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(iDiaresis, iDiaresisRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(accoladeOpen))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(accoladeOpen, accoladeOpenRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(accoladeClose))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(accoladeClose, accoladeCloseRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                    else if (fo.Lines[i].Contains(aAccent))
                    {
                        fo.Lines[i] = fo.Lines[i].Replace(aAccent, aAccentRep);
                        Console.WriteLine(fo.Lines[i]);
                    }
                }
            }
            //Write changes to disk.
            foreach (FileObject fileObject in fileObjects)
            {
                File.WriteAllLines(fileObject.Path, fileObject.Lines);
            }
        }
    }
}
