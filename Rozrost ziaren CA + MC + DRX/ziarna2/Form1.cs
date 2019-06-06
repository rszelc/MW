using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ziarna2
{
    public partial class Form1 : Form
    {
        Timer T = new Timer();
        Timer T2 = new Timer();
        int licz = 0;
        Random rpent = new Random();
        Random rheks = new Random();
        public Form1()
        {
            InitializeComponent();
            T.Interval = 100;
            T.Tick += new EventHandler(T_Tick);
            T2.Interval = 100;
            T2.Tick += new EventHandler(T2_Tick);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Periodyczne")
            {
                if (comboBox1.Text == "Von Neumann")
                    neumann();
                else if (comboBox1.Text == "Moore")
                {
                    moore();
                }
                else if (comboBox1.Text == "Pentagonalnie")
                {
                    pent();
                }
                else if (comboBox1.Text == "Heksagonalnie")
                {
                    heks();
                }
                else if (comboBox1.Text == "Heksagonalne L")
                {
                    heksl();
                }
                else if (comboBox1.Text == "Heksagonalne P")
                {
                    hekspraw();
                }
                else if (comboBox1.Text == "Z promieniem")
                {

                }
            }

            else if (comboBox3.Text == "Absorbujące")
                if (comboBox1.Text == "Von Neumann")
                    neumannp();
                else if (comboBox1.Text == "Moore")
                {
                    moorep();
                }
                else if (comboBox1.Text == "Pentagonalnie")
                {
                    pentp();
                }
                else if (comboBox1.Text == "Heksagonalnie")
                {
                    heksp();
                }
                else if (comboBox1.Text == "Z promieniem")
                {

                }
            if (comboBox4.Text == "Map")
            {
                draw();
            }
            else if (comboBox4.Text == "Energy map")
            {
                draw_energyp();
            }
        }
        private void T2_Tick(object sender, EventArgs e)
        {
            int[,] memory = new int[sizex + 1, sizey + 1];
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    memory[i, j] = 0;
                    tab2[i, j] = tab[i, j];
                }
            }
            Random rnd = new Random();
            if (comboBox3.Text == "Periodyczne")
            {
                if (comboBox1.Text == "Von Neumann")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    for (int z = 0; z < sizex * sizey; z++)
                    {
                        int x;
                        int y;
                        int cond = 0;
                        int temp = 0;
                        while (cond < 1000 && temp == 0)
                        {
                            x = rnd.Next(sizex);
                            y = rnd.Next(sizey);
                            cond++;
                            if (memory[x, y] == 1)
                            {
                                continue;
                            }
                            temp++;
                            int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                            if (l < 0) l = sizey - 1;
                            if (p == sizey) p = 0;
                            if (g < 0) g = sizex - 1;
                            if (d == sizex) d = 0;
                            int E = 0;
                            if (tab[x, l] != tab[x, y]) E++;
                            if (tab[x, p] != tab[x, y]) E++;
                            if (tab[g, y] != tab[x, y]) E++;
                            if (tab[d, y] != tab[x, y]) E++;
                            
                            int choice = rand.Next(4);
                            int E2 = 0;
                            if (choice == 0)
                            {
                                if (tab[x, l] != tab[x, l]) E2++;
                                if (tab[x, p] != tab[x, l]) E2++;
                                if (tab[g, y] != tab[x, l]) E2++;
                                if (tab[d, y] != tab[x, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: "+kt+" num: "+num+" P: "+P+" R "+R+ " E2: "+E2+" E: "+E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 1)
                            {
                                if (tab[x, l] != tab[x, p]) E2++;
                                if (tab[x, p] != tab[x, p]) E2++;
                                if (tab[g, y] != tab[x, p]) E2++;
                                if (tab[d, y] != tab[x, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 2)
                            {
                                if (tab[x, l] != tab[g, y]) E2++;
                                if (tab[x, p] != tab[g, y]) E2++;
                                if (tab[g, y] != tab[g, y]) E2++;
                                if (tab[d, y] != tab[g, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 3)
                            {
                                if (tab[x, l] != tab[d, y]) E2++;
                                if (tab[x, p] != tab[d, y]) E2++;
                                if (tab[g, y] != tab[d, y]) E2++;
                                if (tab[d, y] != tab[d, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                        }
                    }
                    for (int i = 0; i < sizex; i++)
                        for (int j = 0; j < sizey; j++)
                            tab[i, j] = tab2[i, j];
                }
                else if (comboBox1.Text == "Moore")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    for (int z = 0; z < sizex * sizey; z++)
                    {
                        int x;
                        int y;
                        int cond = 0;
                        int temp = 0;
                        while (cond < 1000 && temp == 0)
                        {
                            x = rnd.Next(sizex);
                            y = rnd.Next(sizey);
                            cond++;
                            if (memory[x, y] == 1)
                            {
                                continue;
                            }
                            temp++;
                            int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                            if (l < 0) l = sizey - 1;
                            if (p == sizey) p = 0;
                            if (g < 0) g = sizex - 1;
                            if (d == sizex) d = 0;
                            int E = 0;
                            if (tab[x, l] != tab[x, y]) E++;
                            if (tab[x, p] != tab[x, y]) E++;
                            if (tab[g, y] != tab[x, y]) E++;
                            if (tab[d, y] != tab[x, y]) E++;
                            if (tab[g, l] != tab[x, y]) E++;
                            if (tab[g, p] != tab[x, y]) E++;
                            if (tab[d, l] != tab[x, y]) E++;
                            if (tab[d, p] != tab[x, y]) E++;
                            
                            int choice = rand.Next(8);
                            int E2 = 0;
                            if (choice == 0)
                            {
                                if (tab[x, l] != tab[x, l]) E2++;
                                if (tab[x, p] != tab[x, l]) E2++;
                                if (tab[g, y] != tab[x, l]) E2++;
                                if (tab[d, y] != tab[x, l]) E2++;
                                if (tab[g, l] != tab[x, l]) E2++;
                                if (tab[g, p] != tab[x, l]) E2++;
                                if (tab[d, l] != tab[x, l]) E2++;
                                if (tab[d, p] != tab[x, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 1)
                            {
                                if (tab[x, l] != tab[x, p]) E2++;
                                if (tab[x, p] != tab[x, p]) E2++;
                                if (tab[g, y] != tab[x, p]) E2++;
                                if (tab[d, y] != tab[x, p]) E2++;
                                if (tab[g, l] != tab[x, p]) E2++;
                                if (tab[g, p] != tab[x, p]) E2++;
                                if (tab[d, l] != tab[x, p]) E2++;
                                if (tab[d, p] != tab[x, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 2)
                            {
                                if (tab[x, l] != tab[g, y]) E2++;
                                if (tab[x, p] != tab[g, y]) E2++;
                                if (tab[g, y] != tab[g, y]) E2++;
                                if (tab[d, y] != tab[g, y]) E2++;
                                if (tab[g, l] != tab[g, y]) E2++;
                                if (tab[g, p] != tab[g, y]) E2++;
                                if (tab[d, l] != tab[g, y]) E2++;
                                if (tab[d, p] != tab[g, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 3)
                            {
                                if (tab[x, l] != tab[d, y]) E2++;
                                if (tab[x, p] != tab[d, y]) E2++;
                                if (tab[g, y] != tab[d, y]) E2++;
                                if (tab[d, y] != tab[d, y]) E2++;
                                if (tab[g, l] != tab[d, y]) E2++;
                                if (tab[g, p] != tab[d, y]) E2++;
                                if (tab[d, l] != tab[d, y]) E2++;
                                if (tab[d, p] != tab[d, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 4)
                            {
                                if (tab[x, l] != tab[g, l]) E2++;
                                if (tab[x, p] != tab[g, l]) E2++;
                                if (tab[g, y] != tab[g, l]) E2++;
                                if (tab[d, y] != tab[g, l]) E2++;
                                if (tab[g, l] != tab[g, l]) E2++;
                                if (tab[g, p] != tab[g, l]) E2++;
                                if (tab[d, l] != tab[g, l]) E2++;
                                if (tab[d, p] != tab[g, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 5)
                            {
                                if (tab[x, l] != tab[g, p]) E2++;
                                if (tab[x, p] != tab[g, p]) E2++;
                                if (tab[g, y] != tab[g, p]) E2++;
                                if (tab[d, y] != tab[g, p]) E2++;
                                if (tab[g, l] != tab[g, p]) E2++;
                                if (tab[g, p] != tab[g, p]) E2++;
                                if (tab[d, l] != tab[g, p]) E2++;
                                if (tab[d, p] != tab[g, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 6)
                            {
                                if (tab[x, l] != tab[d, l]) E2++;
                                if (tab[x, p] != tab[d, l]) E2++;
                                if (tab[g, y] != tab[d, l]) E2++;
                                if (tab[d, y] != tab[d, l]) E2++;
                                if (tab[g, l] != tab[d, l]) E2++;
                                if (tab[g, p] != tab[d, l]) E2++;
                                if (tab[d, l] != tab[d, l]) E2++;
                                if (tab[d, p] != tab[d, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 7)
                            {
                                if (tab[x, l] != tab[d, p]) E2++;
                                if (tab[x, p] != tab[d, p]) E2++;
                                if (tab[g, y] != tab[d, p]) E2++;
                                if (tab[d, y] != tab[d, p]) E2++;
                                if (tab[g, l] != tab[d, p]) E2++;
                                if (tab[g, p] != tab[d, p]) E2++;
                                if (tab[d, l] != tab[d, p]) E2++;
                                if (tab[d, p] != tab[d, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                        }
                    }
                    for (int i = 0; i < sizex; i++)
                        for (int j = 0; j < sizey; j++)
                            tab[i, j] = tab2[i, j];
                }
                else if (comboBox1.Text == "Pentagonalnie")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    int pent = rpent.Next(5);
                    if(pent == 0)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                //if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                //if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                                //if (tab[d, p] != tab[x, y]) E++;
                                
                                int choice = rand.Next(8);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    //if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                   // if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                   // if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    //if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    //if (tab[g, p] != tab[g, y]) E2++;
                                    if (tab[d, l] != tab[g, y]) E2++;
                                   // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                   // if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    if (tab[g, l] != tab[d, y]) E2++;
                                   // if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                   // if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    //if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                    if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                    //if (tab[g, p] != tab[g, l]) E2++;
                                    if (tab[d, l] != tab[g, l]) E2++;
                                    //if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    //if (tab[x, p] != tab[d, l]) E2++;
                                    if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                    if (tab[g, l] != tab[d, l]) E2++;
                                   // if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    //if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 1)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                               // if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                               // if (tab[d, l] != tab[x, y]) E++;
                               // if (tab[d, p] != tab[x, y]) E++;
                                
                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                   // if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                    if (tab[g, p] != tab[x, l]) E2++;
                                   // if (tab[d, l] != tab[x, l]) E2++;
                                   // if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                   // if (tab[d, y] != tab[x, p]) E2++;
                                    if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                   // if (tab[d, l] != tab[x, p]) E2++;
                                   // if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                   // if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                   // if (tab[d, l] != tab[g, y]) E2++;
                                   // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                   // if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                    if (tab[g, p] != tab[g, l]) E2++;
                                   // if (tab[d, l] != tab[g, l]) E2++;
                                   // if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    //if (tab[d, y] != tab[g, p]) E2++;
                                    if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                   // if (tab[d, l] != tab[g, p]) E2++;
                                   // if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 2)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                               // if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                //if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                               // if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                   // if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                   // if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                   // if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                   // if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                   // if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                    //if (tab[d, l] != tab[g, y]) E2++;
                                    if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                   // if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                   // if (tab[g, l] != tab[d, y]) E2++;
                                    if (tab[g, p] != tab[d, y]) E2++;
                                   // if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    //if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    if (tab[d, y] != tab[g, p]) E2++;
                                   // if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                    //if (tab[d, l] != tab[g, p]) E2++;
                                    if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    //if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                    if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                    //if (tab[g, l] != tab[d, p]) E2++;
                                    if (tab[g, p] != tab[d, p]) E2++;
                                   // if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 3)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                               // if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                              //  if (tab[g, l] != tab[x, y]) E++;
                               // if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    //if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    //if (tab[g, l] != tab[x, l]) E2++;
                                   // if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                    if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                   // if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                   // if (tab[g, l] != tab[x, p]) E2++;
                                   // if (tab[g, p] != tab[x, p]) E2++;
                                    if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                   //if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                   // if (tab[g, l] != tab[d, y]) E2++;
                                   // if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    if (tab[x, p] != tab[d, l]) E2++;
                                    //if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                   // if (tab[g, l] != tab[d, l]) E2++;
                                   // if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                   // if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                   // if (tab[g, l] != tab[d, p]) E2++;
                                   // if (tab[g, p] != tab[d, p]) E2++;
                                    if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                               
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                }
                else if (comboBox1.Text == "Heksagonalnie")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    int heks = rheks.Next(2);
                    if (heks == 0)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                //if (tab[g, p] != tab[x, y]) E++;
                                //if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;
                                
                                int choice = rand.Next(6);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                    //if (tab[g, p] != tab[x, l]) E2++;
                                   // if (tab[d, l] != tab[x, l]) E2++;
                                    if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                    if (tab[g, l] != tab[x, p]) E2++;
                                    //if (tab[g, p] != tab[x, p]) E2++;
                                    //if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    //if (tab[g, p] != tab[g, y]) E2++;
                                    //if (tab[d, l] != tab[g, y]) E2++;
                                    if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    if (tab[g, l] != tab[d, y]) E2++;
                                    //if (tab[g, p] != tab[d, y]) E2++;
                                    //if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                    if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                   // if (tab[g, p] != tab[g, l]) E2++;
                                   // if (tab[d, l] != tab[g, l]) E2++;
                                    if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 5)
                                {
                                    if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                    if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                    if (tab[g, l] != tab[d, p]) E2++;
                                    if (tab[g, p] != tab[d, p]) E2++;
                                    if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                               
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (heks == 1)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = sizey - 1;
                                if (p == sizey) p = 0;
                                if (g < 0) g = sizex - 1;
                                if (d == sizex) d = 0;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                               // if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                               // if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(6);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                  //  if (tab[g, l] != tab[x, l]) E2++;
                                    if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                    //if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                   // if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                    if (tab[d, l] != tab[x, p]) E2++;
                                    //if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    //if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                    if (tab[d, l] != tab[g, y]) E2++;
                                   // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    //if (tab[g, l] != tab[d, y]) E2++;
                                    if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                    //if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    if (tab[d, y] != tab[g, p]) E2++;
                                    //if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                    if (tab[d, l] != tab[g, p]) E2++;
                                    //if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 5)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    if (tab[x, p] != tab[d, l]) E2++;
                                    if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                    //if (tab[g, l] != tab[d, l]) E2++;
                                    if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    //if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                               
                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                }
                else if (comboBox1.Text == "Z promieniem")
                {

                }
            }
            else if (comboBox3.Text == "Absorbujące")
            {
                if (comboBox1.Text == "Von Neumann")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    for (int z = 0; z < sizex * sizey; z++)
                    {
                        int x;
                        int y;
                        int cond = 0;
                        int temp = 0;
                        while (cond < 1000 && temp == 0)
                        {
                            x = rnd.Next(sizex);
                            y = rnd.Next(sizey);
                            cond++;
                            if (memory[x, y] == 1)
                            {
                                continue;
                            }
                            temp++;
                            int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                            if (l < 0) l = y;
                            if (p == sizey) p = y;
                            if (g < 0) g = x;
                            if (d == sizex) d = x;
                            int E = 0;
                            if (tab[x, l] != tab[x, y]) E++;
                            if (tab[x, p] != tab[x, y]) E++;
                            if (tab[g, y] != tab[x, y]) E++;
                            if (tab[d, y] != tab[x, y]) E++;
                            int choice = rand.Next(4);
                            int E2 = 0;
                            if (choice == 0)
                            {
                                if (tab[x, l] != tab[x, l]) E2++;
                                if (tab[x, p] != tab[x, l]) E2++;
                                if (tab[g, y] != tab[x, l]) E2++;
                                if (tab[d, y] != tab[x, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: "+kt+" num: "+num+" P: "+P+" R "+R+ " E2: "+E2+" E: "+E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 1)
                            {
                                if (tab[x, l] != tab[x, p]) E2++;
                                if (tab[x, p] != tab[x, p]) E2++;
                                if (tab[g, y] != tab[x, p]) E2++;
                                if (tab[d, y] != tab[x, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 2)
                            {
                                if (tab[x, l] != tab[g, y]) E2++;
                                if (tab[x, p] != tab[g, y]) E2++;
                                if (tab[g, y] != tab[g, y]) E2++;
                                if (tab[d, y] != tab[g, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            if (choice == 3)
                            {
                                if (tab[x, l] != tab[d, y]) E2++;
                                if (tab[x, p] != tab[d, y]) E2++;
                                if (tab[g, y] != tab[d, y]) E2++;
                                if (tab[d, y] != tab[d, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                        }
                    }
                    for (int i = 0; i < sizex; i++)
                        for (int j = 0; j < sizey; j++)
                            tab[i, j] = tab2[i, j];
                }
                else if (comboBox1.Text == "Moore")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    for (int z = 0; z < sizex * sizey; z++)
                    {
                        int x;
                        int y;
                        int cond = 0;
                        int temp = 0;
                        while (cond < 1000 && temp == 0)
                        {
                            x = rnd.Next(sizex);
                            y = rnd.Next(sizey);
                            cond++;
                            if (memory[x, y] == 1)
                            {
                                continue;
                            }
                            temp++;
                            int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                            if (l < 0) l = y;
                            if (p == sizey) p = y;
                            if (g < 0) g = x;
                            if (d == sizex) d = x;
                            int E = 0;
                            if (tab[x, l] != tab[x, y]) E++;
                            if (tab[x, p] != tab[x, y]) E++;
                            if (tab[g, y] != tab[x, y]) E++;
                            if (tab[d, y] != tab[x, y]) E++;
                            if (tab[g, l] != tab[x, y]) E++;
                            if (tab[g, p] != tab[x, y]) E++;
                            if (tab[d, l] != tab[x, y]) E++;
                            if (tab[d, p] != tab[x, y]) E++;

                            int choice = rand.Next(8);
                            int E2 = 0;
                            if (choice == 0)
                            {
                                if (tab[x, l] != tab[x, l]) E2++;
                                if (tab[x, p] != tab[x, l]) E2++;
                                if (tab[g, y] != tab[x, l]) E2++;
                                if (tab[d, y] != tab[x, l]) E2++;
                                if (tab[g, l] != tab[x, l]) E2++;
                                if (tab[g, p] != tab[x, l]) E2++;
                                if (tab[d, l] != tab[x, l]) E2++;
                                if (tab[d, p] != tab[x, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);

                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 1)
                            {
                                if (tab[x, l] != tab[x, p]) E2++;
                                if (tab[x, p] != tab[x, p]) E2++;
                                if (tab[g, y] != tab[x, p]) E2++;
                                if (tab[d, y] != tab[x, p]) E2++;
                                if (tab[g, l] != tab[x, p]) E2++;
                                if (tab[g, p] != tab[x, p]) E2++;
                                if (tab[d, l] != tab[x, p]) E2++;
                                if (tab[d, p] != tab[x, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[x, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 2)
                            {
                                if (tab[x, l] != tab[g, y]) E2++;
                                if (tab[x, p] != tab[g, y]) E2++;
                                if (tab[g, y] != tab[g, y]) E2++;
                                if (tab[d, y] != tab[g, y]) E2++;
                                if (tab[g, l] != tab[g, y]) E2++;
                                if (tab[g, p] != tab[g, y]) E2++;
                                if (tab[d, l] != tab[g, y]) E2++;
                                if (tab[d, p] != tab[g, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 3)
                            {
                                if (tab[x, l] != tab[d, y]) E2++;
                                if (tab[x, p] != tab[d, y]) E2++;
                                if (tab[g, y] != tab[d, y]) E2++;
                                if (tab[d, y] != tab[d, y]) E2++;
                                if (tab[g, l] != tab[d, y]) E2++;
                                if (tab[g, p] != tab[d, y]) E2++;
                                if (tab[d, l] != tab[d, y]) E2++;
                                if (tab[d, p] != tab[d, y]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, y];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 4)
                            {
                                if (tab[x, l] != tab[g, l]) E2++;
                                if (tab[x, p] != tab[g, l]) E2++;
                                if (tab[g, y] != tab[g, l]) E2++;
                                if (tab[d, y] != tab[g, l]) E2++;
                                if (tab[g, l] != tab[g, l]) E2++;
                                if (tab[g, p] != tab[g, l]) E2++;
                                if (tab[d, l] != tab[g, l]) E2++;
                                if (tab[d, p] != tab[g, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 5)
                            {
                                if (tab[x, l] != tab[g, p]) E2++;
                                if (tab[x, p] != tab[g, p]) E2++;
                                if (tab[g, y] != tab[g, p]) E2++;
                                if (tab[d, y] != tab[g, p]) E2++;
                                if (tab[g, l] != tab[g, p]) E2++;
                                if (tab[g, p] != tab[g, p]) E2++;
                                if (tab[d, l] != tab[g, p]) E2++;
                                if (tab[d, p] != tab[g, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[g, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 6)
                            {
                                if (tab[x, l] != tab[d, l]) E2++;
                                if (tab[x, p] != tab[d, l]) E2++;
                                if (tab[g, y] != tab[d, l]) E2++;
                                if (tab[d, y] != tab[d, l]) E2++;
                                if (tab[g, l] != tab[d, l]) E2++;
                                if (tab[g, p] != tab[d, l]) E2++;
                                if (tab[d, l] != tab[d, l]) E2++;
                                if (tab[d, p] != tab[d, l]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, l];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                            else if (choice == 7)
                            {
                                if (tab[x, l] != tab[d, p]) E2++;
                                if (tab[x, p] != tab[d, p]) E2++;
                                if (tab[g, y] != tab[d, p]) E2++;
                                if (tab[d, y] != tab[d, p]) E2++;
                                if (tab[g, l] != tab[d, p]) E2++;
                                if (tab[g, p] != tab[d, p]) E2++;
                                if (tab[d, l] != tab[d, p]) E2++;
                                if (tab[d, p] != tab[d, p]) E2++;
                                if (E2 <= E)
                                {
                                    tab2[x, y] = tab[d, p];
                                }
                                else
                                {
                                    double kt = Convert.ToDouble(textBox7.Text);
                                    double num = ((E - E2) / kt);
                                    double P = Math.Exp(num);
                                    double R = r.NextDouble();
                                    //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                    if (R <= P)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                }
                                memory[x, y] = 1;
                            }
                        }
                    }
                    for (int i = 0; i < sizex; i++)
                        for (int j = 0; j < sizey; j++)
                            tab[i, j] = tab2[i, j];
                }
                else if (comboBox1.Text == "Pentagonalne")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    int pent = rpent.Next(5);
                    if (pent == 0)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                //if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                //if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                                //if (tab[d, p] != tab[x, y]) E++;

                                int choice = rand.Next(8);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    //if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                    // if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                    // if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);

                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    //if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    //if (tab[g, p] != tab[g, y]) E2++;
                                    if (tab[d, l] != tab[g, y]) E2++;
                                    // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    // if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    if (tab[g, l] != tab[d, y]) E2++;
                                    // if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                    // if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    //if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                    if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                    //if (tab[g, p] != tab[g, l]) E2++;
                                    if (tab[d, l] != tab[g, l]) E2++;
                                    //if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    //if (tab[x, p] != tab[d, l]) E2++;
                                    if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                    if (tab[g, l] != tab[d, l]) E2++;
                                    // if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    //if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 1)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                // if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                                // if (tab[d, l] != tab[x, y]) E++;
                                // if (tab[d, p] != tab[x, y]) E++;

                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    // if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                    if (tab[g, p] != tab[x, l]) E2++;
                                    // if (tab[d, l] != tab[x, l]) E2++;
                                    // if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);

                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    // if (tab[d, y] != tab[x, p]) E2++;
                                    if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                    // if (tab[d, l] != tab[x, p]) E2++;
                                    // if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    // if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                    // if (tab[d, l] != tab[g, y]) E2++;
                                    // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                    // if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                    if (tab[g, p] != tab[g, l]) E2++;
                                    // if (tab[d, l] != tab[g, l]) E2++;
                                    // if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    //if (tab[d, y] != tab[g, p]) E2++;
                                    if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                    // if (tab[d, l] != tab[g, p]) E2++;
                                    // if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 2)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                // if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                //if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                                // if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    // if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                    // if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                    // if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    // if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    // if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                    //if (tab[d, l] != tab[g, y]) E2++;
                                    if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    // if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    // if (tab[g, l] != tab[d, y]) E2++;
                                    if (tab[g, p] != tab[d, y]) E2++;
                                    // if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    //if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    if (tab[d, y] != tab[g, p]) E2++;
                                    // if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                    //if (tab[d, l] != tab[g, p]) E2++;
                                    if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    //if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                    if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                    //if (tab[g, l] != tab[d, p]) E2++;
                                    if (tab[g, p] != tab[d, p]) E2++;
                                    // if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (pent == 3)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                // if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                //  if (tab[g, l] != tab[x, y]) E++;
                                // if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(5);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    //if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    //if (tab[g, l] != tab[x, l]) E2++;
                                    // if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                    if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    // if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                    // if (tab[g, l] != tab[x, p]) E2++;
                                    // if (tab[g, p] != tab[x, p]) E2++;
                                    if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    //if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    // if (tab[g, l] != tab[d, y]) E2++;
                                    // if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    if (tab[x, p] != tab[d, l]) E2++;
                                    //if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                    // if (tab[g, l] != tab[d, l]) E2++;
                                    // if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                    // if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                    // if (tab[g, l] != tab[d, p]) E2++;
                                    // if (tab[g, p] != tab[d, p]) E2++;
                                    if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                }
                else if (comboBox1.Text == "Heksagonalne")
                {
                    Random rand = new Random();
                    Random r = new Random();
                    int heks = rheks.Next(2);
                    if (heks == 0)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                if (tab[g, l] != tab[x, y]) E++;
                                //if (tab[g, p] != tab[x, y]) E++;
                                //if (tab[d, l] != tab[x, y]) E++;
                                if (tab[d, p] != tab[x, y]) E++;

                                int choice = rand.Next(6);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    if (tab[g, l] != tab[x, l]) E2++;
                                    //if (tab[g, p] != tab[x, l]) E2++;
                                    // if (tab[d, l] != tab[x, l]) E2++;
                                    if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                    if (tab[g, l] != tab[x, p]) E2++;
                                    //if (tab[g, p] != tab[x, p]) E2++;
                                    //if (tab[d, l] != tab[x, p]) E2++;
                                    if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    if (tab[g, l] != tab[g, y]) E2++;
                                    //if (tab[g, p] != tab[g, y]) E2++;
                                    //if (tab[d, l] != tab[g, y]) E2++;
                                    if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    if (tab[g, l] != tab[d, y]) E2++;
                                    //if (tab[g, p] != tab[d, y]) E2++;
                                    //if (tab[d, l] != tab[d, y]) E2++;
                                    if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, l]) E2++;
                                    if (tab[x, p] != tab[g, l]) E2++;
                                    if (tab[g, y] != tab[g, l]) E2++;
                                    if (tab[d, y] != tab[g, l]) E2++;
                                    if (tab[g, l] != tab[g, l]) E2++;
                                    // if (tab[g, p] != tab[g, l]) E2++;
                                    // if (tab[d, l] != tab[g, l]) E2++;
                                    if (tab[d, p] != tab[g, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 5)
                                {
                                    if (tab[x, l] != tab[d, p]) E2++;
                                    if (tab[x, p] != tab[d, p]) E2++;
                                    if (tab[g, y] != tab[d, p]) E2++;
                                    if (tab[d, y] != tab[d, p]) E2++;
                                    if (tab[g, l] != tab[d, p]) E2++;
                                    if (tab[g, p] != tab[d, p]) E2++;
                                    if (tab[d, l] != tab[d, p]) E2++;
                                    if (tab[d, p] != tab[d, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                    else if (heks == 1)
                    {
                        for (int z = 0; z < sizex * sizey; z++)
                        {
                            int x;
                            int y;
                            int cond = 0;
                            int temp = 0;
                            while (cond < 1000 && temp == 0)
                            {
                                x = rnd.Next(sizex);
                                y = rnd.Next(sizey);
                                cond++;
                                if (memory[x, y] == 1)
                                {
                                    continue;
                                }
                                temp++;
                                int l = y - 1, p = y + 1, g = x - 1, d = x + 1;
                                if (l < 0) l = y;
                                if (p == sizey) p = y;
                                if (g < 0) g = x;
                                if (d == sizex) d = x;
                                int E = 0;
                                if (tab[x, l] != tab[x, y]) E++;
                                if (tab[x, p] != tab[x, y]) E++;
                                if (tab[g, y] != tab[x, y]) E++;
                                if (tab[d, y] != tab[x, y]) E++;
                                // if (tab[g, l] != tab[x, y]) E++;
                                if (tab[g, p] != tab[x, y]) E++;
                                if (tab[d, l] != tab[x, y]) E++;
                                // if (tab[d, p] != tab[x, y]) E++;
                                int choice = rand.Next(6);
                                int E2 = 0;
                                if (choice == 0)
                                {
                                    if (tab[x, l] != tab[x, l]) E2++;
                                    if (tab[x, p] != tab[x, l]) E2++;
                                    if (tab[g, y] != tab[x, l]) E2++;
                                    if (tab[d, y] != tab[x, l]) E2++;
                                    //  if (tab[g, l] != tab[x, l]) E2++;
                                    if (tab[g, p] != tab[x, l]) E2++;
                                    if (tab[d, l] != tab[x, l]) E2++;
                                    //if (tab[d, p] != tab[x, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);

                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 1)
                                {
                                    if (tab[x, l] != tab[x, p]) E2++;
                                    if (tab[x, p] != tab[x, p]) E2++;
                                    if (tab[g, y] != tab[x, p]) E2++;
                                    if (tab[d, y] != tab[x, p]) E2++;
                                    // if (tab[g, l] != tab[x, p]) E2++;
                                    if (tab[g, p] != tab[x, p]) E2++;
                                    if (tab[d, l] != tab[x, p]) E2++;
                                    //if (tab[d, p] != tab[x, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[x, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[x, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 2)
                                {
                                    if (tab[x, l] != tab[g, y]) E2++;
                                    if (tab[x, p] != tab[g, y]) E2++;
                                    if (tab[g, y] != tab[g, y]) E2++;
                                    if (tab[d, y] != tab[g, y]) E2++;
                                    //if (tab[g, l] != tab[g, y]) E2++;
                                    if (tab[g, p] != tab[g, y]) E2++;
                                    if (tab[d, l] != tab[g, y]) E2++;
                                    // if (tab[d, p] != tab[g, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 3)
                                {
                                    if (tab[x, l] != tab[d, y]) E2++;
                                    if (tab[x, p] != tab[d, y]) E2++;
                                    if (tab[g, y] != tab[d, y]) E2++;
                                    if (tab[d, y] != tab[d, y]) E2++;
                                    //if (tab[g, l] != tab[d, y]) E2++;
                                    if (tab[g, p] != tab[d, y]) E2++;
                                    if (tab[d, l] != tab[d, y]) E2++;
                                    //if (tab[d, p] != tab[d, y]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, y];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, y];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 4)
                                {
                                    if (tab[x, l] != tab[g, p]) E2++;
                                    if (tab[x, p] != tab[g, p]) E2++;
                                    if (tab[g, y] != tab[g, p]) E2++;
                                    if (tab[d, y] != tab[g, p]) E2++;
                                    //if (tab[g, l] != tab[g, p]) E2++;
                                    if (tab[g, p] != tab[g, p]) E2++;
                                    if (tab[d, l] != tab[g, p]) E2++;
                                    //if (tab[d, p] != tab[g, p]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[g, p];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[g, p];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }
                                else if (choice == 5)
                                {
                                    if (tab[x, l] != tab[d, l]) E2++;
                                    if (tab[x, p] != tab[d, l]) E2++;
                                    if (tab[g, y] != tab[d, l]) E2++;
                                    if (tab[d, y] != tab[d, l]) E2++;
                                    //if (tab[g, l] != tab[d, l]) E2++;
                                    if (tab[g, p] != tab[d, l]) E2++;
                                    if (tab[d, l] != tab[d, l]) E2++;
                                    //if (tab[d, p] != tab[d, l]) E2++;
                                    if (E2 <= E)
                                    {
                                        tab2[x, y] = tab[d, l];
                                    }
                                    else
                                    {
                                        double kt = Convert.ToDouble(textBox7.Text);
                                        double num = ((E - E2) / kt);
                                        double P = Math.Exp(num);
                                        double R = r.NextDouble();
                                        //System.Diagnostics.Debug.WriteLine("kt: " + kt + " num: " + num + " P: " + P + " R " + R + " E2: " + E2 + " E: " + E);
                                        if (R <= P)
                                        {
                                            tab2[x, y] = tab[d, l];
                                        }
                                    }
                                    memory[x, y] = 1;
                                }

                            }
                        }
                        for (int i = 0; i < sizex; i++)
                            for (int j = 0; j < sizey; j++)
                                tab[i, j] = tab2[i, j];
                    }
                }
                else if (comboBox1.Text == "Z promieniem")
                {

                }
            }
            if (comboBox4.Text == "Map")
            {
                draw();
            }
            else if (comboBox4.Text == "Energy map")
            {
                draw_energyp();
            }
            int iter = Int32.Parse(textBox6.Text);
            iter++;
            textBox6.Text = Convert.ToString(iter);
        }

        SolidBrush[] brush = new SolidBrush[10000];
        Bitmap bmp;
        Graphics gr;
        int[,] tab;
        int[,] tab2;
        int sizex;
        int sizey;
        int px;
        void neumann()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (tab[x, y] == 0)
                    {
                        if (x == 0 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                        }
                        else if (x == 0 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[0, 0] != 0) tab[0, 0] = tab[x, y];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                        }
                        else if (x == sizex - 1 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                        }
                        else if (x == sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                        }
                        else if (x == 0 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                        }
                        else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                        }
                        else if (x != 0 && x != sizex - 1 && y == 0)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                        }
                        else
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void moore()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (tab[x, y] == 0)
                    {
                        if (x == 0 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                            if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == 0 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                            if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                        }
                        else if (x == sizex - 1 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                            if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                        }
                        else if (x == sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                            if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                            if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                        }
                        else if (x == 0 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                            if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                            if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == 0)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                            if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                            if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                        }
                        else
                        {
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void moorep()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (tab[x, y] == 0)
                    {
                        if (x == 0 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            //if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                            // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == 0 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            // if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                            // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                        }
                        else if (x == sizex - 1 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            // if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                            // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                        }
                        else if (x == sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                            // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                            // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                        }
                        else if (x == 0 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            //  if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                            //  if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                            // if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == 0)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            //  if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                            // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                            // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                        }
                        else
                        {
                            if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void heks()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            Random rnd = new Random();
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    
                    int r = rnd.Next(2);
                    int cos = 0;
                    cos = 0;
                    if (r == 0)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                //if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                //if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                    else if (r == 1)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void heksl()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void hekspraw()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (tab[x, y] == 0)
                    {
                        if (x == 0 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            //if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                            if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == 0 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            //if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                            // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                        }
                        else if (x == sizex - 1 && y == 0)
                        {
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            //if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                            if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                        }
                        else if (x == sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                            if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                            if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                        }
                        else if (x == 0 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                            //if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                            if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                        }
                        else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                            if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                            //if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == 0)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                            if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                            if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                        }
                        else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                            if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                            // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                        }
                        else
                        {
                            // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                            if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                            if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                            if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                            if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                            if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                            if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                            // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                        }
                    }
                    
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void heksp()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(1, 3);
            if (r == 1)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                //if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //  if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                //if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //  if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            if (r == 2)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //  if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //  if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //  if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //  if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //  if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //  if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                //  if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                //  if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void pent()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }

            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    Random rnd = new Random();
                    int r = rnd.Next(4);
                    int cos = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                            cos++;
                    }
                    cos = 0;
                    if (r == 0)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                //if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                //if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                // if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                    else if (r == 1)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                //if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                //if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                //if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                //if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                //if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                //if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                    else if (r == 2)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                //if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                //if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                    else if (r == 3)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //  if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void pentp()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(1, 5);
            if (r == 1)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                //if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                //if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                //  if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                //if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                //  if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                // if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            else if (r == 2)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                //if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                //if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //  if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                //  if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                //if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                //  if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                //if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                //if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                //  if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                //if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //  if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            else if (r == 3)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //  if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                //if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                //  if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                //  if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                //if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                //if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                //  if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                //  if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                //if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                // if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                //if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                //  if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                //  if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                // if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            else if (r == 4)
            {
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (tab[x, y] == 0)
                        {
                            if (x == 0 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                //  if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //  if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                                // if (tab[sizex - 1, sizey - 1] != 0) tab2[x, y] = tab[sizex - 1, sizey - 1];
                                //  if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == 0 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[1, 0] != 0) tab2[x, y] = tab[1, 0];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                            }
                            else if (x == sizex - 1 && y == 0)
                            {
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                //  if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                                // if (tab[0, 1] != 0) tab2[x, y] = tab[0, 1];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                            }
                            else if (x == sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                // if (tab[sizex - 1, 0] != 0) tab2[x, y] = tab[sizex - 1, 0];
                                // if (tab[sizex - 2, 0] != 0) tab2[x, y] = tab[sizex - 2, 0];
                                // if (tab[0, sizey - 2] != 0) tab2[x, y] = tab[0, sizey - 2];
                                // if (tab[0, sizey - 1] != 0) tab2[x, y] = tab[0, sizey - 1];
                                //  if (tab[0, 0] != 0) tab2[x, y] = tab[0, 0];
                            }
                            else if (x == 0 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                // if (tab[sizex - 1, y] != 0) tab2[x, y] = tab[sizex - 1, y];
                                // if (tab[sizex - 1, y - 1] != 0) tab2[x, y] = tab[sizex - 1, y - 1];
                                // if (tab[sizex - 1, y + 1] != 0) tab2[x, y] = tab[sizex - 1, y + 1];
                            }
                            else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                            {
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                // if (tab[0, y] != 0) tab2[x, y] = tab[0, y];
                                // if (tab[0, y - 1] != 0) tab2[x, y] = tab[0, y - 1];
                                //  if (tab[0, y + 1] != 0) tab2[x, y] = tab[0, y + 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == 0)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                // if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                                //if (tab[x - 1, sizey - 1] != 0) tab2[x, y] = tab[x - 1, sizey - 1];
                                // if (tab[x, sizey - 1] != 0) tab2[x, y] = tab[x, sizey - 1];
                                // if (tab[x + 1, sizey - 1] != 0) tab2[x, y] = tab[x + 1, sizey - 1];
                            }
                            else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                            {
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                // if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                // if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                // if (tab[x - 1, 0] != 0) tab2[x, y] = tab[x - 1, 0];
                                // if (tab[x, 0] != 0) tab2[x, y] = tab[x, 0];
                                // if (tab[x + 1, 0] != 0) tab2[x, y] = tab[x + 1, 0];
                            }
                            else
                            {
                                if (tab[x - 1, y - 1] != 0) tab2[x, y] = tab[x - 1, y - 1];
                                if (tab[x, y - 1] != 0) tab2[x, y] = tab[x, y - 1];
                                if (tab[x + 1, y - 1] != 0) tab2[x, y] = tab[x + 1, y - 1];
                                if (tab[x - 1, y] != 0) tab2[x, y] = tab[x - 1, y];
                                if (tab[x + 1, y] != 0) tab2[x, y] = tab[x + 1, y];
                                if (tab[x - 1, y + 1] != 0) tab2[x, y] = tab[x - 1, y + 1];
                                if (tab[x, y + 1] != 0) tab2[x, y] = tab[x, y + 1];
                                if (tab[x + 1, y + 1] != 0) tab2[x, y] = tab[x + 1, y + 1];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void neumannp()
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab2[i, j] = tab[i, j];
                }
            }
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (tab[x, y] != 0)
                    {
                        if (x == 0 && y == 0)
                        {
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            // if (tab[x, sizey - 1] == 0) tab2[x, sizey - 1] = tab[x, y];
                            // if (tab[sizex - 1, y] == 0) tab2[sizex - 1, y] = tab[x, y];
                        }
                        else if (x == 0 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            // if (tab[0, 0] == 0) tab[0, 0] = tab2[x, y];
                            // if (tab[sizex - 1, y] == 0) tab2[sizex - 1, y] = tab[x, y];
                        }
                        else if (x == sizex - 1 && y == 0)
                        {
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            // if (tab[x, sizey - 1] == 0) tab2[x, sizey - 1] = tab[x, y];
                            //if (tab[0, 0] == 0) tab2[0, 0] = tab[x, y];
                        }
                        else if (x == sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            // if (tab[sizex - 1, 0] == 0) tab2[sizex - 1, 0] = tab[x, y];
                            //if (tab[0, sizey - 1] == 0) tab2[0, sizey - 1] = tab[x, y];
                        }
                        else if (x == 0 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            //  if (tab[sizex - 1, y] == 0) tab2[sizex - 1, y] = tab[x, y];
                        }
                        else if (x == sizex - 1 && y != 0 && y != sizey - 1)
                        {
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            // if (tab[0, y] == 0) tab2[0, y] = tab[x, y];
                        }
                        else if (x != 0 && x != sizex - 1 && y == 0)
                        {
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                            // if (tab[x, sizey - 1] == 0) tab2[x, sizey - 1] = tab[x, y];
                        }
                        else if (x != 0 && x != sizex - 1 && y == sizey - 1)
                        {
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            // if (tab[x, 0] == 0) tab2[x, 0] = tab[x, y];
                        }
                        else
                        {
                            if (tab[x, y - 1] == 0) tab2[x, y - 1] = tab[x, y];
                            if (tab[x - 1, y] == 0) tab2[x - 1, y] = tab[x, y];
                            if (tab[x + 1, y] == 0) tab2[x + 1, y] = tab[x, y];
                            if (tab[x, y + 1] == 0) tab2[x, y + 1] = tab[x, y];
                        }
                    }
                }
            }
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    tab[i, j] = tab2[i, j];
                }
            }
        }
        void draw()
        {
            for (int i = 0; i <= px * sizex; i += px)
            {
                for (int j = 0; j <= px * sizey; j += px)
                {
                    for (int k = 1; k <= licz; k++)
                    {
                        if (tab[i / px, j / px] == k)
                        {
                            gr.FillRectangle(brush[k], j, i, px, px);
                        }
                    }
                }
            }
            pictureBox1.Image = bmp;
        }
        void draw_energyp()
        {
            Random rpent = new Random();
            for (int x = 0; x <= px * sizex; x += px)
            {
                for (int y = 0; y <= px * sizey; y += px)
                {
                    int E = 0;
                    if (comboBox1.Text == "Von Neumann")
                    {
                        int l = y - px, p = y + px, g = x - px, d = x + px;
                        if (l < 0) l = (sizey - 1) * px;
                        if (p / px == sizey) p = 0;
                        if (g < 0) g = (sizex - 1) * px;
                        if (d / px == sizex) d = 0;

                        if (tab[x / px, y / px] == 0) continue;
                        if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                        if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                        if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                        if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                        //if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                        //if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                        //if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                        //if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                    }
                    else if (comboBox1.Text == "Moore")
                    {
                        int l = y - px, p = y + px, g = x - px, d = x + px;
                        if (l < 0) l = (sizey - 1) * px;
                        if (p / px == sizey) p = 0;
                        if (g < 0) g = (sizex - 1) * px;
                        if (d / px == sizex) d = 0;
                        
                        if (tab[x / px, y / px] == 0) continue;
                        if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                        if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                        if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                        if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                        if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                        if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                        if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                        if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                    }
                    else if (comboBox1.Text == "Pentagonalnie")
                    {
                        int choice = rpent.Next(5);
                        if (choice == 0)
                        {
                            int l = y - px, p = y + px, g = x - px, d = x + px;
                            if (l < 0) l = (sizey - 1) * px;
                            if (p / px == sizey) p = 0;
                            if (g < 0) g = (sizex - 1) * px;
                            if (d / px == sizex) d = 0;

                            if (tab[x / px, y / px] == 0) continue;
                           // if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                           // if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                            //if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                        }
                        else if (choice == 1)
                        {
                            int l = y - px, p = y + px, g = x - px, d = x + px;
                            if (l < 0) l = (sizey - 1) * px;
                            if (p / px == sizey) p = 0;
                            if (g < 0) g = (sizex - 1) * px;
                            if (d / px == sizex) d = 0;

                            if (tab[x / px, y / px] == 0) continue;
                            if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                           // if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                           // if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                           // if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                        }
                        else if (choice == 2)
                        {
                            int l = y - px, p = y + px, g = x - px, d = x + px;
                            if (l < 0) l = (sizey - 1) * px;
                            if (p / px == sizey) p = 0;
                            if (g < 0) g = (sizex - 1) * px;
                            if (d / px == sizex) d = 0;

                            if (tab[x / px, y / px] == 0) continue;
                            if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                           // if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                           // if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                            if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                           // if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                        }
                        else if (choice == 3)
                        {
                            int l = y - px, p = y + px, g = x - px, d = x + px;
                            if (l < 0) l = (sizey - 1) * px;
                            if (p / px == sizey) p = 0;
                            if (g < 0) g = (sizex - 1) * px;
                            if (d / px == sizex) d = 0;

                            if (tab[x / px, y / px] == 0) continue;
                            if (tab[x / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[x / px, p / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, y / px] != tab[x / px, y / px]) E++;
                           // if (tab[d / px, y / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, l / px] != tab[x / px, y / px]) E++;
                            if (tab[g / px, p / px] != tab[x / px, y / px]) E++;
                           // if (tab[d / px, l / px] != tab[x / px, y / px]) E++;
                           // if (tab[d / px, p / px] != tab[x / px, y / px]) E++;
                        }
                    }
                    if (E==0)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(255, 255, 255));
                        gr.FillRectangle(brusht,y,x,px,px);
                    }
                    else if (E == 1)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(169, 169, 169));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 2)
                    {

                        SolidBrush brusht = new SolidBrush(Color.FromArgb(105, 105, 105));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 3)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(255, 215, 0));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 4)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(255, 140, 0));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 5)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(255, 0, 0));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 6)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(128, 0, 0));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 7)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(128, 0, 128));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                    else if (E == 8)
                    {
                        SolidBrush brusht = new SolidBrush(Color.FromArgb(0, 0, 0));
                        gr.FillRectangle(brusht, y, x, px, px);
                    }
                }
                   /* for (int k = 1; k <= licz; k++)
                    {
                        if (tab[i / px, j / px] == k)
                        {
                            gr.FillRectangle(brush[k], j, i, px, px);
                        }
                    }*/
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            px = Int32.Parse(textBox3.Text);
            pictureBox1.Width = px * Int32.Parse(textBox1.Text);
            pictureBox1.Height = px * Int32.Parse(textBox2.Text);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(bmp);
            sizey = Int32.Parse(textBox1.Text);
            sizex = Int32.Parse(textBox2.Text);
            tab = new int[sizex + 1, sizey + 1];
            tab2 = new int[sizex + 1, sizey + 1];
            for (int i = 0; i <= sizex; i++)
            {
                for (int j = 0; j <= sizey; j++)
                {
                    tab[i, j] = 0;
                    tab2[i, j] = 0;
                }
            }
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                brush[i] = new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
            }

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            licz++;
            int x = e.X;
            int y = e.Y;
            tab[y / px, x / px] = licz;
            if (comboBox4.Text == "Map")
            {
                draw();
            }
            else if (comboBox4.Text == "Energy map")
            {
                draw_energyp();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T.Start();
            // neumann();
            // draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= sizex; i++)
            {
                for (int j = 0; j <= sizey; j++)
                {
                    tab[i, j] = 0;
                    tab2[i, j] = 0;
                }
            }
            licz = 0;
            gr.Clear(pictureBox1.BackColor);
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            T.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Jednorodne")
            {
                int wiersz = Int32.Parse(textBox4.Text);
                int kolumna = Int32.Parse(textBox5.Text);
                double skokx = (1.0 * sizey) / (1.0 * wiersz);
                double skoky = (1.0 * sizex) / (1.0 * kolumna);
                double tempx = skokx / 2;
                double tempy = skoky / 2;
                for (int i = 0; i < wiersz; i++)
                {
                    int x = (int)tempx;
                    for (int j = 0; j < kolumna; j++)
                    {

                        int y = (int)tempy;
                        tab[y, x] = ++licz;
                        tempy += skoky;
                    }
                    tempx += skokx;
                    tempy = skoky / 2;
                }

                if (comboBox4.Text == "Map")
                {
                    draw();
                }
                else if (comboBox4.Text == "Energy map")
                {
                    draw_energyp();
                }
            }
            else if (comboBox2.Text == "Z promieniem")
            {
                if (comboBox3.Text == "Absorbujące")
                {
                    int ilosc = Int32.Parse(textBox4.Text);
                    int r = Int32.Parse(textBox5.Text);
                    Random rnd = new Random();
                    for (int i = 0; i < ilosc; i++)
                    {
                        int cond = 0;
                        while (cond < 1000)
                        {

                            int temp = 0;
                            int x = rnd.Next(sizey);
                            int y = rnd.Next(sizex);
                            cond++;
                            for (int j = x - r; j <= x + r; j++)
                            {
                                for (int k = y - r; k <= y + r; k++)
                                {
                                    if (j < 0 || k < 0 || j >= sizex || k >= sizey)
                                        continue;
                                    if (Math.Abs((k - y) * (k - y)) + Math.Abs((j - x) * (j - x)) > r * r)
                                        continue;
                                    if (tab[k, j] != 0)
                                        temp++;
                                }
                            }
                            if (tab[y, x] == 0 && temp == 0)
                            {
                                tab[y, x] = ++licz;
                                break;
                            }
                        }
                    }
                }
                else if (comboBox3.Text == "Periodyczne")
                {
                    int ilosc = Int32.Parse(textBox4.Text);
                    int r = Int32.Parse(textBox5.Text);
                    Random rnd = new Random();
                    for (int i = 0; i < ilosc; i++)
                    {
                        int cond = 0;
                        while (cond < 1000)
                        {

                            int temp = 0;
                            int x = rnd.Next(sizey);
                            int y = rnd.Next(sizex);
                            cond++;
                            for (int j = x - r; j <= x + r; j++)
                            {
                                for (int k = y - r; k <= y + r; k++)
                                {
                                    int chuj = Math.Abs((k - y) * (k - y)) + Math.Abs((j - x) * (j - x));
                                    if (Math.Abs((k - y) * (k - y)) + Math.Abs((j - x) * (j - x)) > r * r)
                                    {

                                        continue;
                                    }
                                    int ka = k;
                                    int jot = j;
                                    if (ka < 0)
                                        ka += sizey;
                                    if (jot < 0)
                                        jot += sizex;
                                    if (ka > sizey - 1)
                                        ka -= sizey;
                                    if (jot > sizex - 1)
                                        jot -= sizex;


                                    if (tab[ka, jot] != 0)
                                        temp++;
                                }
                            }
                            if (tab[y, x] == 0 && temp == 0)
                            {
                                tab[y, x] = ++licz;
                                break;
                            }
                        }
                    }
                }
                if (comboBox4.Text == "Map")
                {
                    draw();
                }
                else if (comboBox4.Text == "Energy map")
                {
                    draw_energyp();
                }
            }
            else if (comboBox2.Text == "Losowe")
            {
                int ilosc = Int32.Parse(textBox4.Text);
                Random iks = new Random();
                for (int i = 0; i < ilosc; i++)
                {
                    while (true)
                    {
                        int x = iks.Next(sizex);
                        int y = iks.Next(sizey);
                        if (tab[x, y] == 0)
                        {
                            tab[x, y] = ++licz;
                            break;
                        }
                    }
                }
                if (comboBox4.Text == "Map")
                {
                    draw();
                }
                else if (comboBox4.Text == "Energy map")
                {
                    draw_energyp();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            T2.Start();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            T2.Stop();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(comboBox4.Text == "Map")
            {
                if (comboBox4.Text == "Map")
                {
                    draw();
                }
                else if (comboBox4.Text == "Energy map")
                {
                    draw_energyp();
                }
            }
            else if(comboBox4.Text == "Energy map")
            {
                draw_energyp();
            }
        }
    }
}
