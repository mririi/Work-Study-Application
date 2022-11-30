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
    public partial class PartenaireUniversite : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public PartenaireUniversite()
        {
            InitializeComponent();
        }

        private void PartenaireUniversite_Load(object sender, EventArgs e)
        {
            con.Open();
            string Query = "SELECT Distinct email from [User] u,[candidature] c where c.IDUser=u.ID and c.accepte='1' and u.IDEntreprise is not null ";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
