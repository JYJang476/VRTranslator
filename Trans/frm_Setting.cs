using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.CoreAudioApi;

namespace Trans
{
    public partial class frm_Setting : Form
    {
        frm_trans ft = new frm_trans();
        public int inputindex, outputindex;

        public frm_Setting()
        {
            InitializeComponent();
        }

        private void bt_done_Click(object sender, EventArgs e)
        {
            ft.maxp = float.Parse(txt_maxp.Text);
            ft.minp = float.Parse(txt_minp.Text);

            ft.voicerec = cvr.Checked;

            this.Close();
        }

        private void lbinput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbinput.SelectedIndex == outputindex)
            {
               DialogResult dr = MessageBox.Show("듣기 장치와 중첩됩니다 바꾸시겠습니까?", "경고", MessageBoxButtons.YesNo);
               if(dr == DialogResult.OK) inputindex = lbinput.SelectedIndex;
            }
        }

        private void lboutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboutput.SelectedIndex == inputindex)
            {
                DialogResult dr = MessageBox.Show("마이크와 중첩됩니다 바꾸시겠습니까?", "경고", MessageBoxButtons.YesNo);
                if (dr == DialogResult.OK) outputindex = lboutput.SelectedIndex;
            }
        }

        private void cvr_CheckedChanged(object sender, EventArgs e)
        {
            if(!cvr.Checked)
            {
                lbmaxp.Enabled = false;
                lbminp.Enabled = false;
                txt_maxp.Enabled = false;
                txt_minp.Enabled = false;
            }
            else if(cvr.Checked)
            {
                lbmaxp.Enabled = true;
                lbminp.Enabled = true;
                txt_maxp.Enabled = true;
                txt_minp.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundDevice sd = new SoundDevice();

            sd.SetDeviceEnable("Realtek High Definition Audio", false);

        }

        private void frm_Setting_Load(object sender, EventArgs e)
        {
            SoundDevice sd = new SoundDevice();
            List<MMDevice> gmd = sd.GetInputDeviceList();
            

            
            foreach (MMDevice md in gmd)
            {

                lbinput.Items.Add(md.FriendlyName);
                lboutput.Items.Add(md.FriendlyName);

            }
        }
    }
}
