using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form2 : Form
    {
        public string[] str;
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((o) =>
                    {
                        ClassLibrary2.Class1 c = new ClassLibrary2.Class1();
                        c.Search(folderBrowserDialog1.SelectedPath + "\\", out str, comboBox1.SelectedItem.ToString());
                        listBox1.Items.AddRange(str);
                        listBox1.SelectedIndex = 0;
                        listBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
                    }));
                    if (!t.IsAlive)
                    {
                        t.Start();
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("未找到文件！");
                }
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(listBox1.SelectedItem as string);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((o) => {
                new Form3().ShowDialog();
                comboBox1.Items.Add(Form3.str);
            }));
            if (!t.IsAlive)
            {
                t.Start();
            }
        }
    }
}
