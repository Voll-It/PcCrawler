namespace PcCrawler
{
    partial class Crawler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crawler));
            this.tv_test = new System.Windows.Forms.TreeView();
            this.bt_test = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_name = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_fullpath = new System.Windows.Forms.Label();
            this.lb_size = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_test
            // 
            this.tv_test.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_test.Location = new System.Drawing.Point(0, 0);
            this.tv_test.Name = "tv_test";
            this.tv_test.Size = new System.Drawing.Size(390, 588);
            this.tv_test.TabIndex = 0;
            this.tv_test.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_test_NodeMouseClick);
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(603, 3);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(170, 50);
            this.bt_test.TabIndex = 1;
            this.bt_test.Text = "Start Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_test);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.bt_test);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 588);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 13);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(73, 16);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(47, 13);
            this.lb_name.TabIndex = 3;
            this.lb_name.Text = "lb_name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this.lb_size);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(this.lb_fullpath);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.lb_name);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 13);
            label3.TabIndex = 4;
            label3.Text = "Full Path";
            // 
            // lb_fullpath
            // 
            this.lb_fullpath.AutoSize = true;
            this.lb_fullpath.Location = new System.Drawing.Point(73, 29);
            this.lb_fullpath.Name = "lb_fullpath";
            this.lb_fullpath.Size = new System.Drawing.Size(55, 13);
            this.lb_fullpath.TabIndex = 5;
            this.lb_fullpath.Text = "lb_fullpath";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 42);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(27, 13);
            label5.TabIndex = 6;
            label5.Text = "Size";
            // 
            // lb_size
            // 
            this.lb_size.AutoSize = true;
            this.lb_size.Location = new System.Drawing.Point(73, 42);
            this.lb_size.Name = "lb_size";
            this.lb_size.Size = new System.Drawing.Size(39, 13);
            this.lb_size.TabIndex = 7;
            this.lb_size.Tag = "";
            this.lb_size.Text = "lb_size";
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 588);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Crawler";
            this.Text = "PC Cawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_test;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_size;
        private System.Windows.Forms.Label lb_fullpath;
        private System.Windows.Forms.Label lb_name;
    }
}

