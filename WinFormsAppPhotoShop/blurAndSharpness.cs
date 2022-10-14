using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppPhotoShop
{
    public partial class blurAndSharpness : Form
    {
        Form1 ownerForm;
        public blurAndSharpness(Form1 ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            button1.Click += new System.EventHandler(this.Button_Click);
            button2.Click += new System.EventHandler(this.Button_Click);
        }
        private void FromBitmapToScreen()
        {
            ownerForm.FromBitmapToScreen();
        }
        /// <summary>
        /// Edit sharpness
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(Form1.ImageName != "\0")
            {
                double m1 = trackBar1.Value / trackBar1.Maximum;
                for(int i = 0; i < Form1.Image.Height; i++)
                {
                    for(int j = 0; j < Form1.Image.Width; j ++)
                    {
                        Filter.matrix_filtration(j, i, Form1.matrixPixel, Filter.N1, Filter.sharpness, m1);
                        Form1.FromPixelToBitmap();
                    }
                }
                FromBitmapToScreen();
            }
        }
        /// <summary>
        /// Edit blur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (Form1.ImageName != "\0")
            {
                double m2 = trackBar2.Value / trackBar2.Maximum;
                for (int i = 0; i < Form1.Image.Height; i++)
                {
                    for (int j = 0; j < Form1.Image.Width; j++)
                    {
                        Filter.matrix_filtration(j, i, Form1.matrixPixel, Filter.N2, Filter.blur, m2);
                        Form1.FromPixelToBitmap();
                    }
                }
                FromBitmapToScreen();
            }
        }
        /// <summary>
        /// button work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            if(Form1.ImageName != "\0")
            {
                for(int i = 0; i < Form1.Image.Height; i++)
                {
                    for(int j = 0; j < Form1.Image.Width; j ++)
                    {
                        Form1.matrixPixel[i, j] = (UInt32)(Form1.Image.GetPixel(j, i).ToArgb());
                    }
                }
                trackBar1.Value = 0;
                trackBar2.Value = 0;
            }
        }
    }
}
