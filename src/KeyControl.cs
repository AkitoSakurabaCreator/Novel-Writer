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
        novel novel = null;
        Functions functions = null;

        public KeyControl()
        {
            InitializeComponent();
        }
        internal KeyControl(novel novel, Functions functions)
        {
            this.novel = novel;
            this.functions = functions;
            InitializeComponent();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            functions.F2 = textBox1.Text;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            functions.F3 = textBox2.Text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            functions.F4 = textBox3.Text;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            functions.F5 = textBox4.Text;
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