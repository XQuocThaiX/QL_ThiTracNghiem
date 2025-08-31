
namespace SinhVien
{
    partial class FrmThiTracNghiem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThiTracNghiem));
            this.cboDeThi = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.labelCauHoi = new System.Windows.Forms.Label();
            this.btnCauSau = new System.Windows.Forms.Button();
            this.btnCauTruoc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNopBai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBatDauLamBai = new System.Windows.Forms.Button();
            this.timerTestTime = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDeThi
            // 
            this.cboDeThi.FormattingEnabled = true;
            this.cboDeThi.Location = new System.Drawing.Point(102, 24);
            this.cboDeThi.Name = "cboDeThi";
            this.cboDeThi.Size = new System.Drawing.Size(135, 21);
            this.cboDeThi.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.radioD);
            this.groupBox1.Controls.Add(this.radioC);
            this.groupBox1.Controls.Add(this.radioB);
            this.groupBox1.Controls.Add(this.radioA);
            this.groupBox1.Controls.Add(this.labelCauHoi);
            this.groupBox1.Controls.Add(this.btnCauSau);
            this.groupBox1.Controls.Add(this.btnCauTruoc);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnNopBai);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(16, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 511);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nội Dung Bài Thi";
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.BackColor = System.Drawing.SystemColors.Control;
            this.radioD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioD.Location = new System.Drawing.Point(86, 354);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(35, 20);
            this.radioD.TabIndex = 5;
            this.radioD.Text = "D";
            this.radioD.UseVisualStyleBackColor = false;
            this.radioD.CheckedChanged += new System.EventHandler(this.radioD_CheckedChanged);
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.BackColor = System.Drawing.SystemColors.Control;
            this.radioC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioC.Location = new System.Drawing.Point(86, 277);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(34, 20);
            this.radioC.TabIndex = 4;
            this.radioC.Text = "C";
            this.radioC.UseVisualStyleBackColor = false;
            this.radioC.CheckedChanged += new System.EventHandler(this.radioC_CheckedChanged);
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.BackColor = System.Drawing.SystemColors.Control;
            this.radioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioB.Location = new System.Drawing.Point(86, 205);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(34, 20);
            this.radioB.TabIndex = 3;
            this.radioB.Text = "B";
            this.radioB.UseVisualStyleBackColor = false;
            this.radioB.CheckedChanged += new System.EventHandler(this.radioB_CheckedChanged);
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.BackColor = System.Drawing.SystemColors.Control;
            this.radioA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioA.Location = new System.Drawing.Point(86, 136);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(34, 20);
            this.radioA.TabIndex = 2;
            this.radioA.Text = "A";
            this.radioA.UseVisualStyleBackColor = false;
            this.radioA.CheckedChanged += new System.EventHandler(this.radioA_CheckedChanged);
            // 
            // labelCauHoi
            // 
            this.labelCauHoi.AutoSize = true;
            this.labelCauHoi.BackColor = System.Drawing.SystemColors.Control;
            this.labelCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelCauHoi.Location = new System.Drawing.Point(83, 60);
            this.labelCauHoi.Name = "labelCauHoi";
            this.labelCauHoi.Size = new System.Drawing.Size(66, 18);
            this.labelCauHoi.TabIndex = 6;
            this.labelCauHoi.Text = "Câu hỏi\r\n";
            // 
            // btnCauSau
            // 
            this.btnCauSau.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCauSau.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCauSau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCauSau.Location = new System.Drawing.Point(525, 474);
            this.btnCauSau.Name = "btnCauSau";
            this.btnCauSau.Size = new System.Drawing.Size(90, 23);
            this.btnCauSau.TabIndex = 7;
            this.btnCauSau.Text = "Câu Sau";
            this.btnCauSau.UseVisualStyleBackColor = false;
            this.btnCauSau.Click += new System.EventHandler(this.btnCauSau_Click);
            // 
            // btnCauTruoc
            // 
            this.btnCauTruoc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCauTruoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCauTruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCauTruoc.Location = new System.Drawing.Point(422, 474);
            this.btnCauTruoc.Name = "btnCauTruoc";
            this.btnCauTruoc.Size = new System.Drawing.Size(97, 23);
            this.btnCauTruoc.TabIndex = 6;
            this.btnCauTruoc.Text = "Câu Trước";
            this.btnCauTruoc.UseVisualStyleBackColor = false;
            this.btnCauTruoc.Click += new System.EventHandler(this.btnCauTruoc_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1022, 431);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnNopBai
            // 
            this.btnNopBai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNopBai.BackColor = System.Drawing.Color.Blue;
            this.btnNopBai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNopBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNopBai.ForeColor = System.Drawing.Color.White;
            this.btnNopBai.Location = new System.Drawing.Point(925, 456);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(101, 54);
            this.btnNopBai.TabIndex = 8;
            this.btnNopBai.Text = "Nộp Bài";
            this.btnNopBai.UseVisualStyleBackColor = false;
            this.btnNopBai.Click += new System.EventHandler(this.btnNopBai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đề thi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBatDauLamBai
            // 
            this.btnBatDauLamBai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatDauLamBai.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBatDauLamBai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatDauLamBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBatDauLamBai.ForeColor = System.Drawing.Color.White;
            this.btnBatDauLamBai.Location = new System.Drawing.Point(355, 10);
            this.btnBatDauLamBai.Name = "btnBatDauLamBai";
            this.btnBatDauLamBai.Size = new System.Drawing.Size(172, 47);
            this.btnBatDauLamBai.TabIndex = 1;
            this.btnBatDauLamBai.Text = "Bắt Đầu Làm Bài";
            this.btnBatDauLamBai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBatDauLamBai.UseVisualStyleBackColor = false;
            this.btnBatDauLamBai.Click += new System.EventHandler(this.btnBatDauLamBai_Click);
            // 
            // timerTestTime
            // 
            this.timerTestTime.Interval = 1000;
            this.timerTestTime.Tick += new System.EventHandler(this.timerTestTime_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(717, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTimer.ForeColor = System.Drawing.Color.Red;
            this.labelTimer.Location = new System.Drawing.Point(756, 21);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(210, 30);
            this.labelTimer.TabIndex = 5;
            this.labelTimer.Text = "Thời Gian Còn Lại:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(360, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // FrmThiTracNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1060, 572);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBatDauLamBai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboDeThi);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmThiTracNghiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thi Trắc Nghiệm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmThiTracNghiem_FormClosing);
            this.Load += new System.EventHandler(this.FrmThiTracNghiem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDeThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBatDauLamBai;
        private System.Windows.Forms.Button btnNopBai;
        private System.Windows.Forms.Timer timerTestTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCauSau;
        private System.Windows.Forms.Button btnCauTruoc;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.Label labelCauHoi;
    }
}