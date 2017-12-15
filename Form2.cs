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
    public partial class Form2 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        int i = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            player.URL = "Robinson.wav";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = i + 1; //เมื่อกดปุ่มนี้ให้ตัวแปร i เริ่มต้นที่0 และเพิ่มขึ้นทีละ1
            if (i == 1) //ถ้า i  มีค่าเป็น1
            {
                player.controls.pause(); //ให้หยุดเพลง
            }
            else if (i > 0)
            {
                player.controls.play(); //ให้เปิดเพลงที่กำหนด
                i = 0; //ให้ i มีค่าเป็น0
            }
        }
    }
}
