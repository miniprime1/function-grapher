using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Function_Grapher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float f(float x, float a, float b, float c)
        {
            double f_x = a * x * x / 50 + b * x + c * 10;
            float fixed_f_x = float.Parse(Convert.ToString(-1 * f_x));
            return fixed_f_x;
        }

        private void DrawGrid(Panel p)
        {
            Graphics g = p.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Brushes.Black);
            pen.Width = 3.0F;
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(pen, new PointF(0, 150), new PointF(300, 150));
            g.DrawLine(pen, new PointF(150, 0), new PointF(150, 300));
            pen.Dispose();
        }

        private void DrawGraph(Panel p)
        {
            Graphics g = p.CreateGraphics();
            g.Clear(Color.White);
            float a = 0, b = 0, c = 0;
            try { a = float.Parse(textBox1.Text); } catch { a = 0; }
            try { b = float.Parse(textBox2.Text); } catch { b = 0; }
            try { c = float.Parse(textBox3.Text); } catch { c = 0; }
            DrawGrid(p);
            Pen pen = new Pen(Brushes.Red);
            pen.Width = 1.0F;
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            for (int i = -150; i < 150; i++) { g.DrawLine(pen, new PointF(i+150, f(i,a,b,c)+150), new PointF(i+150+1, f(i+1,a,b,c)+150)); }
            pen.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(panel1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DrawGraph(panel1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DrawGraph(panel1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DrawGraph(panel1);
        }
    }
}
