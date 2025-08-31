namespace SinhVien.frmAdmin
{
    partial class frmQLDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLDeThi));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSuaGhiChu = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNoiDung = new System.Windows.Forms.RichTextBox();
            this.cboMaDeThi = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnXoaCH = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnThemCauHoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSuaDeThi = new System.Windows.Forms.Button();
            this.btnXoaDeThi = new System.Windows.Forms.Button();
            this.btnThemDeThi = new System.Windows.Forms.Button();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.numberThoiGianLam = new System.Windows.Forms.NumericUpDown();
            this.numberSoLuongCauHoi = new System.Windows.Forms.NumericUpDown();
            this.txtMaDeThi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberThoiGianLam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberSoLuongCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1056, 646);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 461);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1050, 194);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSuaGhiChu);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.cboMaDeThi);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.btnXoaCH);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnThemCauHoi);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 229);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Chi Tiết Đề Thi";
            // 
            // btnSuaGhiChu
            // 
            this.btnSuaGhiChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnSuaGhiChu.FlatAppearance.BorderSize = 0;
            this.btnSuaGhiChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaGhiChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnSuaGhiChu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaGhiChu.Image")));
            this.btnSuaGhiChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaGhiChu.Location = new System.Drawing.Point(353, 144);
            this.btnSuaGhiChu.Name = "btnSuaGhiChu";
            this.btnSuaGhiChu.Size = new System.Drawing.Size(166, 32);
            this.btnSuaGhiChu.TabIndex = 13;
            this.btnSuaGhiChu.Text = "Sửa ghi chú";
            this.btnSuaGhiChu.UseVisualStyleBackColor = false;
            this.btnSuaGhiChu.Click += new System.EventHandler(this.btnSuaGhiChu_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BackColor = System.Drawing.Color.MintCream;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTimKiem.Location = new System.Drawing.Point(706, 194);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(334, 21);
            this.txtTimKiem.TabIndex = 20;
            this.txtTimKiem.Text = "Tìm kiếm theo mã câu hỏi hoặc tên ghi chú";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(676, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.panel1.Location = new System.Drawing.Point(676, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 1);
            this.panel1.TabIndex = 18;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNoiDung.Enabled = false;
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtNoiDung.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNoiDung.Location = new System.Drawing.Point(609, 38);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(427, 77);
            this.txtNoiDung.TabIndex = 17;
            this.txtNoiDung.Text = "";
            // 
            // cboMaDeThi
            // 
            this.cboMaDeThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cboMaDeThi.FormattingEnabled = true;
            this.cboMaDeThi.Location = new System.Drawing.Point(115, 41);
            this.cboMaDeThi.Name = "cboMaDeThi";
            this.cboMaDeThi.Size = new System.Drawing.Size(313, 29);
            this.cboMaDeThi.TabIndex = 16;
            this.cboMaDeThi.SelectionChangeCommitted += new System.EventHandler(this.cboMaDeThi_SelectionChangeCommitted);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtGhiChu.Location = new System.Drawing.Point(116, 86);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(312, 29);
            this.txtGhiChu.TabIndex = 4;
            // 
            // btnXoaCH
            // 
            this.btnXoaCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnXoaCH.FlatAppearance.BorderSize = 0;
            this.btnXoaCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCH.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCH.ForeColor = System.Drawing.Color.White;
            this.btnXoaCH.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCH.Image")));
            this.btnXoaCH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCH.Location = new System.Drawing.Point(181, 144);
            this.btnXoaCH.Name = "btnXoaCH";
            this.btnXoaCH.Size = new System.Drawing.Size(166, 32);
            this.btnXoaCH.TabIndex = 14;
            this.btnXoaCH.Text = "Xóa Câu Hỏi";
            this.btnXoaCH.UseVisualStyleBackColor = false;
            this.btnXoaCH.Click += new System.EventHandler(this.btnXoaCH_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(524, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nội Dung";
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnThemCauHoi.FlatAppearance.BorderSize = 0;
            this.btnThemCauHoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCauHoi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCauHoi.ForeColor = System.Drawing.Color.White;
            this.btnThemCauHoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCauHoi.Image")));
            this.btnThemCauHoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCauHoi.Location = new System.Drawing.Point(9, 144);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(166, 32);
            this.btnThemCauHoi.TabIndex = 15;
            this.btnThemCauHoi.Text = "Thêm Câu Hỏi";
            this.btnThemCauHoi.UseVisualStyleBackColor = false;
            this.btnThemCauHoi.Click += new System.EventHandler(this.btnThemCauHoi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ghi Chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã Đề Thi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuaDeThi);
            this.groupBox1.Controls.Add(this.btnXoaDeThi);
            this.groupBox1.Controls.Add(this.btnThemDeThi);
            this.groupBox1.Controls.Add(this.dtpNgayTao);
            this.groupBox1.Controls.Add(this.numberThoiGianLam);
            this.groupBox1.Controls.Add(this.numberSoLuongCauHoi);
            this.groupBox1.Controls.Add(this.txtMaDeThi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Đề Thi";
            // 
            // btnSuaDeThi
            // 
            this.btnSuaDeThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnSuaDeThi.FlatAppearance.BorderSize = 0;
            this.btnSuaDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDeThi.ForeColor = System.Drawing.Color.White;
            this.btnSuaDeThi.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaDeThi.Image")));
            this.btnSuaDeThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaDeThi.Location = new System.Drawing.Point(353, 146);
            this.btnSuaDeThi.Name = "btnSuaDeThi";
            this.btnSuaDeThi.Size = new System.Drawing.Size(166, 32);
            this.btnSuaDeThi.TabIndex = 13;
            this.btnSuaDeThi.Text = "Sửa Đề Thi";
            this.btnSuaDeThi.UseVisualStyleBackColor = false;
            this.btnSuaDeThi.Click += new System.EventHandler(this.btnSuaDeThi_Click);
            // 
            // btnXoaDeThi
            // 
            this.btnXoaDeThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnXoaDeThi.FlatAppearance.BorderSize = 0;
            this.btnXoaDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDeThi.ForeColor = System.Drawing.Color.White;
            this.btnXoaDeThi.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDeThi.Image")));
            this.btnXoaDeThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDeThi.Location = new System.Drawing.Point(181, 146);
            this.btnXoaDeThi.Name = "btnXoaDeThi";
            this.btnXoaDeThi.Size = new System.Drawing.Size(166, 32);
            this.btnXoaDeThi.TabIndex = 14;
            this.btnXoaDeThi.Text = "Xóa Đề Thi";
            this.btnXoaDeThi.UseVisualStyleBackColor = false;
            this.btnXoaDeThi.Click += new System.EventHandler(this.btnXoaDeThi_Click);
            // 
            // btnThemDeThi
            // 
            this.btnThemDeThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(142)))), ((int)(((byte)(239)))));
            this.btnThemDeThi.FlatAppearance.BorderSize = 0;
            this.btnThemDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDeThi.ForeColor = System.Drawing.Color.White;
            this.btnThemDeThi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDeThi.Image")));
            this.btnThemDeThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDeThi.Location = new System.Drawing.Point(9, 146);
            this.btnThemDeThi.Name = "btnThemDeThi";
            this.btnThemDeThi.Size = new System.Drawing.Size(166, 32);
            this.btnThemDeThi.TabIndex = 15;
            this.btnThemDeThi.Text = "Thêm Đề Thi";
            this.btnThemDeThi.UseVisualStyleBackColor = false;
            this.btnThemDeThi.Click += new System.EventHandler(this.btnThemDeThi_Click);
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dtpNgayTao.Location = new System.Drawing.Point(627, 38);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(287, 29);
            this.dtpNgayTao.TabIndex = 6;
            // 
            // numberThoiGianLam
            // 
            this.numberThoiGianLam.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numberThoiGianLam.Location = new System.Drawing.Point(627, 78);
            this.numberThoiGianLam.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numberThoiGianLam.Name = "numberThoiGianLam";
            this.numberThoiGianLam.Size = new System.Drawing.Size(120, 29);
            this.numberThoiGianLam.TabIndex = 5;
            // 
            // numberSoLuongCauHoi
            // 
            this.numberSoLuongCauHoi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numberSoLuongCauHoi.Location = new System.Drawing.Point(181, 78);
            this.numberSoLuongCauHoi.Name = "numberSoLuongCauHoi";
            this.numberSoLuongCauHoi.Size = new System.Drawing.Size(120, 29);
            this.numberSoLuongCauHoi.TabIndex = 5;
            // 
            // txtMaDeThi
            // 
            this.txtMaDeThi.Enabled = false;
            this.txtMaDeThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtMaDeThi.Location = new System.Drawing.Point(181, 38);
            this.txtMaDeThi.Name = "txtMaDeThi";
            this.txtMaDeThi.Size = new System.Drawing.Size(273, 29);
            this.txtMaDeThi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(509, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thời Gian Làm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Lượng Câu Hỏi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Đề Thi";
            // 
            // frmQLDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1056, 646);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmQLDeThi";
            this.Text = "frmQLDeThi";
            this.Load += new System.EventHandler(this.frmQLDeThi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberThoiGianLam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberSoLuongCauHoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMaDeThi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.NumericUpDown numberThoiGianLam;
        private System.Windows.Forms.NumericUpDown numberSoLuongCauHoi;
        private System.Windows.Forms.Button btnSuaDeThi;
        private System.Windows.Forms.Button btnXoaDeThi;
        private System.Windows.Forms.Button btnThemDeThi;
        private System.Windows.Forms.ComboBox cboMaDeThi;
        private System.Windows.Forms.Button btnXoaCH;
        private System.Windows.Forms.Button btnThemCauHoi;
        private System.Windows.Forms.RichTextBox txtNoiDung;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnSuaGhiChu;
    }
}