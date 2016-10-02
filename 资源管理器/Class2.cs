using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    public class Class2
    {
        public bool CheckDll(string Dll1)
        {
            return System.IO.File.Exists(Dll1);
        }
        public bool CheckDll(string Dll1,string Dll2)
        {
            return CheckDll(Dll1) && System.IO.File.Exists(Dll2);
        }
        public bool CheckDll(string Dll1, string Dll2,string Dll3)
        {
            return CheckDll(Dll1, Dll2) && System.IO.File.Exists(Dll3);
        }
        public bool CheckDll(string Dll1, string Dll2, string Dll3,string Dll4)
        {
            return CheckDll(Dll1, Dll2, Dll3) && System.IO.File.Exists(Dll4);
        }
        public bool CheckDll(params string[] Dlls)
        {
            foreach (var item in Dlls)
            {
                return CheckDll(item);
            }
            return false;
        }
    }
}
