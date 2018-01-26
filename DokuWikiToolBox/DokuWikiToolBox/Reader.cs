using System.IO;

namespace DokuWikiToolBox
{
    class Reader
    {
        public string[] GetRead(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}