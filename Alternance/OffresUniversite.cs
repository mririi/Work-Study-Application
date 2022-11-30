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
    public partial class OffresUniversite : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public OffresUniversite()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void showOffres()
        {
            con.Open();
            string Query = "select ID, description as Description,pour as Pour from [Offre] where IDUser='" + user + "'";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void OffresUniversite_Load(object sender, EventArgs e)
        {
            showOffres();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            SqlCommand cmd = new SqlCommand("insert into [Offre] (description,pour,IDUser) values (@description,@pour,@IDUser)", con);
            cmd.Parameters.AddWithValue("@description", textBox1.Text);
            cmd.Parameters.AddWithValue("@pour", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@IDUser", user);
            con.Open();
            cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                con.Close();
                showOffres();
            }
        }
        string IDSelectionne;
        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Êtes-vous sûr de supprimer cet offre?", "Confirmer!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string Query1 = "DELETE FROM Candidature where IDOffre = '" + IDSelectionne + "'";
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                    cmd1.ExecuteNonQuery();
                    string Query = "DELETE FROM offre where ID = '" + IDSelectionne + "'";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Offre supprimé avec succès");


                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    con.Close();
                    showOffres();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                comboBox1.SelectedItem = row.Cells[2].Value.ToString();
                IDSelectionne=row.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            string Query = "UPDATE Offre set description= '" + textBox1.Text + "',pour='" + comboBox1.SelectedItem + "' WHERE ID = '" + IDSelectionne + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Offre Modifié avec succès");
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
            con.Close();
            showOffres();
            }
        }
    }
}
