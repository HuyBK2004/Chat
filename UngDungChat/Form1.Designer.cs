namespace UngDungChat
{
    partial class Form1
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
            this.txtTinNhan = new System.Windows.Forms.TextBox();
            this.txtGuiTin = new System.Windows.Forms.TextBox();
            this.lbNguoiDung = new System.Windows.Forms.ListBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGui = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTinNhan
            // 
            this.txtTinNhan.Location = new System.Drawing.Point(250, 12);
            this.txtTinNhan.Multiline = true;
            this.txtTinNhan.Name = "txtTinNhan";
            this.txtTinNhan.ReadOnly = true;
            this.txtTinNhan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTinNhan.Size = new System.Drawing.Size(375, 238);
            this.txtTinNhan.TabIndex = 0;
            // 
            // txtGuiTin
            // 
            this.txtGuiTin.Location = new System.Drawing.Point(250, 256);
            this.txtGuiTin.Multiline = true;
            this.txtGuiTin.Name = "txtGuiTin";
            this.txtGuiTin.Size = new System.Drawing.Size(375, 40);
            this.txtGuiTin.TabIndex = 1;
            // 
            // lbNguoiDung
            // 
            this.lbNguoiDung.FormattingEnabled = true;
            this.lbNguoiDung.Location = new System.Drawing.Point(34, 12);
            this.lbNguoiDung.Name = "lbNguoiDung";
            this.lbNguoiDung.Size = new System.Drawing.Size(210, 238);
            this.lbNguoiDung.TabIndex = 2;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(34, 256);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 40);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(156, 256);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(88, 40);
            this.btnGui.TabIndex = 4;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lbNguoiDung);
            this.Controls.Add(this.txtGuiTin);
            this.Controls.Add(this.txtTinNhan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTinNhan;
        private System.Windows.Forms.TextBox txtGuiTin;
        private System.Windows.Forms.ListBox lbNguoiDung;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGui;
    }
}