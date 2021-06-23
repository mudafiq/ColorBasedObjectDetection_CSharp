using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ColorBasedObjectDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openFile = new OpenFileDialog();
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFile.Title = "Browse Image";
            openFile.Filter = "JPEG Files|*.jpg|PNG Files|*.png";

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                Image image = Image.FromFile(openFile.FileName);
                pictureBox1.Image = image;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(openFile.FileName);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                //img._SmoothGaussian(35);

                Bgr lower = new Bgr(0, 0, 120);
                Bgr higher = new Bgr(100, 40, 255);

                var mask = img.InRange(lower, higher).Not();
                img.SetValue(new Bgr(0, 0, 0), mask);
                pictureBox1.Image = img.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                img._SmoothGaussian(5);

                Bgr lower = new Bgr(0, 100, 0);
                Bgr higher = new Bgr(100, 255, 30);

                var mask = img.InRange(lower, higher).Not();
                img.SetValue(new Bgr(0, 0, 0), mask);
                pictureBox1.Image = img.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                //
                img._SmoothGaussian(5);

                Bgr lower = new Bgr(170, 0, 0);
                Bgr higher = new Bgr(255, 230, 60);

                var mask = img.InRange(lower, higher).Not();
                img.SetValue(new Bgr(0, 0, 0), mask);
                pictureBox1.Image = img.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
