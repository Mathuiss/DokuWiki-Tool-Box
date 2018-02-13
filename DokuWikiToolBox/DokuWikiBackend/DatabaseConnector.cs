using System;

namespace DokuWikiBackend
{
    public class DatabaseConnector
    {
        public  dbConnecion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\DokuWiki\DokuWiki-Tool-Box\DokuWikiToolBox\DokuWikiToolBoxOnline\App_Data\Users.mdf;Integrated Security=True";

        public void Register(string name, string email, string password)
        {

        }
    }
}
