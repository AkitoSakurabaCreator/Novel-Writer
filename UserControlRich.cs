using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novel
{
    public partial class UserControlRich : UserControl
    {
        public UserControlRich()
        {
            InitializeComponent();
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            richTextBox1.VScroll += RichTextBox1_VScroll;
        }
        private void RichTextBox1_VScroll(object sender, EventArgs e)
        {
            DrawLineNumber();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            DrawLineNumber();
        }

        void DrawLineNumber()
        {
            int lineNum = 0;
            int height = richTextBox1.Size.Height;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            int charIndex = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
            lineNum = richTextBox1.GetLineFromCharIndex(charIndex);

            while (true)
            {
                charIndex = richTextBox1.GetFirstCharIndexFromLine(lineNum);
                if (charIndex == -1)
                    break;
                Point pt = richTextBox1.GetPositionFromCharIndex(charIndex);
                Font f = new Font("ＭＳ 明朝", 10, GraphicsUnit.Pixel);
                g.DrawString((lineNum + 1).ToString(), f, Brushes.Blue, new PointF(0, pt.Y));
                lineNum++;

                if (height < pt.Y)
                    break;
            }
            g.Dispose();
        }
    }
}
