using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace DokuWikiToolBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring the protocol to select and the List with fileObjects
        int protocol;
        List<FileObject> fileObjects = new List<FileObject>();
        List<DocObject> docObjects = new List<DocObject>();
        List<PdfObject> pdfObjects = new List<PdfObject>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uses the FileSelector class to select text files. 
        /// Returns a List with fileObjects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_pickTextFile_Click(object sender, RoutedEventArgs e)
        {
            var textFileSelector = new TextFileSelector();
            fileObjects = textFileSelector.SelectTextFile(ref ProgressBar);
            textFileSelector = null;
        }

        /// <summary>
        /// Uses the FileSelector class to select Doc or Docx files.
        /// Returns a List with fileObjects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_pickDocFile_Click(object sender, RoutedEventArgs e)
        {
            TextBlockConsole.Text = "This operation might take up to several minutes, depending on the size of the documents.";
            var docFileSelector = new DocFileSelector();
            docObjects = docFileSelector.SelectDocFile(ref ProgressBar);
            docFileSelector = null;
            TextBlockConsole.Text = "Operation complete";
        }

        private void Btn_load_pdf_Click(object sender, RoutedEventArgs e)
        {
            TextBlockConsole.Text = "This operation might take up to several minutes, depending on the size of the documents.";
            var pdfFileSelector = new PdfFileSelector();
            pdfObjects = pdfFileSelector.SelectPdfFile();
            pdfFileSelector = null;
            TextBlockConsole.Text = "Operation complete";
        }

        private void Btn_wordToDokuwiki_Click(object sender, RoutedEventArgs e)
        {
            var converter = new XmlParser();
            converter.WordToDokuwiki(docObjects, ref ProgressBar);
            converter = null;
            Process.Start(@"C:\\Users\\" + Environment.UserName + "\\Desktop\\output");
        }

        /// <summary>
        /// By clicking on of the functionalities of the DokuWiki ToolBox
        /// the system selects the corresponding protocol.
        /// The textblock console will display messages corresponding with each protocol.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_replaceFunction_Click(object sender, RoutedEventArgs e)
        {
            protocol = 1;
            TextBlockConsole.Text = "Replace target with replacement.";
        }

        private void Btn_hyperLinkCreator_Click(object sender, RoutedEventArgs e)
        {
            protocol = 2;
            TextBlockConsole.Text = "Find links and creating hyper links.";
        }

        private void Btn_encodingCleanup_Click(object sender, RoutedEventArgs e)
        {
            protocol = 3;
            TextBlockConsole.Text = "Change the encoding to UTF-8.";
        }

        private void Btn_fileNameFunction_Click(object sender, RoutedEventArgs e)
        {
            protocol = 4;
            TextBlockConsole.Text = "Renames the .txr file to dokuwiki  standards and makes the file in doku wiki display the name of the H1. " +
                "Please specify the number of lines that contain the header";
        }

        private void Btn_chapterSplitter_Click(object sender, RoutedEventArgs e)
        {
            protocol = 5;
            TextBlockConsole.Text = "Split all chapters and paragraphs into a tree structure.";
        }

        private void Btn_labelCreator_Click(object sender, RoutedEventArgs e)
        {
            protocol = 6;
            TextBlockConsole.Text = "Finding chapters an paragraphs and creating Label. This needs the label plugin on the server.";
        }

        private void Btn_purge_Click(object sender, RoutedEventArgs e)
        {
            protocol = 7;
            TextBlockConsole.Text = "Replaces everything with the replacement except for the target. Leave replacement empty if you want to purge the text.";
        }

        /// <summary>
        /// When the uses presses launch, the selected protocol will be launched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_launch_Click(object sender, RoutedEventArgs e)
        {
            switch (protocol)
            {
                case 1:
                    var replaceEngine = new ReplaceEngine();
                    replaceEngine.Run(fileObjects, tb_target.Text, tb_replacement.Text);
                    replaceEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                case 2:
                    var hyperLinkEngine = new HyperLinkEngine();
                    hyperLinkEngine.Run(fileObjects);
                    hyperLinkEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                case 3:
                    var encodingCleanEngine = new EncodingCleanEngine();
                    encodingCleanEngine.Run(fileObjects);
                    encodingCleanEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                case 4:
                    var renameEngine = new RenameEngine();
                    int headerSize = 2; //2 Is a standard header size
                    try
                    {
                        headerSize = Convert.ToInt32(tb_target.Text);
                    }
                    catch (Exception ex) { MessageBox.Show("Please enter a number" + ex); }
                    renameEngine.Run(fileObjects, headerSize);
                    renameEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                case 5:
                    var splitEngine = new SplitEngine();
                    splitEngine.Run(fileObjects, tb_target.Text);
                    TextBlockConsole.Text = "Process Complete!";
                    Process.Start(@"C:\\Users\\" + Environment.UserName + "\\Desktop\\output");
                    break;
                case 6:
                    var labelEngine = new LabelEngine();
                    labelEngine.Run(fileObjects);
                    labelEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                case 7:
                    var purgeEngine = new PurgeEngine();
                    purgeEngine.Run(fileObjects, tb_target.Text, tb_replacement.Text);
                    purgeEngine = null;
                    TextBlockConsole.Text = "Process Complete!";
                    break;
                default:
                    TextBlockConsole.Text = "Please select an option.";
                    break;
            }
        }
    }
}
