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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (email.Text == "" || mdp.Text == "")
            {
                MessageBox.Show("Saisir l'email et le mot de passe");
                return;
            }
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("select * from [User] where email = '" + email.Text + "' and password= '" + mdp.Text + "'", con);
                DataTable dtable = new DataTable();
                cmd.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    if (dtable.Rows[0][5].ToString()!=null)
                    {
                        AccEtudiant screen = new AccEtudiant();
                        //screen.user = dtable.Rows[0][0].ToString();
                        screen.Show();
                        this.Hide();
                    }
                    else if (dtable.Rows[0][6].ToString() != null)
                    {
                        AccEntreprise screen = new AccEntreprise();
                        //screen.user = dtable.Rows[0][0].ToString();
                        screen.Show();
                        this.Hide();
                    }
                    else if (dtable.Rows[0][7].ToString() != null)
                    {
                        AccUniversite screen = new AccUniversite();
                        //screen.user = dtable.Rows[0][0].ToString();
                        screen.Show();
                        this.Hide();

                    }

                }
                else
                {
                    MessageBox.Show("Invalid details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterEtudiant screen = new RegisterEtudiant();
            screen.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterEntreprise screen = new RegisterEntreprise();
            screen.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUniversite screen = new RegisterUniversite();
            screen.Show();
            this.Hide();
        }
    }
}
