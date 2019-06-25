using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileCreator
{
    public partial class Form1 : Form
    {
        Stream strm = null;
        string home = @"C:\Users\usagi\source\repos\TileCreator\TileCreator\output";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // main 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            // border
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //convert button
            Bitmap border = (Bitmap)Bitmap.FromFile(textBox2.Text);
            Bitmap main = (Bitmap)Bitmap.FromFile(textBox1.Text);

            int u = (int)numericUpDown1.Value;

            border = border.ClearCenter(u);

            pictureBox1.Image = main;
            pictureBox2.Image = border;

            Bitmap s0 = main;
            Bitmap s1 = main.AddToTop(border);

            //missing one side border
            Bitmap s2 = main.AddToTop(border.RemoveBorder(u));  // missing bot
            Bitmap s3 = s2.rotate();                            // missing left
            Bitmap s4 = s3.rotate();                            // missing top
            Bitmap s5 = s4.rotate();                            // missing right

            //missing two adjacent sides
            Bitmap s6 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u));
            Bitmap s7 = s6.rotate();
            Bitmap s8 = s7.rotate();
            Bitmap s9 = s8.rotate();

            //missing two adjacent sides and a corner
            Bitmap s17 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u));
            Bitmap s18 = s17.rotate();
            Bitmap s19 = s18.rotate();
            Bitmap s20 = s19.rotate();

            //missing two opposite sides
            Bitmap s10 = main.AddToTop(border.RemoveBorder(u).rotate().rotate().RemoveBorder(u));
            Bitmap s11 = s10.rotate();

            //missing three adjacent sides
            Bitmap s12 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u));
            Bitmap s13 = s12.rotate();
            Bitmap s14 = s13.rotate();
            Bitmap s15 = s14.rotate();

            //missing three adjacent sides and a corner
            Bitmap s21 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u));
            Bitmap s22 = s21.rotate();
            Bitmap s23 = s22.rotate();
            Bitmap s24 = s23.rotate();

            //missing three adjacent sides and the other corner
            Bitmap s25 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).rotate().rotate().rotate().RemoveCorner(u).rotate());
            Bitmap s26 = s25.rotate();
            Bitmap s27 = s26.rotate();
            Bitmap s28 = s27.rotate();

            //missing three adjacent sides and both corners
            Bitmap s29 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u).rotate().rotate().rotate().RemoveCorner(u).rotate());
            Bitmap s30 = s29.rotate();
            Bitmap s31 = s30.rotate();
            Bitmap s32 = s31.rotate();

            //missing all sides
            Bitmap s16 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u));

            //missing all sides and a corner
            Bitmap s33 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u));
            Bitmap s34 = s33.rotate();
            Bitmap s35 = s34.rotate();
            Bitmap s36 = s35.rotate();

            //missing all sides and two corners
            Bitmap s37 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u).rotate().RemoveCorner(u).rotate().rotate().rotate());
            Bitmap s38 = s37.rotate();
            Bitmap s39 = s38.rotate();
            Bitmap s40 = s39.rotate();

            //missing all sides and three corners
            Bitmap s41 = main.AddToTop(border.RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).rotate().RemoveBorder(u).RemoveCorner(u).rotate().RemoveCorner(u).rotate().RemoveCorner(u).rotate().rotate());
            Bitmap s42 = s41.rotate();
            Bitmap s43 = s42.rotate();
            Bitmap s44 = s43.rotate();

            //saving
            string name = textBox3.Text;
            save(s0, $"{name}_0");
            save(s1, $"{name}_1");
            save(s2, $"{name}_2");
            save(s3, $"{name}_3");
            save(s4, $"{name}_4");
            save(s5, $"{name}_5");
            save(s6, $"{name}_6");
            save(s7, $"{name}_7");
            save(s8, $"{name}_8");
            save(s9, $"{name}_9");
            save(s10, $"{name}_10");
            save(s11, $"{name}_11");
            save(s12, $"{name}_12");
            save(s13, $"{name}_13");
            save(s14, $"{name}_14");
            save(s15, $"{name}_15");
            save(s16, $"{name}_16");
            save(s17, $"{name}_17");
            save(s18, $"{name}_18");
            save(s19, $"{name}_19");
            save(s20, $"{name}_20");
            save(s21, $"{name}_21");
            save(s22, $"{name}_22");
            save(s23, $"{name}_23");
            save(s24, $"{name}_24");
            save(s25, $"{name}_25");
            save(s26, $"{name}_26");
            save(s27, $"{name}_27");
            save(s28, $"{name}_28");
            save(s29, $"{name}_29");
            save(s30, $"{name}_30");
            save(s31, $"{name}_31");
            save(s32, $"{name}_32");
            save(s33, $"{name}_33");
            save(s34, $"{name}_34");
            save(s35, $"{name}_35");
            save(s36, $"{name}_36");
            save(s37, $"{name}_37");
            save(s38, $"{name}_38");
            save(s39, $"{name}_39");
            save(s40, $"{name}_40");
            save(s41, $"{name}_41");
            save(s42, $"{name}_42");
            save(s43, $"{name}_43");
            save(s44, $"{name}_44");

        }
        
        private void save(Bitmap bmp, string name)
        {
            bmp.Save($@"{home}\{name}.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private Bitmap rotate(Bitmap bmp, int times)
        {
            Bitmap rot = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < times; i ++)
            {
                for (int y = 0; y < bmp.Width; y++)
                {
                    for (int x = 0; x < bmp.Height; x++)
                    {
                        rot.SetPixel(y, x, bmp.GetPixel(x, y));
                    }
                }
            }
            return rot;
        }
    }
}
