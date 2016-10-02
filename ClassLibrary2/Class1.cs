using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Collections;

namespace ClassLibrary2
{
    public class Class1 : IClass1
    {
        public virtual string Search(string path, out string[] sp, string search = "*.sln")
        {

            if (Directory.Exists(path))
            {
                string[] v = Directory.GetFiles(path, search, SearchOption.AllDirectories);
                sp = v;
                foreach (string item in v)
                {
                    return item;
                }
                return "-1";
            }
            else
            {
                throw new ArgumentException("Path is a File!");
            }
        }
        string IClass1.Search(string path, out string[] sp, string search)
        {
            return Search(path, out sp, search);
        }
        public virtual string[] Search(string path, string search = "*.sln")
        {
            string[] str;
            Search(path, out str, search);
            return str;
        }
        string[] IClass1.Search(string path, string search)
        {
            return Search(path, search);
        }
    }
       
}
