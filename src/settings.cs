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
        novel novel;
        Functions functions;
        internal settings(novel novel, Functions funcitons)
        {
            InitializeComponent();
            this.novel = novel;
        }

        string[] files;
        private void settings_Load(object sender, EventArgs e)
        {
            files = System.IO.Directory.GetFiles(
            $@"{System.AppDomain.CurrentDomain.BaseDirectory}Settings\Image", "*", System.IO.SearchOption.AllDirectories);

            this.TopMost = !this.TopMost;
            for (int i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
            }
            novel.BackgroundImageLayout = ImageLayout.Center;
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (File.Exists(files[listBox1.SelectedIndex]))
                {
                    novel.BackgroundImage = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                }
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (File.Exists(files[listBox1.SelectedIndex]))
                {
                    novel.BackgroundImage = System.Drawing.Image.FromFile(files[listBox1.SelectedIndex]);
                }
            }
            else
            {
                novel.BackgroundImage = null;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(files[listBox1.SelectedIndex]);
            }
            catch (Exception ex)
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
                functions.tabSwitch = true;
            }
            else
            {
                functions.tabSwitch = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            novel.customRichText1.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            novel.customRichText2.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            novel.customRichText3.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);

            novel.BackColor = Color.FromArgb(colorPickEdit1.Color.R, colorPickEdit1.Color.G, colorPickEdit1.Color.B);
            novel.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);

            novel.customRichText1.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
            novel.customRichText2.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
            novel.customRichText3.ForeColor = Color.FromArgb(colorPickEdit2.Color.R, colorPickEdit2.Color.G, colorPickEdit2.Color.B);
        }
    }
}
