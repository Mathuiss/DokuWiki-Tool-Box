﻿using System.Collections.Generic;
using Model;

namespace Utils.Xml
{
    public class XmlTranslator
    {
        public XmlNode[] TranslateNodes(List<XmlNode> nodeList)
        {
            XmlNode[] nodes = nodeList.ToArray();

            for (int i = 0; i < nodes.Length; i++)
            {
                try
                {
                    if (nodes[i].Type.Contains("preserve") && i > 0)
                    {
                        nodes[i - 1].Value += "\n" + nodes[i].Value;
                        nodes[i].Value = "";
                    }
                    else if (nodes[i].Type.Contains("<bold>"))
                    {
                        nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "**" + nodes[i].Value + "**");
                    }
                    else if (nodes[i].Type.Contains("Heading2"))
                    {
                        nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "=== " + nodes[i].Value + " ===");
                    }
                    else if (nodes[i].Type.Contains("Kop2"))
                    {
                        nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "=== " + nodes[i].Value + " ===");
                    }
                    else if (nodes[i].Type.Contains("Kop1"))
                    {
                        nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "===== " + nodes[i].Value + " =====");
                    }
                }
                catch { } //Yet to be clear
            }
            return nodes;
        }
    }
}
