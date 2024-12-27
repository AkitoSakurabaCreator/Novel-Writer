using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novel
{
    public partial class UplaterDownload : Form
    {
        public UplaterDownload()
        {
            InitializeComponent();
        }
        private void method_0(object sender, DownloadProgressChangedEventArgs e)
        {
            base.BeginInvoke(new MethodInvoker(delegate
            {
                double num = double.Parse(e.BytesReceived.ToString());
                double num2 = double.Parse(e.TotalBytesToReceive.ToString());
                double d = num / num2 * 100.0;
                this.progressBarControl1.EditValue = int.Parse(Math.Truncate(d).ToString());
            }));
        }

        // Token: 0x0600024A RID: 586 RVA: 0x00067CF4 File Offset: 0x00065EF4
        private void method_1(object sender, AsyncCompletedEventArgs e)
        {
            XtraMessageBox.Show("アップデートが完了しました。再起動します。\r\n再起動されない場合はお手数ですが、\r\n手動で起動してください。", "アップデート", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string text = "";
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            for (int i = 1; i < commandLineArgs.Length; i++)
            {
                if (1 < i)
                {
                    text += " ";
                }
                text = text + "\"" + commandLineArgs[i] + "\"";
            }
            //Process.Start(Application.ExecutablePath, text);
            //Application.Exit();
            //Environment.Exit(0);
            Process.Start(Application.ExecutablePath, text);
            Application.Exit();
        }

        private void UplaterDownload_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
            try
            {
                File.Move("Novel Writer.exe", "old.exe");
            }
            catch (Exception ex)
            {

            }

            WebClient webClient = new WebClient();
            try
            {
                string uriString = "https://kaedeworks.web.fc2.com/novelwriter/NovelWriter.exe";
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.method_0);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.method_1);
                webClient.DownloadFileAsync(new Uri(uriString), "Novel Writer.exe");
            }
            catch (Exception)
            {
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(40000);
        }
    }
}
