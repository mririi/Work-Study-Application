using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
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
        }

        private void OffresUniversite_Load(object sender, EventArgs e)
        {

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
            }
        }
    }
}
