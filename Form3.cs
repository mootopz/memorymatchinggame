using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Matching_Memory_Game
{
    public partial class Form3 : Form
    {
        int i = 0;
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            player.URL = "gtasan.wav";
            pictureBox1.Image = Properties.Resources.aa3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 1)
            {
                pictureBox1.Image = Properties.Resources.aa1;
            }
            else if (i == 2)
            {
                pictureBox1.Image = Properties.Resources.aa2;
            }
            else if (i == 3)
            {
                i = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pictureBox1.Image = Properties.Resources.aa3;
            }
            else if (i == 1)
            {
                pictureBox1.Image = Properties.Resources.aa1;
            }
            else if (i == 2)
            {
                pictureBox1.Image = Properties.Resources.aa2;
            }
            else if (i < 0)
            {
                i = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
