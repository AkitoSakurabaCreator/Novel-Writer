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

namespace novel
{
    public partial class Keyword : DevExpress.XtraEditors.XtraForm
    {
        novel f1;

        private int pos = -1;
        private int prv = -1;
        private string text;
        private string search;
        /*
        public KeyControl(novel f)
        {
            f1 = f;
            InitializeComponent();
        }
        */
        public Keyword(novel f)
        {
            f1 = f;
            InitializeComponent();
        }

        private void next()
        {
            try
            {
                if (pos != -1)
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search, pos + 1);
                    f1.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    f1.customRichText1.Focus();
                    //f1.customRichText1.ScrollToCaret();
                    f1.customRichText1.SelectionStart = pos;
                    f1.customRichText1.SelectionLength = search.Length;
                    this.Focus();
                }
                else
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search);
                    f1.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    f1.customRichText1.Focus();
                    //f1.customRichText1.ScrollToCaret();
                    f1.customRichText1.SelectionStart = pos;
                    f1.customRichText1.SelectionLength = search.Length;
                    this.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("文字が該当しません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            next();
            //string str = f1.customRichText1.Text;
            //f1.F2.Text = textBox1.Text;



            //対象文字列.Remove(消去を開始したい位置,消去したい文字数)
            //string next = str.Remove(pos, Text.Length);
            //textBox_Output.Text += string.Format("{0:d} 文字目で該当しました。\r\n", pos);
        }

        private void preview()
        {
            try
            {
                if (prv != -1)
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    prv = text.LastIndexOf(search, prv - 1);
                    f1.customRichText1.SelectionStart = prv;
                    //テキストボックスにフォーカスを移動
                    f1.customRichText1.Focus();
                    f1.customRichText1.SelectionStart = prv;
                    f1.customRichText1.SelectionLength = search.Length;
                    //f1.customRichText1.ScrollToCaret();
                    this.Focus();
                }
                else
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    prv = text.LastIndexOf(search);
                    f1.customRichText1.SelectionStart = prv;
                    //テキストボックスにフォーカスを移動
                    f1.customRichText1.Focus();
                    f1.customRichText1.SelectionStart = prv;
                    f1.customRichText1.SelectionLength = search.Length;
                    //f1.customRichText1.ScrollToCaret();
                    this.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("文字が該当しません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            preview();
        }
        private void Keyword_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
            this.TopMost = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                next();
            }

            if (e.KeyData == (Keys.Shift | Keys.Enter))
            {
                preview();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pos != -1)
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search, pos + 1);
                    f1.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(f1.customRichText1.Text);
                    sb.Replace(search, textBox2.Text, pos, search.Length);
                    f1.customRichText1.Text = sb.ToString();
                    f1.customRichText1.Focus();
                    //f1.customRichText1.ScrollToCaret();
                    f1.customRichText1.SelectionStart = pos;
                    f1.customRichText1.SelectionLength = search.Length;
                    
                    this.Focus();
                }
                else
                {
                    text = f1.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search);
                    f1.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(f1.customRichText1.Text);
                    sb.Replace(search, textBox2.Text, pos, search.Length);
                    f1.customRichText1.Text = sb.ToString();
                    f1.customRichText1.Focus();
                    //f1.customRichText1.ScrollToCaret();
                    f1.customRichText1.SelectionStart = pos;
                    f1.customRichText1.SelectionLength = search.Length;
                    this.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("文字が該当しません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            while (true)
            {
                try
                {
                    if (pos != -1)
                    {
                        text = f1.customRichText1.Text;
                        search = textBox1.Text;

                        pos = text.IndexOf(search, pos + 1);
                        f1.customRichText1.SelectionStart = pos;
                        //テキストボックスにフォーカスを移動
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(f1.customRichText1.Text);
                        sb.Replace(search, textBox2.Text, pos, search.Length);
                        f1.customRichText1.Text = sb.ToString();
                        f1.customRichText1.Focus();
                        //f1.customRichText1.ScrollToCaret();
                        f1.customRichText1.SelectionStart = pos;
                        f1.customRichText1.SelectionLength = search.Length;

                        this.Focus();
                    }
                    else
                    {
                        text = f1.customRichText1.Text;
                        search = textBox1.Text;

                        pos = text.IndexOf(search);
                        f1.customRichText1.SelectionStart = pos;
                        //テキストボックスにフォーカスを移動
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(f1.customRichText1.Text);
                        sb.Replace(search, textBox2.Text, pos, search.Length);
                        f1.customRichText1.Text = sb.ToString();
                        f1.customRichText1.Focus();
                        //f1.customRichText1.ScrollToCaret();
                        f1.customRichText1.SelectionStart = pos;
                        f1.customRichText1.SelectionLength = search.Length;
                        this.Focus();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("全ての置換が完了しました。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }
    }
}