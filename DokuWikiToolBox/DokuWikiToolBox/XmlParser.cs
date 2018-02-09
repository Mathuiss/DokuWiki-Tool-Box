using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DokuWikiToolBox
{
    public class XmlParser
    {
        public void WordToDokuwiki(List<DocObject> docObjects, ref ProgressBar pb)
        {
            pb.Value = 0;
            int index = 1;

            double valueIncrement = 100 / docObjects.Count;
            foreach (DocObject doc in docObjects)
            {
                var nodeList = new List<XmlNode>();
                GetNodes(doc, ref nodeList);

                var xmlTranslator = new XmlTranslator();
                WriteNodes(xmlTranslator.TranslateNodes(nodeList), index);
                
                index++;
                pb.Value += valueIncrement;
            }
        }

        public void GetNodes(DocObject doc, ref List<XmlNode> nodeList)
        {

            string[] xml = doc.Lines.ToArray();

            for (int i = 0; i < xml.Length; i++)
            {
                //New node detected
                if ((xml[i].Contains("<w:rPr") || xml[i].Contains("<w:pPr")) && !xml[i + 1].Contains("<w:rPr"))
                {
                    //Create node with type
                    var node = new XmlNode(GetType(xml[i + 1], "\""), "");

                    //Fast forward to value
                    while ((!xml[i].Contains("<w:t") && i < xml.Length - 1) || xml[i].Contains("<w:tab"))
                    {
                        i++;
                    }

                    //Check if the node should be on the same line as the next node
                    if (xml[i].Contains("<w:t") && xml[i].Contains("=\"preserve\""))
                        node.Type = GetType(xml[i], "\"");

                    //Add the value
                    node.Value = GetValue(xml[i], "<w:t");

                    nodeList.Add(node);
                }
            }
        }

        //This method searches for a node type and returns it as a string
        public string GetType(string input, string target)
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
        public string GetValue(string input, string target)
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

        public void WriteNodes(XmlNode[] nodes, int index)
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
