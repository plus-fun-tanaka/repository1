using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "CSV ファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";
                DialogResult dr = dlg.ShowDialog();

                if (dr != DialogResult.OK)
                {
                    return;
                }
                
                textBox1.Focus();
            }                          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;

            if (! System.IO.File.Exists(filePath))
            {
                MessageBox.Show("ファイルが見つかりません。" ,"チェック", MessageBoxButtons.OK,  MessageBoxIcon.Exclamation);
                textBox1.Focus();
                return;
            }

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;//todo 選択できるとよい
                parser.SetDelimiters(",");                 //todo 選択できるとよい

                while (!parser.EndOfData)
                {
                    string[] items = parser.ReadFields();
                }
            }            
        }
    }
}
