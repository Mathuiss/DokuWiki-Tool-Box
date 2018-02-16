using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FileObject
/// </summary>
public struct FileObject
{
    private string[] lines;
    private string path;

    public FileObject(string[] lines, string path)
    {
        this.lines = lines;
        this.path = path;
    }

    public string[] Lines { get => lines; set => lines = value; }
    public string Path { get => path; set => path = value; }
}