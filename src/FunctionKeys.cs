using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novel
{
    internal class FunctionKeys
    {
        novel novel = null;
        Functions functions = null;

        public FunctionKeys() { }
        public FunctionKeys(novel novel, Functions functions)
        {
            this.novel = novel;
            this.functions = functions;
        }

        public void excute(PreviewKeyDownEventArgs e, CustomRichText customRich)
        {
            if (e.KeyData == Keys.Control && e.KeyData == Keys.Home)
            {
                settings a = new settings(novel, functions);
                a.Show();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                functions.saveFile();
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                functions.saveAsFile();
            }

            if (e.KeyData == (Keys.Control | Keys.F) || e.KeyData == (Keys.Control | Keys.H))
            {
                functions.KeyWordOpen();
            }


            if (e.KeyData == (Keys.Control | Keys.F11))
            {
                functions.topMost();
            }

            if (e.KeyData == Keys.F1)
            {
                if (novel.checkBox3.Checked == true)
                {
                    customRich.SelectionBackColor = Color.OrangeRed;
                    customRich.DeselectAll();
                    customRich.SelectionBackColor = Color.FromArgb(45, 45, 45);
                }
                else
                {
                    customRich.SelectionBackColor = Color.OrangeRed;
                    customRich.DeselectAll();
                    customRich.SelectionBackColor = Color.White;
                }
            }

            if (e.KeyData == Keys.F2)
            {
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = functions.F2;
                customRich.Focus();
            }
            if (e.KeyData == Keys.F3)
            {
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = functions.F3;
                customRich.Focus();
            }
            if (e.KeyData == Keys.F4)
            {
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = functions.F4;
                customRich.Focus();
            }
            if (e.KeyData == Keys.F5)
            {
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = functions.F5;
                customRich.Focus();
            }

            if (e.KeyData == Keys.F10)
            {
                DateTime a = DateTime.Now;
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = (a.ToString("yyyy年MM月dd日dddd"));
            }

            if (e.KeyData == Keys.F11)
            {
                if (customRich.SelectedText.Length == 0)
                    customRich.SelectedText = ("\r\n起\r\n\r\n承\r\n\r\n転\r\n\r\n結\r\n\r\n");
            }

            if (e.KeyData == Keys.F12)
            {
                if (novel.panel1.Visible == true)
                {
                    novel.panel1.Visible = false;
                }
                else
                {
                    novel.panel1.Visible = true;
                }
            }

            if (e.KeyData == Keys.Escape)
            {
                if (novel.checkBox3.Checked == true)
                {
                    customRich.SelectionBackColor = Color.FromArgb(45, 45, 45);
                    customRich.DeselectAll();
                }
                else
                {
                    customRich.DeselectAll();
                    customRich.SelectionBackColor = Color.White;
                    customRich.DeselectAll();
                }
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.PageUp))
            {
                functions.split();
            }
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                functions.Secret();
            }
            if (e.KeyData == (Keys.Control | Keys.Tab))
            {
                novel.ActiveControl = customRich;
            }
        }
    }
}
