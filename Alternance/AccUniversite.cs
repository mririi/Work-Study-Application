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
    public partial class AccUniversite : Form
    {
        public string user { get; set; }
        public AccUniversite()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void AccUniversite_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OffresUniversite screen = new OffresUniversite();
            screen.user = user;
            screen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartenaireUniversite screen = new PartenaireUniversite();
            screen.user = user;
            screen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CandidateUniversite screen = new CandidateUniversite();
            screen.user = user;
            screen.Show();
        }
    }
}
