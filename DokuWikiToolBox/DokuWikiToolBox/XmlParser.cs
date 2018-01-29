using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;

namespace DokuWikiToolBox
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
                var xmlTranslator = new XmlTranslator();
                WriteNodes(xmlTranslator.TranslateNodes(nodeList), index);
                index++;
            }
        }

        public void GetNodes(DocObject doc, ref List<XmlNode> nodeList)
        {
            
            string[] xml = doc.Lines.ToArray();

            for (int i = 0; i < xml.Length; i++)
            {
                //New node detected
                if (xml[i].Contains("<w:pPr"))
                {
                    var node = new XmlNode();

                    //Get type H2
                    if (xml[i + 1].Contains("<w:pStyle"))
                    {
                        node.Type = GetType(xml[i + 1], "\"");

                        //Fast forward to value
                        while (!xml[i].Contains("<w:t"))
                        {
                            try { i++; }
                            catch (IndexOutOfRangeException iore) { MessageBox.Show(iore.ToString()); }
                        }

                        if (xml[i].Contains("<w:t"))
                            node.Value = GetValue(xml[i], "<w:t");
                    }

                    nodeList.Add(node);
                }
                else if (xml[i].Contains("<w:rPr"))
                {
                    var node = new XmlNode();

                    //Get type H2
                    if (xml[i + 1].Contains("<w:rFonts"))
                    {
                        node.Type = GetType(xml[i + 1], "\""); //" identifies a type string within xml

                        //Fast forward to value
                        try
                        {
                            while (!xml[i].Contains("<w:t"))
                            {
                                i++;                       
                            }
                        }
                        catch { break; }

                        if (xml[i].Contains("<w:t"))
                            node.Value = GetValue(xml[i], "<w:t");
                    }

                    nodeList.Add(node);
                }
            }
        }

        public string GetType(string input, string target)
        {
            int first = input.IndexOf(target) + 1;
            input = input.Remove(0, first);
            int last = input.LastIndexOf(target);
            input = input.Remove(last, input.Length - last); //Because it's a 0 based array
            return input;
        }

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
                last = input.Length;
                //throw new Exception("Unable to detect node. Missing char '<' or '>'"); //Show Exception Message
            
            input = input.Remove(last, input.Length - last); //Because it's a 0 based array
            input = input.Remove(0, first + 1); //+1 To Delete the '>' as well

            return input;
        }

        public void WriteNodes(XmlNode[] nodes, int index)
        {
            string[] values = new string[nodes.Length];

            //Transfering the nodes vall
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = nodes[i].Value;
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
