namespace QR
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.TextBox();
            this.encoding = new System.Windows.Forms.Button();
            this.decoding = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.qrimage = new System.Windows.Forms.PictureBox();
            this.result = new System.Windows.Forms.TextBox();
            this.combine = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.savetext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openlink = new System.Windows.Forms.Button();
            this.processedimage = new System.Windows.Forms.PictureBox();
            this.detail = new System.Windows.Forms.Button();
            this.hide = new System.Windows.Forms.Button();
            this.processedimage2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.qrimage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedimage2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contents:";
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(126, 32);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(381, 23);
            this.content.TabIndex = 1;
            // 
            // encoding
            // 
            this.encoding.Location = new System.Drawing.Point(30, 164);
            this.encoding.Name = "encoding";
            this.encoding.Size = new System.Drawing.Size(75, 23);
            this.encoding.TabIndex = 2;
            this.encoding.Text = "Generate";
            this.encoding.UseVisualStyleBackColor = true;
            this.encoding.Click += new System.EventHandler(this.encoding_Click);
            // 
            // decoding
            // 
            this.decoding.Location = new System.Drawing.Point(30, 210);
            this.decoding.Name = "decoding";
            this.decoding.Size = new System.Drawing.Size(75, 23);
            this.decoding.TabIndex = 3;
            this.decoding.Text = "Decode";
            this.decoding.UseVisualStyleBackColor = true;
            this.decoding.Click += new System.EventHandler(this.decoding_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(30, 256);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // qrimage
            // 
            this.qrimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrimage.Location = new System.Drawing.Point(132, 165);
            this.qrimage.Name = "qrimage";
            this.qrimage.Size = new System.Drawing.Size(157, 157);
            this.qrimage.TabIndex = 5;
            this.qrimage.TabStop = false;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(326, 131);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(157, 133);
            this.result.TabIndex = 6;
            // 
            // combine
            // 
            this.combine.Location = new System.Drawing.Point(30, 299);
            this.combine.Name = "combine";
            this.combine.Size = new System.Drawing.Size(75, 23);
            this.combine.TabIndex = 7;
            this.combine.Text = "Combine";
            this.combine.UseVisualStyleBackColor = true;
            this.combine.Click += new System.EventHandler(this.combine_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "QR_CODE",
            "PDF_417",
            "CODE_128"});
            this.comboBox1.Location = new System.Drawing.Point(132, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 25);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Code Type:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "BLACK",
            "RED",
            "YELLOW",
            "BLUE"});
            this.comboBox2.Location = new System.Drawing.Point(132, 94);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 25);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Code Color:";
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.SystemColors.Menu;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Location = new System.Drawing.Point(6, 22);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(146, 29);
            this.treeView1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hide);
            this.groupBox1.Controls.Add(this.detail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.combine);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.qrimage);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.savetext);
            this.groupBox1.Controls.Add(this.decoding);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.encoding);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.openlink);
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 338);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR Master";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Erro correction:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "L",
            "M",
            "Q",
            "H"});
            this.comboBox3.Location = new System.Drawing.Point(132, 128);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(157, 25);
            this.comboBox3.TabIndex = 17;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // savetext
            // 
            this.savetext.Location = new System.Drawing.Point(408, 270);
            this.savetext.Name = "savetext";
            this.savetext.Size = new System.Drawing.Size(75, 23);
            this.savetext.TabIndex = 16;
            this.savetext.Text = "Copy text";
            this.savetext.UseVisualStyleBackColor = true;
            this.savetext.Click += new System.EventHandler(this.savetext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(326, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 57);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drag here to decode";
            // 
            // openlink
            // 
            this.openlink.Location = new System.Drawing.Point(326, 270);
            this.openlink.Name = "openlink";
            this.openlink.Size = new System.Drawing.Size(75, 23);
            this.openlink.TabIndex = 15;
            this.openlink.Text = "Open link";
            this.openlink.UseVisualStyleBackColor = true;
            this.openlink.Click += new System.EventHandler(this.openlink_Click);
            // 
            // processedimage
            // 
            this.processedimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processedimage.Location = new System.Drawing.Point(101, 356);
            this.processedimage.Name = "processedimage";
            this.processedimage.Size = new System.Drawing.Size(157, 157);
            this.processedimage.TabIndex = 14;
            this.processedimage.TabStop = false;
            this.processedimage.Click += new System.EventHandler(this.processedimage_Click);
            // 
            // detail
            // 
            this.detail.Location = new System.Drawing.Point(326, 299);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(75, 23);
            this.detail.TabIndex = 19;
            this.detail.Text = "Detail";
            this.detail.UseVisualStyleBackColor = true;
            this.detail.Click += new System.EventHandler(this.detail_Click);
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(408, 299);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(75, 23);
            this.hide.TabIndex = 20;
            this.hide.Text = "Hide";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // processedimage2
            // 
            this.processedimage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processedimage2.Location = new System.Drawing.Point(314, 356);
            this.processedimage2.Name = "processedimage2";
            this.processedimage2.Size = new System.Drawing.Size(156, 157);
            this.processedimage2.TabIndex = 15;
            this.processedimage2.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(556, 521);
            this.Controls.Add(this.processedimage2);
            this.Controls.Add(this.processedimage);
            this.Controls.Add(this.content);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "QR Master";
            ((System.ComponentModel.ISupportInitialize)(this.qrimage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedimage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.TextBox contents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox content;
        private System.Windows.Forms.Button encoding;
        private System.Windows.Forms.Button decoding;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.PictureBox qrimage;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button combine;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button openlink;
        private System.Windows.Forms.Button savetext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.PictureBox processedimage;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button detail;
        private System.Windows.Forms.PictureBox processedimage2;
    }
}

