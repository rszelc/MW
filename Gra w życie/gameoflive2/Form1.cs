using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameoflive2
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Timer T = new Timer();
        int licz = 0;
        public Form1()
        {
            InitializeComponent();
            T.Interval = 100;
            T.Tick += new EventHandler(T_Tick);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            int moves = Int32.Parse(textBox4.Text);
            
            move(moves, licz);
            licz++;
        }

        SolidBrush brush = new SolidBrush(Color.);
        Bitmap bmp;
        Graphics gr;
        int[,] tab;
        int[,] tab2;
        int sizex;
        int sizey;
        int px;
        
        void next()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    check(i, j);
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i,j] = tab2[i,j];
                    tab2[i,j] = 0;
                }
            }

        }
        void check(int x, int y)
        {
            int temp = 0;
            int cell = isAlive(x, y);
            if (x == 0 && y == 0)
            {
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x + 1,y + 1] == 1) temp++;
                if (tab[x,sizey - 1] == 1) temp++;
                if (tab[x + 1,sizey - 1] == 1) temp++;
                if (tab[sizex-1, sizey - 1] == 1) temp++;
                if (tab[sizex-1, y] == 1) temp++;
                if (tab[sizex-1, y+1] == 1) temp++;
            }
            else if (x == 0 && y == sizey - 1)
            {
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x + 1,y - 1] == 1) temp++;
                if (tab[0,0] == 1) temp++;
                if (tab[1,0] == 1) temp++;
                if (tab[sizex-1, y-1] == 1) temp++;
                if (tab[sizex - 1, y ] == 1) temp++;
                if (tab[sizex-1, 0] == 1) temp++;
            }
            else if (x == sizex - 1 && y == 0)
            {
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x - 1,y + 1] == 1) temp++;
                if (tab[x,sizey - 1] == 1) temp++;
                if (tab[x - 1,sizey - 1] == 1) temp++;
                if (tab[0, 0] == 1) temp++;
                if (tab[0, 1] == 1) temp++;
                if (tab[0, sizey-1] == 1) temp++;
            }
            else if (x == sizex - 1 && y == sizey - 1)
            {
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x - 1,y - 1] == 1) temp++;
                if (tab[sizex - 1,0] == 1) temp++;
                if (tab[sizex - 2,0] == 1) temp++;
                if (tab[0, sizey-2] == 1) temp++;
                if (tab[0, sizey-1] == 1) temp++;
                if (tab[0, 0] == 1) temp++;
            }
            else if (x == 0 && y != 0 && y != sizey - 1)
            {
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x + 1,y - 1] == 1) temp++;
                if (tab[x + 1,y + 1] == 1) temp++;
                if (tab[sizex-1, y] == 1) temp++;
                if (tab[sizex - 1, y - 1] == 1) temp++;
                if (tab[sizex - 1, y + 1] == 1) temp++;
            }
            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
            {
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x - 1,y - 1] == 1) temp++;
                if (tab[x - 1,y + 1] == 1) temp++;
                if (tab[0, y] == 1) temp++;
                if (tab[0, y - 1] == 1) temp++;
                if (tab[0, y + 1] == 1) temp++;
            }
            else if (x != 0 && x != sizex - 1 && y == 0)
            {
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x - 1,y + 1] == 1) temp++;
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x + 1,y + 1] == 1) temp++;
                if (tab[x - 1,sizey - 1] == 1) temp++;
                if (tab[x,sizey - 1] == 1) temp++;
                if (tab[x + 1,sizey - 1] == 1) temp++;
            }
            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
            {
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x - 1,y - 1] == 1) temp++;
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x + 1,y - 1] == 1) temp++;
                if (tab[x - 1,0] == 1) temp++;
                if (tab[x,0] == 1) temp++;
                if (tab[x + 1,0] == 1) temp++;
            }
            else
            {
                if (tab[x - 1,y - 1] == 1) temp++;
                if (tab[x,y - 1] == 1) temp++;
                if (tab[x + 1,y - 1] == 1) temp++;
                if (tab[x - 1,y] == 1) temp++;
                if (tab[x + 1,y] == 1) temp++;
                if (tab[x - 1,y + 1] == 1) temp++;
                if (tab[x,y + 1] == 1) temp++;
                if (tab[x + 1,y + 1] == 1) temp++;
            }

            if (cell == 0 && temp == 3)
                tab2[x,y] = 1;
            if (cell == 1 && temp > 1 && temp < 4)
                tab2[x,y] = 1;
            if (cell == 1 && temp < 2 && temp > 3)
                tab2[x,y] = 0;

        }
        int isAlive(int x, int y)
        {
            if (tab[x,y] == 1)
                return 1;
            else
                return 0;
        }
        void draw()
        {
            for(int i=0;i<=px*sizex;i+=px)
            {
                for (int j = 0; j <= px * sizey; j += px)
                    if (tab[i / px, j / px] == 1)
                    {
                        gr.FillRectangle(brush, j, i, px, px);
                    }
            }
            pictureBox1.Image = bmp;
        }
        void move(int moves, int l)
        {
            if (l < moves)
            {
                gr.Clear(pictureBox1.BackColor);
                next();
                draw();
            }
            else
            {
                T.Stop();
                licz = -1;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            T.Start();
        }
        double rnd()
        {
            
            double x = rand.NextDouble();
            return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            px = Int32.Parse(textBox5.Text);
            pictureBox1.Width = px * Int32.Parse(textBox1.Text);
            pictureBox1.Height = px * Int32.Parse(textBox6.Text);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(bmp);
            sizey = Int32.Parse(textBox1.Text);
            sizex = Int32.Parse(textBox6.Text);
            tab = new int[sizex+1, sizey+1];
            tab2 = new int[sizex+1, sizey+1];
            
            for (int i=0;i<=sizex;i++)
            {
                for (int j = 0; j <= sizey; j++)
                {
                    tab[i, j] = 0;
                    tab2[i, j] = 0;
                }
            }
            if(comboBox1.Text=="niezmienny")
            {
                tab[1, 2] = 1;
                tab[1, 3] = 1;
                tab[2, 1] = 1;
                tab[2, 4] = 1;
                tab[3, 2] = 1;
                tab[3, 3] = 1;
                draw();
            }
            else if (comboBox1.Text == "glider")
            {
                tab[1, 2] = 1;
                tab[1, 3] = 1;
                tab[2, 1] = 1;
                tab[2, 2] = 1;
                tab[3, 3] = 1;
                draw();
            }
            else if (comboBox1.Text == "oscylator")
            {
                tab[2, 2] = 1;
                tab[3, 2] = 1;
                tab[4, 2] = 1;
                draw();
            }
            else if (comboBox1.Text == "losowy")
            {
                for(int i = 0;i<=sizex;i++)
                {
                    for (int j = 0; j <= sizey; j++)
                    {
                        double x = rnd();
                        if (x < 0.4)
                        {
                            tab[i, j] = 1;
                        }

                    }
                }
                draw();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            T.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tab[Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text)] = 1;
            draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= sizex; i++)
            {
                for (int j = 0; j <= sizey; j++)
                {
                    tab[i, j] = 0;
                    tab2[i, j] = 0;
                }
            }
            pictureBox1.Image = null;
        }
    }
}
