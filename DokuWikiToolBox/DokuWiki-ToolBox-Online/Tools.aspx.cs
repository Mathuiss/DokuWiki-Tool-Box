using System;
using System.Collections.Generic;

public partial class Tools : System.Web.UI.Page
{
    //Declaring the protocol to select and the List with fileObjects
    private int protocol;

    List<FileObject> fileObjects = new List<FileObject>();
    List<DocObject> docObjects = new List<DocObject>();
    List<PdfObject> pdfObjects = new List<PdfObject>();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_LoadTextFile_Click(object sender, EventArgs e)
    {
        var textFileSelector = new TextFileSelector();
        fileObjects = textFileSelector.SelectTextFile(ref ProgressBar);
        textFileSelector = null;
    }

    protected void Btn_LoadWordDocument_Click(object sender, EventArgs e)
    {
        TextBlockConsole.Text = "This operation might take up to several minutes, depending on the size of the documents.";
        var docFileSelector = new DocFileSelector();
        docObjects = docFileSelector.SelectDocFile(ref ProgressBar);
        docFileSelector = null;
        TextBlockConsole.Text = "Operation complete";
    }

    protected void Btn_LoadPdf_Click(object sender, EventArgs e)
    {
        TextBlockConsole.Text = "This operation might take up to several minutes, depending on the size of the documents.";
        var pdfFileSelector = new PdfFileSelector();
        pdfObjects = pdfFileSelector.SelectPdfFile();
        pdfFileSelector = null;
        TextBlockConsole.Text = "Operation complete";
    }

    protected void Btn_WordToDokuWiki_Click(object sender, EventArgs e)
    {
        var converter = new XmlParser();
        converter.WordToDokuwiki(docObjects, ref ProgressBar);
        converter = null;
        Process.Start(@"C:\\Users\\" + Environment.UserName + "\\Desktop\\output");
    }

    protected void Btn_ReplaceFunction_Click(object sender, EventArgs e)
    {
        protocol = 1;
        TextBlockConsole.Text = "Replace target with replacement.";
    }

    protected void Btn_HyperLinkCreator_Click(object sender, EventArgs e)
    {
        protocol = 2;
        TextBlockConsole.Text = "Find links and creating hyper links.";
    }

    protected void Btn_EncodingCleanup_Click(object sender, EventArgs e)
    {
        protocol = 3;
        TextBlockConsole.Text = "Change the encoding to UTF-8.";
    }


    protected void Btn_FileNameCorrection_Click(object sender, EventArgs e)
    {
        protocol = 4;
        TextBlockConsole.Text = "Renames the .txt file to dokuwiki  standards and makes the file in doku wiki display the name of the header. " +
        "Please specify the number of lines that contain the header";
    }

    protected void Btn_ChapterSplitter_Click(object sender, EventArgs e)
    {
        protocol = 5;
        TextBlockConsole.Text = "Split all chapters and paragraphs into a tree structure.";
    }

    protected void Btn_LabelCreator_Click(object sender, EventArgs e)
    {
        protocol = 6;
        TextBlockConsole.Text = "Finding chapters an paragraphs and creating Label. This requires the label plugin on the server.";
    }


protected void Btn_Purge_Click(object sender, EventArgs e)
    {
        protocol = 7;
        TextBlockConsole.Text = "Replaces everything with the replacement except for the target. Leave replacement empty if you want to purge the text.";
    }

    protected void Btn_Launch_Click(object sender, EventArgs e)
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