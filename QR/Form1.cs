using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR
{
    public partial class Form1 : Form
    {
        private int originalHeight;
        public Form1()
        {
            InitializeComponent();

            originalHeight = this.Height;
            this.Height = originalHeight - processedimage.Height-9;

            treeView1.AllowDrop = true;

            treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
        }

        private BarCode qrcode = new BarCode();
        string codeType = null;
        string codeColor = null;
        string erroCorrectionLevel = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            string path = null;
            path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            qrcode.DecodeQRCode(qrimage, processedimage, processedimage2, result, path);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeType = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeColor = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            erroCorrectionLevel = comboBox3.Text;
        }

        private void encoding_Click(object sender, EventArgs e)
        {
            qrcode.GenerateQRCode(content.Text, qrimage, codeType, codeColor, erroCorrectionLevel, true);
        }

        private void decoding_Click(object sender, EventArgs e)
        {
            qrcode.DecodeQRCode(qrimage, processedimage, processedimage2, result, null);
        }

        private void save_Click(object sender, EventArgs e)
        {
            qrcode.SaveQRCode(qrimage);
        }

        private void combine_Click(object sender, EventArgs e)
        {
            if (codeType == "PDF_417" || codeType == "CODE_128" || codeType == null)
            {
                MessageBox.Show("Cannot combine this kind of code");
            }
            else
            {
                qrcode.CombineQRCode(content.Text, qrimage, codeType, codeColor, erroCorrectionLevel);
            }
        }

        private void openlink_Click(object sender, EventArgs e)
        {
            if (result.Text != string.Empty)
            {
                System.Diagnostics.Process.Start(result.Text.ToString());
            }
        }

        private void savetext_Click(object sender, EventArgs e)
        {
            if (result.Text != string.Empty)
            {
                Clipboard.SetDataObject(result.Text.ToString());
            }
        }

        private void processedimage_Click(object sender, EventArgs e)
        {

        }

        private void detail_Click(object sender, EventArgs e)
        {
            this.Height = originalHeight;
        }

        private void hide_Click(object sender, EventArgs e)
        {
            this.Height = originalHeight - processedimage.Height-9;
        }
       
    }
}
