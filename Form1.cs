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
    public partial class Form1 : Form
    {
        int i = 0; //กำหนดตัวแปร intเพื่อเก็บค่า i
        Random locate = new Random(); //กำหนดตัวแปร เพื่อสุ่มพื้นที่ของการ์ด
        List<Point> top = new List<Point>(); //กำหนดค่า point ในตัวแปร
        PictureBox flipcard1; //เก็บการเปิดการ์ดแรกไว้ในตัวแปร flipcard1
        PictureBox flipcard2; //เก็บการเปิดการ์ดที่สองไว้ในตัวแปร flipcard2
        WindowsMediaPlayer sound = new WindowsMediaPlayer(); //สร้างตัวแปรเพื่อเปิดเสียงเพลง
        WindowsMediaPlayer player = new WindowsMediaPlayer(); //ตร้างตัวแปรเพื่อเปิดเสียงเพลง

        public Form1()
        {
            InitializeComponent();
            player.URL = "Robinson.wav"; //กำหนดตัวแปร player เป็นเพลง robinson
            sound.URL = "smurf.wav";
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            player.controls.stop(); //ปิดเพลง robinson ไว้ก่อน
            foreach (PictureBox pic in panel1.Controls) //วนลูปด้วยคำสั่ง foreac และกำหนดให้ pictureboxทั้งหมดใน panel1 ชื่อ pic 
            {
                pic.Enabled = false; //ปิด picturebox ทั้งหมดไม่ให้กดได้
                top.Add(pic.Location); //กำหนดการ์ดทั้งหมดไว้ในคำสั่ง list
            }
            foreach (PictureBox pic in panel1.Controls) //วนลูปด้วยคำสั่ง foreac และกำหนดให้ pictureboxทั้งหมดใน panel1 ชื่อ pic
            {
                int t = locate.Next(top.Count); //กำหนด t ให้เป็นจำนวนการ์ดทะเงหมดใน panel1
                Point ZQR = top[t]; //กำหนดตัวแปรชื่อ ZQR เพื่อให้เก็บค่าที่ตั้งไว้ในตัวแปร list
                pic.Location = ZQR; //สุ่มที่อยู่ของการ์ดจากคำส่ง random
                top.Remove(ZQR); //เคลียร์ค่าในตัวแปร ZQR
            }
            timer1.Start(); //เริ่มใช้งาน timer1
            timer2.Start(); //เริ่มใช้งาน timer2 ในการนับเวลาถอยหลัง
            card1.Image = Properties.Resources.c1;  //กำหนดให้ card1 แสดงรูปภาพที่1
            dcard1.Image = Properties.Resources.c1; //กำหนดให้ dcard1 แสดงรูปภาพที่1
            card2.Image = Properties.Resources.c2; //กำหนดให้ card2 แสดงรูปภาพที่2
            dcard2.Image = Properties.Resources.c2; //กำหนดให้ dcard2 แสดงรูปภาพที่2
            card3.Image = Properties.Resources.c3; //กำหนดให้ card3 แสดงรูปภาพที่3
            dcard3.Image = Properties.Resources.c3; //กำหนดให้ dcard3 แสดงรูปภาพที่3
            card4.Image = Properties.Resources.c4; //กำหนดให้ card4 แสดงรูปภาพที่4
            dcard4.Image = Properties.Resources.c4; //กำหนดให้ dcard4 แสดงรูปภาพที่4
            card5.Image = Properties.Resources.c5; //กำหนดให้ card5 แสดงรูปภาพที่5
            dcard5.Image = Properties.Resources.c5; //กำหนดให้ dcard5 แสดงรูปภาพที่5
            card6.Image = Properties.Resources.c6; //กำหนดให้ card6 แสดงรูปภาพที่6
            dcard6.Image = Properties.Resources.c6; //กำหนดให้ dcard6 แสดงรูปภาพที่6
            card7.Image = Properties.Resources.c7; //กำหนดให้ card7 แสดงรูปภาพที่7
            dcard7.Image = Properties.Resources.c7; //กำหนดให้ dcard7 แสดงรูปภาพที่7
            card8.Image = Properties.Resources.c8; //กำหนดให้ card8 แสดงรูปภาพที่8
            dcard8.Image = Properties.Resources.c8; //กำหนดให้ dcard8 แสดงรูปภาพที่8
            card9.Image = Properties.Resources.c9; //กำหนดให้ card9 แสดงรูปภาพที่9
            dcard9.Image = Properties.Resources.c9; //กำหนดให้ dcard9 แสดงรูปภาพที่9
        }
        /// <summary>
        /// สร้าง เมดธอท ชื่อokay
        /// </summary>
        void okay()
        {
            ScoreLb.Text = Convert.ToString(int.Parse(ScoreLb.Text) + 10); //ถ้าจับคู่ถูกให้ score เพิ่มขึ้นทีละ10
            if ((card1.Enabled == false && dcard1.Enabled == false && card2.Enabled == false && dcard2.Enabled == false && card3.Enabled == false && dcard3.Enabled == false && card4.Enabled == false && dcard4.Enabled == false && card5.Enabled == false && dcard5.Enabled == false && card6.Enabled == false && dcard6.Enabled == false && card7.Enabled == false && dcard7.Enabled == false && card8.Enabled == false && dcard8.Enabled == false && card9.Enabled == false && dcard9.Enabled == false))
            { //ถ้าจับคู่การ์ดถูกครบทุกใบ
                button4.Visible = false; //ซ่อนปุ่มปิดเสียง
                sound.URL = "win.wav"; //กำหนดให้ตัวแปร sound เป็นเพลง win
                sound.controls.play(); //ให้เล่นเพลงที่กำหนดไว้ในตัวแปร sound
                timer4.Stop(); //ให้หยุดการจับเวลา
                MessageBox.Show("You Win!!!!" + "\r\n" + "Score : " + ScoreLb.Text + "\r\n" + "ใช้เวลาทั้งหมด : " + minLb.Text + "." + secLb.Text + " min.", "Matching Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //ให้ เมสเสสบ๊อกโชว์ข้อความที่กำหนด
                sound.controls.stop(); //เมื่อกดปุ่มOKให้หยุดเพลงในตัวแปร sound
                picture(); //เรียกใช้คำสั่งใน เมดธอท picture
                player.controls.play(); //ให้เริ่มเล่นเพลงที่กำหนดไว้ในตัวแปร player
                
            }
        }
        /// <summary>
        /// สร้างเมดธอทชื่อ worng
        /// </summary>
        void wrong()
        {           
            ScoreLb.Text = Convert.ToString(int.Parse(ScoreLb.Text) - 5); //ถ้าจับคู่ผิดให้ score ลดลงทีละ5
            if (int.Parse(ScoreLb.Text) < 0) //ถ้าคะแนนได้ต่ำกว่า0
            {
                button4.Visible = false; //ซ่อนปุ่มปิดเสียง
                sound.URL = "false.wav"; //กำหนดให้ตัวแปร sound เป็นเพลง false
                sound.controls.play(); //ให้เล่นเพลงที่กำหนดไว้ในตัวแปร sound
                timer4.Stop(); //ให้หยุดการจับเวลา
                MessageBox.Show("Game Over!!!" + "\r\n" + "Score : " + ScoreLb.Text + "\r\n" + "ใช้เวลาทั้งหมด : " + minLb.Text + "." + secLb.Text + " min.","Matching Game",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                //ให้ เมสเสสบ๊อกโชว์ข้อความที่กำหนด
                sound.controls.stop(); //เมื่อกดปุ่มOKให้หยุดเพลงในตัวแปร sound
                picture(); //เรียกใช้คำสั่งใน เมดธอท picture
                player.controls.play(); //ให้เริ่มเล่นเพลงที่กำหนดไว้ในตัวแปร player
            }
            timer3.Start(); //เริ่มการทำงานของ timer3
        }
        /// <summary>
        /// สร้างเมดธอทชื่อ picture
        /// </summary>
        void picture()
        {
            foreach (PictureBox pic in panel1.Controls) //วนลูปด้วยคำสั่ง foreac และกำหนดให้ pictureboxทั้งหมดใน panel1 ชื่อ pic
            {
                pic.Image = Properties.Resources.cFlip; //กำหนดให้ pic แสดงการ์ดที่กำหนด
                pic.Enabled = false; //ให้ปิดการ์ดทั้งหมด
                ScoreLb.Text = "0"; //กำหนดให้ score เริ่มต้น = 0
                label2.Text = "5"; //กำหนดให้การนับเวลาถอยหลังเริ่มต้นที่0
                minLb.Text = ""; 
                secLb.Text = "";
                label4.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); //หยุดการทำงานของ timer1
            foreach (PictureBox pic in panel1.Controls) //วนลูปด้วยคำสั่ง foreac และกำหนดให้ pictureboxทั้งหมดใน panel1 ชื่อ pic
            {
                pic.Enabled = true; //เปิดการ์ดทั้งหมด
                pic.Cursor = Cursors.Hand; //เปลี่ยน cursor เป็นรูปมือ
                pic.Image = Properties.Resources.cFlip; //ให้แสดงการ์ดทั้งหมดเป็นรูปภาพที่กำหนด
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int second = Convert.ToInt32(label2.Text); //กำหนดให้ตัวแปร second แทนค่าของ label2 เพื่อจับเวลาถอยหลัง
            second = second - 1; //ให้ second ลดลงทีละ1วินาที
            label2.Text = Convert.ToString(second); //แปลงค่า second เป็นาตริง
            if (second == 0) //ถ้า second = 0
            {
                timer2.Stop(); //ให้หยุดการจับเวลาถอยหลัง
                label2.Text = "";
                label4.Text = ":";
                minLb.Text = "0";
                secLb.Text = "0";
                timer4.Start(); //เริ่มการจับเวลาใน timer4
            }
            
        }

        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.c1; //กำหนดให้ card1 เป็นรูปแรก
            if (flipcard1 == null) //ถ้าเปิดตัวแปร flipcard1 เป็นครั้งแรก ให้แสดงการ์ดที่กำหนด
            {
                flipcard1 = card1;
            }
            else if (flipcard1 != null && flipcard2 == null) //ถ้าเปิดตัวแปร flipcard2 เป็นครั้งแรก ให้แสดงการ์ดที่กำหนด
            {
                flipcard2 = card1;
            }
            if (flipcard1 != null && flipcard2 != null) //ถ้าไม่ได้เปิดตัวแปร flipcard1 flipcard2 เป็นครั้งแรก ให้แสดผลตามคำสั่งต่อไปนี้
            {
                if (flipcard1.Tag == flipcard2.Tag) //ถ้า tag ของการ์ดเปิดการ์ดทั้ง2 เป็นภาพเดียวกัน
                {
                    flipcard1 = null; //ให้ตัวแปร flipcard1 กลับไปเป็นคลิกแรก
                    flipcard2 = null; //ให้ตัวแปร flipcard2 กลับไปเป็นคลิกแรก
                    card1.Enabled = false; //ให้ปิดการ์ดที่เปิดแล้วและมีภาพเหมือนกัน
                    dcard1.Enabled = false;
                    okay(); //เรียกใช้ เมดธอท okay
                }
                else //ถ้าการ์ดที่เปิดไม่เหมืนกัน
                {
                    wrong(); //เรียกใช้ เมดธอท wrong
                }
            }
        }

        private void dcard1_Click(object sender, EventArgs e)
        {
            dcard1.Image = Properties.Resources.c1; //กำหนดให้ dcard1 เป็นรูปแรก
            if (flipcard1 == null)
            {
                flipcard1 = dcard1;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard1;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null; 
                    flipcard2 = null; 
                    card1.Enabled = false;
                    dcard1.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card2_Click(object sender, EventArgs e)
        {
            card2.Image = Properties.Resources.c2; //กำหนดให้ card2 เป็นรูป2
            if (flipcard1 == null)
            {
                flipcard1 = card2;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card2;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card2.Enabled = false;
                    dcard2.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard2_Click(object sender, EventArgs e)
        {
            dcard2.Image = Properties.Resources.c2; //กำหนดให้ dcard2 เป็นรูป2
            if (flipcard1 == null)
            {
                flipcard1 = dcard2;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard2;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card2.Enabled = false;
                    dcard2.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card3_Click(object sender, EventArgs e)
        {
            card3.Image = Properties.Resources.c3; //กำหนดให้ card3 เป็นรูป3
            if (flipcard1 == null)
            {
                flipcard1 = card3;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card3;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card3.Enabled = false;
                    dcard3.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard3_Click(object sender, EventArgs e)
        { 
            dcard3.Image = Properties.Resources.c3; //กำหนดให้ dcard3 เป็นรูป3
            if (flipcard1 == null)
            {
                flipcard1 = dcard3;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard3;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card3.Enabled = false;
                    dcard3.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card4_Click(object sender, EventArgs e)
        {
            card4.Image = Properties.Resources.c4; //กำหนดให้ card4 เป็นรูป4
            if (flipcard1 == null)
            {
                flipcard1 = card4;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card4;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card4.Enabled = false;
                    dcard4.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard4_Click(object sender, EventArgs e)
        {
            dcard4.Image = Properties.Resources.c4; //กำหนดให้ dcard4 เป็นรูป4
            if (flipcard1 == null)
            {
                flipcard1 = dcard4;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard4;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card4.Enabled = false;
                    dcard4.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card5_Click(object sender, EventArgs e)
        {
            card5.Image = Properties.Resources.c5; //กำหนดให้ card5 เป็นรูป5
            if (flipcard1 == null)
            {
                flipcard1 = card5;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card5;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card5.Enabled = false;
                    dcard5.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard5_Click(object sender, EventArgs e)
        {
            dcard5.Image = Properties.Resources.c5; //กำหนดให้ dcard5 เป็นรูป5
            if (flipcard1 == null)
            {
                flipcard1 = dcard5;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard5;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card5.Enabled = false;
                    dcard5.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card6_Click(object sender, EventArgs e)
        {
            card6.Image = Properties.Resources.c6; //กำหนดให้ card6 เป็นรูป6
            if (flipcard1 == null)
            {
                flipcard1 = card6;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card6;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card6.Enabled = false;
                    dcard6.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard6_Click(object sender, EventArgs e)
        {
            dcard6.Image = Properties.Resources.c6; //กำหนดให้ dcard6 เป็นรูป6
            if (flipcard1 == null)
            {
                flipcard1 = dcard6;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard6;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card6.Enabled = false;
                    dcard6.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card7_Click(object sender, EventArgs e)
        {
            card7.Image = Properties.Resources.c7; //กำหนดให้ card7 เป็นรูป7
            if (flipcard1 == null)
            {
                flipcard1 = card7;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card7;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card7.Enabled = false;
                    dcard7.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard7_Click(object sender, EventArgs e)
        {
            dcard7.Image = Properties.Resources.c7; //กำหนดให้ dcard7 เป็นรูป7
            if (flipcard1 == null)
            {
                flipcard1 = dcard7;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard7;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card7.Enabled = false;
                    dcard7.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card8_Click(object sender, EventArgs e)
        {
            card8.Image = Properties.Resources.c8; //กำหนดให้ card8 เป็นรูป8
            if (flipcard1 == null)
            {
                flipcard1 = card8;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card8;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card8.Enabled = false;
                    dcard8.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard8_Click(object sender, EventArgs e)
        {
            dcard8.Image = Properties.Resources.c8; //กำหนดให้ dcard8 เป็นรูป8
            if (flipcard1 == null)
            {
                flipcard1 = dcard8;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard8;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card8.Enabled = false;
                    dcard8.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void card9_Click(object sender, EventArgs e)
        {
            card9.Image = Properties.Resources.c9; //กำหนดให้ card9 เป็นรูป9
            if (flipcard1 == null)
            {
                flipcard1 = card9;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = card9;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card9.Enabled = false;
                    dcard9.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void dcard9_Click(object sender, EventArgs e)
        {
            dcard9.Image = Properties.Resources.c9; //กำหนดให้ dcard9 เป็นรูป9
            if (flipcard1 == null)
            {
                flipcard1 = dcard9;
            }
            else if (flipcard1 != null && flipcard2 == null)
            {
                flipcard2 = dcard9;
            }
            if (flipcard1 != null && flipcard2 != null)
            {
                if (flipcard1.Tag == flipcard2.Tag)
                {
                    flipcard1 = null;
                    flipcard2 = null;
                    card9.Enabled = false;
                    dcard9.Enabled = false;
                    okay();
                }
                else
                {
                    wrong();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop(); //หยุดการทำงานของ timer3
            flipcard1.Image = Properties.Resources.cFlip; //ให้แสดงการ์ดที่กำหนดไว้
            flipcard2.Image = Properties.Resources.cFlip; //ให้แสดงการ์ดที่กำหนดไว้
            flipcard1 = null;
            flipcard2 = null;
        }
        /// <summary>
        /// ปุ่ม เริ่มเกมใหม่
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restart_Click(object sender, EventArgs e)
        {
            label2.Text = "5";
            secLb.Text = "";
            minLb.Text = "";
            label4.Text = "";
            flipcard1 = null;
            flipcard2 = null;
            timer2.Stop(); //หยุดการทำงานของ timer2
            timer4.Stop(); //หยุดการทำงานของ timer4
            sound.controls.play(); //ให้เปิดเพลงที่กำหนดไว้
            button4.Visible = true; //แสดงปุ่ม เปิด/ปิด เสียง
            Form1_Load(sender, e); // โหลด form1 ใหม่อีกครั้ง
        }
        /// <summary>
        /// ปุ่มปิดโปรแกรม
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void end_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.Show();
            sound.controls.stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            secLb.Text = Convert.ToString(int.Parse(secLb.Text)+1);
            if (int.Parse(secLb.Text) == 60) //ถ้าครบ60วินาที
            {
                secLb.Text = "0"; //ให้ label ที่กำหนดเริ่มต้นใหม่ที่0
                int min = Convert.ToInt32(minLb.Text); //แปลงค่าใน label ให้เป็น int และเก็บในตัวแปร min
                min = min + 1; //ให้ min เพิ่มขึ้นทีละ1นาที
                minLb.Text = Convert.ToString(min); //แปลงค่า min ให้เป็น string 
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            i = i + 1; //เมื่อกดปุ่มนี้ให้ตัวแปร i เริ่มต้นที่0 และเพิ่มขึ้นทีละ1
            if (i == 1) //ถ้า i  มีค่าเป็น1
            {
                sound.controls.pause(); //ให้หยุดเพลง
            }
            else if (i > 0)
            {
                sound.controls.play(); //ให้เปิดเพลงที่กำหนด
                i = 0; //ให้ i มีค่าเป็น0
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}