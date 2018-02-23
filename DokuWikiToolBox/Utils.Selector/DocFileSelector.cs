using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Model;


namespace Utils.Selector
{
    public class DocFileSelector
    {
        public List<DocObject> SelectDocFile(ref ProgressBar pb)
        {
            pb.Value = 0;
            string outputDir = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output\\";

            var filesToDelete = new List<string>();
            var openFileDialog = new OpenFileDialog();
            var docObjects = new List<DocObject>();

            //Properties of the OpenFileDialog
            openFileDialog.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\";
            openFileDialog.Filter = "Word Documents (*.docx)|*.docx|Word Documents (*.doc)|*.doc|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = ".docx";
            openFileDialog.Multiselect = true;
            openFileDialog.ReadOnlyChecked = false;

            //Adding the files to the list
            if (openFileDialog.ShowDialog() == true)
            {
                double valueIncrement = 100 / openFileDialog.FileNames.Length;
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    //Creating the output directory
                    if (!Directory.Exists(outputDir))
                        Directory.CreateDirectory(outputDir);

                    //Creating a filename and a temp output file
                    string fileName = "TempDocument" + i + ".docx";
                    string outputFile = outputDir + fileName + ".zip";
                    string extractionFolder = outputDir + "ExtractedFile" + i;

                    filesToDelete.Add(outputFile);
                    filesToDelete.Add(extractionFolder);

                    ClearOutput(fileName, outputFile, extractionFolder, i, openFileDialog);
                    ZipFile.ExtractToDirectory(outputFile, extractionFolder);
                    Beautify(extractionFolder);

                    var docObject = new DocObject(new List<string>(), "");
                    ReadXml(extractionFolder, ref docObject);
                    docObjects.Add(docObject);

                    DeleteTempFiles(filesToDelete);

                    pb.Value += valueIncrement;
                }
            }
            return docObjects;
        }

        public void ClearOutput(string fileName, string outputFile, string extractionFolder, int i, OpenFileDialog openFileDialog)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            //Moving the file and changing the extention to .zip
            File.Copy(openFileDialog.FileNames[i], outputFile);

            //If directory already exists, remove
            if (Directory.Exists(extractionFolder))
                Directory.Delete(extractionFolder, true);
        }

        private void Beautify(string extractionFolder)
        {
            //Before we can remove the faulty bytes from the string we need to load the xml document into memory
            string xml;
            using (var reader = new StreamReader(extractionFolder + "\\word\\document.xml"))
            {
                xml = reader.ReadToEnd();
            }

            //Remove hidden bytes in the xml string to avoid errors
            string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (xml.StartsWith(_byteOrderMarkUtf8))
            {
                xml = xml.Remove(0, _byteOrderMarkUtf8.Length - 1);
            }

            var document = new XmlDocument();
            document.Load(extractionFolder + "\\word\\document.xml");

            using (var writer = new XmlTextWriter(extractionFolder + "\\word\\document.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }
        }

        public void ReadXml(string extractionFolder, ref DocObject docObject)
        {
            //which is the xml file that stores the word xml markup
            using (var reader = new StreamReader(extractionFolder + "\\word\\document.xml"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    docObject.Lines.Add(line);
                    reader.Read();
                }
                reader.Close();
            }
        }

        public void DeleteTempFiles(List<string> filesToDelete)
        {
            foreach (string file in filesToDelete)
            {
                if (File.Exists(file))
                    File.Delete(file);
                if (Directory.Exists(file))
                    Directory.Delete(file, true);
            }
        }
    }
}
