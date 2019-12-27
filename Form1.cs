using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace görüntüIslemeO4
{
    public partial class Form1 : Form
    {
        Bitmap resim = new Bitmap(300, 300);
        Bitmap resim_grayScale = new Bitmap(300, 300);
        Bitmap resim_bitMap = new Bitmap(300, 300);
        Bitmap resim_erosion = new Bitmap(300, 300);
        Bitmap resim_dilasion = new Bitmap(300, 300);
        Bitmap resim_opening = new Bitmap(300, 300);
        Bitmap resim_closing = new Bitmap(300, 300);
        Bitmap resim_convulation = new Bitmap(300, 300);
        Bitmap resim_gradient = new Bitmap(300, 300);
        Bitmap resim_std = new Bitmap(300, 300);



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
            Graphics.FromImage(resim).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_grayScale).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_bitMap).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_erosion).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_dilasion).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_opening).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_closing).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_convulation).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_gradient).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(resim_std).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void bnt_gray_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int gray;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    gray = (r + g + b) / 3;
                    resim_grayScale.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
                pictureBox1.Image = resim_grayScale;
                this.Refresh();
            }
        }

        private void btn_bitmap_Click(object sender, EventArgs e)
        {
            double bit = 0;
            for (int y = 0; y < resim_bitMap.Height; y++)
            {
                for (int x = 0; x < resim_bitMap.Width; x++)
                {
                    bit += resim_bitMap.GetPixel(x, y).GetBrightness();
                }
            }

            bit = bit / (resim_bitMap.Width * resim_bitMap.Height);
            bit = bit < .3 ? .3 : bit;
            bit = bit > .7 ? .7 : bit;

            for (int y = 0; y < resim_bitMap.Height; y++)
            {
                for (int x = 0; x < resim_bitMap.Width; x++)
                {
                    if (resim_bitMap.GetPixel(x, y).GetBrightness() > bit) resim_bitMap.SetPixel(x, y, Color.White);
                    else resim_bitMap.SetPixel(x, y, Color.Black);
                }
            }
            pictureBox1.Image = resim_bitMap;
            this.Refresh();
        }

        private void setpix1_Click(object sender, EventArgs e)
        {
            Color c;
            int r, g, b;
            int anti_renk;
            anti_renk = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    c = resim_grayScale.GetPixel(i, j);
                    r = c.R + anti_renk;
                    if (r > 255) r = 255;
                    g = c.R + anti_renk;
                    if (g > 255) g = 255;
                    b = c.R + anti_renk;
                    if (b > 255) b = 255;
                    resim_grayScale.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            pictureBox1.Image = resim_grayScale;
            this.Refresh();
        }

        private void setpix2_Click(object sender, EventArgs e)
        {
            Color c;
            int r, g, b;
            int anti_renk;
            anti_renk = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    c = resim_grayScale.GetPixel(i, j);
                    r = c.R - anti_renk;
                    if (r < 0) r = 0;
                    g = c.R - anti_renk;
                    if (g < 0) g = 0;
                    b = c.R - anti_renk;
                    if (b < 0) b = 0;
                    resim_grayScale.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            pictureBox1.Image = resim_grayScale;
            this.Refresh();
        }

        private void tersSim_Click(object sender, EventArgs e)
        {
            Color c;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    c = resim_grayScale.GetPixel(i,j);
                    Color tmp = resim_grayScale.GetPixel(300 - i - 1, j);
                    resim_grayScale.SetPixel(i, j, tmp);
                    resim_grayScale.SetPixel(300 - i - 1, j, c);
                }
            }
            pictureBox1.Image = resim_grayScale;
            this.Refresh();
        }

        private void btn_erosion_Click(object sender, EventArgs e)
        {
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color c;
            int b1, b2, b3;
            for(int y = 1; y<300 - 1; y++)
            {
                for(int x = 1; x<300 -1 ; x++)
                {
                    c = resim_bitMap.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y);
                    b3 = c.R;

                    if(b1 == x1 & b2 == x2 & b3 == x3)
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = resim_erosion;
            this.Refresh();
        }

        private void btn_dila_Click(object sender, EventArgs e)
        {
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color c;
            int b1, b2, b3;
            for (int y = 1; y < 300 - 1; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    c = resim_bitMap.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y);
                    b3 = c.R;

                    if (b1 == x1 & b2 == x2 & b3 == x3)
                    {
                        resim_dilasion.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        resim_dilasion.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox1.Image = resim_dilasion;
            this.Refresh();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            resim_bitMap = resim_grayScale;
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color c;
            int b1, b2, b3;
            for (int y = 1; y < 300 - 1; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    c = resim_bitMap.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y);
                    b3 = c.R;

                    if (b1 == x1 & b2 == x2 & b3 == x3)
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            for (int y = 1; y < 300 - 1; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    c = resim_erosion.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_erosion.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_erosion.GetPixel(x + 1, y);
                    b3 = c.R;

                    if (b1 == x1 & b2 == x2 & b3 == x3)
                    {
                        resim_opening.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resim_opening.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            pictureBox1.Image = resim_opening;
            this.Refresh();
        }

        private void btn_con_Click(object sender, EventArgs e)
        {
            resim_bitMap = resim_grayScale;
            Color c;
            int con;
            int x1, x2, x3, x4, x5, x6, x7, x8, x9;
            int b1, b2, b3, b4, b5, b6, b7, b8, b9;
            x1 = -1;
            x2 = -1;
            x3 = -1;
            x4 = -1;
            x6 = -1;
            x7 = -1;
            x8 = -1;
            x9 = -1;
            x5 = 8;
            for(int x = 1; x < 300 -1; x++)
            {
                for(int y = 1; y < 300 -1; y++)
                {
                    c = resim_bitMap.GetPixel(x - 1, y - 1);
                    b1 = c.R;
                    c = resim_bitMap.GetPixel(x, y - 1);
                    b2 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y - 1);
                    b3 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y);
                    b4 = c.R;
                    c = resim_bitMap.GetPixel(x, y);
                    b5 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y);
                    b6 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y + 1);
                    b7 = c.R;
                    c = resim_bitMap.GetPixel(x, y + 1);
                    b8 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y + 1);
                    b9 = c.R;

                    con = x1 * b1 + x2 * b2 + x3 * b3 + x4 * b4 + x5 * b5 + x6 * b6 + x7 * b7 + x8 * b8 + x9 * b9;
                    if (con > 255) con = 255;
                    if (con < 0) con = 0;
                    resim_convulation.SetPixel(x, y, Color.FromArgb(con, con, con));
                }
            }
            pictureBox1.Image = resim_convulation;
            this.Refresh();

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color c;
            int b1, b2, b3;
            for (int y = 1; y < 300 - 1; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    c = resim_bitMap.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_bitMap.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_bitMap.GetPixel(x + 1, y);
                    b3 = c.R;
                    if (b1 == x1 || b2 == x2 || b3 == x3)
                    {
                        resim_dilasion.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resim_dilasion.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            for (int y = 1; y < 300 - 1; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    c = resim_dilasion.GetPixel(x, y);
                    b1 = c.R;
                    c = resim_dilasion.GetPixel(x - 1, y);
                    b2 = c.R;
                    c = resim_dilasion.GetPixel(x + 1, y);
                    b3 = c.R;
                    if (b1 == x1 && b2 == x2 && b3 == x3)
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resim_erosion.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            pictureBox1.Image = resim_erosion;
            this.Refresh();
        }

        private void bnt_gra_Click(object sender, EventArgs e)
        {
            int gradient;
            Color cl;
            int x1, x2, x3, x4;
            int b1, b2, b3, b4;
            x1 = -1; x2 = 1; x3 = -1; x4 = 1;
            for (int x = 1; x < 299; x++)
            {
                for (int y = 1; y < 299; y++)
                {
                    cl = resim_grayScale.GetPixel(x, y);
                    b1 = cl.R;
                    cl = resim_grayScale.GetPixel(x + 1, y);
                    b2 = cl.R;
                    cl = resim_grayScale.GetPixel(x, y + 1);
                    b3 = cl.R;
                    cl = resim_grayScale.GetPixel(x + 1, y + 1);
                    b4 = cl.R;
                    gradient = x1 * b1 + x2 * b2 + x3 * b3 + x4 * b4;
                    if (gradient > 255) gradient = 255;
                    if (gradient < 0) gradient = 0;
                    resim_gradient.SetPixel(x, y, Color.FromArgb(gradient, gradient, gradient));
                }
            }
            pictureBox1.Image = resim_gradient;
            this.Refresh();

        }

        private void btn_std_Click(object sender, EventArgs e)
        {
            int ort_toplam, standart_toplam;
            double ort, STD;
            Color cl;
            ort_toplam = 0;
            standart_toplam = 0;
            for (int x = 1; x < 299; x++)
            {
                for (int y = 1; y < 299; y++)
                {
                    cl = resim_grayScale.GetPixel(x, y);
                    ort_toplam += cl.R;
                }
            }
            ort = ort_toplam / (300 * 300);
            for (int x = 1; x < 299; x++)
            {
                for (int y = 1; y < 299; y++)
                {
                    int gecici;
                    int piksel;
                    cl = resim_grayScale.GetPixel(x, y);
                    piksel = cl.R;
                    gecici = Convert.ToInt32(ort) - piksel;
                    standart_toplam += gecici * gecici;
                }
            }
            STD = Math.Sqrt(standart_toplam / (300 * 300 - 1));
            int taban, tavan;
            taban = (int)Math.Abs(ort - STD);
            tavan = (int)Math.Abs(ort + STD);
            for (int x = 1; x < 299; x++)
            {
                for (int y = 1; y < 299; y++)
                {

                    int piksel;
                    cl = resim_grayScale.GetPixel(x, y);
                    piksel = cl.R;
                    if ((piksel >= taban) && (piksel <= tavan))
                    {
                        resim_std.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        resim_std.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox1.Image = resim_std;
            this.Refresh();
        }
    }
}
