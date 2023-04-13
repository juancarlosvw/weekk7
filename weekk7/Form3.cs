using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weekk7
{
    public partial class Form3 : Form
    {
        List<string> kuning = new List<string>();
        int id;
        int pilihjadwal = 0;
        Random random = new Random();
        string data;
        DataTable dtmovie;
        public Form1 Referensi { get; set; }
        public Form3(DataTable dtmovie, string id)
        {
            InitializeComponent();
            this.dtmovie = dtmovie;
            this.id = Convert.ToInt32(id);



        }
        int x = 0;
        private void Form3_Load(object sender, EventArgs e)
        {
            Button newbutton = new Button();
            newbutton.Enabled = true;
            newbutton.Size = new Size(60, 40);
            newbutton.Location = new Point(35, 040);
            newbutton.Tag = "G";
            newbutton.Text = "10.30 - 12.00";
            newbutton.Click += clickk;
            paneljadwal.Controls.Add(newbutton);
            Button newbutton2 = new Button();
            newbutton2.Enabled = true;
            newbutton2.Size = new Size(60, 40);
            newbutton2.Location = new Point(35, 140);
            newbutton2.Tag = "GG";
            newbutton2.Text = "16.00 - 17.30";
            newbutton2.Click += clickk;
            paneljadwal.Controls.Add(newbutton2);
            Button newbutton3 = new Button();
            newbutton3.Enabled = true;
            newbutton3.Size = new Size(60, 40);
            newbutton3.Location = new Point(35, 240);
            newbutton3.Tag = "GGG";
            newbutton3.Text = "20.00 - 22.00";
            newbutton3.Click += clickk;
            paneljadwal.Controls.Add(newbutton3);

            int counter = 0;
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Button btn = new Button();
                    btn.Tag = counter.ToString();
                    btn.Enabled = true;
                    btn.Size = new Size(25, 25);
                    btn.Click += clickseat;
                    btn.Location = new Point(x * 22 + 185, y * 22 + 26);
                    paneljadwal.Controls.Add(btn);
                    counter++;
                }
            }

            Button newbutton4 = new Button();
            newbutton4.Enabled = true;
            newbutton4.Size = new Size(60, 40);
            newbutton4.Location = new Point(120, 70);
            newbutton4.Tag = "C";
            newbutton4.Text = "ADD";
            newbutton4.Click += add;
            paneljadwal.Controls.Add(newbutton4);
            Button newbutton5 = new Button();
            newbutton5.Enabled = true;
            newbutton5.Size = new Size(60, 40);
            newbutton5.Location = new Point(120, 120);
            newbutton5.Tag = "B";
            newbutton5.Text = "RESET";
            newbutton5.Click += reset;
            paneljadwal.Controls.Add(newbutton5);
            Button newbutton6 = new Button();
            newbutton6.Enabled = true;
            newbutton6.Size = new Size(60, 40);
            newbutton6.Location = new Point(120, 170);
            newbutton6.Tag = "C";
            newbutton6.Text = "CLEAR";
            newbutton6.Click += clear;
            paneljadwal.Controls.Add(newbutton6);
            Button newbutton7 = new Button();
            newbutton7.Enabled = true;
            newbutton7.Size = new Size(60, 40);
            newbutton7.Location = new Point(120, 240);
            newbutton7.Tag = "Cfesf";
            newbutton7.Text = "BACK";
            newbutton7.Click += back;
            paneljadwal.Controls.Add(newbutton7);

        }
        private void setjadwal()
        {
            Referensi.gantijadwal(pilihjadwal, id, data);
            for (int i = 0; i < 100; i++)
            {
                foreach (Button button in paneljadwal.Controls.OfType<Button>())
                {
                    if (button.Tag.ToString() == i.ToString())
                    {
                        if (data[i] == '0')
                        {
                            button.BackColor = Color.Gray;
                        }
                        else
                        {
                            button.BackColor = Color.Green;
                        }
                    }
                }
            }
        }
        private void clickk(object sender, EventArgs e)
        {

            Button button = sender as Button;
            string jadwalkapan = button.Tag.ToString();
            if (jadwalkapan == "G")
            {
                pilihjadwal = 2;
                data = dtmovie.Rows[id][2].ToString();
            }
            else if (jadwalkapan == "GG")
            {
                pilihjadwal = 3;
                data = dtmovie.Rows[id][3].ToString();
            }
            else
            {
                pilihjadwal = 4;
                data = dtmovie.Rows[id][4].ToString();
            }
            setjadwal();
        }
        private void add(object sender, EventArgs e)
        {
            string databaru = "";
            for (int i = 0; i < 100; i++)
            {
                if (kuning.Contains(i.ToString()))
                {
                    databaru = databaru + "1";
                }
                else
                {
                    databaru = databaru + data[i];
                }
            }
            kuning.Clear();
            data = databaru;
            setjadwal();
        }
        private void reset(object sender, EventArgs e)
        {

            string jadwal = "";
            for (int k = 0; k < 100; k++)
            {
                int persen = random.Next(1, 101);
                if (persen > 30)
                {
                    int duduk = random.Next(0, 2);
                    jadwal = jadwal + duduk;
                }
                else

                    jadwal = jadwal + 0;
            }
            data = jadwal;
            setjadwal();
        }
        private void clear(object sender, EventArgs e)
        {
            data = "";
            for (int i = 0; i < 100; i++)
            {
                data = data + "0";
            }
        
            setjadwal();
        }

        private void clickseat(object sender, EventArgs e)
        {
            Button newbutton = sender as Button;
            if (newbutton.BackColor == SystemColors.Control)
            {
                MessageBox.Show("PIlih Waktu");
            }
            else
            {
                if (newbutton.BackColor == Color.Gray)
                {
                    newbutton.BackColor = Color.Yellow;
                    kuning.Add(newbutton.Tag.ToString());

                }
                else if (newbutton.BackColor == Color.Yellow)
                {
                    newbutton.BackColor = Color.Gray;
                    kuning.Remove(newbutton.Tag.ToString());
                }
                
            }
        }
        private void back(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
