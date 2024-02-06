using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPOS_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly Font StatusFont = new Font("源ノ角ゴシック JP Normal ", 36,FontStyle.Italic); //状態表示用
        Brush textColor = new SolidBrush(Color.FromArgb(40, 40, 40));

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.StateResult = StateResult.Regist;
            WriteStatusToDisplay(Program.StateResult);
        }

        private void WriteStatusToDisplay(StateResult State)
        {
            Brush textColor = new SolidBrush(Color.FromArgb(40, 40, 40));
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            string stateMessage = null;
            switch (State)
            {
                case StateResult.Idle:
                    stateMessage = "";
                    break;
                case StateResult.Regist:
                    stateMessage = "売上登録";
                    break;
                case StateResult.Payment:
                    stateMessage = "支払";
                    break;
            }
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.FillRectangle(new SolidBrush(Color.GreenYellow),new Rectangle(0,0,canvas.Width,canvas.Height));
                g.DrawString(stateMessage,StatusFont,textColor,75,5);
            }
            pictureBox1.Image = canvas;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
