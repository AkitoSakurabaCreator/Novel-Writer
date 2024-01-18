using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novel
{
    public partial class settings : Form
    {
        novel f;
        public settings(novel f)
        {
            InitializeComponent();
            this.f = f;
        }

        string[] files;
        private void settings_Load(object sender, EventArgs e)
        {
            files = System.IO.Directory.GetFiles(
            $@"{System.AppDomain.CurrentDomain.BaseDirectory}Settings\Image", "*", System.IO.SearchOption.AllDirectories);

            this.TopMost = !this.TopMost;
            for(int i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
            }
            f.BackgroundImageLayout = ImageLayout.Center;
            //f.pictureBox1.Layout = ImageLayout.Center;
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (File.Exists(files[listBox1.SelectedIndex]))
                {
                    f.BackgroundImage = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                    //f.pictureBox1.Image = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                }
            }  
            
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (File.Exists(files[listBox1.SelectedIndex]))
                {
                    f.BackgroundImage = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                    //f.pictureBox1.Image = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                }
            }
            else
            {
                f.BackgroundImage = null;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(files[listBox1.SelectedIndex]);
            }catch(Exception ex)
            {

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            files = System.IO.Directory.GetFiles(
           $@"{System.AppDomain.CurrentDomain.BaseDirectory}Settings\Image", "*", System.IO.SearchOption.AllDirectories);
            listBox1.Items.Clear();
            for (int i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                f.tabSwitch = true;
            }
            else
            {
                f.tabSwitch = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            f.customRichText1.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            f.customRichText2.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            f.customRichText3.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);

            f.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            f.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);

            f.customRichText1.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
            f.customRichText2.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
            f.customRichText3.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
        }
    }
}
