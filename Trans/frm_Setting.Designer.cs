namespace Trans
{
    partial class frm_Setting
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
            this.tab_setting = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.cvr = new System.Windows.Forms.CheckBox();
            this.bt_done = new System.Windows.Forms.Button();
            this.g_output = new System.Windows.Forms.GroupBox();
            this.lboutput = new System.Windows.Forms.ListBox();
            this.g_input = new System.Windows.Forms.GroupBox();
            this.lbinput = new System.Windows.Forms.ListBox();
            this.lbminp = new System.Windows.Forms.Label();
            this.lbmaxp = new System.Windows.Forms.Label();
            this.txt_maxp = new System.Windows.Forms.TextBox();
            this.txt_minp = new System.Windows.Forms.TextBox();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tab_setting.SuspendLayout();
            this.tp1.SuspendLayout();
            this.g_output.SuspendLayout();
            this.g_input.SuspendLayout();
            this.tp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_setting
            // 
            this.tab_setting.Controls.Add(this.tp1);
            this.tab_setting.Controls.Add(this.tp2);
            this.tab_setting.Location = new System.Drawing.Point(0, 0);
            this.tab_setting.Name = "tab_setting";
            this.tab_setting.SelectedIndex = 0;
            this.tab_setting.Size = new System.Drawing.Size(313, 390);
            this.tab_setting.TabIndex = 0;
            // 
            // tp1
            // 
            this.tp1.Controls.Add(this.button1);
            this.tp1.Controls.Add(this.cvr);
            this.tp1.Controls.Add(this.bt_done);
            this.tp1.Controls.Add(this.g_output);
            this.tp1.Controls.Add(this.g_input);
            this.tp1.Controls.Add(this.lbminp);
            this.tp1.Controls.Add(this.lbmaxp);
            this.tp1.Controls.Add(this.txt_maxp);
            this.tp1.Controls.Add(this.txt_minp);
            this.tp1.Location = new System.Drawing.Point(4, 22);
            this.tp1.Name = "tp1";
            this.tp1.Padding = new System.Windows.Forms.Padding(3);
            this.tp1.Size = new System.Drawing.Size(305, 364);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "Setting";
            this.tp1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cvr
            // 
            this.cvr.AutoSize = true;
            this.cvr.Checked = true;
            this.cvr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cvr.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cvr.Location = new System.Drawing.Point(6, 8);
            this.cvr.Name = "cvr";
            this.cvr.Size = new System.Drawing.Size(98, 16);
            this.cvr.TabIndex = 7;
            this.cvr.Text = "Voice Record";
            this.cvr.UseVisualStyleBackColor = true;
            this.cvr.CheckedChanged += new System.EventHandler(this.cvr_CheckedChanged);
            // 
            // bt_done
            // 
            this.bt_done.Location = new System.Drawing.Point(190, 298);
            this.bt_done.Name = "bt_done";
            this.bt_done.Size = new System.Drawing.Size(58, 21);
            this.bt_done.TabIndex = 6;
            this.bt_done.Text = "Ok";
            this.bt_done.UseVisualStyleBackColor = true;
            this.bt_done.Click += new System.EventHandler(this.bt_done_Click);
            // 
            // g_output
            // 
            this.g_output.Controls.Add(this.lboutput);
            this.g_output.Location = new System.Drawing.Point(8, 192);
            this.g_output.Name = "g_output";
            this.g_output.Size = new System.Drawing.Size(240, 100);
            this.g_output.TabIndex = 5;
            this.g_output.TabStop = false;
            this.g_output.Text = "Output Device";
            // 
            // lboutput
            // 
            this.lboutput.FormattingEnabled = true;
            this.lboutput.ItemHeight = 12;
            this.lboutput.Location = new System.Drawing.Point(7, 19);
            this.lboutput.Name = "lboutput";
            this.lboutput.Size = new System.Drawing.Size(223, 76);
            this.lboutput.TabIndex = 0;
            this.lboutput.SelectedIndexChanged += new System.EventHandler(this.lboutput_SelectedIndexChanged);
            // 
            // g_input
            // 
            this.g_input.Controls.Add(this.lbinput);
            this.g_input.Location = new System.Drawing.Point(8, 86);
            this.g_input.Name = "g_input";
            this.g_input.Size = new System.Drawing.Size(240, 100);
            this.g_input.TabIndex = 4;
            this.g_input.TabStop = false;
            this.g_input.Text = "Input Device";
            // 
            // lbinput
            // 
            this.lbinput.FormattingEnabled = true;
            this.lbinput.ItemHeight = 12;
            this.lbinput.Location = new System.Drawing.Point(7, 19);
            this.lbinput.Name = "lbinput";
            this.lbinput.Size = new System.Drawing.Size(223, 76);
            this.lbinput.TabIndex = 0;
            this.lbinput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbinput_MouseDoubleClick);
            // 
            // lbminp
            // 
            this.lbminp.AutoSize = true;
            this.lbminp.Location = new System.Drawing.Point(6, 60);
            this.lbminp.Name = "lbminp";
            this.lbminp.Size = new System.Drawing.Size(63, 12);
            this.lbminp.TabIndex = 3;
            this.lbminp.Text = "Min Pich :";
            // 
            // lbmaxp
            // 
            this.lbmaxp.AutoSize = true;
            this.lbmaxp.Location = new System.Drawing.Point(6, 34);
            this.lbmaxp.Name = "lbmaxp";
            this.lbmaxp.Size = new System.Drawing.Size(63, 12);
            this.lbmaxp.TabIndex = 2;
            this.lbmaxp.Text = "Max Pich:";
            // 
            // txt_maxp
            // 
            this.txt_maxp.Location = new System.Drawing.Point(72, 28);
            this.txt_maxp.Name = "txt_maxp";
            this.txt_maxp.Size = new System.Drawing.Size(81, 21);
            this.txt_maxp.TabIndex = 1;
            this.txt_maxp.Text = "0.007";
            // 
            // txt_minp
            // 
            this.txt_minp.Location = new System.Drawing.Point(72, 55);
            this.txt_minp.Name = "txt_minp";
            this.txt_minp.Size = new System.Drawing.Size(81, 21);
            this.txt_minp.TabIndex = 0;
            this.txt_minp.Text = "0.001";
            // 
            // tp2
            // 
            this.tp2.Controls.Add(this.textBox1);
            this.tp2.Location = new System.Drawing.Point(4, 22);
            this.tp2.Name = "tp2";
            this.tp2.Size = new System.Drawing.Size(305, 364);
            this.tp2.TabIndex = 1;
            this.tp2.Text = "Chrome";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 21);
            this.textBox1.TabIndex = 0;
            // 
            // frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 390);
            this.Controls.Add(this.tab_setting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Setting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frm_Setting_Load);
            this.tab_setting.ResumeLayout(false);
            this.tp1.ResumeLayout(false);
            this.tp1.PerformLayout();
            this.g_output.ResumeLayout(false);
            this.g_input.ResumeLayout(false);
            this.tp2.ResumeLayout(false);
            this.tp2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_setting;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.Label lbminp;
        private System.Windows.Forms.Label lbmaxp;
        private System.Windows.Forms.TextBox txt_maxp;
        private System.Windows.Forms.TextBox txt_minp;
        private System.Windows.Forms.GroupBox g_output;
        private System.Windows.Forms.ListBox lboutput;
        private System.Windows.Forms.GroupBox g_input;
        private System.Windows.Forms.ListBox lbinput;
        private System.Windows.Forms.Button bt_done;
        private System.Windows.Forms.CheckBox cvr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.TextBox textBox1;
    }
}