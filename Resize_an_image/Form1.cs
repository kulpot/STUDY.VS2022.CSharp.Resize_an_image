using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ref link:https://www.youtube.com/watch?v=_9J7C2u_jIY&list=PLAIBPfq19p2EJ6JY0f5DyQfybwBGVglcR&index=77
//PS: you may want to name your images as destination and source image to make it more readable. Overloading the method to accept and return bitmaps may be desirable as well.

namespace Resize_an_image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Image ResizeImage(Image image, Size newSize)
        {
            Image newImage = new Bitmap(newSize.Width, newSize.Height);

            using(Graphics GFX = Graphics.FromImage((Bitmap)newImage))
            {
                GFX.DrawImage(image, new Rectangle(Point.Empty, newSize));
            }

            return newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();

            if(dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
                    image = ResizeImage(image, this.Size);
                    image.Save("saved.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    System.Diagnostics.Process.Start("saved.bmp");
                }
                catch
                {
                    // Catch general error
                }
            }

            dlgOpenFileDialog.Dispose();
        }
    }
}
