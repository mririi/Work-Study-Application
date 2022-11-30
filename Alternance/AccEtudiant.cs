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
    public partial class AccEtudiant : Form
    {
        public string user { get; set; }
        public AccEtudiant()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void AccEtudiant_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OffresEtudiant screen = new OffresEtudiant();
            screen.user = user;
            screen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MesCandidatures screen = new MesCandidatures();
            screen.user = user;
            screen.Show();
        }
    }
}
