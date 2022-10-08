using System.Drawing.Imaging;
namespace WinFormsAppPhotoShop
{
    public partial class Form1 : Form
    {
        public static UInt32[,] matrixPixel;
       public static string ImageName = "\0";
        public static Bitmap Image;
        public Form1()
        {
            InitializeComponent();
        }

        public static void FromPixelToBitmap()
        {
            for(int i = 0; i < Image.Height; i ++)
            {
                for(int j = 0; j < Image.Width; j ++)
                {
                    Image.SetPixel(j, i, Color.FromArgb((int)matrixPixel[i, j]));
                }
            }
        }

        public static void FromOnePixelToDitmap(int x, int y, UInt32 matrixPixel)
        {
            Image.SetPixel(y, x, Color.FromArgb((int) matrixPixel));
        }

        public void FromBitmapToScreen()
        {
            pictureBox1.Image = Image;
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Photo Shop";
            sfd.DefaultExt = "jpg";
            sfd.Filter = "JPG Image File| *.jpg";
            sfd.ValidateNames = true;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox1.Width);
                int height = Convert.ToInt32(pictureBox1.Height);
                Bitmap bpm = new Bitmap(width, height);
                pictureBox1.DrawToBitmap(bpm, new Rectangle(0, 0, width, height));
                bpm.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " JPG Image File| *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImageName = ofd.FileName;
                    Image = new Bitmap(ofd.FileName);
                    pictureBox1.Size = Image.Size;
                    pictureBox1.Image = Image;
                    matrixPixel = new UInt32[Image.Height, Image.Width];
                    for (int i = 0; i < Image.Height; i++)
                    {
                        for (int j = 0; j < Image.Width; j++)
                        {
                            matrixPixel[i, j] = (UInt32)(Image.GetPixel(j, i).ToArgb());
                        }
                    }
                }
                catch
                {
                    ImageName = "";
                    MessageBox.Show("Unable to open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void brightnesscontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 brigtnessForm = new Form2(this);
            brigtnessForm.ShowDialog();
        }

        private void balanceOfColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 ColorBalanceForm = new Form3(this);
            ColorBalanceForm.ShowDialog();
        }

        private void raiseSharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ImageName != "\0")
            {
                matrixPixel = Filter.matrix_filtration(Image.Width, Image.Height, matrixPixel, Filter.N1, Filter.sharpness);
                FromPixelToBitmap();
                FromBitmapToScreen();
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageName != "\0")
            {
                matrixPixel = Filter.matrix_filtration(Image.Width, Image.Height, matrixPixel, Filter.N2, Filter.blur);
                FromPixelToBitmap();
                FromBitmapToScreen();
            }
        }
    }
}