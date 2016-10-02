using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    internal class Class1
    {
        internal async void Add(object o)
        {
            Assembly assembly = GetType().Assembly;
            Stream streamSmall = assembly.GetManifestResourceStream("FileExplorer.Resources.ClassLibrary2.dll");
            FileStream fs = File.Open(Application.StartupPath + "\\ClassLibrary2.dll", FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.ReadWrite);
            byte[] buffer;
            buffer=new byte[streamSmall.Length+1];
            await streamSmall.ReadAsync(buffer, 0, (int)streamSmall.Length+1);
            BinaryWriter b = new BinaryWriter(fs);
            b.Write(buffer,0,buffer.Length);
            b.Flush();
            fs.Flush();
            streamSmall.Close();
            b.Close();
            fs.Close();
            Test();
            //ClassLibrary2.pdb
        }
        private async void Test()
        {
            Assembly assembly = GetType().Assembly;
            Stream streamSmall2 = assembly.GetManifestResourceStream("FileExplorer.Resources.ClassLibrary2.pdb");
            FileStream fs2 = File.Open(Application.StartupPath + "\\ClassLibrary2.pdb", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            byte[] buffer2;
            buffer2 = new byte[streamSmall2.Length + 1];
            await streamSmall2.ReadAsync(buffer2, 0, (int)streamSmall2.Length + 1);
            BinaryWriter b2 = new BinaryWriter(fs2);
            b2.Write(buffer2, 0, buffer2.Length);
            b2.Flush();
            fs2.Flush();
            streamSmall2.Close();
            b2.Close();
            fs2.Close();
        }
    }
}
