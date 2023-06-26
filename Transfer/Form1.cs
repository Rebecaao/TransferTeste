using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer
{
    public partial class Form1 : Form
    {
        string sourceLocation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK )
            {
                sourceLocation = fbd.SelectedPath;
                textSourceLoaction.Text = sourceLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sourceLocationPath = textSourceLoaction.Text;
            if(sourceLocationPath != "")
            {
                //create destination directory
                if (!Directory.Exists(@"\\192.168.101.104\Users\rebeca\TesteTransferrr"))
                {
                    Directory.CreateDirectory(@"\\192.168.101.104\Users\rebeca\TesteTransferrr");
                }

                foreach (string newpath in Directory.GetFiles(sourceLocationPath, "*.*", SearchOption.AllDirectories))
                    File.Copy(newpath, newpath.Replace(sourceLocationPath, @"\\192.168.101.104\Users\rebeca\TesteTransferrr"), true);

                MessageBox.Show("Copy Done");
            }
            else
            {
                MessageBox.Show("Please Select Source Location");
            }
        }
    }
}
