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
    public partial class Form3 : Form
    {
        Form1 OwnerForm;
        public Form3(Form1 ownerForm)
        {
            InitializeComponent();
            OwnerForm = ownerForm;
            button1.Click += new System.EventHandler(this.Button_Click);
            button2.Click += new System.EventHandler(this.Button_Click);
            button3.Click += new System.EventHandler(this.Button_Click);
            this.FormClosing += new FormClosingEventHandler(Form3Closing);
        }

        private void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (Form1.ImageName != "\0")
            {
                for (int i = 0; i < Form1.Image.Height; i++)
                {
                    for (int j = 0; j < Form1.Image.Width; j++)
                    {
                        Form1.matrixPixel[i, j] = (UInt32)(Form1.Image.GetPixel(j, i).ToArgb());
                    }
                }
                trackBar1.Value = 0;
                trackBar2.Value = 0;
                trackBar3.Value = 0;
            }
        }
        /// <summary>
        /// Add red color to picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (Form1.ImageName != "\0")
            {
                UInt32 p;
                for (int i = 0; i < Form1.Image.Height; i++)
                {
                    for (int j = 0; j < Form1.Image.Width; j++)
                    {
                        p = ColourBalance.ColorBalance_R(Form1.matrixPixel[i, j], trackBar1.Value, trackBar1.Maximum);
                        Form1.FromOnePixelToBitmap(i, j, p);
                    }
                }
                FromBitmapToScreen();
            }
        }
        /// <summary>
        /// Add green color for the picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (Form1.ImageName != "\0")
            {
                UInt32 p;
                for (int i = 0; i < Form1.Image.Height; i++)
                {
                    for (int j = 0; j < Form1.Image.Width; j++)
                    {
                        p = ColourBalance.ColorBalance_G(Form1.matrixPixel[i, j], trackBar2.Value, trackBar2.Maximum);
                        Form1.FromOnePixelToBitmap(i, j, p);
                    }
                }
                FromBitmapToScreen();
            }
        }
        /// <summary>
        /// Add blue color to the picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (Form1.ImageName != "\0")
            {
                UInt32 p;
                for (int i = 0; i < Form1.Image.Height; i++)
                {
                    for (int j = 0; j < Form1.Image.Width; j++)
                    {
                        p = ColourBalance.ColorBalance_B(Form1.matrixPixel[i, j], trackBar3.Value, trackBar3.Maximum);
                        Form1.FromOnePixelToBitmap(i, j, p);
                    }
                }
                FromBitmapToScreen();
            }
        }
        /// <summary>
        /// Close form3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3Closing(object sender, System.EventArgs e)
        {
            if(Form1.ImageName != "\0")
            {
                Form1.FromPixelToBitmap();
                FromBitmapToScreen();
            }
        }
    }
}
