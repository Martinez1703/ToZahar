using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3LabInd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            xDistance = pictureBox1.Width / 2 - 45;
            yDistance = pictureBox1.Height / 2 - 50;

            xDistance1 = pictureBox1.Width / 2;
            yDistance1 = pictureBox1.Height / 2 - 20;

           
            // Ensure that the Paint event of pictureBox1 is handled
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint_1);
        }

        int xDistance;
        int yDistance;
        int xDistance1;
        int yDistance1;

        Form2 form2 = new Form2();
        private void Draw_Text(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(60, 56, 141), 5);
            // 6
            g.DrawLine(pen, xDistance - 160, yDistance - 20, xDistance - 140, yDistance - 20);
            g.DrawLine(pen, xDistance - 160, yDistance - 20, xDistance - 160, yDistance + 20);
            g.DrawLine(pen, xDistance - 160, yDistance, xDistance - 140, yDistance);
            g.DrawLine(pen, xDistance - 140, yDistance, xDistance - 140, yDistance + 20);
            g.DrawLine(pen, xDistance - 160, yDistance + 20, xDistance - 140, yDistance + 20);
            // 3
            g.DrawLine(pen, xDistance - 130, yDistance - 20, xDistance - 110, yDistance - 20);
            g.DrawLine(pen, xDistance - 110, yDistance - 20, xDistance - 110, yDistance);
            g.DrawLine(pen, xDistance - 130, yDistance, xDistance - 110, yDistance);
            g.DrawLine(pen, xDistance - 110, yDistance, xDistance - 110, yDistance + 20);
            g.DrawLine(pen, xDistance - 130, yDistance + 20, xDistance - 110, yDistance + 20);
            // г
            g.DrawLine(pen, xDistance - 80, yDistance, xDistance - 60, yDistance);
            g.DrawLine(pen, xDistance - 80, yDistance, xDistance - 80, yDistance + 24);
            // о
            g.DrawLine(pen, xDistance - 50, yDistance, xDistance - 30, yDistance);
            g.DrawLine(pen, xDistance - 50, yDistance, xDistance - 50, yDistance + 20);
            g.DrawLine(pen, xDistance - 50, yDistance + 20, xDistance - 30, yDistance + 20);
            g.DrawLine(pen, xDistance - 30, yDistance, xDistance - 30, yDistance + 20);
            // д
            g.DrawLine(pen, xDistance - 15, yDistance, xDistance - 2, yDistance);
            g.DrawLine(pen, xDistance - 20, yDistance + 20, xDistance - 0, yDistance + 20);
            g.DrawLine(pen, xDistance - 15, yDistance, xDistance - 17, yDistance + 20);
            g.DrawLine(pen, xDistance - 2, yDistance, xDistance - 2, yDistance + 20);
            g.DrawLine(pen, xDistance - 20, yDistance + 20, xDistance - 20, yDistance + 28);
            g.DrawLine(pen, xDistance - 0, yDistance + 20, xDistance - 0, yDistance + 28);
            // а
            g.DrawLine(pen, xDistance + 10, yDistance, xDistance + 30, yDistance);
            g.DrawLine(pen, xDistance + 10, yDistance + 13, xDistance + 30, yDistance + 13);
            g.DrawLine(pen, xDistance + 10, yDistance, xDistance + 10, yDistance + 24);
            g.DrawLine(pen, xDistance + 30, yDistance, xDistance + 30, yDistance + 24);
            // T
            g.DrawLine(pen, xDistance + 58, yDistance - 20, xDistance + 92, yDistance - 20);
            g.DrawLine(pen, xDistance + 75, yDistance - 20, xDistance + 75, yDistance + 24);
            // U
            g.DrawLine(pen, xDistance + 100, yDistance - 22, xDistance + 100, yDistance + 20);
            g.DrawLine(pen, xDistance + 100, yDistance + 20, xDistance + 130, yDistance + 20);
            g.DrawLine(pen, xDistance + 130, yDistance - 22, xDistance + 130, yDistance + 20);
            // S
            g.DrawLine(pen, xDistance + 140, yDistance - 20, xDistance + 172, yDistance - 20);
            g.DrawLine(pen, xDistance + 140, yDistance - 20, xDistance + 140, yDistance);
            g.DrawLine(pen, xDistance + 140, yDistance, xDistance + 170, yDistance);
            g.DrawLine(pen, xDistance + 170, yDistance, xDistance + 170, yDistance + 20);
            g.DrawLine(pen, xDistance + 170, yDistance + 20, xDistance + 138, yDistance + 20);
            // U
            g.DrawLine(pen, xDistance + 180, yDistance - 22, xDistance + 180, yDistance + 20);
            g.DrawLine(pen, xDistance + 180, yDistance + 20, xDistance + 210, yDistance + 20);
            g.DrawLine(pen, xDistance + 210, yDistance - 22, xDistance + 210, yDistance + 20);
            // R
            g.DrawLine(pen, xDistance + 220, yDistance - 20, xDistance + 250, yDistance - 20);
            g.DrawLine(pen, xDistance + 220, yDistance - 20, xDistance + 220, yDistance + 22);
            g.DrawLine(pen, xDistance + 250, yDistance - 20, xDistance + 250, yDistance);
            g.DrawLine(pen, xDistance + 220, yDistance, xDistance + 250, yDistance);
            g.DrawLine(pen, xDistance + 220, yDistance, xDistance + 252, yDistance + 20);
        }

        private void Draw_Logo(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(60, 56, 141), 16);

            g.DrawLine(pen, xDistance1 - 200, yDistance1 + 20, xDistance1 - 200, yDistance1 + 100);
            g.DrawLine(pen, xDistance1 - 240, yDistance1 + 20, xDistance1 - 160, yDistance1 + 20);

            g.DrawLine(pen, xDistance1 - 140, yDistance1 + 20, xDistance1 - 100, yDistance1 + 60);
            g.DrawLine(pen, xDistance1 - 60, yDistance1 + 20, xDistance1 - 120, yDistance1 + 100);

            g.DrawLine(pen, xDistance1 - 40, yDistance1 + 20, xDistance1 - 40, yDistance1 + 100);
            g.DrawLine(pen, xDistance1 - 40, yDistance1 + 95, xDistance1 + 40, yDistance1 + 95);
            g.DrawLine(pen, xDistance1 - 40, yDistance1 + 25, xDistance1 + 40, yDistance1 + 25);

            g.DrawLine(pen, xDistance1 + 60, yDistance1 + 20, xDistance1 + 100, yDistance1 + 60);
            g.DrawLine(pen, xDistance1 + 140, yDistance1 + 20, xDistance1 + 80, yDistance1 + 100);

            g.DrawLine(pen, xDistance1 + 160, yDistance1 + 20, xDistance1 + 160, yDistance1 + 100);
            g.DrawLine(pen, xDistance1 + 160, yDistance1 + 25, xDistance1 + 240, yDistance1 + 25);
            g.DrawLine(pen, xDistance1 + 240, yDistance1 + 20, xDistance1 + 240, yDistance1 + 70);
            g.DrawLine(pen, xDistance1 + 160, yDistance1 + 70, xDistance1 + 240, yDistance1 + 70);
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            Draw_Text(e.Graphics);
            Draw_Logo(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
    }
}
