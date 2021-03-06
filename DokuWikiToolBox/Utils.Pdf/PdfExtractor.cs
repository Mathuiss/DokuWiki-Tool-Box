﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Model;

namespace Utils.Pdf
{
    public class PdfExtractor
    {
        public List<PdfObject> Read(string[] fileNames)
        {
            var pdfObjects = new List<PdfObject>();
            for (int i = 0; i < fileNames.Length; i++)
            {
                try
                {
                    using (var reader = new StreamReader(fileNames[i], Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
            return pdfObjects;
        }
    }
}
