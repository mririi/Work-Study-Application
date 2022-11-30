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
    public partial class PartenairesEntreprise : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Alternance;Integrated Security=True");
        public string user { get; set; }
        public PartenairesEntreprise()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void PartenairesEntreprise_Load(object sender, EventArgs e)
        {
            con.Open();
            string Query = "SELECT Distinct email as Email_Universite,adresse as Adresse_Universite from [User] u,[candidature] c,[Offre] o,[universite] uni where uni.ID=u.IDUni and o.ID=c.IDOffre and o.IDUser=u.ID and c.accepte='1' and u.IDUni is not null ";
            SqlDataAdapter sd = new SqlDataAdapter(Query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sd);
            var ds = new DataSet();
            sd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
