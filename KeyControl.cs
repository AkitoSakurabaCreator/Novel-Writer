using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using novel;

namespace novel
{
    public partial class KeyControl : DevExpress.XtraEditors.XtraForm
    {
        novel f1;
        public KeyControl(novel f)
        {
            f1 = f;
            InitializeComponent();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            /*
            TextBox f1_F2 = (TextBox)f1.Controls["F2"];
            f1_F2.Text = this.textBox1.Text;
            */
            f1.F2 = textBox1.Text;
            /*
            Label f1_F2 = (Label)f1.Controls["label9"];
            f1_F2.Text = this.textBox1.Text;
            */
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            f1.F3 = textBox2.Text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            f1.F4 = textBox3.Text;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            f1.F5 = textBox4.Text;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeyF2 = textBox1.Text;
            Properties.Settings.Default.KeyF3 = textBox2.Text;
            Properties.Settings.Default.KeyF4 = textBox3.Text;
            Properties.Settings.Default.KeyF5 = textBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void KeyControl_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.KeyF2;
            textBox2.Text = Properties.Settings.Default.KeyF3;
            textBox3.Text = Properties.Settings.Default.KeyF4;
            textBox4.Text = Properties.Settings.Default.KeyF5;
        }
    }
}