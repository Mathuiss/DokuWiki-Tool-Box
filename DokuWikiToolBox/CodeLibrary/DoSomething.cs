using System.IO;

namespace CodeLibrary
{
    public class DoSomething
    {
        public void WriteHello()
        {
            string hw = "Hello World!";
            File.WriteAllText("C:\\Users\\Mathuis\\Desktop\\output\\file 1.txt", hw);
        }
    }
}
