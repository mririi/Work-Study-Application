using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alternance
{
    public partial class AccEntreprise : Form
    {
        public string user { get; set; }
        public AccEntreprise()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcceuilEntreprise screen = new AcceuilEntreprise();
            screen.user = user;
            screen.Show();
        }

        private void AccEntreprise_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartenairesEntreprise screen = new PartenairesEntreprise();
            screen.user = user;
            screen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MesCandidatures screen = new MesCandidatures();
            screen.user = user;
            screen.Show();
        }
    }
}
