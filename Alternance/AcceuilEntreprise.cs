using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alternance
{
    public partial class AcceuilEntreprise : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public AcceuilEntreprise()
        {
            InitializeComponent();
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            string ID = ((Button)sender).Name;
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("select * from [Candidature] where IDOffre='" + ID + "'", con);
                DataTable dtable = new DataTable();
                cmd.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    MessageBox.Show("Vous avez déja postulé a cet offre");
                    return;
                }
                SqlCommand cmd2 = new SqlCommand("insert into [Candidature] (IDUser,IDOffre) values (@IDUser,@IDOffre)", con);
                cmd2.Parameters.AddWithValue("@IDUser", user);
                cmd2.Parameters.AddWithValue("@IDOffre", ID);
                con.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Vous avez postulé avec succes ");
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }
        int Y = 0;
        private void AcceuilEntreprise_Load(object sender, EventArgs e)
        {
            SqlDataAdapter cmd = new SqlDataAdapter("select * from [Offre] where pour='Entreprise'", con);
            DataTable dtable = new DataTable();
            cmd.Fill(dtable);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Text = dtable.Rows[i][1].ToString();
                btn.Name = dtable.Rows[i][0].ToString();
                btn.Click += new EventHandler(OnButtonClick);
                btn.TextAlign = ContentAlignment.TopLeft;
                btn.Size = new Size(400, 100);
                btn.Location = new Point(90, 100 * (Y + 1));
                Y++;
                Controls.Add(btn);
            }
        }
    }
}
