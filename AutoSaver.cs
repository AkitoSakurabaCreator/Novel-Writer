using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.StructuredStorage.Internal.Writer;
using DevExpress.XtraEditors;
using System.Security.Policy;

namespace novel
{
    public partial class AutoSaver : DevExpress.XtraEditors.XtraForm
    {
        public AutoSaver()
        {
            InitializeComponent();
        }

        string path = Path.GetTempPath();

        SaveFileDialog sfd = new SaveFileDialog();
        Stream stream;
        /*
        IEnumerable<string> files =
            System.IO.Directory.EnumerateFiles(
                $@"{Path.GetTempPath()}ノベルライター\AutoSave", "*", System.IO.SearchOption.AllDirectories);
        */
        string[] files = System.IO.Directory.GetFiles(
            $@"{Path.GetTempPath()}ノベルライター\AutoSave", "*", System.IO.SearchOption.AllDirectories);
        
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            novel appNovel = new novel();
            appNovel.Show();
        }

        private void AutoSaver_Load(object sender, EventArgs e)
        {


            if (files.Count() > 0)
            {
                foreach (string f in files)
                {
                    listBox1.Items.Add(Path.GetFileName(f));
                }
            }

            sfd.Filter = "ノベルライター|*.nvw";
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //StreamReader. files[listBox1.SelectedIndex];
                StreamReader sr = new StreamReader(
                    files[listBox1.SelectedIndex], Encoding.GetEncoding("UTF-8"));

                string text = sr.ReadToEnd();

                sr.Close();
                richTextBox1.Text = text;
            }
            catch (Exception ex)
            {

            }
        }

        private void AutoSaver_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
            Form currentForm = novel.ActiveForm;
            if (currentForm.Controls.Count == 0)
            {
                Environment.Exit(0);
            }
            */

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(files[listBox1.SelectedIndex]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                richTextBox1.Clear();
                files[listBox1.SelectedIndex] = null;
            }
            catch (Exception ex)
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(files[listBox1.SelectedIndex]);
            novel appNovel = new novel(files[listBox1.SelectedIndex]);
            //appNovel.Owner = this;
            appNovel.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    stream.Close();

                    StreamReader sr = new StreamReader(files[listBox1.SelectedIndex], Encoding.GetEncoding("UTF-8"));

                    string rec = sr.ReadToEnd();

                    sr.Close();
                    StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("UTF-8"));
                    sw.Write(rec);
                    sw.Close();

                    XtraMessageBox.Show("復元されました。\r\n" + sfd.FileName, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AutoSaver_FormClosing(object sender, FormClosingEventArgs e)
        {
            int count_first = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "novel")
                {
                    count_first++;
                    continue;
                }
            }
            if (count_first == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
                XtraMessageBox.Show("ノベルライターを全て閉じてください。", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                try
                {
                    File.Delete(files[listBox1.SelectedIndex]);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    richTextBox1.Clear();
                    files[listBox1.SelectedIndex] = null;
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}