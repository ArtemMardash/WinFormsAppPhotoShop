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
    public partial class Form2 : Form
    {
        Form1 OwnerForm;
        public Form2(Form1 ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            button1.Click += new System.EventHandler(this.Button_Click);
            button2.Click += new System.EventHandler(this.Button_Click);
        }

        public void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }
        /// <summary>
        /// Edit Brigtness
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(Form1.ImageName != "\0")
            {
                UInt32 p;
                for(int i = 0; i < Form1.Image.Height; i++)
                {
                    for(int j = 0; j < Form1.Image.Width; j++)
                    {
                        p = BrightnessContrast.Brightness(Form1.matrixPixel[i, j], trackBar1.Value, trackBar1.Maximum);
                        Form1.FromOnePixelToBitmap(i, j, p);
                    }
                }
                FromBitmapToScreen();
            }
        }



        private void Button_Click(object sender, EventArgs e)
        {
            if(Form1.ImageName != "\0")
            {
                for(int i = 0; i < Form1.Image.Height; i ++ )
                {
                    for(int j = 0; j < Form1.Image.Width; j ++)
                    {
                        Form1.matrixPixel[i,j] = (UInt32)(Form1.Image.GetPixel(j,i).ToArgb());
                    }
                }
                trackBar1.Value = 0;
                trackBar2.Value = 0;
            }
        }
        /// <summary>
        /// Edit contrast
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
                        p = BrightnessContrast.Contrast(Form1.matrixPixel[i, j], trackBar1.Value, trackBar1.Maximum);
                        Form1.FromOnePixelToBitmap(i, j, p);
                    }
                }
                FromBitmapToScreen();
            }
        }
    }
}
