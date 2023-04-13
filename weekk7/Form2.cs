using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weekk7
{
    
    public partial class Form2 : Form
    {
        DataTable dtmovie;
        int x = 0;
        public Form2(DataTable dtmovie)
        {
            InitializeComponent();
            this.dtmovie = dtmovie;
        }
        public Form1 Referensi { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 3; i++)
            {
                PictureBox gambar = new PictureBox();
                gambar.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\source\repos\weekk7\weekk7\MOVIEE\{dtmovie.Rows[i][1]}");
                gambar.Location = new Point(25 + x, 15);
                gambar.SizeMode = PictureBoxSizeMode.StretchImage;
                gambar.Size = new Size(130, 200);
                panel1.Controls.Add(gambar);
                x += 150;
                Button newbutton = new Button();
                newbutton.Enabled = true;
                newbutton.Size = new Size(60, 40);
                newbutton.Location = new Point(55 + x - 130, 240);
                newbutton.Tag = i.ToString();
                newbutton.Text = "BUY TICKET";
                newbutton.Click += click;
                panel1.Controls.Add(newbutton);
               
            }
        }
        private void click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string tag = button.Tag.ToString();
            Referensi.Updates(tag);
            this.Close();
        }
    }
}
