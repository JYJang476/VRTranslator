namespace Trans
{
    partial class frm_trans
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtt = new System.Windows.Forms.TextBox();
            this.starttrans = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tm_wave = new System.Windows.Forms.Timer(this.components);
            this._tmex = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.btchange = new System.Windows.Forms.Button();
            this.lbsolist = new System.Windows.Forms.ListBox();
            this.bt_setting = new System.Windows.Forms.Button();
            this.txt_ori = new System.Windows.Forms.ComboBox();
            this.txt_sor = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtt
            // 
            this.txtt.Location = new System.Drawing.Point(29, 240);
            this.txtt.Multiline = true;
            this.txtt.Name = "txtt";
            this.txtt.Size = new System.Drawing.Size(332, 163);
            this.txtt.TabIndex = 1;
            this.txtt.Visible = false;
            // 
            // starttrans
            // 
            this.starttrans.Location = new System.Drawing.Point(102, 56);
            this.starttrans.Name = "starttrans";
            this.starttrans.Size = new System.Drawing.Size(81, 25);
            this.starttrans.TabIndex = 2;
            this.starttrans.Text = "Start";
            this.starttrans.UseVisualStyleBackColor = true;
            this.starttrans.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, -3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 18);
            this.button2.TabIndex = 6;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Setting";
            // 
            // tm_wave
            // 
            this.tm_wave.Interval = 1;
            this.tm_wave.Tick += new System.EventHandler(this.tm_wave_Tick);
            // 
            // _tmex
            // 
            this._tmex.Interval = 1000;
            this._tmex.Tick += new System.EventHandler(this._tmex_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btchange
            // 
            this.btchange.Location = new System.Drawing.Point(262, 17);
            this.btchange.Name = "btchange";
            this.btchange.Size = new System.Drawing.Size(75, 20);
            this.btchange.TabIndex = 10;
            this.btchange.Text = "Change";
            this.btchange.UseVisualStyleBackColor = true;
            this.btchange.Click += new System.EventHandler(this.btchange_Click);
            // 
            // lbsolist
            // 
            this.lbsolist.FormattingEnabled = true;
            this.lbsolist.ItemHeight = 12;
            this.lbsolist.Location = new System.Drawing.Point(29, 86);
            this.lbsolist.Name = "lbsolist";
            this.lbsolist.Size = new System.Drawing.Size(332, 148);
            this.lbsolist.TabIndex = 11;
            this.lbsolist.Visible = false;
            this.lbsolist.DoubleClick += new System.EventHandler(this.lbsolist_DoubleClick);
            // 
            // bt_setting
            // 
            this.bt_setting.Location = new System.Drawing.Point(320, 53);
            this.bt_setting.Name = "bt_setting";
            this.bt_setting.Size = new System.Drawing.Size(75, 21);
            this.bt_setting.TabIndex = 12;
            this.bt_setting.Text = "Setting";
            this.bt_setting.UseVisualStyleBackColor = true;
            this.bt_setting.Visible = false;
            this.bt_setting.Click += new System.EventHandler(this.bt_setting_Click);
            // 
            // txt_ori
            // 
            this.txt_ori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_ori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_ori.FormattingEnabled = true;
            this.txt_ori.Items.AddRange(new object[] {
            "English",
            "Japanese",
            "Korean"});
            this.txt_ori.Location = new System.Drawing.Point(7, 17);
            this.txt_ori.Name = "txt_ori";
            this.txt_ori.Size = new System.Drawing.Size(114, 20);
            this.txt_ori.TabIndex = 13;
            this.txt_ori.SelectedIndexChanged += new System.EventHandler(this.txt_ori_SelectedIndexChanged);
            // 
            // txt_sor
            // 
            this.txt_sor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_sor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_sor.FormattingEnabled = true;
            this.txt_sor.Items.AddRange(new object[] {
            "English",
            "Japanese",
            "Korean"});
            this.txt_sor.Location = new System.Drawing.Point(147, 17);
            this.txt_sor.Name = "txt_sor";
            this.txt_sor.Size = new System.Drawing.Size(108, 20);
            this.txt_sor.TabIndex = 14;
            this.txt_sor.SelectedIndexChanged += new System.EventHandler(this.txt_sor_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, -5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_sor);
            this.groupBox1.Controls.Add(this.txt_ori);
            this.groupBox1.Controls.Add(this.btchange);
            this.groupBox1.Location = new System.Drawing.Point(17, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(125, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = ">";
            // 
            // frm_trans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 85);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_setting);
            this.Controls.Add(this.lbsolist);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.starttrans);
            this.Controls.Add(this.txtt);
            this.Name = "frm_trans";
            this.Text = "VR Translator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_trans_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button starttrans;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tm_wave;
        private System.Windows.Forms.Timer _tmex;
        public System.Windows.Forms.TextBox txtt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btchange;
        private System.Windows.Forms.ListBox lbsolist;
        private System.Windows.Forms.Button bt_setting;
        public System.Windows.Forms.ComboBox txt_ori;
        public System.Windows.Forms.ComboBox txt_sor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
    }
}

