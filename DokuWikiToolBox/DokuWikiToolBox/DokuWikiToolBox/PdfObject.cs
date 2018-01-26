using iTextSharp.text.pdf;

namespace DokuWikiToolBox
{
    struct PdfObject
    {
        private string[] lines;
        private string path;

        public PdfObject(string[] lines, string path)
        {
            this.lines = lines;
            this.path = path;
        }

        public string[] Lines { get => lines; set => lines = value; }
        public string Path { get => path; set => path = value; }
    }
}