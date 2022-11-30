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
        }

        private void CandidateUniversite_Load(object sender, EventArgs e)
        {
            con.Open();
            string Query = "SELECT email,description from [Candidature] c,[Offre] o,[User] u where o.IDUser='" + user + "' and o.ID=c.IDOffre and c.IDUser=u.ID";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
