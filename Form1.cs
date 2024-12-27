using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using RegexTest;
using DevExpress.XtraEditors;
using System.IO;
using System.Net;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Novel_Writer;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.Threading;


namespace novel
{
    public partial class novel : Form
    {

        private bool autoenter = true;
        Functions functions = null;
        FunctionKeys functionKeys = null;
        string[] args;
        static readonly Func<string, string> EscapeCommandArg = x => x.Contains(' ') ? string.Format("\"{0}\"", x) : x;
        static readonly Func<string[], string> ToCommandArgs = x => string.Join(" ", x.Select(EscapeCommandArg));

        public novel()
        {
            functions = new Functions(this);
            functionKeys = new FunctionKeys(this, functions);
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
            functions.loading();
        }
        public novel(string file)
        {
            functions = new Functions(this, file);
            functionKeys = new FunctionKeys(this, functions);
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
            functions.loading();
        }


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CustomRichText1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            functions.saveAsFile();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

        }



        private void simpleButton6_Click(object sender, EventArgs e)
        {
            functions.print();
        }




        private void novel_Load(object sender, EventArgs e)
        {
        }




        private void simpleButton10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void regexMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            functions.memoPanel();
        }

        private void CustomRichText1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void customRichText1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void customRichText1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CustomRichText1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            customRichText1.SelectionStart = customRichText1.Text.Length;
            //テキストボックスにフォーカスを移動
            customRichText1.Focus();
            customRichText1.ScrollToCaret();
        }

        private void コピーするToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novel_writer_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            functions.topMost();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.font = comboBox2.Text;
            Properties.Settings.Default.fontweight = comboBox4.Text;
            Properties.Settings.Default.fontsize = (int)float.Parse(comboBox3.Text);
            Properties.Settings.Default.Save();
            functions.changeFont();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            KeyControl keyControl = new KeyControl(this, functions);
            keyControl.Show();
        }
        public static Bitmap ToBmp(Control control)
        {
            control.Update();
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.CopyFromScreen(control.PointToScreen(Point.Empty), Point.Empty, control.Size);
            }
            return bmp;
        }

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        public static Bitmap CaptureControl(Control target)
        {
            Bitmap caputuredBitmap;
            using (Graphics targetGraphic = target.CreateGraphics())
            {
                caputuredBitmap = new Bitmap(target.Width, target.Height);
                using (Graphics capturedGraphics = Graphics.FromImage(caputuredBitmap))
                {
                    IntPtr targetDc = targetGraphic.GetHdc();
                    IntPtr capturedDc = capturedGraphics.GetHdc();
                    BitBlt(capturedDc, 0, 0, target.Width, target.Height, targetDc, 0, 0, 0xCC0020);
                    targetGraphic.ReleaseHdc(targetDc);
                    capturedGraphics.ReleaseHdc(capturedDc);
                }
            }

            return caputuredBitmap;
        }
        private void simpleButton19_Click(object sender, EventArgs e)
        {

            XtraMessageBox.Show("ファイルバージョンは:" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location) + "\r\nダウンロードしていただき、ありがとうございます。\r\n制作者: 桜羽 明人\r\nTwitter:@_sakuraba_akito", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            functions.saveAsPdf();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            string result = dt.ToString("時刻: " + "yyyy/MM/dd HH:mm:ss");
            label11.Text = result;
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            //テキストボックスにフォーカスを移動
            customRichText1.Focus();
            customRichText1.SelectionStart = 0;
            customRichText1.ScrollToCaret();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            functions.KeyWordOpen();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (trackBarControl1.Value > 0)
            {
                this.Opacity = trackBarControl1.Value * 0.1;
            }
            else if (trackBarControl1.Value <= 0)
            {
                trackBarControl1.Value = 1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            functions.clock(checkBox2);
        }

        private void CheckBoxClock_TextChanged(object sender, EventArgs e)
        {

        }

        private void コピーCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, customRichText1.SelectedRtf);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 貼り付けCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                customRichText1.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        private void 切り取りCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customRichText1.Cut();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                functions.themeChangeColor(checkBox3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            functions.print();
        }

        private void novel_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void CustomRichText2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void novel_FormClosing(object sender, FormClosingEventArgs e)
        {
            functions.exiting(e);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void simpleButton23_Click(object sender, EventArgs e)
        {
            functions.split();
        }

        private void CustomRichText1_LinkClicked(object sender, LinkClickedEventArgs e)
        {

        }

        private void CustomRichText2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            functions.fontChange();
        }

        private void CustomRichText2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomRichText3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CustomRichText3_TextChanged(object sender, EventArgs e)
        {

        }

        private void customRichText3_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void customRichText3_LinkClicked(object sender, LinkClickedEventArgs e)
        {

        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            functions.changeFont();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            functions.changeFont();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            functions.changeFont();
        }

        private void customRichText1_TextChanged(object sender, EventArgs e)
        {
            if (autoenter)
            {
                customRichText3.Text = customRichText1.Text;
            }

            functions.countChange();
            functions.fontChange();
            functions.autoSaveChanege();
        }

        private void customRichText1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!autoenter)
            {
                autoenter = true;
            }
            functionKeys.excute(e, customRichText1);
        }

        private void customRichText1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void customRichText1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void customRichText2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void customRichText2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void customRichText2_TextChanged(object sender, EventArgs e)
        {

        }

        private void customRichText3_TextChanged(object sender, EventArgs e)
        {
            if (!autoenter)
            {
                customRichText3.Text = customRichText1.Text;
            }
        }

        private void customRichText3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void customRichText3_LinkClicked_1(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            settings setting = new settings(this, functions);
            setting.Show();
        }

        private void customRichText1_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void customRichText2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void customRichText3_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void customRichText1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void customRichText2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            functionKeys.excute(e, customRichText2);
        }

        private void customRichText3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!autoenter)
            {
                autoenter = true;
            }
        }

        private void novel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            functionKeys.excute(e, customRichText1);
        }
    }
}