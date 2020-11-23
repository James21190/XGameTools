using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Network;

namespace CommonNetworkListener
{
    public partial class NetworkListener : Form
    {
        public NetworkListener()
        {
            InitializeComponent();
        }

        Listener netListener = new Listener(25565);

        private void NetworkListener_Load(object sender, EventArgs e)
        {

        }
    }
}
