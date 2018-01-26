using System;
using System.Collections.Generic;

namespace DokuWikiToolBox
{
    public class XmlParser
    {
        public void WordToDokuwiki(List<DocObject> docObjects)
        {
            foreach (DocObject doc in docObjects)
            {
                var nodeList = new List<XmlNode>();
                GetNodes(doc, ref nodeList);
            }
        }

        public void GetNodes(DocObject doc, ref List<XmlNode> nodeList)
        {
            string[] xml = doc.Lines.ToArray();

            for (int i = 0; i < xml.Length; i++)
            {
                if (xml[i].Contains("<w:pPr"))
                {
                    if (xml[i + 1].Contains("<w:pStyle"))
                    {
                        Console.WriteLine(GetValue(xml[i + 1], "\""));
                    }
                }
            }
        }

        public string GetValue(string input, string target)
        {
            int first = input.IndexOf(target) + 1;
            input = input.Remove(0, first);
            int last = input.LastIndexOf(target);
            input = input.Remove(last, input.Length - last); //Because it's a 0 based array
            return input;
        }
    }
}
