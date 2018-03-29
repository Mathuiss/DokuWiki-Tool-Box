using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace Utils.Xml
{
    public class XmlParser
    {
        public void WordToDokuwiki(List<DocObject> docObjects)
        {
            int index = 1;
            
            foreach (DocObject doc in docObjects)
            {
                var nodeList = new List<XmlNode>();
                GetNodes(doc, ref nodeList);
                
                WriteNodes(nodeList.ToArray(), index);

                index++;
            }
        }

        static DocObject GetDocObject(string path)
        {
            var docObject = new DocObject();
            docObject.Lines = new List<string>();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    docObject.Lines.Add(line);
                }
                reader.Close();
            }

            docObject.Path = path;
            return docObject;
        }

        static void GetNodes(DocObject doc, ref List<XmlNode> nodeList)
        {
            string[] xml = doc.Lines.ToArray();

            for (int i = 0; i < xml.Length; i++)
            {
                //New node detected
                if (xml[i].Contains("<w:p w") && !xml[i].Contains("/>"))
                {
                    //Create node with type
                    var node = new XmlNode(string.Empty, string.Empty);

                    while (!xml[i].Contains("</w:p>"))
                    {
                        i++;
                        if (xml[i].Contains("<w:pStyle"))
                        {
                            node.Type = GetType(xml[i], "\"");
                        }

                        if (xml[i].Contains("<w:t"))
                        {
                            node.Value += GetValue(xml[i], "<w:t");
                        }
                    }
                    nodeList.Add(node);
                }
            }
        }

        //This method searches for a node type and returns it as a string
        static string GetType(string input, string target)
        {
            if (input.Contains("\""))
            {
                int first = input.IndexOf(target) + 1;
                input = input.Remove(0, first);
                int last = input.LastIndexOf(target);
                input = input.Remove(last, input.Length - last); //Because it's a 0 based array
                return input;

            }
            else
            {
                return "\n";
            }
        }

        //This method searches for a value in the line and returns that value
        static string GetValue(string input, string target)
        {
            char[] line = input.ToCharArray();
            bool hasReadValue = false;
            int first = 0;
            int last = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '>')
                {
                    first = i;
                    hasReadValue = true;
                }
                else if (line[i] == '<' && hasReadValue)
                {
                    last = i;
                    break;
                }
            }

            if (first == 0 || last == 0)
            {
                last = input.Length;
            }

            input = input.Remove(last, input.Length - last); //Because it's a 0 based array
            input = input.Remove(0, first + 1); //+1 To Delete the '>' as well

            return input;
        }

        static void WriteNodes(XmlNode[] nodes, int index)
        {
            string[] values = new string[nodes.Length];
            int numActualLines = 0;

            //Transfering the nodes vall
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = nodes[i].Value;
                if (!values[i].Equals("")) //Appearantly values[2] is null??
                {
                    numActualLines++;
                }
            }

            string outputFolder = "C:\\Users\\" + Environment.UserName + "\\Desktop\\output\\";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string outputFile = outputFolder + "file " + index + " .txt"; //Later make this file names
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            File.WriteAllLines(outputFile, values);
        }
    }
}
