using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alternance
{
    public partial class MesCandidatures : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public MesCandidatures()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void showCandidatures()
        {
            con.Open();
            string Query = "select c.ID, description as Description,nom as Nom_Universite,accepte as Etat from [Candidature] c,[Offre] o,[Universite] u where c.IDUser='" + user + "' and c.IDOffre=o.ID and o.IDUser=u.IDUser";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void MesCandidatures_Load(object sender, EventArgs e)
        {
            showCandidatures();
        }
        string IDSelectionne;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                IDSelectionne = row.Cells[0].Value.ToString();
                label2.Text = IDSelectionne;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Êtes-vous sûr de supprimer cet candidature?", "Confirmer!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                con.Open();
                string Query = "DELETE FROM Candidature where ID = '" + IDSelectionne + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Candidature supprimé avec succès");


                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    con.Close();
                    showCandidatures();
                }
            }
        }
    }
}
