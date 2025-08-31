namespace SinhVien.frmAdmin
{
    partial class frmQLKetQua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLKetQua));
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.SoCauSai = new System.Windows.Forms.NumericUpDown();
            this.SoCauDung = new System.Windows.Forms.NumericUpDown();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.dtpNgayHoanThanh = new System.Windows.Forms.DateTimePicker();
            this.cboMaKyThi = new System.Windows.Forms.ComboBox();
            this.cboMaDeThi = new System.Windows.Forms.ComboBox();
            this.cboMaSV = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNgayHT = new System.Windows.Forms.Label();
            this.lblMaKyThi = new System.Windows.Forms.Label();
            this.lblMaDT = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoCauSai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoCauDung)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(4, 507);
            this.dgvKetQua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 62;
            this.dgvKetQua.Size = new System.Drawing.Size(1561, 442);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.SoCauSai);
            this.groupBox1.Controls.Add(this.SoCauDung);
            this.groupBox1.Controls.Add(this.txtDiem);
            this.groupBox1.Controls.Add(this.dtpNgayHoanThanh);
            this.groupBox1.Controls.Add(this.cboMaKyThi);
            this.groupBox1.Controls.Add(this.cboMaDeThi);
            this.groupBox1.Controls.Add(this.cboMaSV);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblNgayHT);
            this.groupBox1.Controls.Add(this.lblMaKyThi);
            this.groupBox1.Controls.Add(this.lblMaDT);
            this.groupBox1.Controls.Add(this.lblMaSV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1561, 492);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Kết Quả";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BackColor = System.Drawing.Color.MintCream;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTimKiem.Location = new System.Drawing.Point(1043, 443);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(501, 32);
            this.txtTimKiem.TabIndex = 23;
            this.txtTimKiem.Text = "Tìm kiếm theo mã sinh viên";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1000, 440);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.panel1.Location = new System.Drawing.Point(1000, 482);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 2);
            this.panel1.TabIndex = 21;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(536, 329);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(249, 49);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa Kết Quả";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(278, 329);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(249, 49);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa Kết Quả";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(20, 329);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(249, 49);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "Thêm Kết Quả";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // SoCauSai
            // 
            this.SoCauSai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.SoCauSai.Location = new System.Drawing.Point(958, 117);
            this.SoCauSai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SoCauSai.Name = "SoCauSai";
            this.SoCauSai.Size = new System.Drawing.Size(180, 39);
            this.SoCauSai.TabIndex = 13;
            this.SoCauSai.ValueChanged += new System.EventHandler(this.SoCauSai_ValueChanged);
            // 
            // SoCauDung
            // 
            this.SoCauDung.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.SoCauDung.Location = new System.Drawing.Point(958, 60);
            this.SoCauDung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SoCauDung.Name = "SoCauDung";
            this.SoCauDung.Size = new System.Drawing.Size(180, 39);
            this.SoCauDung.TabIndex = 12;
            this.SoCauDung.ValueChanged += new System.EventHandler(this.SoCauDung_ValueChanged);
            // 
            // txtDiem
            // 
            this.txtDiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtDiem.Location = new System.Drawing.Point(958, 174);
            this.txtDiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(148, 39);
            this.txtDiem.TabIndex = 11;
            // 
            // dtpNgayHoanThanh
            // 
            this.dtpNgayHoanThanh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dtpNgayHoanThanh.Location = new System.Drawing.Point(284, 234);
            this.dtpNgayHoanThanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNgayHoanThanh.Name = "dtpNgayHoanThanh";
            this.dtpNgayHoanThanh.Size = new System.Drawing.Size(432, 39);
            this.dtpNgayHoanThanh.TabIndex = 10;
            // 
            // cboMaKyThi
            // 
            this.cboMaKyThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cboMaKyThi.FormattingEnabled = true;
            this.cboMaKyThi.Location = new System.Drawing.Point(284, 174);
            this.cboMaKyThi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMaKyThi.Name = "cboMaKyThi";
            this.cboMaKyThi.Size = new System.Drawing.Size(432, 40);
            this.cboMaKyThi.TabIndex = 9;
            // 
            // cboMaDeThi
            // 
            this.cboMaDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cboMaDeThi.FormattingEnabled = true;
            this.cboMaDeThi.Location = new System.Drawing.Point(284, 117);
            this.cboMaDeThi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMaDeThi.Name = "cboMaDeThi";
            this.cboMaDeThi.Size = new System.Drawing.Size(432, 40);
            this.cboMaDeThi.TabIndex = 8;
            // 
            // cboMaSV
            // 
            this.cboMaSV.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cboMaSV.FormattingEnabled = true;
            this.cboMaSV.Location = new System.Drawing.Point(284, 60);
            this.cboMaSV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMaSV.Name = "cboMaSV";
            this.cboMaSV.Size = new System.Drawing.Size(432, 40);
            this.cboMaSV.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(794, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Điểm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(794, 125);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số Câu Sai";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(794, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số Câu Đúng";
            // 
            // lblNgayHT
            // 
            this.lblNgayHT.AutoSize = true;
            this.lblNgayHT.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHT.Location = new System.Drawing.Point(70, 240);
            this.lblNgayHT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayHT.Name = "lblNgayHT";
            this.lblNgayHT.Size = new System.Drawing.Size(212, 32);
            this.lblNgayHT.TabIndex = 3;
            this.lblNgayHT.Text = "Ngày Hoàn Thành";
            // 
            // lblMaKyThi
            // 
            this.lblMaKyThi.AutoSize = true;
            this.lblMaKyThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKyThi.Location = new System.Drawing.Point(70, 182);
            this.lblMaKyThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKyThi.Name = "lblMaKyThi";
            this.lblMaKyThi.Size = new System.Drawing.Size(122, 32);
            this.lblMaKyThi.TabIndex = 2;
            this.lblMaKyThi.Text = "Mã Kỳ Thi";
            // 
            // lblMaDT
            // 
            this.lblMaDT.AutoSize = true;
            this.lblMaDT.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDT.Location = new System.Drawing.Point(70, 123);
            this.lblMaDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaDT.Name = "lblMaDT";
            this.lblMaDT.Size = new System.Drawing.Size(126, 32);
            this.lblMaDT.TabIndex = 1;
            this.lblMaDT.Text = "Mã Đề Thi";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSV.Location = new System.Drawing.Point(70, 65);
            this.lblMaSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(158, 32);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã Sinh Viên";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvKetQua, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1569, 952);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // frmQLKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 952);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQLKetQua";
            this.Text = "QLKetQua";
            this.Load += new System.EventHandler(this.frmQLKetQua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoCauSai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoCauDung)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown SoCauSai;
        private System.Windows.Forms.NumericUpDown SoCauDung;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.DateTimePicker dtpNgayHoanThanh;
        private System.Windows.Forms.ComboBox cboMaKyThi;
        private System.Windows.Forms.ComboBox cboMaDeThi;
        private System.Windows.Forms.ComboBox cboMaSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNgayHT;
        private System.Windows.Forms.Label lblMaKyThi;
        private System.Windows.Forms.Label lblMaDT;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}