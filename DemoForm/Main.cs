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

namespace DemoForm
{
    public partial class Main : Form
    {
        public Main ()
        {
            InitializeComponent ();
        }

    

        private  void Main_Load (object sender , EventArgs e)
        {
           
        }

        private void btnOpen_Click (object sender , EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog ();
            open.Filter = "文本文件|*.txt";
            if ( open.ShowDialog()== DialogResult.OK )
            {
                txtFileName.Text = open.FileName;
                txtFiles.Text = File.ReadAllText (open.FileName);
                textBox1.ScrollBars = ScrollBars.Both;
                textBox1.Text = txtFiles.Text;
            }
            
        }
    }
}
