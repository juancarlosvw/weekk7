using System.Data;

namespace weekk7
{
    public partial class Form1 : Form
    {
        DataTable dtmovie = new DataTable();
        Random random = new Random();
        

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.DataSource = dtmovie;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // buat nama dan gambar
            dtmovie.Columns.Add("nama movie");
            dtmovie.Columns.Add("gambar movie");
            dtmovie.Columns.Add("jadwalpagi");
            dtmovie.Columns.Add("jadwalsore");
            dtmovie.Columns.Add("jadwalmalam");
            string user = Environment.UserName;
            string datamovie = File.ReadAllText($@"C:\Users\{user}\source\repos\weekk7\weekk7\listmovie.txt");
            string[] data = datamovie.Split(',');
            for (int i = 0; i < data.Length; i++)
            {
                string[] namadangambar = data[i].Split('-');
                dtmovie.Rows.Add(namadangambar[0], namadangambar[1], "", "", "");
            }
            // buat jadwal
            for (int i = 0; i < dtmovie.Rows.Count; i++)
            {
                string jadwal = "";
                for(int k= 0; k < 100; k++)
                {
                    int persen = random.Next(1, 101);
                    if (persen > 30)
                    {
                        int duduk = random.Next(0, 2);
                        jadwal = jadwal + duduk;
                    }
                    else
                    {
                        jadwal = jadwal + 0;
                    }
                }
                dtmovie.Rows[i][2] = jadwal;
            }
            for (int i = 0; i < dtmovie.Rows.Count; i++)
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
                    {
                        jadwal = jadwal + 0;
                    }
                }
                dtmovie.Rows[i][3] = jadwal;
            }
            for (int i = 0; i < dtmovie.Rows.Count; i++)
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
                    {
                        jadwal = jadwal + 0;
                    }
                }
                dtmovie.Rows[i][4] = jadwal;
            }
        }
        public void Updates(string id)
        {
            Form3 newform2 = new Form3(dtmovie,id);
            newform2.TopLevel = false;
            newform2.Dock = DockStyle.Fill;
            newform2.Referensi = this;
            panelpertama.Controls.Add(newform2);
            newform2.FormBorderStyle = FormBorderStyle.None;
            newform2.Show();
        }
        public void gantijadwal(int jadwalwaktu, int movieapa, string data)
        {
            dtmovie.Rows[movieapa][jadwalwaktu] = data;
        }
            
        private void menuMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form2 newform2 = new Form2(dtmovie);
            newform2.TopLevel = false;
            newform2.Dock = DockStyle.Fill;
            newform2.Referensi = this;
            panelpertama.Controls.Add(newform2);
            newform2.FormBorderStyle = FormBorderStyle.None;
            newform2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}