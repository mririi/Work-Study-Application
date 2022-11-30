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
    public partial class RegisterEntreprise : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");

        public RegisterEntreprise()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void RegisterEntreprise_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login screen = new Login();
            screen.Show();
            this.Hide();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (email.Text == "" || nom.Text == "" || address.Text == "")
            {
                MessageBox.Show("Les champs ne doivent pas etre vide !!");
                return;
            }
            if (mdp.Text.Length < 6)
            {
                MessageBox.Show("Saisir un mot de passe de 6 characters ou plus !!");
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("insert into [User] (email,password) values (@email,@password)", con);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", mdp.Text);
                con.Open();
                cmd.ExecuteNonQuery();


            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();

            }
            try
            {
                SqlDataAdapter cmd1 = new SqlDataAdapter("select ID from [User] where email='" + email.Text + "'", con);
                DataTable dtable1 = new DataTable();
                cmd1.Fill(dtable1);
                if (dtable1.Rows.Count > 0)
                {
                    SqlCommand cmd2 = new SqlCommand("insert into [Entreprise] (nom,adresse,IDUser) values (@nom,@adresse,@IDUser)", con);
                    cmd2.Parameters.AddWithValue("@nom", nom.Text);
                    cmd2.Parameters.AddWithValue("@adresse", address.Text);
                    cmd2.Parameters.AddWithValue("@IDUser", dtable1.Rows[0][0].ToString());
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter cmd3 = new SqlDataAdapter("select ID from [Entreprise] where IDUser='" + dtable1.Rows[0][0].ToString() + "'", con);
                    DataTable dtable3 = new DataTable();
                    cmd3.Fill(dtable3);
                    SqlCommand cmd4 = new SqlCommand("update [User] set IDEntreprise='" + dtable3.Rows[0][0].ToString() + "' where ID='" + dtable1.Rows[0][0].ToString() + "'", con);
                    cmd4.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Errorr");
            }
            finally
            {
                con.Close();
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }
    }
}
