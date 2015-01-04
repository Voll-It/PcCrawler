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
            this.tv_test = new System.Windows.Forms.TreeView();
            this.bt_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tv_test
            // 
            this.tv_test.Location = new System.Drawing.Point(13, 13);
            this.tv_test.Name = "tv_test";
            this.tv_test.Size = new System.Drawing.Size(435, 332);
            this.tv_test.TabIndex = 0;
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(455, 13);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 1;
            this.bt_test.Text = "Start Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 357);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.tv_test);
            this.Name = "Crawler";
            this.Text = "Cawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_test;
        private System.Windows.Forms.Button bt_test;
    }
}

