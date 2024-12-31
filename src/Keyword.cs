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
        novel novel;

        private int pos = -1;
        private int prv = -1;
        private string text;
        private string search;
        internal Keyword(novel novel, Functions functions)
        {
            this.novel = novel;
            InitializeComponent();
        }

        private void next()
        {
            try
            {
                if (pos != -1)
                {
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search, pos + 1);
                    novel.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    novel.customRichText1.Focus();
                    //novel.customRichText1.ScrollToCaret();
                    novel.customRichText1.SelectionStart = pos;
                    novel.customRichText1.SelectionLength = search.Length;
                    this.Focus();
                }
                else
                {
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search);
                    novel.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    novel.customRichText1.Focus();
                    //novel.customRichText1.ScrollToCaret();
                    novel.customRichText1.SelectionStart = pos;
                    novel.customRichText1.SelectionLength = search.Length;
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
        }

        private void preview()
        {
            try
            {
                if (prv != -1)
                {
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    prv = text.LastIndexOf(search, prv - 1);
                    novel.customRichText1.SelectionStart = prv;
                    //テキストボックスにフォーカスを移動
                    novel.customRichText1.Focus();
                    novel.customRichText1.SelectionStart = prv;
                    novel.customRichText1.SelectionLength = search.Length;
                    //novel.customRichText1.ScrollToCaret();
                    this.Focus();
                }
                else
                {
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    prv = text.LastIndexOf(search);
                    novel.customRichText1.SelectionStart = prv;
                    //テキストボックスにフォーカスを移動
                    novel.customRichText1.Focus();
                    novel.customRichText1.SelectionStart = prv;
                    novel.customRichText1.SelectionLength = search.Length;
                    //novel.customRichText1.ScrollToCaret();
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
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search, pos + 1);
                    novel.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(novel.customRichText1.Text);
                    sb.Replace(search, textBox2.Text, pos, search.Length);
                    novel.customRichText1.Text = sb.ToString();
                    novel.customRichText1.Focus();
                    //novel.customRichText1.ScrollToCaret();
                    novel.customRichText1.SelectionStart = pos;
                    novel.customRichText1.SelectionLength = search.Length;

                    this.Focus();
                }
                else
                {
                    text = novel.customRichText1.Text;
                    search = textBox1.Text;

                    pos = text.IndexOf(search);
                    novel.customRichText1.SelectionStart = pos;
                    //テキストボックスにフォーカスを移動
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(novel.customRichText1.Text);
                    sb.Replace(search, textBox2.Text, pos, search.Length);
                    novel.customRichText1.Text = sb.ToString();
                    novel.customRichText1.Focus();
                    //novel.customRichText1.ScrollToCaret();
                    novel.customRichText1.SelectionStart = pos;
                    novel.customRichText1.SelectionLength = search.Length;
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
                        text = novel.customRichText1.Text;
                        search = textBox1.Text;

                        pos = text.IndexOf(search, pos + 1);
                        novel.customRichText1.SelectionStart = pos;
                        //テキストボックスにフォーカスを移動
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(novel.customRichText1.Text);
                        sb.Replace(search, textBox2.Text, pos, search.Length);
                        novel.customRichText1.Text = sb.ToString();
                        novel.customRichText1.Focus();
                        //novel.customRichText1.ScrollToCaret();
                        novel.customRichText1.SelectionStart = pos;
                        novel.customRichText1.SelectionLength = search.Length;

                        this.Focus();
                    }
                    else
                    {
                        text = novel.customRichText1.Text;
                        search = textBox1.Text;

                        pos = text.IndexOf(search);
                        novel.customRichText1.SelectionStart = pos;
                        //テキストボックスにフォーカスを移動
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(novel.customRichText1.Text);
                        sb.Replace(search, textBox2.Text, pos, search.Length);
                        novel.customRichText1.Text = sb.ToString();
                        novel.customRichText1.Focus();
                        //novel.customRichText1.ScrollToCaret();
                        novel.customRichText1.SelectionStart = pos;
                        novel.customRichText1.SelectionLength = search.Length;
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