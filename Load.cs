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
using System.IO;

namespace novel
{
    public partial class Load : DevExpress.XtraEditors.XtraForm
    {
        public Load()
        {
            InitializeComponent();
            //StartPosition = FormStartPosition.CenterScreen;
            this.progressPanel1.AutoHeight = true;
        }

        private void progressPanel1_Click(object sender, EventArgs e)
        {

        }
        string path = Path.GetTempPath();
        string[] files;

        private bool sw = true;
        private void Load_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists($@"{path}ノベルライター"))
            {
                Directory.CreateDirectory($@"{path}ノベルライター");
            }
            if (!Directory.Exists($@"{path}ノベルライター\AutoSave"))
            {
                Directory.CreateDirectory($@"{path}ノベルライター\AutoSave");
            }
            if (!Directory.Exists($@"{path}ノベルライター\Secret"))
            {
                Directory.CreateDirectory($@"{path}ノベルライター\Secret");
            }

            if (!Directory.Exists($@"{System.AppDomain.CurrentDomain.BaseDirectory}Settings\Image"))
            {
                Directory.CreateDirectory($@"{System.AppDomain.CurrentDomain.BaseDirectory}Settings\Image");
            }

            string[] files = System.IO.Directory.GetFiles(
                $@"{path}ノベルライター\AutoSave", "*", System.IO.SearchOption.AllDirectories);

            string[] argFiles = System.Environment.GetCommandLineArgs();
            var files1 = argFiles.Skip(1);
            //MessageBox.Show(files.Length.ToString());

            foreach (var filePath in files1)
            {
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        novel appNovel = new novel(filePath);
                        appNovel.Show();
                        sw = false;
                        break;
                    }
                    catch
                    {
                        XtraMessageBox.Show(String.Format("{0}を開くことができません", filePath), "エラー", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
            
            
            if (sw)
            {
                if (files.Count() > 0)
                {
                    AutoSaver appAutoSaver = new AutoSaver();
                    appAutoSaver.Show();
                }
                else
                {
                   
                    novel appNovel = new novel();
                    appNovel.Show();
                }
            }
            
            //Visible = false;
            //Hide();
        }

        private void Load_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}