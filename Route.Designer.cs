namespace Tour
{
    partial class Route
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Route));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XuatPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianToChuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchtxb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdbInternational = new System.Windows.Forms.RadioButton();
            this.rdbNational = new System.Windows.Forms.RadioButton();
            this.nighttxb = new System.Windows.Forms.TextBox();
            this.Destxb = new System.Windows.Forms.TextBox();
            this.daytxb = new System.Windows.Forms.TextBox();
            this.DLtxb = new System.Windows.Forms.TextBox();
            this.tNametxb = new System.Windows.Forms.TextBox();
            this.IDtxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GotoTourbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tourist routes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.MaTuyen,
            this.TenTuyen,
            this.XuatPhat,
            this.DiaDiem,
            this.ThoiGianToChuc,
            this.TenLoaiTuyen});
            this.dataGridView1.Location = new System.Drawing.Point(15, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(772, 234);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // stt
            // 
            this.stt.DataPropertyName = "ID";
            this.stt.HeaderText = "ID";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            this.stt.Visible = false;
            // 
            // MaTuyen
            // 
            this.MaTuyen.DataPropertyName = "MaTuyen";
            this.MaTuyen.FillWeight = 401.0695F;
            this.MaTuyen.HeaderText = "Route ID";
            this.MaTuyen.MinimumWidth = 6;
            this.MaTuyen.Name = "MaTuyen";
            this.MaTuyen.ReadOnly = true;
            this.MaTuyen.Width = 125;
            // 
            // TenTuyen
            // 
            this.TenTuyen.DataPropertyName = "TenTuyen";
            this.TenTuyen.FillWeight = 6.594381F;
            this.TenTuyen.HeaderText = "Route Name";
            this.TenTuyen.MinimumWidth = 6;
            this.TenTuyen.Name = "TenTuyen";
            this.TenTuyen.ReadOnly = true;
            this.TenTuyen.Width = 125;
            // 
            // XuatPhat
            // 
            this.XuatPhat.DataPropertyName = "XuatPhat";
            this.XuatPhat.FillWeight = 6.594381F;
            this.XuatPhat.HeaderText = "Departure";
            this.XuatPhat.MinimumWidth = 6;
            this.XuatPhat.Name = "XuatPhat";
            this.XuatPhat.ReadOnly = true;
            this.XuatPhat.Width = 200;
            // 
            // DiaDiem
            // 
            this.DiaDiem.DataPropertyName = "DiaDiem";
            this.DiaDiem.FillWeight = 6.594381F;
            this.DiaDiem.HeaderText = "Destination";
            this.DiaDiem.MinimumWidth = 6;
            this.DiaDiem.Name = "DiaDiem";
            this.DiaDiem.ReadOnly = true;
            this.DiaDiem.Width = 200;
            // 
            // ThoiGianToChuc
            // 
            this.ThoiGianToChuc.DataPropertyName = "ThoiGianToChuc";
            this.ThoiGianToChuc.FillWeight = 172.553F;
            this.ThoiGianToChuc.HeaderText = "Date";
            this.ThoiGianToChuc.MinimumWidth = 6;
            this.ThoiGianToChuc.Name = "ThoiGianToChuc";
            this.ThoiGianToChuc.ReadOnly = true;
            this.ThoiGianToChuc.Width = 200;
            // 
            // TenLoaiTuyen
            // 
            this.TenLoaiTuyen.DataPropertyName = "TenLoaiTuyen";
            this.TenLoaiTuyen.FillWeight = 6.594381F;
            this.TenLoaiTuyen.HeaderText = "Type of Route";
            this.TenLoaiTuyen.MinimumWidth = 6;
            this.TenLoaiTuyen.Name = "TenLoaiTuyen";
            this.TenLoaiTuyen.ReadOnly = true;
            this.TenLoaiTuyen.Width = 125;
            // 
            // searchtxb
            // 
            this.searchtxb.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxb.Location = new System.Drawing.Point(545, 322);
            this.searchtxb.MaxLength = 100;
            this.searchtxb.Name = "searchtxb";
            this.searchtxb.Size = new System.Drawing.Size(257, 29);
            this.searchtxb.TabIndex = 3;
            this.searchtxb.TextChanged += new System.EventHandler(this.searchtxb_TextChanged);
            this.searchtxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchtxb_KeyPress);
            this.searchtxb.Leave += new System.EventHandler(this.searchtxb_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rdbInternational);
            this.groupBox2.Controls.Add(this.rdbNational);
            this.groupBox2.Controls.Add(this.nighttxb);
            this.groupBox2.Controls.Add(this.Destxb);
            this.groupBox2.Controls.Add(this.daytxb);
            this.groupBox2.Controls.Add(this.DLtxb);
            this.groupBox2.Controls.Add(this.tNametxb);
            this.groupBox2.Controls.Add(this.IDtxb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 195);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Route details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 23;
            this.label8.Text = "Duration";
            // 
            // rdbInternational
            // 
            this.rdbInternational.AutoSize = true;
            this.rdbInternational.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInternational.Location = new System.Drawing.Point(661, 90);
            this.rdbInternational.Margin = new System.Windows.Forms.Padding(2);
            this.rdbInternational.Name = "rdbInternational";
            this.rdbInternational.Size = new System.Drawing.Size(101, 23);
            this.rdbInternational.TabIndex = 22;
            this.rdbInternational.TabStop = true;
            this.rdbInternational.Text = "International";
            this.rdbInternational.UseVisualStyleBackColor = true;
            this.rdbInternational.Enter += new System.EventHandler(this.rdbInternational_Enter);
            // 
            // rdbNational
            // 
            this.rdbNational.AutoSize = true;
            this.rdbNational.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNational.Location = new System.Drawing.Point(530, 90);
            this.rdbNational.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNational.Name = "rdbNational";
            this.rdbNational.Size = new System.Drawing.Size(78, 23);
            this.rdbNational.TabIndex = 21;
            this.rdbNational.TabStop = true;
            this.rdbNational.Text = "National";
            this.rdbNational.UseVisualStyleBackColor = true;
            this.rdbNational.Enter += new System.EventHandler(this.rdbNational_Enter);
            // 
            // nighttxb
            // 
            this.nighttxb.Location = new System.Drawing.Point(661, 142);
            this.nighttxb.MaxLength = 2;
            this.nighttxb.Name = "nighttxb";
            this.nighttxb.Size = new System.Drawing.Size(35, 26);
            this.nighttxb.TabIndex = 18;
            this.nighttxb.Enter += new System.EventHandler(this.nighttxb_Enter);
            this.nighttxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nighttxb_KeyPress);
            // 
            // Destxb
            // 
            this.Destxb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destxb.Location = new System.Drawing.Point(121, 142);
            this.Destxb.MaxLength = 20;
            this.Destxb.Name = "Destxb";
            this.Destxb.Size = new System.Drawing.Size(242, 26);
            this.Destxb.TabIndex = 7;
            this.Destxb.Enter += new System.EventHandler(this.Destxb_Enter);
            // 
            // daytxb
            // 
            this.daytxb.Location = new System.Drawing.Point(530, 142);
            this.daytxb.MaxLength = 2;
            this.daytxb.Name = "daytxb";
            this.daytxb.Size = new System.Drawing.Size(39, 26);
            this.daytxb.TabIndex = 19;
            this.daytxb.Enter += new System.EventHandler(this.daytxb_Enter);
            this.daytxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.daytxb_KeyPress);
            // 
            // DLtxb
            // 
            this.DLtxb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLtxb.Location = new System.Drawing.Point(121, 89);
            this.DLtxb.MaxLength = 20;
            this.DLtxb.Name = "DLtxb";
            this.DLtxb.Size = new System.Drawing.Size(242, 26);
            this.DLtxb.TabIndex = 7;
            this.DLtxb.Enter += new System.EventHandler(this.DLtxb_Enter);
            // 
            // tNametxb
            // 
            this.tNametxb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNametxb.Location = new System.Drawing.Point(530, 36);
            this.tNametxb.MaxLength = 20;
            this.tNametxb.Name = "tNametxb";
            this.tNametxb.Size = new System.Drawing.Size(229, 26);
            this.tNametxb.TabIndex = 7;
            this.tNametxb.TextChanged += new System.EventHandler(this.tNametxb_TextChanged);
            this.tNametxb.Enter += new System.EventHandler(this.tNametxb_Enter);
            // 
            // IDtxb
            // 
            this.IDtxb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDtxb.Location = new System.Drawing.Point(121, 36);
            this.IDtxb.MaxLength = 20;
            this.IDtxb.Name = "IDtxb";
            this.IDtxb.ReadOnly = true;
            this.IDtxb.Size = new System.Drawing.Size(242, 26);
            this.IDtxb.TabIndex = 7;
            this.IDtxb.Enter += new System.EventHandler(this.IDtxb_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Departure";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(712, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "Nights";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(591, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Days";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(412, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Type of Route";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Route Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Route ID";
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.Transparent;
            this.exitbtn.BackgroundImage = global::Tour.Properties.Resources.Btn3;
            this.exitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitbtn.FlatAppearance.BorderSize = 0;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.Color.Red;
            this.exitbtn.Image = global::Tour.Properties.Resources.exit;
            this.exitbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitbtn.Location = new System.Drawing.Point(397, 316);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(100, 38);
            this.exitbtn.TabIndex = 8;
            this.exitbtn.Text = "  EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Tour.Properties.Resources.addp;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(27, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // Updatebtn
            // 
            this.Updatebtn.BackColor = System.Drawing.Color.Transparent;
            this.Updatebtn.BackgroundImage = global::Tour.Properties.Resources.Btn3;
            this.Updatebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Updatebtn.FlatAppearance.BorderSize = 0;
            this.Updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebtn.Image = global::Tour.Properties.Resources.update;
            this.Updatebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Updatebtn.Location = new System.Drawing.Point(148, 316);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(100, 38);
            this.Updatebtn.TabIndex = 7;
            this.Updatebtn.Text = "UPDATE";
            this.Updatebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BackColor = System.Drawing.Color.Transparent;
            this.Deletebtn.BackgroundImage = global::Tour.Properties.Resources.Btn3;
            this.Deletebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Deletebtn.FlatAppearance.BorderSize = 0;
            this.Deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.Image = global::Tour.Properties.Resources.deleteicon;
            this.Deletebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Deletebtn.Location = new System.Drawing.Point(271, 316);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(100, 38);
            this.Deletebtn.TabIndex = 6;
            this.Deletebtn.Text = "DELETE";
            this.Deletebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Tour.Properties.Resources.Tour1;
            this.panel1.Controls.Add(this.GotoTourbtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 77);
            this.panel1.TabIndex = 20;
            // 
            // GotoTourbtn
            // 
            this.GotoTourbtn.BackColor = System.Drawing.Color.Transparent;
            this.GotoTourbtn.BackgroundImage = global::Tour.Properties.Resources.Btn2;
            this.GotoTourbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GotoTourbtn.FlatAppearance.BorderSize = 0;
            this.GotoTourbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GotoTourbtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GotoTourbtn.Location = new System.Drawing.Point(725, 21);
            this.GotoTourbtn.Name = "GotoTourbtn";
            this.GotoTourbtn.Size = new System.Drawing.Size(115, 38);
            this.GotoTourbtn.TabIndex = 10;
            this.GotoTourbtn.Text = "Go to Tour";
            this.GotoTourbtn.UseVisualStyleBackColor = true;
            this.GotoTourbtn.Click += new System.EventHandler(this.GotoTourbtn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROUTE MANAGEMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(843, 656);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchtxb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Route";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route manage";
            this.Load += new System.EventHandler(this.TOUR_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox searchtxb;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button GotoTourbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox IDtxb;
        private System.Windows.Forms.RadioButton rdbInternational;
        private System.Windows.Forms.RadioButton rdbNational;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox daytxb;
        private System.Windows.Forms.TextBox nighttxb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Destxb;
        private System.Windows.Forms.TextBox DLtxb;
        private System.Windows.Forms.TextBox tNametxb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn XuatPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianToChuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiTuyen;
    }
}

