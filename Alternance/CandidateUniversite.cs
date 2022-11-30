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
    public partial class CandidateUniversite : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public CandidateUniversite()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void showCandidate()
        {
            con.Open();
            string Query = "SELECT  Distinct email as Candidate_Email,description as Description_Offre ,pour as Candidate, accepte as Accepte,c.ID as Candidate_ID from [Candidature] c,[Offre] o,[User] u where o.IDUser='" + user + "' and o.ID=c.IDOffre and c.IDUser=u.ID";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void CandidateUniversite_Load(object sender, EventArgs e)
        {
            showCandidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlCommand cmd4 = new SqlCommand("update [Candidature] set accepte='" + 1 + "' where ID='" + currentselectedcandidate + "'", con);
            cmd4.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                con.Close();
                showCandidate();
            }
        }
        string currentselectedcandidate;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                currentselectedcandidate =row.Cells[4].Value.ToString();
                label1.Text = row.Cells[4].Value.ToString();
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("update [Candidature] set accepte='" + 0 + "' where ID='" + currentselectedcandidate + "'", con);
                cmd4.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                con.Close();
                showCandidate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
