namespace pdx_ymlmerger
{
    partial class Mainfrm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainfrm));
            this.btnMerge = new System.Windows.Forms.Button();
            this.Logtxtbox = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Savetxtbox = new System.Windows.Forms.TextBox();
            this.LstFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckSameLinebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(120, 496);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(76, 34);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge Only";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // Logtxtbox
            // 
            this.Logtxtbox.Location = new System.Drawing.Point(205, 30);
            this.Logtxtbox.Multiline = true;
            this.Logtxtbox.Name = "Logtxtbox";
            this.Logtxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logtxtbox.Size = new System.Drawing.Size(271, 460);
            this.Logtxtbox.TabIndex = 1;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(731, 496);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(68, 34);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Savetxtbox
            // 
            this.Savetxtbox.Location = new System.Drawing.Point(482, 30);
            this.Savetxtbox.Multiline = true;
            this.Savetxtbox.Name = "Savetxtbox";
            this.Savetxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Savetxtbox.Size = new System.Drawing.Size(519, 460);
            this.Savetxtbox.TabIndex = 3;
            this.Savetxtbox.WordWrap = false;
            // 
            // LstFiles
            // 
            this.LstFiles.FormattingEnabled = true;
            this.LstFiles.ItemHeight = 12;
            this.LstFiles.Location = new System.Drawing.Point(12, 30);
            this.LstFiles.Name = "LstFiles";
            this.LstFiles.Size = new System.Drawing.Size(184, 460);
            this.LstFiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Varibles Check";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Preview Save";
            // 
            // CheckSameLinebtn
            // 
            this.CheckSameLinebtn.Location = new System.Drawing.Point(482, 496);
            this.CheckSameLinebtn.Name = "CheckSameLinebtn";
            this.CheckSameLinebtn.Size = new System.Drawing.Size(75, 34);
            this.CheckSameLinebtn.TabIndex = 8;
            this.CheckSameLinebtn.Text = "Check Same";
            this.CheckSameLinebtn.UseVisualStyleBackColor = true;
            this.CheckSameLinebtn.Click += new System.EventHandler(this.CheckSameLinebtn_Click);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 541);
            this.Controls.Add(this.CheckSameLinebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstFiles);
            this.Controls.Add(this.Savetxtbox);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Logtxtbox);
            this.Controls.Add(this.btnMerge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDX Game YML Merger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainfrm_FormClosed);
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.TextBox Logtxtbox;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.TextBox Savetxtbox;
        private System.Windows.Forms.ListBox LstFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CheckSameLinebtn;
    }
}

