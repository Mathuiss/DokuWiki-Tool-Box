using System.IO;

namespace Utils.Integrity
{
    public class Reader
    {
        public string[] GetRead(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
