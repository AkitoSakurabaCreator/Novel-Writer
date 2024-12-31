using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraEditors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Document = iTextSharp.text.Document;
using Paragraph = iTextSharp.text.Paragraph;

namespace novel
{
    internal class Functions
    {
        novel novel = null;
        string url = "";
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog sfd2 = new OpenFileDialog();
        Stream stream;
        private bool dockpanel = false;

        string darkmode = null;
        string CheckBoxClock = null;

        public string F2 = "";
        public string F3 = "";
        public string F4 = "";
        public string F5 = "";

        bool secret = true;

        private string printingText;
        private int printingPosition;
        private System.Drawing.Font printFont;
        string filename = "名称未設定";
        private string extendsfile = "";
        public bool tabSwitch = true;

        private string localPath = Path.GetTempPath();
        private string tempFileDate = DateTime.Now.ToString("yyyyMM dd HH：mm：ss");

        bool loadingtrue = false;
        bool number = false;


        [System.Runtime.InteropServices.DllImport("shell32.dll", EntryPoint = "IsUserAnAdmin")]
        extern static Boolean IsUserAnAdmin();

        public Functions(novel novel)
        {
            this.novel = novel;
        }
        public Functions(novel novel, string file)
        {
            this.novel = novel;
        }


        public void UpdateCheck_Start()
        {
            var task = UpdateCheck();
        }


