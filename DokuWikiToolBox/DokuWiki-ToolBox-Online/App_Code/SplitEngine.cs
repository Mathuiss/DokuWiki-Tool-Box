using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/// <summary>
/// Summary description for SplitEngine
/// </summary>
public class SplitEngine
{
    public void Run(List<FileObject> fileObjects, string target)
    {
        string outputPath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output\\chapter.txt";
        string outputDir = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output";

        int chapter = 0;
        int paragraph = 0;

        var writer = new StreamWriter(outputPath);

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        //For each file in the list
        foreach (FileObject fileObject in fileObjects)
        {
            try
            {
                //Use this reader
                using (var reader = new StreamReader(fileObject.Path))
                {
                    bool canCount = false;
                    int counter = 0;

                    //For each line in the file
                    while (!reader.EndOfStream)
                    {
                        //Read line from file
                        string line = reader.ReadLine();

                        //If the line is a target start the counter
                        if (line.Contains(target))
                        {
                            chapter++;
                            paragraph = 1;
                            canCount = true;
                        }

                        if (canCount == true)
                        {
                            counter++;
                        }

                        //If counter is 7 change doutputDir and outputPath
                        if (counter == 7)
                        {
                            //Stop the counter and reset
                            canCount = false;
                            counter = 0;

                            try
                            {
                                outputDir = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output\\" + chapter + "-" + Checker.GetChapterName(line);
                            }
                            catch
                            {
                                outputDir = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output\\" + chapter;
                            }

                            try
                            {
                                outputPath = outputDir + "\\" + Checker.GetChapterName(line) + ".txt";
                            }
                            catch
                            {
                                outputPath = outputDir + "\\" + paragraph + ".txt";
                            }

                            //Dispose off any previous writers
                            if (writer != null)
                            {
                                writer.Dispose();
                                writer = null;
                            }
                        }

                        //If line indicates a paragrap
                        if (Checker.IsParagraph(line))
                        {
                            paragraph++;
                            bool containsInt = line.Any(char.IsDigit);
                            if (containsInt)
                            {
                                try
                                {
                                    outputPath = outputDir + "\\" + Checker.GetChapterName(line) + ".txt";
                                }
                                catch
                                {
                                    outputPath = outputDir + "\\" + paragraph + ".txt";
                                }
                            }
                            else
                            {
                                outputPath = outputDir + "\\" + paragraph + ".txt";
                            }

                            //Dispose of any previous writers
                            if (writer != null)
                            {
                                writer.Dispose();
                                writer = null;
                            }
                        }

                        //If there the writer has been disposed off, make a new writer with the latest outputPath
                        if (writer == null)
                        {
                            if (!Directory.Exists(outputDir))
                            {
                                Directory.CreateDirectory(outputDir);
                            }

                            writer = new StreamWriter(outputPath);
                        }

                        writer.WriteLine(line);
                        line = null;
                    }
                }
            }

            //When all the lines have been read. Dispose off any remaining writers
            finally
            {
                writer.Dispose();
                writer = null;
            }
        }
    }
}