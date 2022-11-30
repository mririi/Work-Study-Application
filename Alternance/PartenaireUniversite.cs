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
            CenterToScreen();
        }

        private void PartenaireUniversite_Load(object sender, EventArgs e)
        {
            con.Open();
            string Query = "SELECT Distinct email as Email_Entreprise,adresse as Adresse_Entreprise from [User] u,[Candidature] c,[Entreprise] e where e.ID=u.IDEntreprise and c.IDUser=u.ID and c.accepte='1' and u.IDEntreprise is not null ";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
