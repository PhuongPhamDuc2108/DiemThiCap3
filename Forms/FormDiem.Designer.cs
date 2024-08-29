namespace BaiTapLon.Forms
{
    partial class FormDiem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiem));
			this.label1 = new System.Windows.Forms.Label();
			this.lbal2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtMaMH = new System.Windows.Forms.TextBox();
			this.txtDiemHS3 = new System.Windows.Forms.TextBox();
			this.txtDiemHS2 = new System.Windows.Forms.TextBox();
			this.txtDiemHS1 = new System.Windows.Forms.TextBox();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.comboBoxMonHoc = new System.Windows.Forms.ComboBox();
			this.txtMaHS = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
			this.label1.Location = new System.Drawing.Point(341, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(387, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nhập điểm học sinh";
			// 
			// lbal2
			// 
			this.lbal2.AutoSize = true;
			this.lbal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.lbal2.Location = new System.Drawing.Point(81, 101);
			this.lbal2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbal2.Name = "lbal2";
			this.lbal2.Size = new System.Drawing.Size(124, 25);
			this.lbal2.TabIndex = 1;
			this.lbal2.Text = "Mã học sinh:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label3.Location = new System.Drawing.Point(79, 224);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 25);
			this.label3.TabIndex = 1;
			this.label3.Text = "Tên môn học:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(549, 101);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(132, 25);
			this.label4.TabIndex = 1;
			this.label4.Text = "Điểm hệ số 1:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label5.Location = new System.Drawing.Point(79, 164);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 25);
			this.label5.TabIndex = 1;
			this.label5.Text = "Mã môn học:";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label6.Location = new System.Drawing.Point(549, 166);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(132, 25);
			this.label6.TabIndex = 1;
			this.label6.Text = "Điểm hệ số 2:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label7.Location = new System.Drawing.Point(549, 224);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(132, 25);
			this.label7.TabIndex = 1;
			this.label7.Text = "Điểm hệ số 3:";
			// 
			// txtMaMH
			// 
			this.txtMaMH.Enabled = false;
			this.txtMaMH.Location = new System.Drawing.Point(263, 226);
			this.txtMaMH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtMaMH.Name = "txtMaMH";
			this.txtMaMH.Size = new System.Drawing.Size(160, 22);
			this.txtMaMH.TabIndex = 2;
			// 
			// txtDiemHS3
			// 
			this.txtDiemHS3.Location = new System.Drawing.Point(699, 226);
			this.txtDiemHS3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDiemHS3.Name = "txtDiemHS3";
			this.txtDiemHS3.Size = new System.Drawing.Size(172, 22);
			this.txtDiemHS3.TabIndex = 2;
			// 
			// txtDiemHS2
			// 
			this.txtDiemHS2.Location = new System.Drawing.Point(699, 166);
			this.txtDiemHS2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDiemHS2.Name = "txtDiemHS2";
			this.txtDiemHS2.Size = new System.Drawing.Size(172, 22);
			this.txtDiemHS2.TabIndex = 2;
			// 
			// txtDiemHS1
			// 
			this.txtDiemHS1.Location = new System.Drawing.Point(699, 103);
			this.txtDiemHS1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDiemHS1.Name = "txtDiemHS1";
			this.txtDiemHS1.Size = new System.Drawing.Size(172, 22);
			this.txtDiemHS1.TabIndex = 2;
			// 
			// btnLuu
			// 
			this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
			this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnLuu.Location = new System.Drawing.Point(304, 343);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(132, 46);
			this.btnLuu.TabIndex = 3;
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// btnThem
			// 
			this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
			this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnThem.Location = new System.Drawing.Point(112, 343);
			this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(136, 46);
			this.btnThem.TabIndex = 3;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// btnSua
			// 
			this.btnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSua.BackgroundImage")));
			this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnSua.Location = new System.Drawing.Point(516, 343);
			this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(123, 46);
			this.btnSua.TabIndex = 3;
			this.btnSua.UseVisualStyleBackColor = true;
			// 
			// btnXoa
			// 
			this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
			this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnXoa.Location = new System.Drawing.Point(699, 343);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(117, 46);
			this.btnXoa.TabIndex = 3;
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// btnThoat
			// 
			this.btnThoat.Location = new System.Drawing.Point(892, 343);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(120, 46);
			this.btnThoat.TabIndex = 3;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// comboBoxMonHoc
			// 
			this.comboBoxMonHoc.FormattingEnabled = true;
			this.comboBoxMonHoc.Location = new System.Drawing.Point(263, 164);
			this.comboBoxMonHoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.comboBoxMonHoc.Name = "comboBoxMonHoc";
			this.comboBoxMonHoc.Size = new System.Drawing.Size(160, 24);
			this.comboBoxMonHoc.TabIndex = 4;
			this.comboBoxMonHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonHoc_SelectedIndexChanged);
			// 
			// txtMaHS
			// 
			this.txtMaHS.Location = new System.Drawing.Point(263, 101);
			this.txtMaHS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtMaHS.Name = "txtMaHS";
			this.txtMaHS.Size = new System.Drawing.Size(160, 22);
			this.txtMaHS.TabIndex = 5;
			// 
			// FormDiem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 554);
			this.Controls.Add(this.txtMaHS);
			this.Controls.Add(this.comboBoxMonHoc);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnSua);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.txtDiemHS1);
			this.Controls.Add(this.txtDiemHS2);
			this.Controls.Add(this.txtDiemHS3);
			this.Controls.Add(this.txtMaMH);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbal2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FormDiem";
			this.Text = "FormDiem";
			this.Load += new System.EventHandler(this.FormDiem_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbal2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtDiemHS3;
        private System.Windows.Forms.TextBox txtDiemHS2;
        private System.Windows.Forms.TextBox txtDiemHS1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox comboBoxMonHoc;
        private System.Windows.Forms.TextBox txtMaHS;
    }
}