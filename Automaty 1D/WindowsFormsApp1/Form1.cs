using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 1);
        SolidBrush brush = new SolidBrush(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }
        void move90(int x, int[,] tab, int[,] tab2, int size)
        {
            for (int k = 0; k < x; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0)
                        {
                            if ((tab[i - 1,size - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 0) || (tab[i - 1,size - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 0) || (tab[i - 1,size - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 1) || (tab[i - 1,size - 1] == 0 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                        else if (j == (size - 1))
                        {
                            if ((tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,0] == 0) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,0] == 0) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,0] == 1) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 0 && tab[i - 1,0] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                        else
                        {
                            if ((tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 0) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 0) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 1) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i,j] = tab2[i,j];
                    }
                }
            }
        }
        void move120(int x, int[,] tab, int[,] tab2, int size)
        {
            for (int k = 0; k < x; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0)
                        {
                            if ((tab[i - 1,size - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 0) || (tab[i - 1,size - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 1) || (tab[i - 1,size - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 0) || (tab[i - 1,size - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                        else if (j == (size - 1))
                        {
                            if ((tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,0] == 0) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,0] == 1) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,0] == 0) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,0] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                        else
                        {
                            if ((tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 0) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 1) || (tab[i - 1,j - 1] == 1 && tab[i - 1,j] == 0 && tab[i - 1,j + 1] == 0) || (tab[i - 1,j - 1] == 0 && tab[i - 1,j] == 1 && tab[i - 1,j + 1] == 1))
                            {
                                tab2[i,j] = 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i,j] = tab2[i,j];
                    }
                }
            }
        }
        void move30(int x, int[,] tab, int[,] tab2, int size)
        {
            for (int k = 0; k < x; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0)
                        {
                            if ((tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                        else if (j == (size - 1))
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 1))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                        else
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = tab2[i, j];
                    }
                }
            }
        }
        void move60(int x, int[,] tab, int[,] tab2, int size)
        {
            for (int k = 0; k < x; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0)
                        {
                            if ((tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1) || (tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                        else if (j == (size - 1))
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 1) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                        else
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = tab2[i, j];
                    }
                }
            }
        }
        void move225(int x, int[,] tab, int[,] tab2, int size)
        {
            for (int k = 0; k < x; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0)
                        {
                            if ((tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0) || (tab[i - 1, size - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1) || (tab[i - 1, size - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                            else
                                tab2[i, j] = 0;
                        }
                        else if (j == (size - 1))
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 1) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, 0] == 0) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, 0] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                            else
                                tab2[i, j] = 0;
                        }
                        else
                        {
                            if ((tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 1) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 1 && tab[i - 1, j + 1] == 0) || (tab[i - 1, j - 1] == 1 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 1) || (tab[i - 1, j - 1] == 0 && tab[i - 1, j] == 0 && tab[i - 1, j + 1] == 0))
                            {
                                tab2[i, j] = 1;
                            }
                            else
                                tab2[i, j] = 0;

                        }
                        
                    }

                    for (int a = 0; a < size; a++)
                    {
                        for (int b = 0; b < size; b++)
                        {
                            tab[a, b] = tab2[a, b];
                        }
                    }
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int px = Int32.Parse(textBox2.Text);
            pictureBox1.Width = px*Int32.Parse(textBox1.Text);
            pictureBox1.Height = px*Int32.Parse(textBox1.Text);
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if(Int32.Parse(comboBox1.Text)==90)
            {
                int size = Int32.Parse(textBox1.Text);
                int moves = Int32.Parse(textBox3.Text);
                int[,] tab = new int[size, size];
                int[,] tab2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i,j] = 0;
                        tab2[i,j] = 0;
                    }
                }
                tab[1, 20] = 1;
                gr.FillRectangle(brush, px*20, px*1, px*1, px*1);
                move90(moves, tab, tab2, size);
                
                for(int i=0;i<px*size;i+=4)
                {
                    for(int j=0;j<px*size;j+=4)
                    {
                        if (tab[i/px, j/px] == 1)
                            gr.FillRectangle(brush, j, i, px, px);
                    }

                }
            }
            if (Int32.Parse(comboBox1.Text) == 30)
            {
                int size = Int32.Parse(textBox1.Text);
                int moves = Int32.Parse(textBox3.Text);
                int[,] tab = new int[size, size];
                int[,] tab2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = 0;
                        tab2[i, j] = 0;
                    }
                }
                tab[1, 20] = 1;
                gr.FillRectangle(brush, px * 20, px * 1, px * 1, px * 1);
                move30(moves, tab, tab2, size);

                for (int i = 0; i < px * size; i += 4)
                {
                    for (int j = 0; j < px * size; j += 4)
                    {
                        if (tab[i / px, j / px] == 1)
                            gr.FillRectangle(brush, j, i, px, px);
                    }

                }
            }
            if (Int32.Parse(comboBox1.Text) == 120)
            {
                int size = Int32.Parse(textBox1.Text);
                int moves = Int32.Parse(textBox3.Text);
                int[,] tab = new int[size, size];
                int[,] tab2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = 0;
                        tab2[i, j] = 0;
                    }
                }
                tab[1, 20] = 1;
                gr.FillRectangle(brush, px * 20, px * 1, px * 1, px * 1);
                move120(moves, tab, tab2, size);

                for (int i = 0; i < px * size; i += 4)
                {
                    for (int j = 0; j < px * size; j += 4)
                    {
                        if (tab[i / px, j / px] == 1)
                            gr.FillRectangle(brush, j, i, px, px);
                    }

                }
            }
            if (Int32.Parse(comboBox1.Text) == 60)
            {
                int size = Int32.Parse(textBox1.Text);
                int moves = Int32.Parse(textBox3.Text);
                int[,] tab = new int[size, size];
                int[,] tab2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = 0;
                        tab2[i, j] = 0;
                    }
                }
                tab[1, 20] = 1;
                gr.FillRectangle(brush, px * 20, px * 1, px * 1, px * 1);
                move60(moves, tab, tab2, size);

                for (int i = 0; i < px * size; i += 4)
                {
                    for (int j = 0; j < px * size; j += 4)
                    {
                        if (tab[i / px, j / px] == 1)
                            gr.FillRectangle(brush, j, i, px, px);
                    }

                }
            }
            if (Int32.Parse(comboBox1.Text) == 225)
            {
                int size = Int32.Parse(textBox1.Text);
                int moves = Int32.Parse(textBox3.Text);
                int[,] tab = new int[size, size];
                int[,] tab2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        tab[i, j] = 0;
                        tab2[i, j] = 0;
                    }
                }
                tab[0, 20] = 1;
                tab2[0, 20] = 1;
                //gr.FillRectangle(brush, px * 20, px * 3, px * 1, px * 1);
                move225(moves, tab, tab2, size);

                for (int i = 0; i < px * size; i += 4)
                {
                    for (int j = 0; j < px * size; j += 4)
                    {
                        if (tab[i / px, j / px] == 1)
                            gr.FillRectangle(brush, j, i, px, px);
                    }

                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
