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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        double k, l;
        double[,] tr = new double[3, 3]; // матрица треугольника
        double[,] pt = new double[5, 3]; // матрица пятиугольника
        private float rotationAngleTr = 0;
        private float rotationAnglePt = 0;
        private float rotationSpeedTr = 1; // скорость вращения треугольника
        private float rotationSpeedPt = 1; // скорость вращения пятиугольника

        private void Init_tr()
        {
            // Координаты треугольника (центр в начале координат)
            tr[0, 0] = -50; tr[0, 1] = 50; tr[0, 2] = 1;  // Вершина 1
            tr[1, 0] = 50; tr[1, 1] = 50; tr[1, 2] = 1;   // Вершина 2
            tr[2, 0] = 0; tr[2, 1] = -50; tr[2, 2] = 1;    // Вершина 3
        }

        private void Init_pt()
        {
            // Координаты пятиугольника (центр в начале координат)
            pt[0, 0] = -50; pt[0, 1] = -20; pt[0, 2] = 1;
            pt[1, 0] = 50; pt[1, 1] = -20; pt[1, 2] = 1;
            pt[2, 0] = 70; pt[2, 1] = 30; pt[2, 2] = 1;
            pt[3, 0] = 0; pt[3, 1] = 50; pt[3, 2] = 1;
            pt[4, 0] = -70; pt[4, 1] = 30; pt[4, 2] = 1;
        }

        private void Draw_Tr()
        {
            k = pictureBox1.Width / 2;  // Центр по X
            l = pictureBox1.Height / 2; // Центр по Y

            Init_tr();
            double[,] tr1 = Multiply_matr(tr, Init_matr_preob(k, l, rotationAngleTr));

            Pen myPen = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, (float)tr1[0, 0], (float)tr1[0, 1], (float)tr1[1, 0], (float)tr1[1, 1]);
            g.DrawLine(myPen, (float)tr1[1, 0], (float)tr1[1, 1], (float)tr1[2, 0], (float)tr1[2, 1]);
            g.DrawLine(myPen, (float)tr1[2, 0], (float)tr1[2, 1], (float)tr1[0, 0], (float)tr1[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void Draw_Pt()
        {
            k = pictureBox1.Width / 4;  // Центр по X (тот же, что и для треугольника)
            l = pictureBox1.Height / 2; // Центр по Y (тот же, что и для треугольника)

            Init_pt();
            double[,] pt1 = Multiply_matr(pt, Init_matr_preob(k, l, rotationAnglePt));

            Pen myPen = new Pen(Color.Red, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, (float)pt1[0, 0], (float)pt1[0, 1], (float)pt1[1, 0], (float)pt1[1, 1]);
            g.DrawLine(myPen, (float)pt1[1, 0], (float)pt1[1, 1], (float)pt1[2, 0], (float)pt1[2, 1]);
            g.DrawLine(myPen, (float)pt1[2, 0], (float)pt1[2, 1], (float)pt1[3, 0], (float)pt1[3, 1]);
            g.DrawLine(myPen, (float)pt1[3, 0], (float)pt1[3, 1], (float)pt1[4, 0], (float)pt1[4, 1]);
            g.DrawLine(myPen, (float)pt1[4, 0], (float)pt1[4, 1], (float)pt1[0, 0], (float)pt1[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private double[,] Init_matr_preob(double k1, double l1, double angle)
        {
            double angleRadians = angle * Math.PI / 180.0;
            double cosTheta = Math.Cos(angleRadians);
            double sinTheta = Math.Sin(angleRadians);

            double[,] matr = new double[3, 3];
            matr[0, 0] = cosTheta; matr[0, 1] = -sinTheta; matr[0, 2] = 0;
            matr[1, 0] = sinTheta; matr[1, 1] = cosTheta; matr[1, 2] = 0;
            matr[2, 0] = k1; matr[2, 1] = l1; matr[2, 2] = 1;

            return matr;
        }

        private void picture_clean()
        {
            pictureBox1.Image = null;
            pictureBox1.Refresh();
        }

        private double[,] Multiply_matr(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            double[,] r = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            picture_clean();
            Draw_Tr();
            Draw_Pt();
            rotationAngleTr -= rotationSpeedTr;
            rotationAnglePt += rotationSpeedPt;

            if (rotationAngleTr < -360) rotationAngleTr += 360;
            if (rotationAnglePt > 360) rotationAnglePt -= 360;

            await Task.Delay(10);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    rotationSpeedTr += 1;
                    break;
                case Keys.Down:
                    rotationSpeedTr = Math.Max(1, rotationSpeedTr - 1);
                    break;
                case Keys.W:
                    rotationSpeedPt += 1;
                    break;
                case Keys.S:
                    rotationSpeedPt = Math.Max(1, rotationSpeedPt - 1);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture_clean();
            Draw_Tr();
            Draw_Pt();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Draw_Pt();
            Draw_Tr();
        }
        //очистка бокса
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1 = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                rotationAngleTr = 0;
                rotationAnglePt = 0;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