        private async Task UpdateCheck()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    Process[] processes = Process.GetProcessesByName("Nvw Updater");
                    if (processes.Length == 0)
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = $@"{AppDomain.CurrentDomain.BaseDirectory}Nvw Updater.exe";
                        Process.Start(info);
                    }
                    else
                    {

                    }
                }

                );
                await task;
            }
            catch (Exception ex)
            {
            }
        }

        public void KeyWordOpen()
        {
            Keyword f2 = new Keyword(novel, this);
            f2.Show();
        }

        public void newFile()
        {
            novel.customRichText1.Text = "";
            novel.customRichText3.Text = "";
            stream = null;
        }
        public void OpenFile(string filePath)
        {
            if (filePath.Substring(filePath.Length - 5, 5).Contains(".nvw"))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"));

                string text = sr.ReadToEnd();

                sr.Close();

                novel.customRichText1.Text = text;

                filename = Path.GetFileName(filePath);
                novel.Text = "ノベルライター " + filename;
            }
            else
            {
                byte[] bs = System.IO.File.ReadAllBytes(filePath);
                //文字コードを取得する
                System.Text.Encoding enc = GetCode(bs);
                //デコードして表示する
                novel.customRichText1.Text = enc.GetString(bs);
            }
        }
        public void click_load(string extendsfile)
        {
            if (extendsfile == "")
            {
                return;
            }
            // ファイルがダブルクリックされたとき
            if (System.IO.File.Exists(extendsfile))
            {
                try
                {
                    OpenFile(extendsfile);
                    url = extendsfile;
                    filename = Path.GetFileName(url);
                    novel.Text = "ノベルライター " + filename;
                    loadingtrue = true;
                }
                catch
                {
                    loadingtrue = false;
                    XtraMessageBox.Show(String.Format("{0}を開くことができません", extendsfile), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void openAsFile()
        {
            sfd2.Filter = "ファイル(*.nvw;*.txt;*.docx;*.doc)|*.nvw;*.txt;*.docx;*.doc|すべてのファイル(*.*)|*.*";
            if (sfd2.ShowDialog() == DialogResult.OK)
            {
                url = (sfd2.FileName);
                filename = Path.GetFileName(url);
                if (!(url.Substring(url.Length - 5, 5).Contains(".docx") || url.Substring(url.Length - 5, 5).Contains(".doc")))
                {
                    if (url.Substring(url.Length - 5, 5).Contains(".nvw"))
                    {
                        StreamReader sr = new StreamReader(url, Encoding.GetEncoding("UTF-8"));

                        string text = sr.ReadToEnd();

                        sr.Close();

                        novel.customRichText1.Text = text;

                        novel.Text = "ノベルライター " + filename;
                    }
                    else
                    {

                        byte[] bs = System.IO.File.ReadAllBytes(url);
                        //文字コードを取得する
                        System.Text.Encoding enc = GetCode(bs);
                        //デコードして表示する
                        novel.customRichText1.Text = enc.GetString(bs);

                        novel.Text = "ノベルライター " + filename;
                    }
                }
                else
                {
                    Spire.Doc.Document doc = new Spire.Doc.Document();
                    doc.LoadFromFile(url);
                    string read = doc.GetText();
                    novel.customRichText1.Text = read.ToString();
                    novel.Text = "ノベルライター " + filename;
                }
            }
        }
        public void saveFile()
        {
            if (url != "")
            {
                //ファイルに書き込む
                StreamWriter sw = new StreamWriter(url, false,
                    System.Text.Encoding.GetEncoding("UTF-8"));
                sw.Write(novel.customRichText1.Text);
                //閉じる
                sw.Close();
                novel.Text = "ノベルライター " + filename;
            }
            else
            {
                XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void saveAsFile()
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、
                //選択された名前で新しいファイルを作成し、
                //読み書きアクセス許可でそのファイルを開く。
                //既存のファイルが選択されたときはデータが消える恐れあり。
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    url = sfd.FileName;
                    stream.Close();
                    StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(novel.customRichText1.Text);
                    sw.Close();

                    filename = Path.GetFileName(sfd.FileName);
                    novel.Text = "ノベルライター " + filename;
                    XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void saveAsPdf()
        {
            if (novel.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //ドキュメントを作成
                Document doc = new Document();
                //ファイルの出力先を設定
                PdfWriter.GetInstance(doc, new FileStream(novel.saveFileDialog1.FileName + ".pdf", FileMode.Create));
                doc.Open();

                //doc.Close();
                //［1］ MSゴシック
                iTextSharp.text.Font fnt1 = new iTextSharp.text.Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, true), 12);
                //文言とフォントを指定してドキュメントに追加
                doc.Add(new Paragraph(novel.customRichText1.Text, fnt1));
                //ドキュメントを閉じる
                doc.Close();

                XtraMessageBox.Show("ファイルを保存しました。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void autoSaveChanege()
        {
            Properties.Settings.Default.backupfix = novel.customRichText1.Text;
            Properties.Settings.Default.Save();

            StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
            sw.Write(novel.customRichText1.Text);
            sw.Close();


            DateTime da = DateTime.Now;
            Properties.Settings.Default.time = da.ToString("yyyy年MM月dd日 HH:mm:ss");
            Properties.Settings.Default.Save();
        }
        public void themeChangeColor(CheckBox checkbox)
        {
            if (checkbox.Checked == true)
            {
                novel.customRichText1.BackColor = Color.FromArgb(45, 45, 45);
                novel.customRichText2.BackColor = Color.FromArgb(45, 45, 45);
                novel.customRichText3.BackColor = Color.FromArgb(45, 45, 45);

                novel.BackColor = Color.FromArgb(45, 45, 45);
                novel.ForeColor = Color.White;

                novel.customRichText1.ForeColor = Color.White;
                novel.customRichText2.ForeColor = Color.White;
                novel.customRichText3.ForeColor = Color.White;

                darkmode = "True";
                Properties.Settings.Default.darkmode = darkmode;
                Properties.Settings.Default.Save();
            }
            else
            {
                novel.customRichText1.ForeColor = Color.White;
                novel.customRichText2.ForeColor = Color.White;
                novel.customRichText3.ForeColor = Color.White;

                novel.BackColor = Color.WhiteSmoke;
                novel.ForeColor = Color.Black;

                novel.customRichText1.ForeColor = Color.Black;
                novel.customRichText2.ForeColor = Color.Black;
                novel.customRichText3.ForeColor = Color.Black;
                darkmode = "False";
                Properties.Settings.Default.darkmode = darkmode;
                Properties.Settings.Default.Save();
            }
        }
        public void clock(CheckBox checkbox)
        {
            if (checkbox.Checked == true)
            {
                CheckBoxClock = "True";
                checkbox.Checked = true;
                novel.timer1.Start();
                Properties.Settings.Default.checkboxauto = CheckBoxClock;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                CheckBoxClock = "False";
                checkbox.Checked = false;
                novel.timer1.Stop();
                novel.label11.Text = "";
                Properties.Settings.Default.checkboxauto = CheckBoxClock;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
        }
        public void topMost()
        {
            if (novel.TopMost == false)
            {
                novel.TopMost = true;
                novel.simpleButton16.Text = "無効化";
                novel.notifyIcon1.BalloonTipTitle = "INFO";
                novel.notifyIcon1.BalloonTipText = "最前列: 有効化";
                novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                novel.notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
                novel.TopMost = false;
                novel.simpleButton16.Text = "最前列";
                novel.notifyIcon1.BalloonTipTitle = "INFO";
                novel.notifyIcon1.BalloonTipText = "最前列: 無効化";
                novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                novel.notifyIcon1.ShowBalloonTip(1000);
            }
        }
        public void memoPanel()
        {
            if (novel.simpleButton14.Text == "メモ")
            {
                novel.panel5.Visible = true;
                novel.simpleButton14.Text = "メモ非表示";
            }
            else
            {
                novel.panel5.Visible = false;
                novel.simpleButton14.Text = "メモ";
            }
        }
        public void split()
        {
            if (dockpanel)
            {
                dockpanel = false;
                novel.splitContainer1.Panel2Collapsed = true;
                novel.customRichText3.Focus();
                novel.simpleButton23.Text = "2分割";
            }
            else
            {
                dockpanel = true;
                novel.splitContainer1.Panel2Collapsed = false;
                novel.simpleButton23.Text = "戻す";
            }
        }

        public void countChange()
        {
            int iLength = novel.customRichText1.TextLength;
            novel.Text = "ノベルライター * " + filename;


        }

        public void fontChange()
        {
            int iLength = novel.customRichText1.TextLength;
            if (novel.comboBox5.Text == "全文字")
            {
                novel.label1.Text = "文字数: " + iLength.ToString();
            }
            else if (novel.comboBox5.Text == "空白無")
            {
                string NewString = Regex.Replace(novel.customRichText1.Text, @"\s", "");
                novel.label1.Text = "文字数: " + NewString.Length.ToString();
            }
            else if (novel.comboBox5.Text == "改行無")
            {
                string someString = novel.customRichText1.Text.Replace(Environment.NewLine, "");
                novel.label1.Text = "文字数: " + someString.Length.ToString();
            }
            else if (novel.comboBox5.Text == "空白改行無")
            {
                string NewString = Regex.Replace(novel.customRichText1.Text, @"\s", "");
                string someString = NewString.Replace(Environment.NewLine, "");
                novel.label1.Text = "文字数: " + someString.Length.ToString();
            }
        }
        public void Secret()
        {
            if (secret)
            {
                StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
                sw.Write(novel.customRichText3.Text);
                sw.Close();

                novel.customRichText3.Clear();
                secret = false;
            }
            else
            {
                StreamReader sr = new StreamReader($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();
                sr.Close();

                novel.customRichText3.Text = text;
                secret = true;
            }
        }

        public void print()
        {
            //印刷する文字列と位置を設定する
            printingText = novel.customRichText1.Text;
            printingPosition = 0;
            //印刷に使うフォントを指定する
            printFont = new System.Drawing.Font("メイリオ", 10);
            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            //印刷を開始する
            pd.Print();
        }
        private void pd_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (printingPosition == 0)
            {
                //改行記号を'\n'に統一する
                printingText = printingText.Replace("\r\n", "\n");
                printingText = printingText.Replace("\r", "\n");
            }

            //印刷する初期位置を決定
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            //1ページに収まらなくなるか、印刷する文字がなくなるかまでループ
            while (e.MarginBounds.Bottom > y + printFont.Height &&
                printingPosition < printingText.Length)
            {
                string line = "";
                for (; ; )
                {
                    //印刷する文字がなくなるか、
                    //改行の時はループから抜けて印刷する
                    if (printingPosition >= printingText.Length ||
                        printingText[printingPosition] == '\n')
                    {
                        printingPosition++;
                        break;
                    }
                    //一文字追加し、印刷幅を超えるか調べる
                    line += printingText[printingPosition];
                    if (e.Graphics.MeasureString(line, printFont).Width
                        > e.MarginBounds.Width)
                    {
                        //印刷幅を超えたため、折り返す
                        line = line.Substring(0, line.Length - 1);
                        break;
                    }
                    //印刷文字位置を次へ
                    printingPosition++;
                }
                //一行書き出す
                e.Graphics.DrawString(line, printFont, Brushes.Black, x, y);
                //次の行の印刷位置を計算
                y += (int)printFont.GetHeight(e.Graphics);
            }

            //次のページがあるか調べる
            if (printingPosition >= printingText.Length)
            {
                e.HasMorePages = false;
                //初期化する
                printingPosition = 0;
            }
            else
                e.HasMorePages = true;
        }

        public void Registory()
        {
            //関連付ける拡張子
            string extension = ".nvw";
            //実行するコマンドライン
            string commandline = "\"" + Application.ExecutablePath + "\" \"%1\"";
            //ファイルタイプ名
            string fileType = Application.ProductName + ".0";
            //説明（「ファイルの種類」として表示される）
            string description = "ノベルライター";
            //動詞
            string verb = "open";
            //動詞の説明（エクスプローラのコンテキストメニューに表示される。
            //　省略すると、「開く(&O)」となる。）
            string verbDescription = "ノベルライターで開く(&O)";
            //アイコンのパスとインデックス
            string iconPath = Application.ExecutablePath;
            int iconIndex = 0;

            Microsoft.Win32.RegistryKey rootkey =
                Microsoft.Win32.Registry.ClassesRoot;

            //拡張子のキーを作成し、そのファイルタイプを登録
            Microsoft.Win32.RegistryKey regkey =
                rootkey.CreateSubKey(extension);
            regkey.SetValue("", fileType);
            regkey.Close();

            //ファイルタイプのキーを作成し、その説明を登録
            Microsoft.Win32.RegistryKey typekey =
                rootkey.CreateSubKey(fileType);
            typekey.SetValue("", description);
            typekey.Close();

            //動詞のキーを作成し、その説明を登録
            Microsoft.Win32.RegistryKey verblkey =
                rootkey.CreateSubKey(fileType + "\\shell\\" + verb);
            verblkey.SetValue("", verbDescription);
            verblkey.Close();

            //コマンドのキーを作成し、実行するコマンドラインを登録
            Microsoft.Win32.RegistryKey cmdkey =
                rootkey.CreateSubKey(fileType + "\\shell\\" + verb + "\\command");
            cmdkey.SetValue("", commandline);
            cmdkey.Close();

            //アイコンのキーを作成し、アイコンのパスと位置を登録
            Microsoft.Win32.RegistryKey iconkey =
                rootkey.CreateSubKey(fileType + "\\DefaultIcon");
            iconkey.SetValue("", iconPath + "," + iconIndex.ToString());
            iconkey.Close();
        }

        public static System.Text.Encoding GetCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }

        public void changeFont()
        {
            if (novel.comboBox4.Text == "普通")
            {
                novel.customRichText1.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Regular);
                novel.customRichText3.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Regular);
                //customRichText1
            }
            if (novel.comboBox4.Text == "斜体")
            {
                novel.customRichText1.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Italic);
                novel.customRichText3.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Italic);
            }
            if (novel.comboBox4.Text == "普通(太)")
            {
                novel.customRichText1.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Bold);
                novel.customRichText3.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Bold);
            }
            if (novel.comboBox4.Text == "下線")
            {
                novel.customRichText1.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Underline);
                novel.customRichText3.Font = new System.Drawing.Font(novel.comboBox2.Text, float.Parse(novel.comboBox3.Text), FontStyle.Underline);
            }
        }
        public void loading()
        {
            novel.notifyIcon1.BalloonTipTitle = "INFO";
            novel.notifyIcon1.BalloonTipText = "Novel Writer 起動しました。";
            novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            novel.notifyIcon1.ShowBalloonTip(1000);


            UpdateCheck_Start();
            string path = $@"{localPath}ノベルライター\AutoSave\{tempFileDate}";
            if (File.Exists(path))
            {
                FileStream fileStream = File.Create(path + "(2)");
                fileStream.Dispose();
            }
            else
            {
                FileStream fileStream = File.Create($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                fileStream.Dispose();
            }

            string secretPath = $@"{localPath}ノベルライター\Secret\{tempFileDate}";
            if (File.Exists(secretPath))
            {
                FileStream fileStream = File.Create(secretPath + "(2)");
                fileStream.Dispose();
            }
            else
            {
                FileStream fileStream = File.Create($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");
                fileStream.Dispose();
            }

            sfd.SupportMultiDottedExtensions = true;
            // フィルターの設定
            sfd.Filter = "ノベルライター|*.nvw|テキスト文書|*.txt|すべてのファイル|*.*";
            //sfd.Filter = "ファイル(*.nvw;*.txt)|*.nvw;*.txt|すべてのファイル(*.*)|*.*";

            novel.label11.Text = "";
            string font = Properties.Settings.Default.font;
            string fontweight = Properties.Settings.Default.fontweight;
            float fontsize = Properties.Settings.Default.fontsize;
            novel.comboBox2.Text = font;
            novel.comboBox4.Text = fontweight;
            novel.comboBox3.Text = fontsize.ToString();

            if (fontweight == "普通")
            {
                novel.customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Regular);
                novel.customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Regular);
                //customRichText1
            }
            if (fontweight == "斜体")
            {
                novel.customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Italic);
                novel.customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Italic);
            }
            if (fontweight == "普通(太)")
            {
                novel.customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Bold);
                novel.customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Bold);
            }
            if (fontweight == "下線")
            {
                novel.customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Underline);
                novel.customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Underline);
            }


            DateTime timegen = DateTime.Now;
            filename = "名称未設定" + timegen.ToString("yyyy年MM月dd日 HH:mm:ss");
            novel.Text = "ノベルライター " + filename;


            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily item in fonts.Families)
            {
                novel.comboBox2.Items.Add(item.Name);
            }


            novel.customRichText2.Text = Properties.Settings.Default.Memo;

            click_load(extendsfile);

            if (loadingtrue == false)
            {
                novel.customRichText1.Text = Properties.Settings.Default.BackUp;
                novel.customRichText3.Text = Properties.Settings.Default.BackUp;
            }


            CheckBoxClock = Properties.Settings.Default.checkboxclock;

            if (CheckBoxClock == "True")
            {
                novel.checkBox2.Checked = true;
                novel.timer1.Start();
            }
            else
            {
                novel.checkBox2.Checked = false;
                novel.label11.Text = "";
                novel.timer1.Stop();
            }

            darkmode = Properties.Settings.Default.darkmode;
            CheckBoxClock = Properties.Settings.Default.checkboxauto;

            if (darkmode == "True")
            {
                novel.customRichText1.BackColor = Color.FromArgb(45, 45, 45);
                novel.customRichText3.BackColor = Color.FromArgb(45, 45, 45);
                novel.customRichText2.BackColor = Color.FromArgb(45, 45, 45);

                novel.customRichText2.BackColor = Color.FromArgb(45, 45, 45);

                novel.BackColor = Color.FromArgb(45, 45, 45);
                novel.ForeColor = Color.White;

                novel.customRichText1.ForeColor = Color.White;
                novel.customRichText3.ForeColor = Color.White;
                novel.customRichText2.ForeColor = Color.White;
                novel.checkBox3.Checked = true;
            }
            else
            {
                novel.customRichText1.BackColor = Color.White;
                novel.customRichText3.BackColor = Color.White;
                novel.customRichText2.BackColor = Color.White;
                novel.customRichText2.BackColor = Color.White;

                novel.BackColor = Color.WhiteSmoke;
                novel.ForeColor = Color.Black;

                novel.customRichText1.ForeColor = Color.Black;
                novel.customRichText3.ForeColor = Color.Black;
                novel.customRichText2.ForeColor = Color.Black;

                novel.checkBox3.Checked = false;
            }


            string Path = "";
            if (Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles"))
            {
                if (!File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt"))
                {

                    Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
                    StreamWriter writer =
                      new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt", false, sjisEnc);
                    writer.Write("False");
                    writer.Close();
                }
            }
            else
            {
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles");
                if (!File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt"))
                {
                    Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
                    StreamWriter writer =
                      new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt", false, sjisEnc);
                    writer.Write("False");
                    writer.Close();
                }
            }

            StreamReader sr = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt", Encoding.GetEncoding("UTF-8"));

            Path = sr.ReadLine();

            sr.Close();

            if (Path != "True")
            {

                DialogResult dr;

                dr = XtraMessageBox.Show(Application.ProductName + "nvwの拡張子を登録しますか?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (IsUserAnAdmin() == false)
                    {
                        XtraMessageBox.Show("管理者モードでの起動が必要です。\r\n管理者モードで起動しますので、再度登録「はい」を押してください。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        ProcessStartInfo pInfo = new ProcessStartInfo();
                        pInfo.Verb = "runas";
                        pInfo.UseShellExecute = true;
                        pInfo.FileName = $"{AppDomain.CurrentDomain.BaseDirectory}Novel Writer.exe";

                        Process.Start(pInfo);
                        Environment.Exit(0);
                    }
                    else
                    {

                        Registory();

                        Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
                        StreamWriter writer =
                          new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}SaveFiles\Registory.txt", false, sjisEnc);
                        writer.Write("True");
                        writer.Close();

                        XtraMessageBox.Show("拡張子、「.nvw」登録が完了しました。\r\n次回から.nvwのファイルを直接開けます。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            F2 = Properties.Settings.Default.KeyF2;
            F3 = Properties.Settings.Default.KeyF3;
            F4 = Properties.Settings.Default.KeyF4;
            F5 = Properties.Settings.Default.KeyF5;

            novel.customRichText1.Select();
            novel.customRichText3.Text = novel.customRichText1.Text;

            novel.customRichText1.HideSelection = false;
        }

        public void exiting(FormClosingEventArgs e)
        {
            int count_first = 0;
            int count_second = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "novel")
                {
                    count_first++;
                    continue;
                }
                if (form.Name == "AutoSaver")
                {
                    count_second++;
                    continue;
                }
            }


            DialogResult dr;

            dr = XtraMessageBox.Show(Application.ProductName + "終了しますか?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (count_second == 0 & count_first == 1)
                {
                    Properties.Settings.Default.fix = 0;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Memo = novel.customRichText2.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.backupfix = "";
                    Properties.Settings.Default.Save();

                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    novel.notifyIcon1.BalloonTipTitle = "INFO";
                    novel.notifyIcon1.BalloonTipText = "Novel Writer 終了しました。";
                    novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    novel.notifyIcon1.ShowBalloonTip(1000);
                    Environment.Exit(0);
                }
                else if (count_first == 1)
                {
                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    novel.notifyIcon1.BalloonTipTitle = "INFO";
                    novel.notifyIcon1.BalloonTipText = $"{novel.Text} 終了しました。";
                    novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    novel.notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    novel.notifyIcon1.BalloonTipTitle = "INFO";
                    novel.notifyIcon1.BalloonTipText = $"{novel.Text} 終了しました。";
                    novel.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    novel.notifyIcon1.ShowBalloonTip(1000);
                }

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
