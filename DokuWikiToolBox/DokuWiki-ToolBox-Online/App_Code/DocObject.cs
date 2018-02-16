using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DocObject
/// </summary>
public struct DocObject
{
    private List<string> lines;
    private string path;

    public DocObject(List<string> lines, string path)
    {
        this.lines = lines;
        this.path = path;
    }

    public List<string> Lines { get => lines; set => lines = value; }
    public string Path { get => path; set => path = value; }
}