using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuWikiToolBox
{
    class XmlTranslator
    {
        public XmlNode[] TranslateNodes(List<XmlNode> nodeList)
        {
            XmlNode[] nodes = nodeList.ToArray();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Type == "Heading2")
                {
                    nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "=== " + nodes[i].Value + " ===");
                }

                if (nodes[i].Type.Contains("<bold>"))
                {
                    nodes[i].Value = nodes[i].Value.Replace(nodes[i].Value, "**" + nodes[i].Value + "**");
                }
            }
            return nodes;
        }
    }
}
