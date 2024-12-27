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
using SpeechLib;


namespace novel
{
    public partial class novel : Form
    {
        // KeyControl no;

        private string printingText;
        private int printingPosition;
        private System.Drawing.Font printFont;
        string filename = "名称未設定";
        private bool dockpanel = false;
        private bool autoenter = true;
        private string extendsfile = "";
        public bool tabSwitch = true;

        bool secret = true;
        //string temp = "";
        private string localPath = Path.GetTempPath();
        //DateTime tempfiletime = DateTime.Now;
        private string tempFileDate = DateTime.Now.ToString("yyyyMM dd HH：mm：ss");

        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog sfd2 = new OpenFileDialog();
        string url = "";
        Stream stream;

        string checkboxautosave = null;
        string CheckBoxClock = null;
        string darkmode = null;
        public novel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
        }
        public novel(string file)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
            this.extendsfile = file;
        }

        void KeyWordOpen()
        {
            /*
            if (!this.sf.Visible)
            {
                Keyword f2 = new Keyword(this); // 自フォームへの参照を渡す
                f2.Show();
            }
            else
            {
                this.sf.Activate();
            }
            */
            Keyword f2 = new Keyword(this); // 自フォームへの参照を渡す
            f2.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CustomRichText1_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        public static void Coloring(RichTextBox target, String keyword, Color color)

        {

            // found 変数では検索を行う文字位置の一つ手前を示します。最初は - 1 となります。

            int found = -1;



            // キーワードが見つからなくなるまで繰り返します。

            do

            {

                // 対象の RichTextBox から、キーワードが見つかる位置を探します。検索開始位置は、前回見つかった場所の次からとします。

                found = target.Find(keyword, found + 1, RichTextBoxFinds.MatchCase);



                // キーワードが見つかった場合は、その色を変更します。

                if (found >= 0)

                {

                    target.SelectionStart = found;

                    target.SelectionLength = keyword.Length;

                    target.SelectionColor = color;

                }

                else

                {

                    // キーワードが見つからなかった場合は、繰り返し処理を終了します。

                    break;

                }

            }

            while (true);

        }

        */
        /*
        private void fontcolor()
        {
            //適切な色で背景を描画する。
            e.DrawBackground();
            string txt = ((RichTextBox)sender).Items[e.Index].ToString(),
            txt2 = txt.Replace("俺", "\n俺\n");
            System.Drawing.Rectangle rec = e.Bounds;
            Graphics g = e.Graphics;
            Color foreColor = Color.Black;//文字色
            foreach (string str in txt2.Split('\n'))
            {
                //文字幅を計算する
                rec.Width = TextRenderer.MeasureText(g, str, e.Font, new Size(int.MaxValue, int.MinValue), TextFormatFlags.NoPadding).Width;
                //文字列中に”ＡＡＡ”が含まれる場合、その文字色を赤に設定する
                if (str.Equals("俺"))
                {
                    foreColor = Color.Red;
                }
                else
                {
                    foreColor = Color.Black;
                }
                //文字列の描画
                TextRenderer.DrawText(g, str, e.Font, rec, foreColor, TextFormatFlags.NoPadding);
                rec.Location = new Point(rec.X + rec.Width, rec.Y);
            }
            //フォーカスを示す四角形を描画
            e.DrawFocusRectangle();
        }
        */

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        string StringReplace(string str, List<KeyValuePair<string, string>> searchReplace)
        {
            foreach (KeyValuePair<string, string> sreplace in searchReplace)
            {
                str = str.Replace(sreplace.Key, sreplace.Value);
            }
            return str;
        }
        */

        /*

     private void SelectionFind()
     {
         object findText = "find me";

         Application.Selection.Find.ClearFormatting();

         if (Application.Selection.Find.Execute(ref findText,
             ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
             ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
             ref missing, ref missing))
         {
             MessageBox.Show("Text found.");
         }
         else
         {
             MessageBox.Show("The text could not be located.");
         }
     }
     */

        /*
    private void simpleButton8_Click(object sender, EventArgs e)
    {
        //  string s = customRichText1.Text;

        //文字列を置換する（「にわ」を「庭」に置換する）
        //   string r1 = s.Replace(textBox2.Text, textBox3.Text);
        //庭には庭庭とりがいる。

        //文字を置換する（「に」を「2」に置換する）
        // string r2 = s.Replace('に', '2');
        //2わ2は2わ2わとりがいる。
        //   string s = "Niwanihaniwaniwatorigairu.";

        //1回だけ置換する
        //string r1 = String.Replace(s, textBox2.Text, textBox3.Text, 1);
        // SelectionFind();
        /*
        StringBuilder str = new StringBuilder(textBox2.Text);
        customRichText1.Text = str.ToString();
        str.Replace(textBox3.Text, textBox2.Text);
        */
        /*
        string str = "";
        RegexOptions regexOptions = this.GetRegexOptions();
        RegexMode selectedValue = (RegexMode)this.regexMode.SelectedValue;
        try
        {
            switch (selectedValue)
            {

                case RegexMode.Replace:
                    str = this.DoRegexReplace(this.customRichText1.Text, this.textBox2.Text, this.textBox3.Text, regexOptions);
                    goto Label_00CC;
            }
        }
        catch (ArgumentException exception)
        {
            str = string.Format("【エラーが発生しました】\r\n{0}", exception.Message);
        }
        Label_00CC:
        this.listBox2.Items.Add(str);

        /*
        string str = "";
        RegexOptions regexOptions = this.GetRegexOptions();
        str = this.DoRegexReplace(this.customRichText1.Text, this.textBox2.Text, this.textBox3.Text, regexOptions);

    }
    */

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            /*
            string str = customRichText1.Text;

            //strに「天気」が含まれているか調べる
            if (0 <= str.IndexOf(textBox1.Text))
            {
                //listBox1.Items.Add()
                // customRichText1.SetBounds.sender.ToString
                //   Active.Select.customRichText1


            }
            else
            {
                MessageBox.Show("指定された文字列が含まれていません");
                // Console.WriteLine("指定された文字列が含まれていません");
                */


            //Regexオブジェクトを作成
            /*
            System.Text.RegularExpressions.Regex r =
                new System.Text.RegularExpressions.Regex(
                    customRichText1.Text,
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                            //TextBox1.Text内で正規表現と一致する対象を1つ検索
                            System.Text.RegularExpressions.Match m = r.Match(textBox1.Text);

                            //次のように一致する対象をすべて検索することもできる
                            //System.Text.RegularExpressions.MatchCollection mc = r.Matches(TextBox1.Text);

                            while (m.Success)
                            {
                                //一致した対象が見つかったときキャプチャした部分文字列を表示
                                Console.WriteLine(m.Value);
                                //次に一致する対象を検索
                                m = m.NextMatch();
                            }



                        int iLength = this.customRichText1.TextLength;

                        // こちらでも可能 
                        //int iLength = this.textBox1.Text.Length;

                        // 取得したテキストの文字数を表示する
                        label7.Text = "文字数: " + iLength.ToString();
                        */

            /*
            //正規表現パターンとオプションを指定してRegexオブジェクトを作成
            System.Text.RegularExpressions.Regex r =
                new System.Text.RegularExpressions.Regex(
                    customRichText1.Text,
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase
                    | System.Text.RegularExpressions.RegexOptions.Singleline);

            //TextBox1.Text内で正規表現と一致する対象をすべて検索
            System.Text.RegularExpressions.MatchCollection mc = r.Matches(textBox1.Text);

            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                //正規表現に一致したグループと位置を表示
                this.customRichText1.Focus();
                XtraMessageBox.Show("タグ:" + m.Groups[1].Value
                    + "\nタグ内の文字列:" + m.Groups[2].Value
                    + "\nタグの位置:" + m.Groups[1].Index);
            }
            */
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            /*
            string result = string.Empty;

            // ファイルの存在チェック
            if (System.IO.File.Exists(@"C:\hogehoge.txt"))
            {

                // StreamReaderでファイルを読み込む
                System.IO.StreamReader reader = (new System.IO.StreamReader(@"C:\hogehoge.txt", System.Text.Encoding.GetEncoding("shift_jis")));

                // ファイルの最後まで読み込む
                result = reader.ReadToEnd();

                // 閉じる (オブジェクトの破棄)
                reader.Close();
            }

            // 結果を表示する
            MessageBox.Show(result);
        }

        */
            //SaveFileDialogクラスのインスタンスを作成

            //ダイアログを表示する

            sfd2.Filter = "ファイル(*.nvw;*.txt;*.docx;*.doc)|*.nvw;*.txt;*.docx;*.doc|すべてのファイル(*.*)|*.*";
            if (sfd2.ShowDialog() == DialogResult.OK)
            {
                url = (sfd2.FileName);
                filename = Path.GetFileName(url);
                if (!(url.Substring(url.Length - 5, 5).Contains(".docx") || url.Substring(url.Length - 5, 5).Contains(".doc")))
                {
                    //テキストファイルを開く
                    //byte[] bs = System.IO.File.ReadAllBytes(url);
                    //.NET Framework 1.1以下では、次のようにする
                    //System.IO.FileStream fs = new System.IO.FileStream(
                    //    TextBox1.Text, System.IO.FileMode.Open,
                    //    System.IO.FileAccess.Read);
                    //byte[] bs = new byte[fs.Length];
                    //fs.Read(bs, 0, bs.Length);
                    //fs.Close();

                    //文字コードを判別する
                    /*
                    System.Text.Encoding enc = DetectEncodingFromBOM(bs);


                    if (enc == null)
                    {
                        XtraMessageBox.Show("文字コードが見つかりません", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    */
                    //テキストファイルを開く
                    
                    if(url.Substring(url.Length - 5, 5).Contains(".nvw"))
                    {
                        StreamReader sr = new StreamReader(url, Encoding.GetEncoding("UTF-8"));

                        string text = sr.ReadToEnd();

                        sr.Close();
                        
                        customRichText1.Text = text;
                        
                        this.Text = "ノベルライター " + filename;
                    }
                    else
                    {
                        
                        byte[] bs = System.IO.File.ReadAllBytes(url);
                        //文字コードを取得する
                        System.Text.Encoding enc = GetCode(bs);
                        //デコードして表示する
                        customRichText1.Text = enc.GetString(bs);
                        
                        this.Text = "ノベルライター " + filename;
                    }
                    /*
                    // customRichText1.Text = (sfd2.OpenFile.FileName);
                    System.IO.StreamReader sr = new System.IO.StreamReader(
         url,
         System.Text.Encoding.GetEncoding("utf-8"));//shift_jis
                    //内容をすべて読み込む
                    string s = sr.ReadToEnd();
                    //閉じる
                    sr.Close();

                    //結果を出力する
                    //  Console.WriteLine(s);
                    customRichText1.Text = s;

                    */
                    /*
                    foreach (var line in File.ReadLines(@"d:\test.txt", Encoding.GetEncoding("Shift_JIS")).Where(line => line.Contains("やまだ")))
                    {
                        Console.WriteLine(line);
                    }
                    */
                }
                else
                {
                    Spire.Doc.Document doc = new Spire.Doc.Document();
                    doc.LoadFromFile(url);
                    string read = doc.GetText();
                    customRichText1.Text = read.ToString();
                    this.Text = "ノベルライター " + filename;
                }
            }
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            /*
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、
                //選択された名前で新しいファイルを作成し、
                //読み書きアクセス許可でそのファイルを開く。
                //既存のファイルが選択されたときはデータが消える恐れあり。
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    //ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
                    sw.Write(customRichText1.Text);
                    //閉じる
                    sw.Close();
                    stream.Close();
                }

            }
            */
            customRichText1.Text = "";
            stream = null;




            /*
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //Shift JISで書き込む
                //書き込むファイルが既に存在している場合は、上書きする
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                @"C:\test\1.txt",
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.Write(customRichText1.Text);
                //閉じる
                sw.Close();
            }
            */
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (url != "")
            {
                //ファイルに書き込む
                StreamWriter sw = new StreamWriter(url, false,
                    System.Text.Encoding.GetEncoding("UTF-8"));
                sw.Write(customRichText1.Text);
                //閉じる
                sw.Close();
                this.Text = "ノベルライター " + filename;
            }
            else
            {
                XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*
                         System.IO.Stream stream;
            stream = sfd.OpenFile();
            if (stream != null)
            {
                //ファイルに書き込む
                System.IO.StreamWriter sw = new System.IO.StreamWriter(stream,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw.Write(customRichText1.Text);
                //閉じる
                sw.Close();
                stream.Close();
            } 
             */
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // sfd.Reset();
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
                    //MessageBox.Show(url);
                    stream.Close();
                    //StreamWriter sw = new StreamWriter(url, false,  Encoding.GetEncoding("shift_jis"));
                    StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    sw.Close();

                    filename = Path.GetFileName(sfd.FileName);
                    this.Text = "ノベルライター " + filename;
                    XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            /*
            this.customRichText1.Focus();


            string s = customRichText1.Text;
            //検索する文字列
            string searchWord = textBox1.Text;

            //始めの位置を探す
            int foundIndex = s.IndexOf(searchWord);
            while (0 <= foundIndex)
            {
                //見つかった位置を表示する
                //Console.WriteLine(foundIndex);
                textBox1.Select(customRichText1.Text.Length, foundIndex);

                //次の検索開始位置
                int nextIndex = foundIndex + searchWord.Length;
                if (nextIndex < s.Length)
                {
                    //次の位置を探す
                    foundIndex = s.IndexOf(searchWord, nextIndex);
                }
                else
                {
                    //最後まで検索したときは終わる
                    break;
                }

                */
                /*
                     int iLength = this.customRichText1.TextLength;

                // こちらでも可能 
                //int iLength = this.textBox1.Text.Length;

                // 取得したテキストの文字数を表示する
                label7.Text = "文字数: " + iLength.ToString();
                  */
            //}
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


        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //印刷する文字列と位置を設定する
            printingText = customRichText1.Text;
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
        public void UpdateCheck_Start()
        {
            var task = UpdateCheck();
        }
        string updatecheck = "";



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

        /*
        void disabletab()
        {

            textBox1.TabStop = false;
            textBox1.TabStop = false;
            textBox1.TabStop = false;
        }
        */
        void click_load(string extendsfile)
        {
            if (extendsfile == "")
            {
                return;
            }
            checkboxautosave = "False";
            // ファイルがダブルクリックされたとき
            //string[] files = System.Environment.GetCommandLineArgs();
            //var files1 = files.Skip(1);
            /*
            foreach (var filePath in files1)
            {
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        OpenFile(filePath);
                        url = filePath;
                        filename = Path.GetFileName(url);
                        this.Text = "ノベルライター " + filename;
                        loadingtrue = true;
                        break;
                    }
                    catch
                    {
                        loadingtrue = false;
                        XtraMessageBox.Show(String.Format("{0}を開くことができません", filePath), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            */
            if (System.IO.File.Exists(extendsfile))
            {
                try
                {
                    OpenFile(extendsfile);
                    url = extendsfile;
                    filename = Path.GetFileName(url);
                    this.Text = "ノベルライター " + filename;
                    loadingtrue = true;
                }
                catch
                {
                    loadingtrue = false;
                    XtraMessageBox.Show(String.Format("{0}を開くことができません", extendsfile), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        void OpenFile(string filePath)
        {
            //url = filePath;
            /*
                // customRichText1.Text = (sfd2.OpenFile.FileName);
                System.IO.StreamReader sr = new System.IO.StreamReader(
     url,
     System.Text.Encoding.GetEncoding("shift_jis"));
                //内容をすべて読み込む
                string s = sr.ReadToEnd();
                //閉じる
                sr.Close();

                //結果を出力する
                //  Console.WriteLine(s);
                customRichText1.Text = s;
            */
            if (filePath.Substring(filePath.Length - 5, 5).Contains(".nvw"))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"));

                string text = sr.ReadToEnd();

                sr.Close();

                customRichText1.Text = text;

                filename = Path.GetFileName(filePath);
                this.Text = "ノベルライター " + filename;
            }
            else
            {
                byte[] bs = System.IO.File.ReadAllBytes(filePath);
                //文字コードを取得する
                System.Text.Encoding enc = GetCode(bs);
                //デコードして表示する
                customRichText1.Text = enc.GetString(bs);
            }
            /*
            foreach (var line in File.ReadLines(@"d:\test.txt", Encoding.GetEncoding("Shift_JIS")).Where(line => line.Contains("やまだ")))
            {
                Console.WriteLine(line);
            }
            */
        }
        bool loadingtrue = false;
        bool number = false;
        /*
        void DrawLineNumber()
        {
            if (number == true)
            {
                int lineNum = 0;
                int height = customRichText1.Size.Height;
                Graphics g = this.CreateGraphics();
                g.Clear(Color.White);

                int charIndex = customRichText1.GetCharIndexFromPosition(new Point(0, 0));
                lineNum = customRichText1.GetLineFromCharIndex(charIndex);

                while (true)
                {
                    charIndex = customRichText1.GetFirstCharIndexFromLine(lineNum);
                    if (charIndex == -1)
                        break;
                    Point pt = customRichText1.GetPositionFromCharIndex(charIndex);
                    System.Drawing.Font f = new System.Drawing.Font(comboBox2.Text, Int32.Parse(comboBox4.Text), GraphicsUnit.Pixel);
                    g.DrawString((lineNum + 1).ToString(), f, Brushes.Blue, new PointF(0, pt.Y));
                    lineNum++;

                    if (height < pt.Y)
                        break;
                }
                g.Dispose();
            }
            
        }
        */
        /*localPath
         comboBox2.Text = font;
            comboBox4.Text = fontweight;
            comboBox3.Text = fontsize.ToString();*/
        /*

        static readonly int GWL_EXSTYLE = -20;
        static readonly int WS_EX_LAYERED = 0x00080000;
        static readonly uint LWA_ALPHA = 0x2;

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        */
        private void novel_Load(object sender, EventArgs e)
        {

            notifyIcon1.BalloonTipTitle = "INFO";
            notifyIcon1.BalloonTipText = "Novel Writer 起動しました。";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(1000);
            /*
            try
            {
                if (File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}old.exe"))
                {
                    File.Delete($@"{AppDomain.CurrentDomain.BaseDirectory}old.exe");
                }
            }
            catch (Exception ex)
            {

            }
            */
            /*
            System.Diagnostics.FileVersionInfo ver =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
            MessageBox.Show(ver.FileVersion.ToString());
            */
            /*
            DataTable table = new DataTable("RegexMode");
            this.regexMode.DisplayMember = "DisplayName";
            this.regexMode.ValueMember = "Value";
            this.regexMode.DataSource = table;
            */

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

            label11.Text = "";
            string font = Properties.Settings.Default.font;
            string fontweight = Properties.Settings.Default.fontweight;
            float fontsize = Properties.Settings.Default.fontsize;
            comboBox2.Text = font;
            comboBox4.Text = fontweight;
            comboBox3.Text = fontsize.ToString();

            if (fontweight == "普通")
            {
                customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Regular);
                customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Regular);
                //customRichText1
            }
            if (fontweight == "斜体")
            {
                customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Italic);
                customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Italic);
            }
            if (fontweight == "普通(太)")
            {
                customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Bold);
                customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Bold);
            }
            if (fontweight == "下線")
            {
                customRichText1.Font = new System.Drawing.Font(font, fontsize, FontStyle.Underline);
                customRichText3.Font = new System.Drawing.Font(font, fontsize, FontStyle.Underline);
            }

            /*
            customRichText1.DetectUrls = true;
            customRichText2.DetectUrls = true;
            customRichText3.DetectUrls = true;
            */

            DateTime timegen = DateTime.Now;
            filename = "名称未設定" + timegen.ToString("yyyy年MM月dd日 HH:mm:ss");
            this.Text = "ノベルライター " + filename;

            /*
            DataTable table = new DataTable("RegexMode");
            table.Columns.Add("DisplayName", typeof(string));
            table.Columns.Add("Value", typeof(RegexMode));
            object[] values = new object[] { "Regex.Matches", RegexMode.Matches };
            table.Rows.Add(values);
            object[] objArray2 = new object[] { "Regex.IsMatch", RegexMode.IsMatch };
            table.Rows.Add(objArray2);
            object[] objArray3 = new object[] { "Regex.Replace", RegexMode.Replace };
            table.Rows.Add(objArray3);
            object[] objArray4 = new object[] { "Regex.Split", RegexMode.Split };
            table.Rows.Add(objArray4);
            this.regexMode.DisplayMember = "DisplayName";
            this.regexMode.ValueMember = "Value";
            this.regexMode.DataSource = table;
            foreach (RegexOptions options in Enum.GetValues(typeof(RegexOptions)))
            {
                this.regexOptions.Items.Add(options);
            }

            DataTable table2 = new DataTable("RegexMode");
            table2.Columns.Add("DisplayName", typeof(string));
            table2.Columns.Add("Value", typeof(RegexMode));
            object[] objArray32 = new object[] { "Regex.Replace", RegexMode.Replace };
            table2.Rows.Add(objArray32);
            this.comboBox1.DisplayMember = "DisplayName";
            this.comboBox1.ValueMember = "Value";
            this.comboBox1.DataSource = table2;
            */

            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily item in fonts.Families)
            {
                comboBox2.Items.Add(item.Name);
            }


            customRichText2.Text = Properties.Settings.Default.Memo;

            click_load(extendsfile);

            if (loadingtrue == false)
            {
                customRichText1.Text = Properties.Settings.Default.BackUp;
                customRichText3.Text = Properties.Settings.Default.BackUp;
            }

            checkboxautosave = Properties.Settings.Default.checkboxauto;
            if (checkboxautosave == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            CheckBoxClock = Properties.Settings.Default.checkboxclock;

            if (CheckBoxClock == "True")
            {
                checkBox2.Checked = true;
                timer1.Start();
            }
            else
            {
                checkBox2.Checked = false;
                label11.Text = "";
                timer1.Stop();
            }

            darkmode = Properties.Settings.Default.darkmode;
            CheckBoxClock = Properties.Settings.Default.checkboxauto;

            if (darkmode == "True")
            {
                customRichText1.BackColor = Color.FromArgb(45, 45, 45);
                customRichText3.BackColor = Color.FromArgb(45, 45, 45);
                customRichText2.BackColor = Color.FromArgb(45, 45, 45);

                customRichText2.BackColor = Color.FromArgb(45, 45, 45);

                this.BackColor = Color.FromArgb(45, 45, 45);
                this.ForeColor = Color.White;

                customRichText1.ForeColor = Color.White;
                customRichText3.ForeColor = Color.White;
                customRichText2.ForeColor = Color.White;
                //checkBox3.BackColor = Color.FromArgb(45, 45, 45);
                checkBox3.Checked = true;
            }
            else
            {
                customRichText1.BackColor = Color.White;
                customRichText3.BackColor = Color.White;
                customRichText2.BackColor = Color.White;
                customRichText2.BackColor = Color.White;

                this.BackColor = Color.WhiteSmoke;
                this.ForeColor = Color.Black;

                customRichText1.ForeColor = Color.Black;
                customRichText3.ForeColor = Color.Black;
                customRichText2.ForeColor = Color.Black;

                //checkBox3.BackColor = Color.WhiteSmoke;
                checkBox3.Checked = false;
            }

            /*
            customRichText1.TabStop = false;
            customRichText2.TabStop = false;
            customRichText3.TabStop = false;
            */
            

            /*
            int fix_teigi = Properties.Settings.Default.fix;
            if (fix_teigi == 1)
            {
                Properties.Settings.Default.fix = 0;
                Properties.Settings.Default.Save();
                customRichText1.Text = Properties.Settings.Default.backupfix;
                Properties.Settings.Default.backupfix = "";
                Properties.Settings.Default.Save();
                string date = Properties.Settings.Default.time;
                filename = date;
                this.Text = filename;
                XtraMessageBox.Show("異常な終了を検出したため、復元しました。\r\n" + date, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Properties.Settings.Default.fix = 1;
                Properties.Settings.Default.Save();

            }
            */

            //var Principle = new WindowsPrincipal(WindowsIdentity.GetCurrent()); 
            //return Principle.IsInRole(WindowsBuiltInRole.Administrator);

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
                        /*
                        var assembly = Assembly.GetEntryAssembly();
                        var startInfo = new ProcessStartInfo(ocation, ToCommandArgs(args))
                        {
                            UseShellExecute = true,
                            Verb = "runas",
                        };
                        */
                        ProcessStartInfo pInfo = new ProcessStartInfo();
                        pInfo.Verb = "runas";
                        pInfo.UseShellExecute = true;
                        //MessageBox.Show(Application.ProductName);
                        pInfo.FileName = $"{AppDomain.CurrentDomain.BaseDirectory}Novel Writer.exe";

                        Process.Start(pInfo);
                        Environment.Exit(0);

                        /*
                        try
                        {
                            Process.Start(pInfo);
                            Environment.Exit(0);
                        }
                        catch (Win32Exception ex)
                        {
                            // ユーザーが [いいえ] を選択すると例外が発生します。
                            //Console.WriteLine(ex.Message);
                        }
                        */
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

            //LineNumberTextBox.Font = customRichText1.Font;
            customRichText1.Select();
            //AddLineNumbers();
            customRichText3.Text = customRichText1.Text;

            customRichText1.HideSelection = false;

            /*
            IntPtr handle = customRichText1.Handle;
            SetWindowLong(handle, GWL_EXSTYLE, GetWindowLong(handle, GWL_EXSTYLE) | WS_EX_LAYERED);
            SetLayeredWindowAttributes(handle, 0, 128, LWA_ALPHA);
            */
            //panel1.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\muramoto\\Desktop\\Zip\\SPOILER_D33F0BC4-70B9-491E-8F80-B160AAFE15D9.jpg");
            /*
            if (File.Exists("C:\\Users\\muramoto\\Pictures\\Slide\\CafeStella_screenshot 2020_02_11 12_11_13.jpg"))
            {
                BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\muramoto\\Pictures\\Slide\\CafeStella_screenshot 2020_02_11 12_11_13.jpg");
            }
            */

            //customRichText1.BackColor = BackColor;


        }
        

        [System.Runtime.InteropServices.DllImport
("shell32.dll", EntryPoint = "IsUserAnAdmin")]
        extern static Boolean IsUserAnAdmin();



        string[] args;
        static readonly Func<string, string> EscapeCommandArg = x => x.Contains(' ') ? string.Format("\"{0}\"", x) : x;
        static readonly Func<string[], string> ToCommandArgs = x => string.Join(" ", x.Select(EscapeCommandArg));

        private void Registory()
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
        private void simpleButton10_Click(object sender, EventArgs e)
        {

        }
        /*
        private RegexOptions GetRegexOptions()
        {
            RegexOptions none = RegexOptions.None;
            foreach (int num in this.regexOptions.CheckedIndices)
            {
                none |= (RegexOptions)this.regexOptions.Items[num];
            }
            return none;
        }
        */
        public string DoRegexMatches(string input, string pattern, RegexOptions opt)
        {
            StringBuilder builder = new StringBuilder();
            MatchCollection matchs = new Regex(pattern, opt).Matches(input);
            for (int i = 0; i < matchs.Count; i++)
            {
                builder.AppendFormat("同じ文字数: {0}:{1}\r\n", i, matchs[i].Value);
                for (int j = 0; j < matchs[i].Groups.Count; j++)
                {
                    /*
                    builder.AppendFormat("  Groups[{0}]:{1}\r\n", j, matchs[i].Groups[j].Value);
                    for (int k = 0; k < matchs[i].Groups[j].Captures.Count; k++)
                    {
                        builder.AppendFormat("    Captures[{0}]:{1}\r\n", k, matchs[i].Groups[j].Captures[k].Value);
                    }
                    */
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
        public string DoRegexIsMatch(string input, string pattern, RegexOptions opt)
        {
            return new Regex(pattern, opt).IsMatch(input).ToString();
        }
        public string DoRegexReplace(string input, string pattern, string replacePattern, RegexOptions opt)
        {
            return new Regex(pattern, opt).Replace(input, replacePattern);
        }

        public string DoRegexSplit(string input, string pattern, RegexOptions opt)
        {
            string[] strArray = new Regex(pattern, opt).Split(input);
            return string.Join("\r\n", strArray);
        }
        /*
        findDialog findDlg = null; //検索ダイアログボックスのインスタンスを格納        
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            //二重起動を防止
            if (findDlg == null || findDlg.IsDisposed)
            {
                //検索ダイアログボックス用フォームのインスタンスを生成
                findDlg = new findDialog(dialogMode.Find, textBox1);
                //検索ダイアログボックスを表示
                findDlg.Show(this);
            }
            */
        /*
        string str = "";
        RegexOptions regexOptions = this.GetRegexOptions();
        RegexMode selectedValue = (RegexMode)this.regexMode.SelectedValue;
        try
        {
            switch (selectedValue)
            {
                case RegexMode.Matches:
                    str = this.DoRegexMatches(this.customRichText1.Text, this.textBox1.Text, regexOptions);
                    goto Label_00CC;
                    /*
                case RegexMode.IsMatch:
                    str = this.DoRegexIsMatch(this.customRichText1.Text, this.textBox1.Text, regexOptions);
                    goto Label_00CC;
                    */
        /*
    case RegexMode.Replace:
        str = this.DoRegexReplace(this.customRichText1.Text, this.textBox1.Text, this.textBox2.Text, regexOptions);
        goto Label_00CC;
        */
        /*
    case RegexMode.Split:
        str = this.DoRegexSplit(this.customRichText1.Text, this.textBox1.Text, regexOptions);
        goto Label_00CC;
        */
        /*
}
}
catch (ArgumentException exception)
{
str = string.Format("【エラーが発生しました】\r\n{0}", exception.Message);
}
Label_00CC:
this.listBox1.Items.Add(str);
*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void regexMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (((RegexMode)this.regexMode.SelectedValue) == RegexMode.Replace)
            {
                this.textBox2.ReadOnly = false;
            }
            else
            {
                this.textBox2.ReadOnly = true;
            }
            */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (((RegexMode)this.regexMode.SelectedValue) == RegexMode.Replace)
            {
                this.textBox2.ReadOnly = false;
            }
            else
            {
                this.textBox2.ReadOnly = true;
            }
            */
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (simpleButton14.Text == "メモ")
            {
                panel5.Visible = true;
                simpleButton14.Text = "メモ非表示";
            }
            else
            {
                panel5.Visible = false;
                simpleButton14.Text = "メモ";
            }
        }

        private void CustomRichText1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void customRichText1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void customRichText1_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.Control && e.KeyData == Keys.W)
            {
                customRichText1.Focus();
                customRichText1.AppendText("「」");
            }
            */
        }

        //private void = $TEST1 

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
            if (this.TopMost == false)
            {
                this.TopMost = true;
                simpleButton16.Text = "無効化";
                notifyIcon1.BalloonTipTitle = "INFO";
                notifyIcon1.BalloonTipText = "最前列: 有効化";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
                this.TopMost = false;
                simpleButton16.Text = "最前列";
                notifyIcon1.BalloonTipTitle = "INFO";
                notifyIcon1.BalloonTipText = "最前列: 無効化";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        void ChangeFont()
        {
            if (comboBox4.Text == "普通")
            {
                customRichText1.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Regular);
                customRichText3.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Regular);
                //customRichText1
            }
            if (comboBox4.Text == "斜体")
            {
                customRichText1.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Italic);
                customRichText3.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Italic);
            }
            if (comboBox4.Text == "普通(太)")
            {
                customRichText1.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Bold);
                customRichText3.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Bold);
            }
            if (comboBox4.Text == "下線")
            {
                customRichText1.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Underline);
                customRichText3.Font = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Underline);
            }
        }
        private void simpleButton17_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.font = comboBox2.Text;
            Properties.Settings.Default.fontweight = comboBox4.Text;
            Properties.Settings.Default.fontsize = (int)float.Parse(comboBox3.Text);
            Properties.Settings.Default.Save();
            ChangeFont();
            /*
            if (comboBox4.Text == "普通")
            {
                customRichText1.SelectionFont = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Regular);
                //customRichText1
            }
            if (comboBox4.Text == "斜体")
            {
                customRichText1.SelectionFont = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Italic);
            }
            if (comboBox4.Text == "普通(太)")
            {
                customRichText1.SelectionFont = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Bold);
            }
            if (comboBox4.Text == "下線")
            {
                customRichText1.SelectionFont = new System.Drawing.Font(comboBox2.Text, float.Parse(comboBox3.Text), FontStyle.Underline);
            }
            */
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            /*
            KeyControl a = new KeyControl();
            a.Show();
            */

            KeyControl f2 = new KeyControl(this); // 自フォームへの参照を渡す
            f2.Show();
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
            /*
            string filePath = @"C:\Novel Writer";

            if (Directory.Exists(filePath))
            {
                //Console.WriteLine("存在します");
            }
            else
            {
                string path = @"C:\Novel Writer";

                Directory.CreateDirectory(path);
            }
            */
            /*
            //ドキュメントを作成
            Document doc = new Document();
            //ファイルの出力先を設定
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Novel Writer\" + label11.Text + ".pdf", FileMode.Create));
            //ドキュメントを開く
            doc.Open();
            //「Hello iTextSharp」をドキュメントに追加
            doc.Add(new Paragraph(customRichText1.Text));
            //ドキュメントを閉じる
            doc.Close();
            */

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /*
                FileStream fs = new FileStream(saveFileDialog1.FileName + ".pdf", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(customRichText1.Text);
                sw.Close();
                fs.Close();
                */


                //ドキュメントを作成
                Document doc = new Document();
                //ファイルの出力先を設定
                PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName + ".pdf", FileMode.Create));
                doc.Open();
                //「Hello iTextSharp」をドキュメントに追加
                //doc.Add(new Paragraph(customRichText1.Text));
                //ドキュメントを閉じる
                //doc.Close();
                //［1］ MSゴシック
                iTextSharp.text.Font fnt1 = new iTextSharp.text.Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, true), 12);
                /*
                //［2］ MS Pゴシック-太字
                iTextSharp.text.Font fnt2 = new iTextSharp.text.Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, true),
                    32, iTextSharp.text.Font.BOLD);

                //［3］ MS UI Gothic-斜体-下線
                iTextSharp.text.Font fnt3 = new iTextSharp.text.Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msgothic.ttc,2", BaseFont.IDENTITY_H, true),
                    20, iTextSharp.text.Font.ITALIC | iTextSharp.text.Font.UNDERLINE);

                // ※CKJフォントを使う場合、事前にTextAsian.dllをロード（Form_Load参照）
                //［4］ CJK明朝
                iTextSharp.text.Font fnt4 = new iTextSharp.text.Font(BaseFont.CreateFont
                    ("HeiseiMin-W3", "UniJIS-UCS2-HW-H", false), 20);

                //［5］ CJKゴシック-赤色
                iTextSharp.text.Font fnt5 = new iTextSharp.text.Font(BaseFont.CreateFont
                    ("HeiseiKakuGo-W5", "UniJIS-UCS2-HW-H", false), 20);
                fnt5.SetColor(255, 0, 0);
                */
                //文言とフォントを指定してドキュメントに追加
                doc.Add(new Paragraph(customRichText1.Text, fnt1));
                /*
                doc.Add(new Paragraph("MS Pゴシックの太字です", fnt2));
                doc.Add(new Paragraph("MS UI Gothicの斜体／下線です", fnt3));
                doc.Add(new Paragraph("HeiseiMin-W3（明朝）です", fnt4));
                doc.Add(new Paragraph("HeiseiKakuGo-W5（ゴシック）の赤色です", fnt5));
                */
                //ドキュメントを閉じる
                doc.Close();

                XtraMessageBox.Show("ファイルを保存しました。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            string result = dt.ToString("時刻: " + "yyyy/MM/dd HH:mm:ss");
            label11.Text = result;

            /*
            result = dt.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            Console.WriteLine(result);

            Console.ReadKey();
            */
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            //customRichText1.SelectionStart = customRichText1.Text.Length;
            //テキストボックスにフォーカスを移動
            customRichText1.Focus();
            customRichText1.SelectionStart = 0;
            customRichText1.ScrollToCaret();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /*
            Keyword f2 = new Keyword(this); // 自フォームへの参照を渡す
            f2.Show();
            */
            KeyWordOpen();
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
            if (checkBox2.Checked == true)
            {

                CheckBoxClock = "True";
                timer1.Start();
                Properties.Settings.Default.checkboxauto = CheckBoxClock;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                CheckBoxClock = "False";
                timer1.Stop();
                label11.Text = "";
                Properties.Settings.Default.checkboxauto = CheckBoxClock;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkboxautosave = "True";
                Properties.Settings.Default.checkboxauto = checkboxautosave;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                checkboxautosave = "False";
                Properties.Settings.Default.checkboxauto = checkboxautosave;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
        }

        private void CheckBoxClock_TextChanged(object sender, EventArgs e)
        {
            if (CheckBoxClock == "True")
            {
                //timer1.Start();
                checkBox2.Checked = true;
            }
            else
            {
                //timer1.Stop();
                checkBox2.Checked = true;
            }
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
            if (checkBox3.Checked == true)
            {
                customRichText1.BackColor = Color.FromArgb(45, 45, 45);
                customRichText2.BackColor = Color.FromArgb(45, 45, 45);
                customRichText3.BackColor = Color.FromArgb(45, 45, 45);

                this.BackColor = Color.FromArgb(45, 45, 45);
                this.ForeColor = Color.White;

                customRichText1.ForeColor = Color.White;
                customRichText2.ForeColor = Color.White;
                customRichText3.ForeColor = Color.White;

                //checkBox3.BackColor = Color.FromArgb(45, 45, 45);

                darkmode = "True";
                Properties.Settings.Default.darkmode = darkmode;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                customRichText1.ForeColor = Color.White;
                customRichText2.ForeColor = Color.White;
                customRichText3.ForeColor = Color.White;

                this.BackColor = Color.WhiteSmoke;
                this.ForeColor = Color.Black;

                customRichText1.ForeColor = Color.Black;
                customRichText2.ForeColor = Color.Black;
                customRichText3.ForeColor = Color.Black;


                //checkBox3.BackColor = Color.WhiteSmoke;
                darkmode = "False";
                Properties.Settings.Default.darkmode = darkmode;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }

            //richTextBox2.BackColor = Color.FromArgb(45, 45, 45);
            /*
            if (checkBox3.Checked == true)
            {
                darkmode.Text = "True";
                Properties.Settings.Default.darkmode = darkmode.Text;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                darkmode.Text = "False";
                Properties.Settings.Default.darkmode = darkmode.Text;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            */
        }

        private void darkmode_TextChanged(object sender, EventArgs e)
        {
            if (darkmode == "True")
            {

                customRichText1.BackColor = Color.FromArgb(45, 45, 45);
                customRichText2.BackColor = Color.FromArgb(45, 45, 45);
                customRichText3.BackColor = Color.FromArgb(45, 45, 45);

                this.BackColor = Color.FromArgb(45, 45, 45);
                this.ForeColor = Color.White;

                customRichText1.ForeColor = Color.White;
                customRichText2.ForeColor = Color.White;
                customRichText3.ForeColor = Color.White;
                // checkBox3.BackColor = Color.FromArgb(45, 45, 45);
            }
            else
            {
                customRichText1.BackColor = Color.White;
                customRichText2.BackColor = Color.White;
                customRichText3.BackColor = Color.White;

                this.BackColor = Color.WhiteSmoke;
                this.ForeColor = Color.Black;

                customRichText1.ForeColor = Color.Black;
                customRichText2.ForeColor = Color.Black;
                customRichText3.ForeColor = Color.Black;

                //checkBox3.BackColor = Color.WhiteSmoke;

            }
            /*
            if (darkmode.Text == "True")
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            */
        }

        private void checkboxautosave_TextChanged(object sender, EventArgs e)
        {
            if (checkboxautosave == "True")
            {

                darkmode = "True";
                Properties.Settings.Default.checkboxauto = checkboxautosave;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }
            else
            {
                darkmode = "False";
                Properties.Settings.Default.checkboxauto = checkboxautosave;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }

        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            //印刷する文字列と位置を設定する
            printingText = "";
            printingPosition = 0;
            //印刷に使うフォントを指定する
            printFont = new System.Drawing.Font(comboBox2.Text, Int32.Parse(comboBox3.Text));
            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            //印刷を開始する
            pd.Print();
        }

        private void novel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.F11))
            {
                if (this.TopMost == false)
                {
                    this.TopMost = true;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 有効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    this.TopMost = false;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 無効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(1000);
                }
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                if (secret)
                {
                    //temp = customRichText1.Text;

                    StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    sw.Close();

                    customRichText1.Clear();
                    secret = false;
                }
                else
                {
                    StreamReader sr = new StreamReader($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", Encoding.GetEncoding("UTF-8"));

                    string text = sr.ReadToEnd();

                    sr.Close();

                    customRichText1.Text = text;
                    //temp = "";
                    secret = true;
                }
            }

                if (e.KeyData == Keys.F12)
            {
                if (panel1.Visible == true)
                {
                    panel1.Visible = false;
                }
                else
                {
                    panel1.Visible = true;
                }

            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (url != "")
                {
                    //ファイルに書き込む
                    StreamWriter sw = new StreamWriter(url, false,
                        System.Text.Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    //閉じる
                    sw.Close();
                    this.Text = "ノベルライター " + filename;
                }
                else
                {
                    XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき、
                    //選択された名前で新しいファイルを作成し、
                    //読み書きアクセス許可でそのファイルを開く。
                    //既存のファイルが選択されたときはデータが消える恐れあり。
                    stream = sfd.OpenFile();
                    string a = ".nvw";
                    if (stream != null)
                    {
                        url = sfd.FileName;
                        //MessageBox.Show(url);
                        stream.Close();
                        //StreamWriter sw = new StreamWriter(url, false,  Encoding.GetEncoding("shift_jis"));
                        StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                        sw.Write(customRichText1.Text);
                        sw.Close();

                        filename = Path.GetFileName(sfd.FileName);
                        this.Text = "ノベルライター " + filename;
                        XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            if (e.KeyData == (Keys.Control | Keys.F))
            {
                /*
                Keyword f2 = new Keyword(this); // 自フォームへの参照を渡す
                f2.Show();
                */
                KeyWordOpen();
            }
            if (e.KeyData == (Keys.Control | Keys.H))
            {
                KeyWordOpen();
            }
        }

        private void CustomRichText2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void novel_FormClosing(object sender, FormClosingEventArgs e)
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
                    Properties.Settings.Default.fix = 0;// この行はエラーになる    
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Memo = customRichText2.Text;// この行はエラーになる    
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.backupfix = "";
                    Properties.Settings.Default.Save();

                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "Novel Writer 終了しました。";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                    Environment.Exit(0);
                }
                else if (count_first == 1)
                {
                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = $"{Text} 終了しました。";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    File.Delete($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw");
                    File.Delete($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw");

                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = $"{Text} 終了しました。";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                
            }
            else
            {
                e.Cancel = true;
            }
        }

        public string F2 = "";
        public string F3 = "";
        public string F4 = "";
        public string F5 = "";

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (checkBox4.Text == "行数表示")
            {
                number = true;
                customRichText1.SelectionBullet = true;
                customRichText1.SelectedText = customRichText1.Text;
                customRichText1.SelectionBullet = false;
                checkBox4.Text = "行数表示解除";
            }
            else
            {

                number = false;
                checkBox4.Text = "行数表示";
            }
            */
        }


        private void simpleButton23_Click(object sender, EventArgs e)
        {
            /*
            //読み上げ

            SpVoice myvoice = new SpVoice();

            SpeechVoiceSpeakFlags myFlag = SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
            myvoice.Rate = 1;
            myvoice.Speak(customRichText1.Text, myFlag);
            */

            /*
            Talker talker = new Talker();
            ServiceControl.StartHost(false);
            talker.Cast = "IA";

            talker.Volume = 100;



            try
            {
                //string version = CeVIO.Talk.RemoteService.ServiceControl.HostVersion;
                talker.ToneScale = 100;
                //talker.Speed = 1;
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex);
            }
            /*
            string[] hairetu = { };

            
            foreach (var aaa in customRichText1.Text)
            {

                Array.Resize(ref hairetu, hairetu.Length + 1);
                hairetu[hairetu.Length - 1] = aaa;
            }
            */
            /*
            string str = customRichText1.Text;
            foreach (var n in str.SubstringAtCount(100))
            {
                talker.Speak(n);
                Thread.Sleep(20000);
            }
        */

            if (dockpanel)
            {
                dockpanel = false;
                splitContainer1.Panel2Collapsed = true;
                simpleButton23.Text = "2分割";
            }
            else
            {
                dockpanel = true;
                splitContainer1.Panel2Collapsed = false;
                customRichText1.Focus();
                simpleButton23.Text = "戻す";
            }
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
            int iLength = this.customRichText1.TextLength;
            if (comboBox5.Text == "全文字")
            {
                label1.Text = "文字数: " + iLength.ToString();
            }
            else if (comboBox5.Text == "空白無")
            {
                string NewString = Regex.Replace(customRichText1.Text, @"\s", "");
                label1.Text = "文字数: " + NewString.Length.ToString();
            }
            else if (comboBox5.Text == "改行無")
            {
                string someString = customRichText1.Text.Replace(Environment.NewLine, "");
                label1.Text = "文字数: " + someString.Length.ToString();
            }
            else if (comboBox5.Text == "空白改行無")
            {
                string NewString = Regex.Replace(customRichText1.Text, @"\s", "");
                string someString = NewString.Replace(Environment.NewLine, "");
                label1.Text = "文字数: " + someString.Length.ToString();
            }
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
            ChangeFont();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeFont();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeFont();
        }

        private void customRichText1_TextChanged(object sender, EventArgs e)
        {
            if (autoenter)
            {
                customRichText3.Text = customRichText1.Text;
            }
            //DrawLineNumber();
            /*
            int found = -1;
            //Coloring(customRichText1.Text, "俺", ForeColor.R);
            //   customRichText1.TextLen
            string keyword = "俺";
            found = customRichText1.Find(keyword, found + 1, RichTextBoxFinds.MatchCase);

            //byte color = ForeColor.R;

            // キーワードが見つかった場合は、その色を変更します。


                customRichText1.SelectionStart = found;

            customRichText1.SelectionLength = keyword.Length;

            customRichText1.SelectionColor = Color.Red;
            //customRichText1.SelectionColor = Color.Red;
            */

            //using System.Drawing;

            /*
            //色を変える文字列
            string searchWord = "俺";

            //現在の選択状態を覚えておく
            int currentSelectionStart = customRichText1.SelectionStart;
            int currentSelectionLength = customRichText1.SelectionLength;

            int pos = 0;
            for (;;)
            {
                //文字列を検索して、選択状態にする
                pos = customRichText1.Find(searchWord, pos, RichTextBoxFinds.MatchCase);
                if (pos < 0)
                {
                    break;
                }
                //背景色を赤にする
                customRichText1.SelectionBackColor = Color.Red;
                pos++;
            }

            //選択状態を元に戻す
            customRichText1.Select(currentSelectionStart, currentSelectionLength);
            */
            int iLength = this.customRichText1.TextLength;
            this.Text = "ノベルライター * " + filename;

            // こちらでも可能 
            //int iLength = this.textBox1.Text.Length;

            // 取得したテキストの文字数を表示する

            /*
            switch (comboBox5.Text)
            {
                case "全文字":

                    break;
            }

            */

            if (comboBox5.Text == "全文字")
            {
                label1.Text = "文字数: " + iLength.ToString();
            }
            else if (comboBox5.Text == "空白無")
            {
                string NewString = Regex.Replace(customRichText1.Text, @"\s", "");
                label1.Text = "文字数: " + NewString.Length.ToString();
            }
            else if (comboBox5.Text == "改行無")
            {
                string someString = customRichText1.Text.Replace(Environment.NewLine, "");
                label1.Text = "文字数: " + someString.Length.ToString();
            }
            else if (comboBox5.Text == "空白改行無")
            {
                string NewString = Regex.Replace(customRichText1.Text, @"\s", "");
                string someString = NewString.Replace(Environment.NewLine, "");
                label1.Text = "文字数: " + someString.Length.ToString();
            }


            if (checkboxautosave == "True")
            {
                Properties.Settings.Default.BackUp = customRichText1.Text;// この行はエラーになる    
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.backupfix = customRichText1.Text;
            Properties.Settings.Default.Save();

            StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\AutoSave\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
            sw.Write(customRichText1.Text);
            sw.Close();


            DateTime da = DateTime.Now;
            Properties.Settings.Default.time = da.ToString("yyyy年MM月dd日 HH:mm:ss");
            Properties.Settings.Default.Save();
        }

        private void customRichText1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!autoenter)
            {
                autoenter = true;
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                if (secret)
                {
                    //temp = customRichText1.Text;

                    StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    sw.Close();

                    customRichText1.Clear();
                    secret = false;
                }
                else
                {
                    StreamReader sr = new StreamReader($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", Encoding.GetEncoding("UTF-8"));

                    string text = sr.ReadToEnd();

                    sr.Close();

                    customRichText1.Text = text;
                    //temp = "";
                    secret = true;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.F11))
            {
                if (this.TopMost == false)
                {
                    this.TopMost = true;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 有効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    this.TopMost = false;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 無効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(1000);
                }
            }

            /*
            if (e.KeyData == Keys.Tab)
            {
                if (tabSwitch == true & customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = "    ";
            }
            */


            if (e.KeyData == (Keys.Control | Keys.Tab))
            {
                //customRichText3.Focus();
                ActiveControl = customRichText1;
            }
            if (e.KeyData == Keys.Control && e.KeyData == Keys.Home)
            {
                settings a = new settings(this);
                a.Show();
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                KeyWordOpen();
            }
            if (e.KeyData == (Keys.Control | Keys.H))
            {
                KeyWordOpen();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (url != "")
                {
                    //ファイルに書き込む
                    StreamWriter sw = new StreamWriter(url, false,
                        System.Text.Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    //閉じる
                    sw.Close();
                    this.Text = "ノベルライター " + filename;
                }
                else
                {
                    XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき、
                    //選択された名前で新しいファイルを作成し、
                    //読み書きアクセス許可でそのファイルを開く。
                    //既存のファイルが選択されたときはデータが消える恐れあり。
                    stream = sfd.OpenFile();
                    string a = ".nvw";
                    if (stream != null)
                    {
                        url = sfd.FileName;
                        //MessageBox.Show(url);
                        stream.Close();
                        //StreamWriter sw = new StreamWriter(url, false,  Encoding.GetEncoding("shift_jis"));
                        StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                        sw.Write(customRichText1.Text);
                        sw.Close();

                        filename = Path.GetFileName(sfd.FileName);
                        this.Text = "ノベルライター " + filename;
                        XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            if (e.KeyData == Keys.F12)
            {
                if (panel1.Visible == true)
                {
                    panel1.Visible = false;
                }
                else
                {
                    panel1.Visible = true;
                }
            }


            if (e.KeyData == Keys.F10)
            {
                DateTime a = DateTime.Now;
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = (a.ToString("yyyy年MM月dd日dddd"));
                //customRichText1.AppendText(a.ToString("yyyy年MM月dd日dddd"));
            }
            if (e.KeyData == Keys.F11)
            {
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = ("\r\n起\r\n\r\n承\r\n\r\n転\r\n\r\n結\r\n\r\n");
            }

            if (e.KeyData == Keys.F1)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText1.SelectionBackColor = Color.OrangeRed;
                    customRichText1.DeselectAll();
                    customRichText1.SelectionBackColor = Color.FromArgb(45, 45, 45);
                }
                else
                {
                    customRichText1.SelectionBackColor = Color.OrangeRed;
                    customRichText1.DeselectAll();
                    customRichText1.SelectionBackColor = Color.White;
                }
            }
            if (e.KeyData == Keys.F2)
            {
                customRichText1.SelectionBackColor = Color.FromArgb(45, 45, 45);
                customRichText1.DeselectAll();
            }

            if (e.KeyData == Keys.Escape)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText1.SelectionBackColor = Color.FromArgb(45, 45, 45);
                    customRichText1.DeselectAll();
                }
                else
                {
                    customRichText1.DeselectAll();
                    customRichText1.SelectionBackColor = Color.White;
                    customRichText1.DeselectAll();
                }
            }


            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.PageUp))
            {
                if (dockpanel)
                {
                    dockpanel = false;
                    splitContainer1.Panel2Collapsed = true;
                    customRichText1.Focus();
                    simpleButton23.Text = "2分割";
                }
                else
                {
                    dockpanel = true;
                    splitContainer1.Panel2Collapsed = false;
                    simpleButton23.Text = "戻す";
                }
            }

            if (e.KeyData == Keys.F2)
            {
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = F2;//DateTime.Now.ToString("HH:mm") + "\r\n";
                customRichText1.Focus();
                /*
                customRichText1.SelectionLength = 0; //なくてもいい
                customRichText1.SelectionStart = customRichText1.Text.Length;
                */
                /*
                customRichText1.Focus();
                customRichText1.AppendText(F2.Text);


                customRichText1.SelectionStart = customRichText1.Text.Length;
                //テキストボックスにフォーカスを移動
                customRichText1.Focus();
                */
                //  customRichText1.SelectionStart =

                //s  customRichText1.ScrollToCaret();
                //  customRichText1.SelectionStart = customRichText1.Text.Length;
                //customRichText1.Select(1, customRichText1.Text.Length);
                //customRichText1.Select(1, customRichText1.SelectionStart = customRichText1.Text.Length);
                //customRichText1.SelectionStart = customRichText1.Text.Length.Last;
                //  customRichText1.Select(0, 0);
            }
            if (e.KeyData == Keys.F3)
            {
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = F3;//DateTime.Now.ToString("HH:mm") + "\r\n";
                customRichText1.Focus();
            }
            if (e.KeyData == Keys.F4)
            {
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = F4;//DateTime.Now.ToString("HH:mm") + "\r\n";
                customRichText1.Focus();
            }
            if (e.KeyData == Keys.F5)
            {
                if (customRichText1.SelectedText.Length == 0)
                    customRichText1.SelectedText = F5;//DateTime.Now.ToString("HH:mm") + "\r\n";
                customRichText1.Focus();
            }
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
            settings setting = new settings(this);
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
            if (e.KeyData == (Keys.Control | Keys.F11))
            {
                if (this.TopMost == false)
                {
                    this.TopMost = true;
                }
                else
                {
                    this.TopMost = false;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                if (secret)
                {
                    //temp = customRichText1.Text;

                    StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    sw.Close();

                    customRichText1.Clear();
                    secret = false;
                }
                else
                {
                    StreamReader sr = new StreamReader($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", Encoding.GetEncoding("UTF-8"));

                    string text = sr.ReadToEnd();

                    sr.Close();

                    customRichText1.Text = text;
                    //temp = "";
                    secret = true;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (url != "")
                {
                    //ファイルに書き込む
                    StreamWriter sw = new StreamWriter(url, false,
                        System.Text.Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText1.Text);
                    //閉じる
                    sw.Close();
                    this.Text = "ノベルライター " + filename;
                }
                else
                {
                    XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき、
                    //選択された名前で新しいファイルを作成し、
                    //読み書きアクセス許可でそのファイルを開く。
                    //既存のファイルが選択されたときはデータが消える恐れあり。
                    stream = sfd.OpenFile();
                    string a = ".nvw";
                    if (stream != null)
                    {
                        url = sfd.FileName;
                        //MessageBox.Show(url);
                        stream.Close();
                        //StreamWriter sw = new StreamWriter(url, false,  Encoding.GetEncoding("shift_jis"));
                        StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                        sw.Write(customRichText1.Text);
                        sw.Close();

                        filename = Path.GetFileName(sfd.FileName);
                        this.Text = "ノベルライター " + filename;
                        XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }


            if (e.KeyData == Keys.F12)
            {
                if (panel1.Visible == true)
                {
                    panel1.Visible = false;
                }
                else
                {
                    panel1.Visible = true;
                }
            }


            if (e.KeyData == Keys.F10)
            {
                DateTime a = DateTime.Now;
                if (customRichText2.SelectedText.Length == 0)
                    customRichText2.SelectedText = (a.ToString("yyyy年MM月dd日"));
                //customRichText1.AppendText(a.ToString("yyyy年MM月dd日dddd"));
            }
            if (e.KeyData == Keys.F11)
            {
                if (customRichText2.SelectedText.Length == 0)
                    customRichText2.SelectedText = ("\r\n起\r\n\r\n承\r\n\r\n転\r\n\r\n結\r\n\r\n");
            }

            if (e.KeyData == Keys.F1)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText2.SelectionBackColor = Color.OrangeRed;
                    customRichText2.DeselectAll();
                    customRichText2.SelectionBackColor = Color.FromArgb(45, 45, 45);
                }
                else
                {
                    customRichText2.SelectionBackColor = Color.OrangeRed;
                    customRichText2.DeselectAll();
                    customRichText2.SelectionBackColor = Color.White;
                }
            }

            if (e.KeyData == Keys.F2)
            {
                customRichText2.SelectionBackColor = Color.FromArgb(45, 45, 45);
                customRichText2.DeselectAll();
            }

            if (e.KeyData == Keys.Escape)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText1.SelectionBackColor = Color.FromArgb(45, 45, 45);
                    customRichText1.DeselectAll();
                }
                else
                {
                    customRichText1.DeselectAll();
                    customRichText1.SelectionBackColor = Color.White;
                    customRichText1.DeselectAll();
                }
            }
            /*
            if (e.KeyData == Keys.Tab)
            {
                if (tabSwitch == true & customRichText2.SelectedText.Length == 0)
                    customRichText2.SelectedText = "    ";
            }
            */
        }

        private void customRichText3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!autoenter)
            {
                autoenter = true;
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                if (secret)
                {
                    //temp = customRichText1.Text;

                    StreamWriter sw = new StreamWriter($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText3.Text);
                    sw.Close();

                    customRichText3.Clear();
                    secret = false;
                }
                else
                {
                    StreamReader sr = new StreamReader($@"{localPath}ノベルライター\Secret\{tempFileDate}.nvw", Encoding.GetEncoding("UTF-8"));

                    string text = sr.ReadToEnd();

                    sr.Close();

                    customRichText3.Text = text;
                    //temp = "";
                    secret = true;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.F11))
            {
                if (this.TopMost == false)
                {
                    this.TopMost = true;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 有効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    this.TopMost = false;
                    notifyIcon1.BalloonTipTitle = "INFO";
                    notifyIcon1.BalloonTipText = "最前列: 無効化";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(1000);
                }
            }

            /*
            if (e.KeyData == Keys.Tab)
            {
                if (tabSwitch == true & customRichText3.SelectedText.Length == 0)
                    customRichText3.SelectedText = "    ";
            }
            */
            if (e.KeyData == (Keys.Control | Keys.Tab))
            {
                //customRichText3.Focus();
                ActiveControl = customRichText3;
            }
            if (e.KeyData == Keys.Control && e.KeyData == Keys.Home)
            {
                settings a = new settings(this);
                a.Show();
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                KeyWordOpen();
            }
            if (e.KeyData == (Keys.Control | Keys.H))
            {
                KeyWordOpen();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (url != "")
                {
                    //ファイルに書き込む
                    StreamWriter sw = new StreamWriter(url, false,
                        System.Text.Encoding.GetEncoding("UTF-8"));
                    sw.Write(customRichText3.Text);
                    //閉じる
                    sw.Close();
                    this.Text = "ノベルライター " + filename;
                }
                else
                {
                    XtraMessageBox.Show("ファイルを開く、名前を付けて保存\r\nでファイルが選択されていないため、保存ができません。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき、
                    //選択された名前で新しいファイルを作成し、
                    //読み書きアクセス許可でそのファイルを開く。
                    //既存のファイルが選択されたときはデータが消える恐れあり。
                    stream = sfd.OpenFile();
                    string a = ".nvw";
                    if (stream != null)
                    {
                        url = sfd.FileName;
                        //MessageBox.Show(url);
                        stream.Close();
                        //StreamWriter sw = new StreamWriter(url, false,  Encoding.GetEncoding("shift_jis"));
                        StreamWriter sw = new StreamWriter(url, false, Encoding.GetEncoding("UTF-8"));
                        sw.Write(customRichText3.Text);
                        sw.Close();

                        filename = Path.GetFileName(sfd.FileName);
                        this.Text = "ノベルライター " + filename;
                        XtraMessageBox.Show("保存されました。\r\n" + url, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            if (e.KeyData == Keys.F12)
            {
                if (panel1.Visible == true)
                {
                    panel1.Visible = false;
                }
                else
                {
                    panel1.Visible = true;
                }
            }


            if (e.KeyData == Keys.F10)
            {
                DateTime a = DateTime.Now;
                if (customRichText3.SelectedText.Length == 0)
                    customRichText3.SelectedText = (a.ToString("yyyy年MM月dd日dddd"));
                //customRichText1.AppendText(a.ToString("yyyy年MM月dd日dddd"));
            }
            if (e.KeyData == Keys.F11)
            {
                if (customRichText3.SelectedText.Length == 0)
                    customRichText3.SelectedText = ("\r\n起\r\n\r\n承\r\n\r\n転\r\n\r\n結\r\n\r\n");
            }

            if (e.KeyData == Keys.F1)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText3.SelectionBackColor = Color.OrangeRed;
                    customRichText3.DeselectAll();
                    customRichText3.SelectionBackColor = Color.FromArgb(45, 45, 45);
                }
                else
                {
                    customRichText3.SelectionBackColor = Color.OrangeRed;
                    customRichText3.DeselectAll();
                    customRichText3.SelectionBackColor = Color.White;
                }
            }
            if (e.KeyData == Keys.F2)
            {
                customRichText3.SelectionBackColor = Color.FromArgb(45, 45, 45);
                customRichText3.DeselectAll();
            }

            if (e.KeyData == Keys.Escape)
            {
                if (checkBox3.Checked == true)
                {
                    customRichText3.SelectionBackColor = Color.FromArgb(45, 45, 45);
                    customRichText3.DeselectAll();
                }
                else
                {
                    customRichText3.DeselectAll();
                    customRichText3.SelectionBackColor = Color.White;
                    customRichText3.DeselectAll();
                }
            }


            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.PageUp))
            {
                if (dockpanel)
                {
                    dockpanel = false;
                    splitContainer1.Panel2Collapsed = true;
                    customRichText3.Focus();
                    simpleButton23.Text = "2分割";
                }
                else
                {
                    dockpanel = true;
                    splitContainer1.Panel2Collapsed = false;
                    simpleButton23.Text = "戻す";
                }
            }
        }
    }
}

public static class StringExtensions
{
    public static string[] SubstringAtCount(this string self, int count)
    {
        var result = new List<string>();
        var length = (int)Math.Ceiling((double)self.Length / count);

        for (int i = 0; i < length; i++)
        {
            int start = count * i;
            if (self.Length <= start)
            {
                break;
            }
            if (self.Length < start + count)
            {
                result.Add(self.Substring(start));
            }
            else
            {
                result.Add(self.Substring(start, count));
            }
        }

        return result.ToArray();
    }
}