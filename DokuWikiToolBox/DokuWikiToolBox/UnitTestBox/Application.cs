using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DokuWikiToolBox;

namespace UnitTestBox
{
    class Application
    {
        public void Run()
        {
            //########### Code Here #############

            var selector = new DocFileSelector();
            var docObjects = selector.SelectDocFile();

            var parser = new XmlParser();
            parser.WordToDokuwiki(docObjects);

            //###################################
            LoopMessageHandler();
        }

        public void LoopMessageHandler()
        {
            Console.Write("Continue? (y/n): ");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "y":
                    IsRunning = true;
                    break;
                case "n":
                    IsRunning = false;
                    break;
                default:
                    LoopMessageHandler();
                    break;
            }
        }
        
        public bool IsRunning { get; set; }
    }
}
