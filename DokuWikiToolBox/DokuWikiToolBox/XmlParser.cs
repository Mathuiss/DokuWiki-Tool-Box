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
                //New node detected
                if (xml[i].Contains("<w:pPr"))
                {
                    var node = new XmlNode();

                    //Get type
                    if (xml[i + 1].Contains("<w:pStyle"))           //TODO: Test This
                    {
                        node.Type = GetType(xml[i + 1], "\"");

                        //Fast forward to value
                        while (!xml[i].Contains("<w:t"))
                        {
                            i++;
                        }

                        if (xml[i].Contains("<w:t"))
                            node.Value = GetValue(xml[i], "<w:t");
                    }
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
                throw new Exception();

            input = input.Remove(0, first);
            input = input.Remove(last, input.Length - last); //Because it's a 0 based array

            return input;
        }
    }
}
