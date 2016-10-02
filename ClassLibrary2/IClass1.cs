using System;
using System.Collections.Generic;
namespace ClassLibrary2
{
    public interface IClass1
    {
        string[] Search(string path, string search = "*.sln");
        string Search(string path, out string[] sp, string search = "*.sln");
    }
}