using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Win32;

namespace DokuWikiToolBox
{
    class TextFileSelector
    {
        public List<FileObject> SelectTextFile(ref ProgressBar pb)
        {
            pb.Value = 0;
            var openFileDialog = new OpenFileDialog();
            var fileObjects = new List<FileObject>();
            var reader = new Reader();

            //Properties of the OpenFileDialog
            openFileDialog.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Multiselect = true;
            openFileDialog.ReadOnlyChecked = false;

            //Adding the files to the FileObject
            if (openFileDialog.ShowDialog() == true)
            {   
                double valueIncrement = 100 / openFileDialog.FileNames.Length;
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    fileObjects.Add(new FileObject(reader.GetRead(openFileDialog.FileNames[i]), openFileDialog.FileNames[i]));
                    pb.Value += valueIncrement;
                }
            }
            return fileObjects;
        }
    }
}
