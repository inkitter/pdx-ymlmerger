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
            this.FilesListbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(155, 351);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(68, 34);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // Logtxtbox
            // 
            this.Logtxtbox.Location = new System.Drawing.Point(264, 77);
            this.Logtxtbox.Multiline = true;
            this.Logtxtbox.Name = "Logtxtbox";
            this.Logtxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logtxtbox.Size = new System.Drawing.Size(281, 275);
            this.Logtxtbox.TabIndex = 1;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(793, 358);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(68, 34);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Savetxtbox
            // 
            this.Savetxtbox.Location = new System.Drawing.Point(580, 77);
            this.Savetxtbox.Multiline = true;
            this.Savetxtbox.Name = "Savetxtbox";
            this.Savetxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Savetxtbox.Size = new System.Drawing.Size(281, 275);
            this.Savetxtbox.TabIndex = 3;
            // 
            // FilesListbox
            // 
            this.FilesListbox.FormattingEnabled = true;
            this.FilesListbox.ItemHeight = 12;
            this.FilesListbox.Location = new System.Drawing.Point(39, 77);
            this.FilesListbox.Name = "FilesListbox";
            this.FilesListbox.Size = new System.Drawing.Size(184, 268);
            this.FilesListbox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Varibles Check";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Preview Save";
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 407);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilesListbox);
            this.Controls.Add(this.Savetxtbox);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Logtxtbox);
            this.Controls.Add(this.btnMerge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainfrm";
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
        private System.Windows.Forms.ListBox FilesListbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

