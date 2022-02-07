using System;
using System.Drawing;
using System.Windows.Forms;

namespace ResizableRectangle
{
    public partial class Form2 : Form
    {
        private Point firstPoint = new Point();

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = Control.MousePosition;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Height += 10;
                pictureBox1.Width += 10;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                firstPoint = Control.MousePosition;
                if (pictureBox1.Height > 50)
                    pictureBox1.Height -= 10;
                if (pictureBox1.Width > 50)
                    pictureBox1.Width -= 10;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Create a temp Point
                Point temp = Control.MousePosition;
                Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                var newX = pictureBox1.Location.X - res.X;
                var newY = pictureBox1.Location.Y - res.Y;
                if (newX < 0)
                    newX = 0;
                if (newY < 0)
                    newY = 0;

                // Apply value to object
                pictureBox1.Location = new Point(newX, newY);
                label2.Text = pictureBox1.Location.X.ToString();
                label4.Text = pictureBox1.Location.Y.ToString();

                // Update firstPoint
                firstPoint = temp;
            }
        }
        private void Form2_Click(object sender, EventArgs e)
        {
            var currPoint = MousePosition;
            MessageBox.Show(currPoint.X.ToString() + "/" + currPoint.Y.ToString());
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
