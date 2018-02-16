using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Checker
/// </summary>
class Checker
{
    public static bool IsParagraph(string line)
    {
        bool contains = false;
        string indexNumbers = "1234567890";
        char[] chapterIdentification;
        chapterIdentification = indexNumbers.ToCharArray();

        string substring;

        if (line.Length >= 10)
        {
            substring = line.Substring(0, 10); //10 for the index position in the char array substring.
        }
        else
        {
            substring = line.Substring(0, line.Length);
        }

        for (int i = 0; i < chapterIdentification.Length; i++)
        {
            //The requirements for the line to be a chapter indication.

            //========================PLS REGEX THIS============================

            if (
                (
                substring.Contains(chapterIdentification[i])
                && line.Contains("**")
                && line.Contains(".")
                && !line.Contains("{{")
                && !line.Contains("[[")
                && !line.Contains("(")
                && !line.Contains(")")
                && !line.Contains(",")
                && !line.Contains("|")
                && !line.Contains("'")
                && !line.Contains("\"")
                && !line.Contains(";")
                )
                || (
                line.StartsWith("\\   -**")
                && !line.Contains("{{")
                && !line.Contains("[[")
                && !line.Contains("(")
                && !line.Contains(")")
                && !line.Contains(",")
                && !line.Contains("|")
                && !line.Contains("'")
                && !line.Contains("\"")
                && !line.Contains(";")
                )
                || (
                line.StartsWith("\\ **")
                && !line.Contains("{{")
                && !line.Contains("[[")
                && !line.Contains("(")
                && !line.Contains(")")
                && !line.Contains(",")
                && !line.Contains("|")
                && !line.Contains("'")
                && !line.Contains("\"")
                && !line.Contains(";")
                )
                )
            {
                contains = true;
            }
        }

        if (contains == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string GetChapterName(string line)
    {
        string chapterName;
        line = line.ToLower();
        if (line.Contains(" / "))
        {
            line = line.Replace(" / ", "");
        }
        if (line.Contains("|"))
        {
            line = line.Replace("|", "");
        }
        if (line.Contains("/"))
        {
            line = line.Replace("/", "");
        }
        if (line.Contains("*"))
        {
            line = line.Replace("*", "");
        }
        if (line.Contains("}"))
        {
            line = line.Replace("}", "");
        }
        if (line.Contains("\\"))
        {
            line = line.Replace("\\", "");
        }
        if (line.Contains("?"))
        {
            line = line.Replace("?", "");
        }
        if (line.Contains(" "))
        {
            line = line.Trim();
        }
        if (line.Contains(":"))
        {
            line = line.Replace(":", "");
        }
        if (line.Contains("]"))
        {
            line = line.Replace("]", "");
        }
        if (line.Contains(")"))
        {
            line = line.Replace(")", "");
        }
        if (line.Contains("("))
        {
            line = line.Replace("(", "");
        }
        if (line.Contains(" "))
        {
            line = line.Replace(" ", "-");
        }
        //This block is propably depricated because the checker is now fully functional.
        //However it's purpose is to prevent long strings like links to become chapter names.
        //I do think that I have written the IsChapterName() So that that won't happen.
        //It is up to tests now to prove my hypothesis.
        //if (line.Length > 45) //Lenth of the largest word in common english dictionaries.
        //{
        //    //throw new Exception();
        //}
        chapterName = line;
        return chapterName;
    }
}
